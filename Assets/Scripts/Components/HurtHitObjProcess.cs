using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Helpers;
using UnityEngine;

public class HurtHitObjProcess : ObjProcess
{
    public BoxCollider selfBoxCollider;
    public Transform hurtbox;
    public Transform hitbox;

    public float zSizeDefault = 0.22f;
    public float maxDistanceToCheckCollision = 0.1f;
    private LayerMask whatIsGround;
    private LayerMask whatIsCeil;
    private LayerMask whatIsWall;
    private LayerMask whatIsItr;

    public float restDamageWaitTime;

    public int currentHp;
    public int totalHp;
    public int currentMp;
    public int totalMp;
    public bool canParry;
    public int lastDamage;

    public new void Start()
    {
        base.Start();
        whatIsGround = LayerMask.GetMask("Ground");
        whatIsCeil = LayerMask.GetMask("Ceil");
        whatIsWall = LayerMask.GetMask("Wall");
        whatIsItr = LayerMask.GetMask("Itr");
        totalHp = ResolveHealthPoint();
        totalMp = ResolveManaPoint();
        currentHp = objHelper.header.startHp;
        currentMp = objHelper.header.startMp;
        dataHelper.isDeath = false;
        canParry = false;
    }

    void OnDisable()
    {
        this.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
    }

    void OnEnable()
    {
        this.rigidbody.constraints = RigidbodyConstraints.None;
        this.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    protected void ManageHealthManaPoints()
    {
        if (dataHelper.execHealthManaPointsOneTimeInFrame)
        {
            dataHelper.execHealthManaPointsOneTimeInFrame = false;
            if (currentFrame.properties.mp.HasValue && currentMp < totalMp)
            {
                currentMp += currentFrame.properties.mp.Value;

                if (currentMp > totalMp)
                {
                    currentMp = totalMp;
                }
            }

            if (currentFrame.properties.hp.HasValue && currentHp < totalHp)
            {
                currentHp += currentFrame.properties.hp.Value;

                if (currentHp > totalHp)
                {
                    currentHp = totalHp;
                }
            }

        }
    }

    protected void ApplyBdy()
    {
        if (currentFrame.bdy != null && currentFrame.bdy.defaultBdy)
        {
            hurtbox.localPosition = new Vector3(0f, spriteRenderer.sprite.bounds.size.y / 2, 0f);
            hurtbox.localScale = new Vector3(spriteRenderer.sprite.bounds.size.x / 2, spriteRenderer.sprite.bounds.size.y, zSizeDefault);
        }
        else
        {
            hurtbox.localPosition = new Vector3(currentFrame.bdy.x, currentFrame.bdy.y, currentFrame.bdy.z);
            hurtbox.localScale = new Vector3(currentFrame.bdy.w, currentFrame.bdy.h, currentFrame.bdy.zwidth);
        }

        selfBoxCollider.center = hurtbox.localPosition;
        selfBoxCollider.size = hurtbox.localScale;
    }

    protected void ApplyItr()
    {
        if (currentFrame.itr != null)
        {
            hitbox.gameObject.SetActive(true);
            if (currentFrame.itr.defaultItr)
            {
                hitbox.localPosition = new Vector3(0f, spriteRenderer.sprite.bounds.size.y / 2, 0f);
                hitbox.localScale = new Vector3(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y, zSizeDefault);
            }
            else
            {
                hitbox.localPosition = new Vector3(currentFrame.itr.x, currentFrame.itr.y, currentFrame.itr.z);
                hitbox.localScale = new Vector3(currentFrame.itr.w, currentFrame.itr.h, currentFrame.itr.zwidth);
            }
        }
        else
        {
            hitbox.gameObject.SetActive(false);
        }
    }

    protected void Timers()
    {
        // Debug.Log(">>" + restDamageWaitTime + "|" + dataHelper.damageRestTU / 30 + "|" + dataHelper.damageRestTU + "|" + gameObject.name);
        if (dataHelper.damageRestTU > 0)
        {
            restDamageWaitTime += Time.deltaTime % 60;
        }
        if (restDamageWaitTime >= dataHelper.damageRestTU / 30)
        {
            dataHelper.wasAttacked = false;
            restDamageWaitTime = 0f;
            dataHelper.damageRestTU = 0f;
        }
        base.Timers();
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

            var scriptObject = collider.transform.parent.GetComponent<HurtHitObjProcess>();

            if (scriptObject.currentFrame.itr == null)
            {
                return;
            }

            Debug.Log(collider.transform.parent.name + " acertou " + gameObject.name + "|" + scriptObject.currentFrame.itr.kind);

            if (scriptObject.dataHelper.targetId == null && scriptObject.dataHelper.damageInSingleTarget)
            {
                scriptObject.dataHelper.targetId = dataHelper.ownerId != null ? dataHelper.ownerId : dataHelper.selfId;
            }
            else
            {
                scriptObject.dataHelper.targetId = null;
            }

            dataHelper.externItr = scriptObject.currentFrame.itr;
            dataHelper.externAction = true;
            dataHelper.externFacingRight = scriptObject.dataHelper.facingRight;
            dataHelper.externTeam = scriptObject.dataHelper.team;
            dataHelper.externId = scriptObject.dataHelper.ownerId != null ? scriptObject.dataHelper.ownerId : scriptObject.dataHelper.selfId;
            dataHelper.externOwnerId = scriptObject.dataHelper.ownerId;

            var contactPointX = scriptObject.dataHelper.facingRight ? scriptObject.currentFrame.itr.x : -scriptObject.currentFrame.itr.x;
            dataHelper.contactPoint = scriptObject.transform.position + new Vector3(contactPointX, scriptObject.currentFrame.itr.y, scriptObject.currentFrame.itr.z);

            // Debug.Log(scriptObject.currentFrame.id + "|" + dataHelper.damageRestTU + "|" + restDamageWaitTime);

            if (this.ExternInteraction(scriptObject))
            {
                scriptObject.dataHelper.attacking = true;
                scriptObject.dataHelper.damageInSingleTarget = scriptObject.currentFrame.itr.applyInSingleEnemy;
                scriptObject.dataHelper.enableNextIfHit = true;
                scriptObject.dataHelper.nextIfHit = scriptObject.currentFrame.itr.nextIfHit;
                dataHelper.wasAttacked = true;
                dataHelper.execHitSpawnOneTimeInFrame = true;
                dataHelper.damageRestTU = scriptObject.currentFrame.itr.rest;
            }
        }
    }

