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

public class AttackSand1 : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/attack-1/sprites");
        base.Awake();
        headerName = "Attack Sand 1";
        totalHp = 500;
        frames = PopulateFrames(this);
        attackLevel1Frame = null;
        attackLevel2Frame = null;
        attackLevel3Frame = null;
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    #region Idle
    private void IdleInvoke_0()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 107;
        wait = 0.5f;
        next = IdleInvoke_1;
        ItrDisable();
        BdyDefault(zwidth: 0.22f);
    }
    private void IdleInvoke_1()
    {
        pic = 100; wait = 1; next = IdleInvoke_2;
        BdyDefault(zwidth: 0.22f);
    }
    private void IdleInvoke_2()
    {
        pic = 101; wait = 1f; next = IdleInvoke_3;
        BdyDefault(zwidth: 0.22f);
    }
    private void IdleInvoke_3()
    {
        pic = 102; wait = 1f; next = IdleInvoke_4;
        BdyDefault(zwidth: 0.22f);
        itr.dvx = 10; itr.dvy = 0; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 50;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 4; itr.physic = ItrPhysicEnum.FIXED;
        ItrDefault(zwidth: 0.22f);
    }
    private void IdleInvoke_4()
    {
        ItrDisable();
        pic = 104; wait = 1f; next = IdleInvoke_5;
        BdyDefault(zwidth: 0.22f);
    }
    private void IdleInvoke_5()
    {
        pic = 105; wait = 1f; next = IdleInvoke_6;
        BdyDefault(zwidth: 0.22f);
    }
    private void IdleInvoke_6()
    {
        pic = 106; wait = 1f; next = IdleInvoke_7;
        BdyDefault(zwidth: 0.22f);
    }
    private void IdleInvoke_7()
    {
        pic = 110; wait = 1f; next = Remove_300;
        BdyDefault(zwidth: 0.22f);
    }
    #endregion


    #region Remove
    private void Remove_300()
    {
        pic = -9999;
        ItrDisable();
        Delete();
    }
    #endregion
}
