using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Domains;
using Enums;
using UnityEngine;
using static CharController;
using Random = UnityEngine.Random;

public class PhysicsObjController : ObjController
{
    public BdyEntity bdy = new();
    public ItrEntity itr = new();
    protected Transform hurtbox;
    protected Rigidbody rb;
    protected Vector3 velocity = Vector3.zero;
    protected bool execMoveToPosition = false;
    protected bool execImpulseForce = false;
    protected bool execFixedMoveToPosition = false;
    protected BoxCollider selfBoxCollider;
    protected Transform hitbox;
    public SpriteRenderer[] stageSpriteRenderer;

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
    public int totalHp;
    public int currentMp;
    public int totalMp;
    public bool canParry;
    public int lastDamage;
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
    public int externId;
    public int? externOwnerId;
    public TeamEnum externTeam;
    public ItrKindEnum externKind;

    protected bool defensable;
    protected bool execHealthPointsOneTimeInFrame = true;
    public bool execManaPointsOneTimeInFrame = true;
    public int mp;
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
    public List<ObjController> opointsControl = new();
    protected int? attackLevel1Frame;
    protected int? attackLevel2Frame;
    protected int? attackLevel3Frame;
    protected List<PhysicsObjController> hittableObjects = new List<PhysicsObjController>();

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        selfBoxCollider = GetComponent<BoxCollider>();
        hurtbox = transform.Find("Hurtbox");
        hitbox = transform.Find("Hitbox");
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

    public void BdyDefault(float zwidth = 0)
    {
        hurtbox.localPosition = new Vector3(0f, spriteRenderer.sprite.bounds.size.y / 2, 0f);
        hurtbox.localScale = new Vector3(spriteRenderer.sprite.bounds.size.x / 2, spriteRenderer.sprite.bounds.size.y,
            zSizeDefault + zwidth);

        selfBoxCollider.center = hurtbox.localPosition;
        selfBoxCollider.size = hurtbox.localScale;
    }

    public void Bdy()
    {
        hurtbox.localPosition = new Vector3(bdy.x, bdy.y, bdy.z);
        hurtbox.localScale = new Vector3(bdy.w, bdy.h, bdy.zwidth);

        selfBoxCollider.center = hurtbox.localPosition;
        selfBoxCollider.size = hurtbox.localScale;
    }

    public void ItrDefault(float zwidth = 0)
    {
        hittableObjects = new List<PhysicsObjController>();
        itr.kind = ItrKindEnum.ENEMY;
        hitbox.gameObject.SetActive(true);
        hitbox.localPosition = new Vector3(0f, spriteRenderer.sprite.bounds.size.y / 2, 0f);
        hitbox.localScale = new Vector3(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y,
            zSizeDefault + zwidth);
    }

    public void Itr()
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

    public void ItrDisable()
    {
        hitbox.gameObject.SetActive(false);
    }

