using Enums;
using UnityEngine;
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using System.Linq;
using Domains;
using System.Collections;

public class PhysicsObjController : ObjController
{
    protected BdyEntity bdy = new();
    protected ItrEntity itr = new();
    protected Transform hurtbox;
    protected Rigidbody rb;
    protected Vector3 velocity = Vector3.zero;
    protected bool execMoveToPosition = false;
    protected bool execImpulseForce = false;
    protected bool execFixedMoveToPosition = false;
    protected BoxCollider selfBoxCollider;
    protected Transform hitbox;
    public SpriteRenderer stageSpriteRenderer;

    protected float maxDistanceToCheckCollision = 0.1f;
    protected LayerMask whatIsGround;
    protected LayerMask whatIsGrabbable;
    protected LayerMask whatIsPlatform;
    protected LayerMask whatIsCeil;
    protected LayerMask whatIsWall;
    protected LayerMask whatIsItr;
    protected object nextIfHit;
    protected bool wasAttacked;
    protected float restDamageWaitTime;

    public int currentHp;
    protected int totalHp;
    public int currentMp;
    protected int totalMp;
    protected bool canParry;
    protected int lastDamage;
    protected bool isDeath;
    protected ItrEntity externItr;
    protected Vector3 externPosition;
    protected bool isExternAction;
    protected bool externFacingRight;
    protected int? externAction;
    public bool onGround;
    public bool onCeil;
    protected Action hitAir;
    protected Action hitGround;
    protected Action hitCeil;
    protected Action hitWall;
    protected Action hitPlatformWall;
    public bool onWall;
    public bool onPlatform;
    public bool isDefending;
    public int externId;
    public int? externOwnerId;
    public TeamEnum externTeam;
    public ItrKindEnum externKind;

