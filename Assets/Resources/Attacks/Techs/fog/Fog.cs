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

public class Fog : AttackController
{
    private PhysicsObjController ownerPhysics;
    void Awake()
    {
        base.Awake();
        headerName = "Fog";
        totalHp = -1;
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        if (owner != null)
        {
            ownerPhysics = owner.GetComponent<PhysicsObjController>();
        }
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

    #region Idle
    private void IdleInvoke_0()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
        pic = 100; wait = 1f; next = IdleInvoke_1; repeatCount = 100;
        ItrDisable();
        hurtbox.gameObject.SetActive(false);
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void IdleInvoke_1()
    {
        pic = 100; wait = 15; next = IdleInvoke_1; Fadein(0.05f); RepeatCountToFrame(IdleInvoke_2);
        selfBoxCollider.center = new Vector3(-0.2124f, 0.8118f, 0);
        selfBoxCollider.size = new Vector3(3.950983f, 2.284836f, 1.57f);
    }
    private void IdleInvoke_2()
    {
        repeatCount = 100;
        pic = 100; wait = 150; next = IdleInvoke_3;
        selfBoxCollider.center = new Vector3(-0.2124f, 0.8118f, 0);
        selfBoxCollider.size = new Vector3(3.950983f, 2.284836f, 1.57f);
    }
    private void IdleInvoke_3()
    {
        pic = 100; wait = 15; next = IdleInvoke_3; Fadeout(0.05f); RepeatCountToFrame(IdleInvoke_4);
        selfBoxCollider.center = new Vector3(-0.2124f, 0.8118f, 0);
        selfBoxCollider.size = new Vector3(3.950983f, 2.284836f, 1.57f);
    }


    private void IdleInvoke_4()
    {
        pic = 100; wait = 2; next = Remove_300;
        selfBoxCollider.center = new Vector3(-0.2124f, 0.8118f, 0);
        selfBoxCollider.size = new Vector3(3.950983f, 2.284836f, 1.57f);
    }
    #endregion

    #region Remove
    private void Remove_300()
    {
        if (ownerPhysics != null) ownerPhysics.hittablePercent = 100;
        Delete();
    }
    #endregion

    void OnTriggerEnter(Collider externObj)
    {
        if (ownerPhysics != null && externObj.transform.parent?.gameObject == owner.gameObject)
        {
            ownerPhysics.hittablePercent = 25;
        }
    }

    void OnTriggerExit(Collider externObj)
    {
        if (ownerPhysics != null && externObj.transform.parent?.gameObject == owner.gameObject)
        {
            ownerPhysics.hittablePercent = 100;
        }
    }
}