    protected void CheckIfNextHitEnable()
    {
        if (dataHelper.enableNextIfHit)
        {
            this.ChangeFrame(dataHelper.nextIfHit);
            dataHelper.enableNextIfHit = false;
            dataHelper.nextIfHit = null;
        }

    }

    protected bool ExternInteraction(HurtHitObjProcess scriptObject)
    {
        bool hit = false;
        if (dataHelper.externAction)
        {
            switch (dataHelper.externItr.kind)
            {
                case ItrKindEnum.ENEMY:
                    if (dataHelper.externTeam != dataHelper.team)
                    {
                        currentHp -= dataHelper.externItr.injury;
                        lastDamage = dataHelper.externItr.injury;
                        canParry = true;
                        if (currentHp <= 0)
                        {
                            dataHelper.isDeath = true;
                        }

                        if (dataHelper.externItr.defensable && dataHelper.isDefending)
                        {
                            if (dataHelper.onGround)
                            {
                                ChangeFrame(StateHelper.HIT_DEFENSE);
                            }
                            else
                            {
                                ChangeFrame(StateHelper.HIT_JUMP_DEFENSE);
                            }
                        }
                        else
                        {
                            ChangeFrame(dataHelper.externItr.action);
                        }
                        hit = true;
                    }
                    break;
                case ItrKindEnum.ALLY:
                    Debug.Log("ALLY");
                    if (dataHelper.externTeam == dataHelper.team)
                    {
                        ChangeFrame(dataHelper.externItr.action);
                        hit = true;
                    }
                    break;
                case ItrKindEnum.OWNER:
                    Debug.Log("OWNER");
                    if (dataHelper.externOwnerId == dataHelper.selfId)
                    {
                        ChangeFrame(dataHelper.externItr.action);
                        hit = true;
                    }
                    break;
                case ItrKindEnum.CHILD:
                    Debug.Log("CHILD");
                    if (dataHelper.externId == dataHelper.ownerId)
                    {
                        ChangeFrame(dataHelper.externItr.action);
                        hit = true;
                    }
                    break;
                case ItrKindEnum.SELF:
                    Debug.Log("SELF");
                    if (dataHelper.externId == dataHelper.selfId)
                    {
                        ChangeFrame(dataHelper.externItr.action);
                        hit = true;
                    }
                    break;
                case ItrKindEnum.ALL:
                    Debug.Log("ALL");
                    ChangeFrame(dataHelper.externItr.action);
                    hit = true;
                    break;
            }
            dataHelper.externAction = false;
        }
        else
        {
            dataHelper.externAction = false;
            hit = false;
        }

        return hit;
    }