    protected int injury;
    protected bool defensable;
    protected bool execHealthPointsOneTimeInFrame;
    protected bool execManaPointsOneTimeInFrame;
    protected int mp;
    protected int hp;
    public float damageRestTU;
    protected int? targetId;
    protected bool attacking;
    protected bool damageInSingleTarget;
    protected Action hitDefenseAction;
    protected Action jumpDefenseAction;
    public int hittablePercent = 100;
    private bool lockHittablePercent = true;
    private int percentToHit = 0;
    private int hitDefenseActionId = 160;
    private int hitJumpDefenseActionId = 305;
    protected List<ObjController> opointsControl = new();

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        selfBoxCollider = GetComponent<BoxCollider>();
        hurtbox = transform.Find("Hurtbox"); ;
        hitbox = transform.Find("Hitbox"); ;
        base.Awake();
    }

    public void Start()
    {
        whatIsGround = LayerMask.GetMask("Ground");
        whatIsCeil = LayerMask.GetMask("Ceil");
        whatIsWall = LayerMask.GetMask("Wall");
        whatIsItr = LayerMask.GetMask("Itr");
        whatIsGrabbable = LayerMask.GetMask("Grabbable");
        whatIsPlatform = LayerMask.GetMask("Platform");
        isDeath = false;
        canParry = false;
        base.Start();
    }

    protected void BdyDefault()
    {
        hurtbox.localPosition = new Vector3(0f, spriteRenderer.sprite.bounds.size.y / 2, 0f);
        hurtbox.localScale = new Vector3(spriteRenderer.sprite.bounds.size.x / 2, spriteRenderer.sprite.bounds.size.y, zSizeDefault);

        selfBoxCollider.center = hurtbox.localPosition;
        selfBoxCollider.size = hurtbox.localScale;
    }

    protected void Bdy()
    {
        hurtbox.localPosition = new Vector3(bdy.x, bdy.y, bdy.z);
        hurtbox.localScale = new Vector3(bdy.w, bdy.h, bdy.zwidth);

        selfBoxCollider.center = hurtbox.localPosition;
        selfBoxCollider.size = hurtbox.localScale;
    }

    protected void ItrDefault(float zwidth = 0)
    {
        itr.kind = ItrKindEnum.ENEMY;
        hitbox.gameObject.SetActive(true);
        hitbox.localPosition = new Vector3(0f, spriteRenderer.sprite.bounds.size.y / 2, 0f);
        hitbox.localScale = new Vector3(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y, zSizeDefault + zwidth);
    }

    protected void Itr()
    {
        itr.kind = ItrKindEnum.ENEMY;
        hitbox.gameObject.SetActive(true);
        hitbox.localPosition = new Vector3(itr.x, itr.y, itr.z);
        hitbox.localScale = new Vector3(itr.w, itr.h, itr.zwidth);
    }

    protected void AllyItr()
    {
        itr.kind = ItrKindEnum.ALLY;
        hitbox.gameObject.SetActive(true);
        hitbox.localPosition = new Vector3(itr.x, itr.y, itr.z);
        hitbox.localScale = new Vector3(itr.w, itr.h, itr.zwidth);
    }

    protected void OwnerItr()
    {
        itr.kind = ItrKindEnum.OWNER;
        hitbox.gameObject.SetActive(true);
        hitbox.localPosition = new Vector3(itr.x, itr.y, itr.z);
        hitbox.localScale = new Vector3(itr.w, itr.h, itr.zwidth);
    }

    protected void ItrDisable()
    {
        hitbox.gameObject.SetActive(false);
    }

    protected void ItrReset()
    {
        itr.x = 0f; itr.y = 0f; itr.z = 0;
        itr.w = 0f; itr.h = 0f; itr.zwidth = 0f;
        itr.dvx = 0; itr.dvy = 0; itr.dvz = 0; itr.action = 0;
        itr.applyInSingleEnemy = true; itr.defensable = true; itr.level = 0; itr.injury = 0;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 0;
    }

    protected void ImpulseForce()
    {
        rb.AddForce(velocity * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    protected void MovePosition()
    {
        rb.linearVelocity = Vector3.zero;
        rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    protected void FixedMovePosition()
    {
        if (!onWall)
        {
            rb.linearVelocity = Vector3.zero;
            rb.MovePosition(externPosition + velocity * Time.fixedDeltaTime);
        }
    }

    protected void ApplyDefaultPhysic(float? dvx, float? dvy, float? dvz, bool facingRight, ItrPhysicEnum physicType = ItrPhysicEnum.DEFAULT, bool ignoreFacing = false)
    {
        if (!execPhysicsOnceInFrame)
        {
            return;
        }
        if (dvx != null)
        {
            if (!ignoreFacing)
            {
                if (facingRight)
                {
                    this.velocity.x = dvx.Value;

                }
                else
                {
                    this.velocity.x = -dvx.Value;
                }
            } else {
                this.velocity.x = dvx.Value;
            }
        }

        if (dvy != null)
        {
            this.velocity.y = dvy.Value;
        }

        if (dvz != null)
        {
            this.velocity.z = dvz.Value;
        }

        switch (physicType)
        {
            case ItrPhysicEnum.FIXED:
                execMoveToPosition = true;
                break;

            default:
                execImpulseForce = true;
                break;
        }

        execPhysicsOnceInFrame = false;
    }

    protected void ApplyExternPhysic()
    {
        if (!execPhysicsOnceInFrame && !isExternAction)
        {
            return;
        }
        this.velocity.x = externFacingRight ? externItr.dvx : -externItr.dvx;
        this.velocity.y = externItr.dvy;
        this.velocity.z = externItr.dvz;

        switch (externItr.physic)
        {
            case ItrPhysicEnum.FIXED:
                execFixedMoveToPosition = true;
                break;

            default:
                execImpulseForce = true;
                break;
        }
        isExternAction = false;
        execPhysicsOnceInFrame = false;
    }

    protected void ExternInteraction(PhysicsObjController scriptObject, Action hitDefenseAction, Action hitJumpDefenseAction)
    {
        isExternAction = true;
        externTeam = scriptObject.team;
        defensable = scriptObject.itr.defensable;
        externAction = scriptObject.itr.action;

        if (isExternAction)
        {
            switch (externKind)
            {
                case ItrKindEnum.ENEMY:
                    if (externTeam != team)
                    {
                        currentHp -= injury;
                        lastDamage = injury;
                        canParry = true;
                        if (currentHp <= 0)
                        {
                            isDeath = true;
                        }

                        if (defensable && isDefending)
                        {
                            if (onGround)
                            {
                                ApplyExternPhysicsBehavior(scriptObject, hitDefenseActionId);
                            }
                            else
                            {
                                ApplyExternPhysicsBehavior(scriptObject, hitJumpDefenseActionId);
                            }
                        }
                        else
                        {
                            ApplyExternPhysicsBehavior(scriptObject, externAction);
                        }
                    }
                    break;
                case ItrKindEnum.ALLY:
                    Debug.Log("ALLY");
                    if (externTeam == team)
                    {
                        ApplyExternPhysicsBehavior(scriptObject, externAction);
                    }
                    break;
                case ItrKindEnum.CHILD:
                    Debug.Log("CHILD");
                    if (externId == ownerId)
                    {
                        ApplyExternPhysicsBehavior(scriptObject, externAction);
                    }
                    break;
                case ItrKindEnum.SELF:
                    Debug.Log("SELF");
                    if (externId == id)
                    {
                        ApplyExternPhysicsBehavior(scriptObject, externAction);
                    }
                    break;
                case ItrKindEnum.ALL:
                    Debug.Log("ALL");
                    ApplyExternPhysicsBehavior(scriptObject, externAction);
                    break;
            }
            isExternAction = false;
        }
        else
        {
            isExternAction = false;
        }
    }

    private void ApplyExternPhysicsBehavior(PhysicsObjController scriptObject, int? action)
    {
        percentToHit = lockHittablePercent ? percentToHit : UnityEngine.Random.Range(0, 100);
        lockHittablePercent = true;
        bool wasHit = hittablePercent == 100 || percentToHit <= hittablePercent;
        damageRestTU = scriptObject.itr.rest;

        if (wasHit)
        {
            externItr = scriptObject.itr;
            externFacingRight = scriptObject.facingRight;
            externId = scriptObject.ownerId.HasValue ? scriptObject.ownerId.Value : scriptObject.id;
            externOwnerId = scriptObject.ownerId;
            externPosition = scriptObject.transform.position;
            scriptObject.attacking = true;
            scriptObject.damageInSingleTarget = scriptObject.itr.applyInSingleEnemy;
            scriptObject.enableNextIfHit = true;
            scriptObject.nextIfHit = scriptObject.itr.nextIfHit;
            scriptObject.targetHit = this;
            wasAttacked = true;
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(ItrEffectSpawn(scriptObject.itr.effect, new Vector3(0f, 0.3f, -0.1f)));
            }
            ChangeFrame(action);
        }
        lockHittablePercent = false;
    }

    protected void CheckPlatforms()
    {
        Collider[] hitColliders = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y - (maxDistanceToCheckCollision / 2), transform.position.z),
            new Vector3(hurtbox.localScale.x / 2, maxDistanceToCheckCollision / 2, zSizeDefault / 2), Quaternion.identity, whatIsGround);
        if (hitColliders.Length > 0 && hitColliders[0].bounds.max.y - 0.01f <= transform.position.y && gameObject.activeSelf)
        {
            StartCoroutine(DetectStage(hitColliders[0]));
            onGround = true;
            onCeil = false;
        }
        else
        {
            onGround = false;
        }

        var forwardCenterX = transform.position.x + (hurtbox.localScale.x / 2) + maxDistanceToCheckCollision;
        Collider[] hitWallFrontColliders = Physics.OverlapBox(new Vector3(forwardCenterX, transform.position.y + spriteRenderer.sprite.bounds.size.y / 2, transform.position.z),
            new Vector3(maxDistanceToCheckCollision / 2, spriteRenderer.sprite.bounds.size.y / 2, zSizeDefault / 2), Quaternion.identity, whatIsWall);

        var backCenterX = transform.position.x - (hurtbox.localScale.x / 2) - maxDistanceToCheckCollision;
        Collider[] hitWallBackColliders = Physics.OverlapBox(new Vector3(backCenterX, transform.position.y + spriteRenderer.sprite.bounds.size.y / 2, transform.position.z),
            new Vector3(maxDistanceToCheckCollision / 2, spriteRenderer.sprite.bounds.size.y / 2, zSizeDefault / 2), Quaternion.identity, whatIsWall);

        if (hitWallFrontColliders.Length > 0 || hitWallBackColliders.Length > 0)
        {
            onWall = true;
        }
        else
        {
            onWall = false;
        }

        if (!onGround)
        {
            Collider[] hitCeilColliders = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y + spriteRenderer.sprite.bounds.size.y + maxDistanceToCheckCollision, transform.position.z),
                new Vector3(spriteRenderer.sprite.bounds.size.x / 2, -maxDistanceToCheckCollision / 2, zSizeDefault / 2), Quaternion.identity, whatIsCeil);

            if (hitCeilColliders.Length > 0)
            {
                onGround = false;
                onCeil = true;
            }
            else
            {
                onCeil = false;
            }
        }
    }

    private IEnumerator DetectStage(Collider collider)
    {
        GroundEffectsController groundEffectsController;
        if (collider.gameObject.TryGetComponent(out groundEffectsController))
        {
            stage = groundEffectsController.type;
        }
        yield return null;
    }

    protected void CheckInteraction()
    {
        if (restDamageWaitTime != 0 || !hurtbox.gameObject.activeInHierarchy)
        {
            return;
        }

        Collider[] hitColliders = new Collider[5];
        int numColliders = Physics.OverlapBoxNonAlloc(hurtbox.position, hurtbox.localScale / 2, hitColliders, Quaternion.identity, whatIsItr);

        for (int i = 0; i < numColliders; i++)
        {
            var collider = hitColliders[i];

            var scriptObject = collider.transform.parent.GetComponent<PhysicsObjController>();

            if (scriptObject.itr == null)
            {
                return;
            }

            if (scriptObject.targetId == null && scriptObject.damageInSingleTarget)
            {
                scriptObject.targetId = ownerId != null ? ownerId : id;
            }
            else
            {
                scriptObject.targetId = null;
            }

            this.ExternInteraction(scriptObject, hitDefenseAction, jumpDefenseAction);
        }
    }

    IEnumerator ItrEffectSpawn(ItrEffectEnum effect, Vector3 contactPoint)
    {
        switch (effect)
        {
            case ItrEffectEnum.NORMAL:
                SpawnOpoint(4, Opoint(x: contactPoint.x, y: contactPoint.y, z: contactPoint.z, oid: 0, facingFront: true, quantity: 1));
                break;

            case ItrEffectEnum.BLOOD:
                SpawnOpoint(5, Opoint(x: contactPoint.x, y: contactPoint.y, z: contactPoint.z, oid: 0, facingFront: true, quantity: 1));
                break;

            case ItrEffectEnum.SLOW:
                Console.WriteLine("Efeito: Lentidão");
                break;

            case ItrEffectEnum.STUN:
                Console.WriteLine("Efeito: Atordoamento");
                break;

            case ItrEffectEnum.IGNITE:
                Console.WriteLine("Efeito: Queima");
                break;

            case ItrEffectEnum.POISON:
                Console.WriteLine("Efeito: Veneno");
                break;

            case ItrEffectEnum.ROOT:
                Console.WriteLine("Efeito: Enraizamento");
                break;

            case ItrEffectEnum.CHARM:
                Console.WriteLine("Efeito: Encantamento");
                break;

            case ItrEffectEnum.FEAR:
                Console.WriteLine("Efeito: Medo");
                break;

            case ItrEffectEnum.TAUNT:
                Console.WriteLine("Efeito: Provocação");
                break;

            case ItrEffectEnum.BLIND:
                Console.WriteLine("Efeito: Cegueira");
                break;

            case ItrEffectEnum.PARALYSIS:
                Console.WriteLine("Efeito: Paralisia");
                break;

            case ItrEffectEnum.FREEZE:
                Console.WriteLine("Efeito: Congelamento");
                break;

            case ItrEffectEnum.CONFUSE:
                Console.WriteLine("Efeito: Confusão");
                break;

            case ItrEffectEnum.SILENCE:
                Console.WriteLine("Efeito: Silêncio");
                break;

            case ItrEffectEnum.DEFENSE:
                Console.WriteLine("Efeito: Defesa");
                break;

            case ItrEffectEnum.NO_EFFECT:
                Console.WriteLine("Efeito: Sem efeito");
                break;

            default:
                Console.WriteLine("Efeito desconhecido");
                break;
        }
        yield return null;
    }

    protected void Timers()
    {
        // Debug.Log(">>" + restDamageWaitTime + "|" + damageRestTU / 30 + "|" + damageRestTU + "|" + gameObject.name);
        if (damageRestTU > 0)
        {
            restDamageWaitTime += Time.deltaTime % 60;
        }
        if (restDamageWaitTime >= damageRestTU / 30)
        {
            wasAttacked = false;
            restDamageWaitTime = 0f;
            damageRestTU = 0f;
        }
        base.Timers();
    }

    protected void ManageHealthPoints()
    {
        if (execHealthPointsOneTimeInFrame)
        {
            execHealthPointsOneTimeInFrame = false;
            if (currentHp < totalHp)
            {
                currentHp += hp;

                if (currentHp > totalHp)
                {
                    currentHp = totalHp;
                }
            }

        }
    }

    protected void ManageManaPoints()
    {
        if (execManaPointsOneTimeInFrame)
        {
            execManaPointsOneTimeInFrame = false;
            if (currentMp < totalMp)
            {
                currentMp += mp;

                if (currentMp > totalMp)
                {
                    currentMp = totalMp;
                }
            }
        }
    }

    void OnDisable()
    {
        this.rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    void OnEnable()
    {
        this.rb.constraints = RigidbodyConstraints.None;
        this.rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    protected void ChangeFrame(Action nextFrame)
    {
        actionTriggered = true;
        execMoveToPosition = false;
        execImpulseForce = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        base.ChangeFrame(nextFrame);
    }

    protected void OnGround(Action action)
    {
        if (onGround)
        {
            ChangeFrame(action);
        }
    }

    protected void OnCeil(Action action)
    {
        if (onCeil)
        {
            ChangeFrame(action);
        }
    }

    protected void OnWall(Action action)
    {
        if (onWall)
        {
            ChangeFrame(action);
        }
    }

    protected void OnPlatform(Action action)
    {
        if (onPlatform)
        {
            ChangeFrame(action);
        }
    }

    protected void StopMovement()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.linearVelocity = Vector3.zero;
    }

    protected void ResetMovementFromStop()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    protected void SpawnGroundExtraLarge(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(11, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    protected void SpawnGroundLarge(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(14, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    protected void SpawnGroundNormal(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(13, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    protected void SpawnGroundExtraSmall(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(12, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    protected void SpawnGroundSmall(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(15, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    protected void StageFadeIn(float fadeInValue)
    {
        if (stageSpriteRenderer.color.a >= 1)
        {
            stageSpriteRenderer.color = new Color(stageSpriteRenderer.color.r, stageSpriteRenderer.color.g, stageSpriteRenderer.color.b, 1);
        }
        else
        {
            stageSpriteRenderer.color = new Color(stageSpriteRenderer.color.r, stageSpriteRenderer.color.g, stageSpriteRenderer.color.b, fadeInValue + stageSpriteRenderer.color.a);
        }
    }

    protected void StageFadeOut(float fadeOutValue)
    {
        if (stageSpriteRenderer.color.a <= 0)
        {
            stageSpriteRenderer.color = new Color(stageSpriteRenderer.color.r, stageSpriteRenderer.color.g, stageSpriteRenderer.color.b, 0);
        }
        else
        {
            stageSpriteRenderer.color = new Color(stageSpriteRenderer.color.r, stageSpriteRenderer.color.g, stageSpriteRenderer.color.b, fadeOutValue - stageSpriteRenderer.color.a);
        }
    }

    protected void FollowTargetPhysic(Transform enemyPosition, float velocityX, float velocityY, float velocityZ)
    {
        if (enemyPosition == null)
        {
            return;
        }
        var selfPosition = transform.position;
        float dvx = 0; float dvy = 0; float dvz = 0; bool facingRight = true;
        if (selfPosition.x < enemyPosition.position.x)
        { //inimigo a frente
            dvx = velocityX;
        }
        else if (selfPosition.x > enemyPosition.position.x)
        { //inimigo a trás
            dvx = -velocityX;
        }
        else
        {
            dvx = 0f;
        }

        if (selfPosition.y < enemyPosition.position.y)
        { //inimigo acima
            dvy = velocityY;
        }
        else if (selfPosition.y > enemyPosition.position.y)
        { //inimigo abaixo
            dvy = -velocityY;
        }
        else
        {
            dvy = 0f;
        }

        if (selfPosition.z < enemyPosition.position.z)
        { //inimigo acima em z
            dvz = velocityZ;
        }
        else if (selfPosition.z > enemyPosition.position.z)
        { //inimigo abaixo em z
            dvz = -velocityZ;
        }
        else
        {
            dvz = 0f;
        }
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight, ItrPhysicEnum.FIXED);
    }
}