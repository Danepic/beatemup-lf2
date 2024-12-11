using System;
using System.Collections.Generic;
using System.Timers;
using AYellowpaper.SerializedCollections;
using Domains;
using Enums;
using Helpers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;
using Utils;

public abstract class ObjProcess : MonoBehaviour
{

    [SerializeField]
    public TextAsset datFile;

    [SerializeField]
    public ObjHelper objHelper;

    [SerializeField]
    public DataHelper dataHelper;

    public Sprite inv;

    public SpriteRenderer spriteRenderer;

    public FrameEntity currentFrame;

    public Rigidbody rigidbody;

    public float waitFrame;
    protected Vector3 velocity = Vector3.zero;

    protected float DV_VALUE_TO_DIVIDE = 100;

    protected float DV_VALUE_TO_STOP = 550;

    protected float runningSpeed = 0f;

    public List<GameObject> opointsToPool;

    public int paletteIndex = 0;

    public int hitNormalFrame;
    public int hitBloodFrame;
    public int defenseHitFrame;
    public Vector3 originalLocalScale;
    public Color originalColor;

    void Awake()
    {
        dataHelper.selfId = gameObject.GetInstanceID();
        objHelper = DatFileLoadUtil.Exec(datFile, paletteIndex);
        objHelper.opoints = DatFileLoadUtil.EnrichOpoints(objHelper.frames, opointsToPool, gameObject.GetInstanceID(), dataHelper.team);
    }

    public void Start()
    {
        if (dataHelper.summonAction == null)
        {
            this.ChangeFrame(0);
        }
        else
        {
            this.ChangeFrame(dataHelper.summonAction);
        }
        waitFrame = 0f;
        runningSpeed = objHelper.stats.speed / 10;
        this.Facing();
        originalLocalScale = transform.localScale;
        originalColor = spriteRenderer.color;
    }

    protected void Facing()
    {
        if (!dataHelper.facingRight)
        {
            transform.localScale = new Vector3(-MathF.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            dataHelper.facingRight = false;
        }
        else
        {
            transform.localScale = new Vector3(MathF.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            dataHelper.facingRight = true;
        }
    }

    protected void Timers()
    {
        waitFrame += Time.deltaTime % 60;
        if (waitFrame >= currentFrame.properties.wait)
        {
            this.ChangeFrame(currentFrame.properties.next);
        }
    }

    protected void ChangeFrame(int? nextFrame)
    {
        bool noInput = false;
        this.ChangeFrame(nextFrame, ref noInput);
    }

    protected void ChangeFrame(int? nextFrame, ref bool hitButton)
    {
        if (nextFrame.HasValue)
        {
            if (this.rigidbody)
            {
                rigidbody.constraints = RigidbodyConstraints.None;
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }
            hitButton = false;
            dataHelper.execOpointOneTimeInFrame = true;
            dataHelper.execImpulseForceOneTimeInFrame = true;
            dataHelper.execHealthManaPointsOneTimeInFrame = true;
            currentFrame = objHelper.frames[nextFrame.Value];
            spriteRenderer.sprite = objHelper.sprites.GetValueOrDefault(currentFrame.properties.pic, inv);
            waitFrame = 0f;

            // Debug.Log(currentFrame.id + "-" + currentFrame.properties.hitAttack);
        }
        else
        {
            if (currentFrame.properties.delete)
            {
                this.Delete();
            }
        }
    }

    protected void SpawnOpoint()
    {
        if (dataHelper.execOpointOneTimeInFrame && currentFrame.opoint != null && currentFrame.opoint.action != null && objHelper.opoints[currentFrame.id].Count > 0)
        {
            ObjProcess opoint = objHelper.opoints[currentFrame.id].Dequeue();
            opoint.dataHelper.summonAction = currentFrame.opoint.action;
            opoint.dataHelper.facingRight = dataHelper.facingRight && currentFrame.opoint.facingFront;

            if (currentFrame.opoint.useSamePalette)
            {
                opoint.paletteIndex = paletteIndex;
            }

            var xPos = 0f;
            var yPos = transform.position.y + opoint.dataHelper.originLocalPosition.y;
            var zPos = transform.position.z + opoint.dataHelper.originLocalPosition.z;
            
            if (dataHelper.facingRight)
            {
                xPos = transform.position.x + opoint.dataHelper.originLocalPosition.x;
            }
            else
            {
                xPos = transform.position.x - opoint.dataHelper.originLocalPosition.x;
            }

            opoint.transform.position = new Vector3(xPos, yPos, zPos);

            opoint.gameObject.SetActive(true);
            for (int i = 0; i < opoint.gameObject.transform.childCount; i++)
            {
                opoint.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
            opoint.Start();

            dataHelper.execOpointOneTimeInFrame = false;
        }
    }

    public void SpawnHitOpoint(Vector3 opointPosition, ItrEffectEnum effect)
    {
        switch (effect)
        {
            case ItrEffectEnum.NORMAL:
                SpawnHit(objHelper.opoints[hitNormalFrame].Dequeue(), opointPosition);
                break;
            case ItrEffectEnum.BLOOD:
                SpawnHit(objHelper.opoints[hitBloodFrame].Dequeue(), opointPosition);
                break;
            case ItrEffectEnum.DEFENSE:
                SpawnHit(objHelper.opoints[defenseHitFrame].Dequeue(), opointPosition);
                break;
            case ItrEffectEnum.SLOW:
            case ItrEffectEnum.STUN:
            case ItrEffectEnum.IGNITE:
            case ItrEffectEnum.POISON:
            case ItrEffectEnum.ROOT:
            case ItrEffectEnum.CHARM:
            case ItrEffectEnum.FEAR:
            case ItrEffectEnum.TAUNT:
            case ItrEffectEnum.BLIND:
            case ItrEffectEnum.PARALYSIS:
            case ItrEffectEnum.FREEZE:
            case ItrEffectEnum.CONFUSE:
            case ItrEffectEnum.SILENCE:
            case ItrEffectEnum.NO_EFFECT:
            default:
                break;
        }
    }

    private void SpawnHit(ObjProcess gameObj, Vector3 opointPosition)
    {
        gameObj.transform.position = opointPosition + new Vector3(0, 0f, -0.09f);
        gameObj.gameObject.SetActive(true);
        for (int i = 0; i < gameObj.transform.childCount; i++)
        {
            gameObj.transform.GetChild(i).gameObject.SetActive(true);
        }
        gameObj.Start();
    }

    protected void Delete()
    {
        
        transform.localScale = originalLocalScale;
        spriteRenderer.color = originalColor;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        if (dataHelper.ownerId == null)
        {
            dataHelper.originPool.Enqueue(this);
            gameObject.SetActive(false);
        }
        else
        {
            dataHelper.originPool.Enqueue(this);
            gameObject.SetActive(false);
        }
    }

    public void HitJump(InputAction.CallbackContext context)
    {
        HitJump(context.performed, context.started, context.canceled);
    }

    public void HitJump(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            dataHelper.hitJump = true;
        }
        else if (started)
        {
            dataHelper.hitJump = true;
        }
        else if (canceled)
        {
            dataHelper.hitJump = false;
        }
    }

    public void HitAttack(InputAction.CallbackContext context)
    {
        HitAttack(context.performed, context.started, context.canceled);
    }

    public void HitAttack(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            dataHelper.hitAttack = true;
        }
        else if (started)
        {
            dataHelper.hitAttack = true;
        }
        else if (canceled)
        {
            dataHelper.hitAttack = false;
        }
    }

    public void HitPower(InputAction.CallbackContext context)
    {
        HitPower(context.performed, context.started, context.canceled);
    }

    public void HitPower(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            dataHelper.hitPower = true;
        }
        else if (started)
        {
            dataHelper.hitPower = true;
        }
        else if (canceled)
        {
            dataHelper.hitPower = false;
        }
    }