    protected void CheckPlatforms()
    {
        Collider[] hitColliders = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y - (maxDistanceToCheckCollision / 2), transform.position.z), new Vector3(spriteRenderer.sprite.bounds.size.x / 2, maxDistanceToCheckCollision / 2, zSizeDefault / 2), Quaternion.identity, whatIsGround);
        if (hitColliders.Length > 0)
        {
            dataHelper.onGround = true;
            dataHelper.onCeil = false;
            if (currentFrame.properties.hitGround != null)
            {
                this.ChangeFrame(currentFrame.properties.hitGround);
            }
        }
        else
        {
            dataHelper.onGround = false;
            if (currentFrame.properties.hitAir != null)
            {
                this.ChangeFrame(currentFrame.properties.hitAir);
            }
        }

        var forwardCenterX = transform.position.x + (spriteRenderer.sprite.bounds.size.x / 2) + maxDistanceToCheckCollision;
        Collider[] hitWallFrontColliders = Physics.OverlapBox(new Vector3(forwardCenterX, transform.position.y + spriteRenderer.sprite.bounds.size.y / 2, transform.position.z), new Vector3(maxDistanceToCheckCollision / 2, spriteRenderer.sprite.bounds.size.y / 2, zSizeDefault / 2), Quaternion.identity, whatIsWall);
        
        var backCenterX = transform.position.x - (spriteRenderer.sprite.bounds.size.x / 2) - maxDistanceToCheckCollision;
        Collider[] hitWallBackColliders = Physics.OverlapBox(new Vector3(backCenterX, transform.position.y + spriteRenderer.sprite.bounds.size.y / 2, transform.position.z), new Vector3(maxDistanceToCheckCollision / 2, spriteRenderer.sprite.bounds.size.y / 2, zSizeDefault / 2), Quaternion.identity, whatIsWall);
        
        if (hitWallFrontColliders.Length > 0 || hitWallBackColliders.Length > 0)
        {
            dataHelper.onWall = true;
            if (currentFrame.properties.hitWall != null)
            {
                this.ChangeFrame(currentFrame.properties.hitWall);
            }
        }
        else
        {
            dataHelper.onWall = false;
        }

        if (!dataHelper.onGround)
        {
            Collider[] hitCeilColliders = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y + spriteRenderer.sprite.bounds.size.y + maxDistanceToCheckCollision, transform.position.z), new Vector3(spriteRenderer.sprite.bounds.size.x / 2, -maxDistanceToCheckCollision / 2, zSizeDefault / 2), Quaternion.identity, whatIsCeil);

            if (hitCeilColliders.Length > 0)
            {
                dataHelper.onGround = false;
                dataHelper.onCeil = true;
                if (currentFrame.properties.hitCeil != null)
                {
                    this.ChangeFrame(currentFrame.properties.hitCeil);
                }
            }
            else
            {
                dataHelper.onCeil = false;
                if (currentFrame.properties.hitAir != null)
                {
                    this.ChangeFrame(currentFrame.properties.hitAir);
                }
            }
        }
    }

    protected void ApplyDefaultPhysic(float? dvx, float? dvy, float? dvz, bool facingRight, ForceMode forceMode)
    {
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

        this.ImpulseForce(forceMode);
    }

    protected void ImpulseForce(ForceMode forceMode)
    {
        if (dataHelper.execImpulseForceOneTimeInFrame && velocity != Vector3.zero)
        {
            rigidbody.linearVelocity = Vector3.zero;
            rigidbody.AddForce(velocity * Time.fixedDeltaTime, forceMode);
            dataHelper.execImpulseForceOneTimeInFrame = false;
            this.velocity = Vector3.zero;
        }
    }

    protected void MovePosition()
    {
        rigidbody.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    private int ResolveManaPoint()
    {
        int mp = 0;
        switch (objHelper.stats.stamina)
        {
            case 1:
                mp = 800;
                break;
            case 2:
                mp = 850;
                break;
            case 3:
                mp = 900;
                break;
            case 4:
                mp = 950;
                break;
            case 5:
                mp = 1000;
                break;
            case 6:
                mp = 1050;
                break;
            case 7:
                mp = 1100;
                break;
            case 8:
                mp = 1150;
                break;
            case 9:
                mp = 1200;
                break;
            case 10:
                mp = 1250;
                break;
        }
        return mp;
    }

    private int ResolveHealthPoint()
    {
        int hp = 0;
        switch (objHelper.stats.stamina)
        {
            case 1:
                hp = 900;
                break;
            case 2:
                hp = 925;
                break;
            case 3:
                hp = 950;
                break;
            case 4:
                hp = 975;
                break;
            case 5:
                hp = 1000;
                break;
            case 6:
                hp = 1025;
                break;
            case 7:
                hp = 1050;
                break;
            case 8:
                hp = 1075;
                break;
            case 9:
                hp = 1100;
                break;
            case 10:
                hp = 1125;
                break;
        }
        return hp;
    }

    void OnDrawGizmos()
    {
        if (gameObject.activeInHierarchy)
        {
            Gizmos.color = Color.cyan;

            Gizmos.DrawWireCube(new Vector3(transform.position.x + (spriteRenderer.sprite.bounds.size.x / 2), transform.position.y + spriteRenderer.sprite.bounds.size.y / 2, transform.position.z), new Vector3(maxDistanceToCheckCollision, spriteRenderer.sprite.bounds.size.y, zSizeDefault));
            Gizmos.DrawWireCube(new Vector3(transform.position.x - (spriteRenderer.sprite.bounds.size.x / 2), transform.position.y + spriteRenderer.sprite.bounds.size.y / 2, transform.position.z), new Vector3(-maxDistanceToCheckCollision, spriteRenderer.sprite.bounds.size.y, zSizeDefault));

            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y + spriteRenderer.sprite.bounds.size.y + maxDistanceToCheckCollision, transform.position.z), new Vector3(spriteRenderer.sprite.bounds.size.x, -maxDistanceToCheckCollision, zSizeDefault));
            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y - (maxDistanceToCheckCollision / 2), transform.position.z), new Vector3(spriteRenderer.sprite.bounds.size.x, maxDistanceToCheckCollision, zSizeDefault));
        }
    }
}
