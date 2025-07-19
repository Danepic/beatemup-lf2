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

public class KamuiAttack : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/sharingan/kamui/attack/sprites");
        base.Awake();
        headerName = "Kamui Attack";
        totalHp = -1;
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    public void Update()
    {
        base.Update();
    }

    #region Idle
    private void Invoke_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 100; wait = 0.5f; next = Invoke_1;
        BdyDefault();
        ItrDisable();
    }
    private void Invoke_1()
    {
        pic = 101; wait = 0.5f; next = Invoke_2;
        BdyDefault();
        itr.x = 0; itr.y = 0.715f; itr.z = 0;
        itr.w = 1.25f; itr.h = 1.43f; itr.zwidth = 0.44f;
        itr.dvx = 10; itr.dvy = 10; itr.dvz = 0; itr.action = 950;
        itr.applyInSingleEnemy = false; itr.defensable = false; itr.level = 1; itr.injury = 550;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 20; itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
    }

    private void Invoke_2()
    {
        pic = 102; wait = 0.5f; next = Invoke_3;
        ItrDisable();
        BdyDefault();
    }
    private void Invoke_3()
    {
        pic = 103; wait = 0.5f; next = Invoke_4;
        BdyDefault();
    }
    private void Invoke_4()
    {
        pic = 104; wait = 0.5f; next = Invoke_5;
        BdyDefault();
    }
    private void Invoke_5()
    {
        pic = 105; wait = 0.5f; next = Invoke_6;
        BdyDefault();
    }
    private void Invoke_6()
    {
        pic = 106; wait = 0.5f; next = Invoke_7;
        BdyDefault();
    }
    private void Invoke_7()
    {
        pic = 107; wait = 0.5f; next = Invoke_8;
        BdyDefault();
    }
    private void Invoke_8()
    {
        pic = 108; wait = 0.5f; next = Invoke_9;
        BdyDefault();
    }
    private void Invoke_9()
    {
        pic = 109; wait = 0.5f; next = lastTargetHit != null ? Invoke_10 : Remove_300;
        BdyDefault();
    }
    private void Invoke_10()
    {
        pic = -9999; wait = 20f; next = Invoke_11;
        BdyDefault();
    }
    private void Invoke_11()
    {
        foreach (var physicsObjController in GetHittableCharacters())
        {
            physicsObjController.ChangeFrame(800);
        }
        hittableObjects.Clear();
        pic = 109; wait = 0.5f; next = Invoke_12;
        BdyDefault();
    }
    private void Invoke_12()
    {
        pic = 108; wait = 0.5f; next = Invoke_13;
        BdyDefault();
    }
    private void Invoke_13()
    {
        pic = 107; wait = 0.5f; next = Invoke_14;
        BdyDefault();
    }
    private void Invoke_14()
    {
        pic = 106; wait = 0.5f; next = Invoke_15;
        BdyDefault();
    }
    private void Invoke_15()
    {
        pic = 105; wait = 0.5f; next = Invoke_16;
        BdyDefault();
    }
    private void Invoke_16()
    {
        pic = 104; wait = 0.5f; next = Invoke_17;
        BdyDefault();
    }
    private void Invoke_17()
    {
        pic = 103; wait = 0.5f; next = Invoke_18;
        BdyDefault();
    }
    private void Invoke_18()
    {
        pic = 102; wait = 0.5f; next = Invoke_19;
        BdyDefault();
    }
    private void Invoke_19()
    {
        pic = 101; wait = 0.5f; next = Invoke_20;
        BdyDefault();
    }
    private void Invoke_20()
    {
        pic = 100; wait = 0.5f; next = Remove_300;
        BdyDefault();
    }
    #endregion

    #region Remove
    private void Remove_300()
    {
        ItrDisable();
        Delete();
    }
    #endregion
}
