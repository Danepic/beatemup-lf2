using Enums;
using Helpers;
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
    public Transform hurtbox;
    public Rigidbody rb;
    protected Vector3 velocity = Vector3.zero;
    protected bool execMoveToPosition = false;
    protected bool execImpulseForce = false;
    public BoxCollider selfBoxCollider;
    public Transform hitbox;

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
    protected bool isExternAction;
    protected bool externFacingRight;
    protected int externAction;
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

    protected void ItrDefault()
    {
        hitbox.gameObject.SetActive(true);
        hitbox.localPosition = new Vector3(0f, spriteRenderer.sprite.bounds.size.y / 2, 0f);
        hitbox.localScale = new Vector3(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y, zSizeDefault);
    }

    protected void Itr()
    {
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
        // rb.linearVelocity = Vector3.zero;
        // Debug.Log(velocity);
        rb.AddForce(velocity * Time.fixedDeltaTime, ForceMode.VelocityChange);
        // this.velocity = Vector3.zero;
    }

    protected void MovePosition()
    {
        rb.linearVelocity = Vector3.zero;
        rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    protected void ApplyDefaultPhysic(float? dvx, float? dvy, float? dvz, bool facingRight)
    {
        if (!execPhysicsOnceInFrame)
        {
            return;
        }
        if (dvx != null)
        {
            if (facingRight)
            {
                this.velocity.x = dvx.Value;

            }
            else
            {
                this.velocity.x = -dvx.Value;
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
        execImpulseForce = true;
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

        // Debug.Log(this.velocity);

        isExternAction = false;
        execImpulseForce = true;
        execPhysicsOnceInFrame = false;
    }

    protected bool ExternInteraction(PhysicsObjController scriptObject, Action hitDefenseAction, Action hitJumpDefenseAction)
    {
        bool hit = false;
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
                                ChangeFrame(hitDefenseAction);
                            }
                            else
                            {
                                ChangeFrame(hitJumpDefenseAction);
                            }
                        }
                        else
                        {
                            ChangeFrame(externAction);
                        }
                        hit = true;
                    }
                    break;
                case ItrKindEnum.ALLY:
                    Debug.Log("ALLY");
                    if (externTeam == team)
                    {
                        ChangeFrame(externAction);
                        hit = true;
                    }
                    break;
                case ItrKindEnum.OWNER:
                    Debug.Log("OWNER");
                    if (externOwnerId == id)
                    {
                        ChangeFrame(externAction);
                        hit = true;
                    }
                    break;
                case ItrKindEnum.CHILD:
                    Debug.Log("CHILD");
                    if (externId == ownerId)
                    {
                        ChangeFrame(externAction);
                        hit = true;
                    }
                    break;
                case ItrKindEnum.SELF:
                    Debug.Log("SELF");
                    if (externId == id)
                    {
                        ChangeFrame(externAction);
                        hit = true;
                    }
                    break;
                case ItrKindEnum.ALL:
                    Debug.Log("ALL");
                    ChangeFrame(externAction);
                    hit = true;
                    break;
            }
            isExternAction = false;
        }
        else
        {
            isExternAction = false;
            hit = false;
        }

        return hit;
    }

    protected void CheckPlatforms()
    {
        Collider[] hitColliders = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y - (maxDistanceToCheckCollision / 2), transform.position.z),
            new Vector3(hurtbox.localScale.x / 2, maxDistanceToCheckCollision / 2, zSizeDefault / 2), Quaternion.identity, whatIsGround);
        if (hitColliders.Length > 0 && hitColliders[0].bounds.max.y - 0.01f <= transform.position.y)
        {
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

    protected void CheckInteraction()
    {
        if (restDamageWaitTime != 0)
        {
            return;
        }

        Collider[] hitColliders = new Collider[1];
        int numColliders = Physics.OverlapBoxNonAlloc(hurtbox.position, hurtbox.localScale / 2, hitColliders, Quaternion.identity, whatIsItr);

        for (int i = 0; i < numColliders; i++)
        {
            var collider = hitColliders[i];

            var scriptObject = collider.transform.parent.GetComponent<PhysicsObjController>();

            if (scriptObject.itr == null)
            {
                return;
            }

            // Debug.Log(collider.transform.parent.name + " acertou " + gameObject.name + "|" + scriptObject.itr.kind);

            if (scriptObject.targetId == null && scriptObject.damageInSingleTarget)
            {
                scriptObject.targetId = ownerId != null ? ownerId : id;
            }
            else
            {
                scriptObject.targetId = null;
            }

            externItr = scriptObject.itr;
            isExternAction = true;
            externFacingRight = scriptObject.facingRight;
            externTeam = scriptObject.team;
            externId = scriptObject.ownerId.HasValue ? scriptObject.ownerId.Value : scriptObject.id;
            externOwnerId = scriptObject.ownerId;
            externAction = scriptObject.itr.action;

            if (this.ExternInteraction(scriptObject, hitDefenseAction, jumpDefenseAction))
            {
                scriptObject.attacking = true;
                scriptObject.damageInSingleTarget = scriptObject.itr.applyInSingleEnemy;
                scriptObject.enableNextIfHit = true;
                scriptObject.nextIfHit = scriptObject.itr.nextIfHit;
                wasAttacked = true;
                damageRestTU = scriptObject.itr.rest;
                if (gameObject.activeInHierarchy)
                {
                    StartCoroutine(ItrEffectSpawn(scriptObject.itr.effect, new Vector3(0f, 0.3f, -0.1f)));
                }
            }
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
}