    protected void ItrReset()
    {
        itr.x = 0f;
        itr.y = 0f;
        itr.z = 0;
        itr.w = 0f;
        itr.h = 0f;
        itr.zwidth = 0f;
        itr.dvx = 0;
        itr.dvy = 0;
        itr.dvz = 0;
        itr.action = 0;
        itr.applyInSingleEnemy = true;
        itr.defensable = true;
        itr.level = 0;
        itr.injury = 0;
        itr.effect = ItrEffectEnum.NORMAL;
        itr.rest = 0;
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

    public void ApplyDefaultPhysic(float? dvx, float? dvy, float? dvz, bool facingRight,
        ItrPhysicEnum physicType = ItrPhysicEnum.DEFAULT, bool ignoreFacing = false)
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
                    velocity.x = dvx.Value;
                }
                else
                {
                    velocity.x = -dvx.Value;
                }
            }
            else
            {
                velocity.x = dvx.Value;
            }
        }

        if (dvy != null)
        {
            velocity.y = dvy.Value;
        }

        if (dvz != null)
        {
            velocity.z = dvz.Value;
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

    public void ApplyExternPhysic()
    {
        if (!execPhysicsOnceInFrame && !isExternAction || externItr == null)
        {
            return;
        }

        velocity.x = externFacingRight ? externItr.dvx : -externItr.dvx;
        velocity.y = externItr.dvy;
        velocity.z = externItr.dvz;

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

    protected void ExternInteraction(PhysicsObjController scriptObject)
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
                        ApplyInjured(scriptObject.itr.injury);
                        canParry = true;
                        if (currentHp <= 0)
                        {
                            isDeath = true;
                        }

                        if (defensable && (state == StateFrameEnum.DEFEND || state == StateFrameEnum.JUMP_DEFEND))
                        {
                            scriptObject.itr.dvx /= 2;
                            scriptObject.itr.dvy /= 2;
                            scriptObject.itr.dvz /= 2;
                            scriptObject.itr.physic = ItrPhysicEnum.DEFAULT;
                            if (onGround)
                            {
                                ApplyExternPhysicsBehavior(scriptObject, 160);
                            }
                            else
                            {
                                ApplyExternPhysicsBehavior(scriptObject, 305);
                            }
                        }
                        else
                        {
                            scriptObject.hittableObjects.Add(this);
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
        percentToHit = lockHittablePercent ? percentToHit : Random.Range(0, 100);
        lockHittablePercent = true;
        bool wasHit = hittablePercent == 100 || percentToHit <= hittablePercent;
        damageRestTU = scriptObject.itr.rest;

        if (wasHit)
        {
            externItr = scriptObject.itr;
            externFacingRight = scriptObject.attachToOwner ? scriptObject.owner.facingRight : scriptObject.facingRight;
            externId = scriptObject.ownerId.HasValue ? scriptObject.ownerId.Value : scriptObject.id;
            externOwnerId = scriptObject.ownerId;
            externPosition = scriptObject.transform.position;
            scriptObject.attacking = true;
            scriptObject.damageInSingleTarget = scriptObject.itr.applyInSingleEnemy;
            scriptObject.enableNextIfHit = true;
            scriptObject.nextIfHit = scriptObject.itr.nextIfHit;
            scriptObject.lastTargetHit = this;
            wasAttacked = true;
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(ItrEffectSpawn(scriptObject.itr.effect, new Vector3(0f, 0.3f, -0.1f)));
            }

            if (TryGetComponent<CharController>(out _))
            {
                ChangeFrame(action);
            }
            else
            {
                switch (scriptObject.itr.level)
                {
                    case 1:
                        ChangeFrame(attackLevel1Frame);
                        break;
                    case 2:
                        ChangeFrame(attackLevel2Frame);
                        break;
                    case 3:
                        ChangeFrame(attackLevel3Frame);
                        break;
                }
            }
        }

        lockHittablePercent = false;
    }

    protected void CheckPlatforms()
    {
        if (gameObject.activeInHierarchy && gameObject.activeSelf)
        {
            StartCoroutine(DetectGround());
            StartCoroutine(DetectWall());
        }
    }

    protected void CheckInteraction()
    {
        if (restDamageWaitTime != 0 || !hurtbox.gameObject.activeInHierarchy)
        {
            return;
        }

        Collider[] hitColliders = new Collider[5];
        int numColliders = Physics.OverlapBoxNonAlloc(hurtbox.position, hurtbox.localScale / 2, hitColliders,
            Quaternion.identity, whatIsItr);

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

            if (bdy.kind != BdyKindEnum.INVULNERABLE)
            {
                ExternInteraction(scriptObject);
            }
        }
    }

    IEnumerator ItrEffectSpawn(ItrEffectEnum effect, Vector3 contactPoint)
    {
        switch (effect)
        {
            case ItrEffectEnum.NORMAL:
                SpawnOpoint(HIT_NORMAL_OPOINT,
                    Opoint(x: contactPoint.x, y: contactPoint.y, z: contactPoint.z, oid: 0, facingFront: true,
                        quantity: 1));
                break;

            case ItrEffectEnum.BLOOD:
                SpawnOpoint(HIT_BLOOD_OPOINT,
                    Opoint(x: contactPoint.x, y: contactPoint.y, z: contactPoint.z, oid: 0, facingFront: true,
                        quantity: 1));
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

    public void AddManaPoints(int mpValue)
    {
        mp = mpValue;
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

    public bool CheckIfHaveMana(int mpValue)
    {
        return mpValue <= currentMp;
    }

    public void UsageManaPoints(int mpValue)
    {
        if (execManaPointsOneTimeInFrame)
        {
            execManaPointsOneTimeInFrame = false;
            currentMp -= mpValue;
            if (currentMp < 0)
            {
                currentMp = 0;
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
        execManaPointsOneTimeInFrame = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        base.ChangeFrame(nextFrame);
    }

    public void ChangeFrame(int? nextFrame)
    {
        ChangeFrame(frames[nextFrame.Value]);
    }

    public void OnGround(int frame)
    {
        OnGround(frames[frame]);
    }

    public void OnGround(Action frame)
    {
        if (onGround)
        {
            ChangeFrame(frame);
        }
    }

    public void InAir(int frame)
    {
        InAir(frames[frame]);
    }

    public void InAir(Action frame)
    {
        if (!onGround)
        {
            ChangeFrame(frame);
        }
    }

    public void OnCeil(int frame)
    {
        ChangeFrame(frames[frame]);
    }

    public void OnCeil(Action frame)
    {
        if (onCeil)
        {
            ChangeFrame(frame);
        }
    }

    public void OnWall(int frame)
    {
        ChangeFrame(frames[frame]);
    }

    public void OnWall(Action frame)
    {
        if (onWall)
        {
            ChangeFrame(frame);
        }
    }

    protected void OnPlatform(Action action)
    {
        if (onPlatform)
        {
            ChangeFrame(action);
        }
    }

    public void StopMovement()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.linearVelocity = Vector3.zero;
    }

    public void ResetMovementFromStop()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void SpawnGroundExtraLarge(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(GROUND_EXTRA_LARGE_OPOINT, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    public void SpawnGroundLarge(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(GROUND_LARGE_OPOINT, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    public void SpawnGroundNormal(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(GROUND_NORMAL_OPOINT, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    public void SpawnGroundExtraSmall(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(GROUND_EXTRA_SMALL_OPOINT, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    public void SpawnGroundSmall(OpointEntity opoint)
    {
        switch (stage)
        {
            case GroundEnum.NONE:
                break;
            case GroundEnum.NORMAL:
                SpawnOpoint(GROUND_SMALL_OPOINT, opoint);
                break;
            case GroundEnum.WATER:
                break;
        }
    }

    public void StageFadeIn(float fadeInValue)
    {
        foreach (var picStage in stageSpriteRenderer)
        {
            if (picStage.color.a >= 1)
            {
                picStage.color = new Color(picStage.color.r, picStage.color.g, picStage.color.b, 1);
            }
            else
            {
                picStage.color = new Color(picStage.color.r, picStage.color.g, picStage.color.b,
                    fadeInValue + picStage.color.a);
            }
        }
    }

    public void StageFadeOut(float fadeOutValue)
    {
        foreach (var picStage in stageSpriteRenderer)
        {
            if (picStage.color.a <= 0)
            {
                picStage.color = new Color(picStage.color.r, picStage.color.g, picStage.color.b, 0);
            }
            else
            {
                picStage.color = new Color(picStage.color.r, picStage.color.g, picStage.color.b,
                    fadeOutValue - picStage.color.a);
            }
        }
    }

    public void BlackoutStage()
    {
        foreach (var picStage in stageSpriteRenderer)
        {
            picStage.color = new Color(picStage.color.r, picStage.color.g, picStage.color.b, 0);
        }
    }

    public void ResetStageColor()
    {
        foreach (var picStage in stageSpriteRenderer)
        {
            picStage.color = new Color(picStage.color.r, picStage.color.g, picStage.color.b, 1);
        }
    }

    protected void FollowTargetPhysic(Transform enemyPosition, float velocityX, float velocityY, float velocityZ)
    {
        if (enemyPosition == null)
        {
            return;
        }

        var selfPosition = transform.position;
        float dvx = 0;
        float dvy = 0;
        float dvz = 0;
        bool facingRight = true;
        if (selfPosition.x < enemyPosition.position.x)
        {
            //inimigo a frente
            dvx = velocityX;
        }
        else if (selfPosition.x > enemyPosition.position.x)
        {
            //inimigo a trás
            dvx = -velocityX;
        }
        else
        {
            dvx = 0f;
        }

        if (selfPosition.y < enemyPosition.position.y)
        {
            //inimigo acima
            dvy = velocityY;
        }
        else if (selfPosition.y > enemyPosition.position.y)
        {
            //inimigo abaixo
            dvy = -velocityY;
        }
        else
        {
            dvy = 0f;
        }

        if (selfPosition.z < enemyPosition.position.z)
        {
            //inimigo acima em z
            dvz = velocityZ;
        }
        else if (selfPosition.z > enemyPosition.position.z)
        {
            //inimigo abaixo em z
            dvz = -velocityZ;
        }
        else
        {
            dvz = 0f;
        }

        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight, ItrPhysicEnum.FIXED);
    }

    private IEnumerator DetectWall()
    {
        var forwardCenterX = hurtbox.transform.position.x + (hurtbox.lossyScale.x / 2) + (0.005f / 2);

        Collider[] hitWallFrontColliders = new Collider[3];
        var hitWallFrontCollidersResult = Physics.OverlapBoxNonAlloc(
            new Vector3(forwardCenterX, hurtbox.transform.position.y, hurtbox.transform.position.z),
            new Vector3(0.005f / 2, hurtbox.lossyScale.y / 2, zSizeDefault / 2), hitWallFrontColliders,
            Quaternion.identity, whatIsWall);

        var backCenterX = hurtbox.transform.position.x - (hurtbox.lossyScale.x / 2) - (0.005f / 2);

        Collider[] hitWallBackColliders = new Collider[3];
        var hitWallBackCollidersResult = Physics.OverlapBoxNonAlloc(
            new Vector3(backCenterX, hurtbox.transform.position.y, hurtbox.transform.position.z),
            new Vector3(0.005f / 2, hurtbox.lossyScale.y / 2, zSizeDefault / 2), hitWallBackColliders,
            Quaternion.identity, whatIsWall);

        if (hitWallFrontCollidersResult > 0)
        {
            Debug.Log(gameObject.name + " | " + hitWallFrontColliders[0].gameObject.name);
            onWall = true;
        }
        else if (hitWallBackCollidersResult > 0)
        {
            Debug.Log(gameObject.name + " | " + hitWallBackColliders[0].gameObject.name);
            onWall = true;
        }
        else
        {
            onWall = false;
        }

        yield return null;
    }

    private IEnumerator DetectGround()
    {
        Collider[] hitColliders = new Collider[3];
        int hitCollidersResult = Physics.OverlapBoxNonAlloc(
            new Vector3(hurtbox.transform.position.x,
                hurtbox.position.y - (hurtbox.transform.lossyScale.y / 2) - (maxDistanceToCheckCollision / 2),
                hurtbox.transform.position.z),
            new Vector3(hurtbox.lossyScale.x / 2, maxDistanceToCheckCollision / 2, zSizeDefault / 2), hitColliders,
            Quaternion.identity, whatIsGround);
        if (hitCollidersResult > 0 && hitColliders[0].bounds.max.y - 0.01f <= hurtbox.transform.position.y &&
            gameObject.activeSelf)
        {
            StartCoroutine(DetectStage(hitColliders[0]));
            onGround = true;
            onCeil = false;
        }
        else
        {
            onGround = false;
        }

        if (!onGround)
        {
            Collider[] hitCeilColliders = new Collider[3];
            int hitCeilCollidersResult = Physics.OverlapBoxNonAlloc(
                new Vector3(hurtbox.transform.position.x,
                    hurtbox.position.y - (hurtbox.transform.lossyScale.y / 2) - (maxDistanceToCheckCollision / 2),
                    hurtbox.transform.position.z),
                new Vector3(hurtbox.lossyScale.x / 2, -maxDistanceToCheckCollision / 2, zSizeDefault / 2),
                hitCeilColliders, Quaternion.identity, whatIsCeil);

            if (hitCeilCollidersResult > 0)
            {
                onGround = false;
                onCeil = true;
            }
            else
            {
                onCeil = false;
            }
        }

        yield return null;
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

    public List<PhysicsObjController> GetHittableCharacters()
    {
        return hittableObjects.Where(ob => ob.type == ObjTypeEnum.CHARACTER).ToList();
    }

    public void ApplyInjured(int injuryDamage)
    {
        currentHp -= injuryDamage;
        lastDamage = injuryDamage;
    }

    public void EnableManaPoints()
    {
        execManaPointsOneTimeInFrame = true;
    }

    private void OnDrawGizmos()
    {
        // if (hurtbox == null) return;
        //
        // // Cor do gizmo
        // Gizmos.color = Color.red;
        //
        // // FRONT WALL BOX
        // Vector3 forwardCenterX = hurtbox.transform.position + new Vector3((hurtbox.lossyScale.x / 2) + (0.005f / 2), 0, 0);
        // Vector3 forwardHalfExtents = new Vector3(0.005f / 2, hurtbox.lossyScale.y / 2, zSizeDefault / 2);
        // Gizmos.DrawWireCube(forwardCenterX, forwardHalfExtents * 2); // *2 porque extents = metade
        //
        // // BACK WALL BOX
        // Vector3 backCenterX = hurtbox.transform.position - new Vector3((hurtbox.lossyScale.x / 2) + (0.005f / 2), 0, 0);
        // Vector3 backHalfExtents = forwardHalfExtents; // mesmo tamanho
        // Gizmos.DrawWireCube(backCenterX, backHalfExtents * 2);
        //
        // // ========== GROUND BOX ==========
        // Gizmos.color = Color.green;
        //
        // Vector3 groundCenter = new Vector3(
        //     hurtbox.transform.position.x,
        //     hurtbox.position.y - (hurtbox.transform.lossyScale.y / 2) - (maxDistanceToCheckCollision / 2),
        //     hurtbox.transform.position.z
        // );
        //
        // Vector3 groundHalfExtents = new Vector3(
        //     hurtbox.lossyScale.x / 2,
        //     maxDistanceToCheckCollision / 2,
        //     zSizeDefault / 2
        // );
        //
        // Gizmos.DrawWireCube(groundCenter, groundHalfExtents * 2);
        //
        // // ========== CEIL BOX ==========
        // if (spriteRenderer != null && spriteRenderer.sprite != null)
        // {
        //     Gizmos.color = Color.cyan;
        //
        //     float spriteHeight = spriteRenderer.sprite.bounds.size.y;
        //     float spriteWidth = spriteRenderer.sprite.bounds.size.x;
        //
        //     Vector3 ceilCenter = new Vector3(
        //         hurtbox.transform.position.x,
        //         hurtbox.position.y+ (hurtbox.transform.lossyScale.y / 2) - (maxDistanceToCheckCollision / 2),
        //         hurtbox.transform.position.z
        //     );
        //
        //     Vector3 ceilHalfExtents = new Vector3(
        //         hurtbox.lossyScale.x / 2,
        //         Mathf.Abs(maxDistanceToCheckCollision / 2),
        //         zSizeDefault / 2
        //     );
        //
        //     Gizmos.DrawWireCube(ceilCenter, ceilHalfExtents * 2);
        // }
    }
}