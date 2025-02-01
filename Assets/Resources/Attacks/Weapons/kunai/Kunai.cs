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

public class Kunai : AttackController
{
    void Awake()
    {
        base.Awake();
        headerName = "Kunai";
        totalHp = 175;
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        ChangeFrame(InvokeFront_0);
        base.Start();
    }

    public void Update() {
        base.Update();
    }

    #region Front
    private void InvokeFront_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 0.5f;
        next = InvokeImpulse_1;
        BdyDefault();
        ItrDisable();
    }
    private void InvokeImpulse_1()
    {
        pic = 100; dvx = 425; dvy = 125; dvz = 0;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeImpulse_2;
        BdyDefault();
        OnGround(Remove_300);
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    private void InvokeImpulse_2()
    {
        pic = 100;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 10f;
        next = InvokeImpulse_3;
        BdyDefault();
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
        wait = 5f;
        next = InvokeImpulse_4;
        BdyDefault();
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        ItrDefault();
        OnGround(Remove_300);
    }
    private void InvokeImpulse_4()
    {
        pic = 102;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeImpulse_4;
        BdyDefault();
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
        pic = -9999;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 0.5f;
        next = InvokeDown_21;
        BdyDefault();
        ItrDisable();
    }
    private void InvokeDown_21()
    {
        pic = 103; dvx = 300; dvy = -25; dvz = 0;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeDown_22;
        BdyDefault();
        OnGround(Remove_300);
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    private void InvokeDown_22()
    {
        pic = 103;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeDown_23;
        BdyDefault();
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        ItrDefault();
        OnGround(Remove_300);
    }
    private void InvokeDown_23()
    {
        pic = 103;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeDown_22;
        BdyDefault();
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