    public void HitDefense(InputAction.CallbackContext context)
    {
        HitDefense(context.performed, context.started, context.canceled);
    }

    public void HitDefense(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            dataHelper.hitDefense = true;
            dataHelper.holdDefenseAfter = true;
        }
        else if (started)
        {
            dataHelper.hitDefense = true;
            dataHelper.holdDefenseAfter = true;
        }
        else if (canceled)
        {
            dataHelper.hitDefense = false;
            dataHelper.holdDefenseAfter = false;
        }
    }

    public void HitUp(InputAction.CallbackContext context)
    {
        HitUp(context.performed, context.started, context.canceled);
    }

    public void HitUp(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            dataHelper.hitUp = true;
        }
        else if (started)
        {
            dataHelper.hitUp = true;
        }
        else if (canceled)
        {
            dataHelper.hitUp = false;
        }
    }

    public void HitDown(InputAction.CallbackContext context)
    {
        HitDown(context.performed, context.started, context.canceled);
    }

    public void HitDown(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            dataHelper.hitDown = true;
        }
        else if (started)
        {
            dataHelper.hitDown = true;
        }
        else if (canceled)
        {
            dataHelper.hitDown = false;
        }
    }

    public void HitLeft(InputAction.CallbackContext context)
    {
        HitLeft(context.performed, context.started, context.canceled);
    }

    public void HitLeft(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            dataHelper.hitLeft = true;
            dataHelper.holdForwardAfter = true;
            dataHelper.releaseHitLeft = false;
        }
        else if (started)
        {
            dataHelper.hitLeft = true;
            dataHelper.releaseHitLeft = false;
            dataHelper.startedHitLeft = true;
        }
        else if (canceled)
        {
            dataHelper.hitLeft = false;
            dataHelper.holdForwardAfter = false;
            dataHelper.releaseHitLeft = true;
            dataHelper.startedHitLeft = false;
        }
    }

    public void HitRight(InputAction.CallbackContext context)
    {
        HitRight(context.performed, context.started, context.canceled);
    }

    public void HitRight(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            dataHelper.hitRight = true;
            dataHelper.holdForwardAfter = true;
            dataHelper.releaseHitRight = false;
        }
        else if (started)
        {
            dataHelper.hitRight = true;
            dataHelper.startedHitRight = true;
            dataHelper.releaseHitRight = false;
        }
        else if (canceled)
        {
            dataHelper.hitRight = false;
            dataHelper.holdForwardAfter = false;
            dataHelper.releaseHitRight = true;
            dataHelper.startedHitRight = false;
        }
    }
}
