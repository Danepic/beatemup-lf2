using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class HurtHitObjProcess : ObjProcess
{
    public BoxCollider selfBoxCollider;
    public Transform hurtbox;
    public Transform hitbox;

    public Rigidbody rigidbody;
    protected MatchController matchController;

    public float zSizeDefault = 0.22f;
    public float maxDistanceToCheckCollision = 0.1f;
    private LayerMask whatIsGround;
    private LayerMask whatIsItr;

    public new void Start()
    {
        base.Start();
        whatIsGround = LayerMask.GetMask("Ground");
        whatIsItr = LayerMask.GetMask("Itr");
        matchController = GameObject.Find("MatchController").GetComponent<MatchController>();
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

    protected void ApplyBdy()
    {
        if (currentFrame.bdy != null && currentFrame.bdy.defaultBdy)
        {
            hurtbox.localPosition = new Vector3(0f, spriteRenderer.sprite.bounds.size.y / 2, 0f);
            hurtbox.localScale = new Vector3(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y, zSizeDefault);
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

    protected void CheckInteraction()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, whatIsItr);

        if (hitColliders.Length > 0)
        {
            var collider = hitColliders[0];
            Debug.Log(collider.transform.parent.name + " acertou " + gameObject.name);

            var scriptObject = collider.transform.parent.GetComponent<HurtHitObjProcess>();

            dataHelper.externItr = scriptObject.currentFrame.itr;
            dataHelper.externAction = true;
            dataHelper.externFacingRight = scriptObject.dataHelper.facingRight;
            dataHelper.externTeam = scriptObject.dataHelper.team;
            dataHelper.externId = collider.gameObject.GetInstanceID();
            dataHelper.externOwnerId = scriptObject.dataHelper.ownerId;
            dataHelper.execHitSpawnOneTimeInFrame = true;
            dataHelper.contactPoint = collider.ClosestPoint(transform.position);
        }
    }

    protected void ExternInteraction()
    {
        if (dataHelper.externAction)
        {
            switch (dataHelper.externItr.kind)
            {
                case ItrKindEnum.ENEMY:
                    Debug.Log("ENEMY" + ":" + dataHelper.externTeam + "|" + dataHelper.team);
                    if (dataHelper.externTeam != dataHelper.team)
                    {
                        ChangeFrame(dataHelper.externItr.action);
                    }
                    break;
                case ItrKindEnum.ALLY:
                    Debug.Log("ALLY");
                    if (dataHelper.externTeam == dataHelper.team)
                    {
                        ChangeFrame(dataHelper.externItr.action);
                    }
                    break;
                case ItrKindEnum.OWNER:
                    Debug.Log("OWNER");
                    if (dataHelper.externOwnerId == dataHelper.selfId)
                    {
                        ChangeFrame(dataHelper.externItr.action);
                    }
                    break;
                case ItrKindEnum.CHILD:
                    Debug.Log("CHILD");
                    if (dataHelper.externId == dataHelper.ownerId)
                    {
                        ChangeFrame(dataHelper.externItr.action);
                    }
                    break;
                case ItrKindEnum.SELF:
                    Debug.Log("SELF");
                    if (dataHelper.externId == dataHelper.selfId)
                    {
                        ChangeFrame(dataHelper.externItr.action);
                    }
                    break;
                case ItrKindEnum.ALL:
                    Debug.Log("ALL");
                    ChangeFrame(dataHelper.externItr.action);
                    break;
            }
            dataHelper.externAction = false;
        }
        else
        {
            dataHelper.externAction = false;
        }
    }

    protected void CheckPlatforms()
    {
        Collider[] hitColliders = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y - (maxDistanceToCheckCollision / 2), transform.position.z), new Vector3(spriteRenderer.sprite.bounds.size.x, maxDistanceToCheckCollision, transform.localScale.z) / 2, Quaternion.identity, whatIsGround);

        if (hitColliders.Length > 0)
        {
            dataHelper.onGround = true;
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
    }

    protected void ApplyDefaultPhysic(float? dvx, float? dvy, float? dvz)
    {
        if (dvx != null)
        {
            if (dataHelper.facingRight)
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
        this.ImpulseForce();
    }

    protected void ImpulseForce()
    {
        if (dataHelper.execImpulseForceOneTimeInFrame)
        {
            rigidbody.AddForce(velocity * Time.fixedDeltaTime, ForceMode.VelocityChange);
            dataHelper.execImpulseForceOneTimeInFrame = false;
        }
    }

    protected void MovePosition()
    {
        rigidbody.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    void OnDrawGizmos()
    {
        if (gameObject.activeInHierarchy)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y - (maxDistanceToCheckCollision / 2), transform.position.z), new Vector3(spriteRenderer.sprite.bounds.size.x, maxDistanceToCheckCollision, zSizeDefault));
        }
    }
}
