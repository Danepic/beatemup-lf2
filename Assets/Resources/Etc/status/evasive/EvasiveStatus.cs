using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Chars;
using Domains;
using Enums;
using UnityEngine;
using UnityEngine.InputSystem;

public class EvasiveStatus : EffectController
{
    private Sprite originSprite;
    public BoxCollider selfBoxCollider;
    private bool useInvSprite = false;

    void Awake()
    {
        base.Awake();
        headerName = "Evasive Status";
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        originSprite = spriteRenderer.sprite;
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    public void Update()
    {
        if (owner.currentFrameId == 1100)
        {
            ChangeFrame(Remove_300);
        }
        base.Update();
    }

    #region KakashiFog
    private void KakashiFogInvoke_0()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
        pic = useInvSprite ? -9999 : 100;
        wait = 1f; next = KakashiFogInvoke_1; repeatCount = 100;
    }
    private void KakashiFogInvoke_1()
    {
        pic = useInvSprite ? -9999 : 100; wait = 15; next = KakashiFogInvoke_1; Fadein(0.05f); RepeatCountToFrame(KakashiFogInvoke_2);
        selfBoxCollider.center = new Vector3(-0.02f, -1.52f, 0);
        selfBoxCollider.size = new Vector3(4f, 2.284836f, 1.57f);
        Debug.Log(currentFrameId);
    }
    private void KakashiFogInvoke_2()
    {
        repeatCount = 100;
        pic = useInvSprite ? -9999 : 100; wait = 150; next = KakashiFogInvoke_3;
        selfBoxCollider.center = new Vector3(-0.02f, -1.52f, 0);
        selfBoxCollider.size = new Vector3(4f, 2.284836f, 1.57f);
    }
    private void KakashiFogInvoke_3()
    {
        pic = useInvSprite ? -9999 : 100; wait = 15; next = KakashiFogInvoke_3; Fadeout(0.05f); RepeatCountToFrame(KakashiFogInvoke_4);
        selfBoxCollider.center = new Vector3(-0.02f, -1.52f, 0);
        selfBoxCollider.size = new Vector3(4f, 2.284836f, 1.57f);
    }


    private void KakashiFogInvoke_4()
    {
        pic = useInvSprite ? -9999 : 100; wait = 2; next = Remove_300;
        selfBoxCollider.center = new Vector3(-0.02f, -1.52f, 0);
        selfBoxCollider.size = new Vector3(4f, 2.284836f, 1.57f);
    }
    #endregion

    #region Remove
    private void Remove_300()
    {
        if (owner != null) spriteRenderer.sprite = inv;
        Delete();
    }
    #endregion

    void OnTriggerEnter(Collider externObj)
    {
        if (owner != null && externObj.transform.parent?.gameObject == owner.gameObject)
        {
            useInvSprite = false;
        }
    }

    void OnTriggerExit(Collider externObj)
    {
        if (owner != null && externObj.transform.parent?.gameObject == owner.gameObject)
        {
            useInvSprite = true;
        }
    }
}
