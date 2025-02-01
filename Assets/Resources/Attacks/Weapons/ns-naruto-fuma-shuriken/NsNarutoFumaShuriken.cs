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

public class NsNarutoFumaShuriken : AttackController
{
    void Awake()
    {
        base.Awake();
        headerName = "NS Naruto Fūma Shuriken";
        totalHp = 350;
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        ChangeFrame(InvokeFront_0);
        base.Start();
    }

    #region Front
    private void InvokeFront_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 200;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 2f;
        next = InvokeImpulse_1;
        BdyDefault();
        ItrDisable();
    }
    private void InvokeImpulse_1()
    {
        pic = 101; dvx = 425; dvy = 175; dvz = 0;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeImpulse_2;
        bdy.x = 0.0266f; bdy.y = 0.1758f; bdy.z = 0f;
        bdy.w = 0.6639989f; bdy.h = 0.2523443f; bdy.zwidth = 0.22f;
        Bdy();
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    private void InvokeImpulse_2()
    {
        pic = 102;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeImpulse_3;
        bdy.x = 0.0266f; bdy.y = 0.1758f; bdy.z = 0f;
        bdy.w = 0.6639989f; bdy.h = 0.2523443f; bdy.zwidth = 0.22f;
        Bdy();
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        ItrDefault();
        OnGround(Remove_300);
    }
    private void InvokeImpulse_3()
    {
        pic = 101;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeImpulse_2;
        bdy.x = 0.0266f; bdy.y = 0.1758f; bdy.z = 0f;
        bdy.w = 0.6639989f; bdy.h = 0.2523443f; bdy.zwidth = 0.22f;
        Bdy();
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        ItrDefault();
        OnGround(Remove_300);
    }
    #endregion

    #region Down
    private void InvokeDown_20()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 200;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 2f;
        next = InvokeDown_21;
        BdyDefault();
        ItrDisable();
    }
    private void InvokeDown_21()
    {
        pic = 101; dvx = 300; dvy = -25; dvz = 0;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeDown_22;
        BdyDefault();
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    private void InvokeDown_22()
    {
        pic = 102;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeDown_23;
        bdy.x = 0.0266f; bdy.y = 0.1758f; bdy.z = 0f;
        bdy.w = 0.6639989f; bdy.h = 0.2523443f; bdy.zwidth = 0.22f;
        Bdy();
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        ItrDefault();
        OnGround(Remove_300);
    }
    private void InvokeDown_23()
    {
        pic = 101;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeDown_22;
        bdy.x = 0.0266f; bdy.y = 0.1758f; bdy.z = 0f;
        bdy.w = 0.6639989f; bdy.h = 0.2523443f; bdy.zwidth = 0.22f;
        Bdy();
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        ItrDefault();
        OnGround(Remove_300);
    }
    #endregion

    private void Remove_300()
    {
        ItrDisable();
        Delete();
    }
}
