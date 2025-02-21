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

public class NsNarutoCloneAttack : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Clones/ns-naruto-clone-attack/sprites");
        base.Awake();
        headerName = "NS Naruto Clone Attack";
        totalHp = 150;
        frames = PopulateFrames(this);
        opoints.Add(0, EnrichOpoint(3, "Effects/Smoke/smoke_1/smoke_1"));
    }

    public void Start()
    {
        ChangeFrame(UppercutInvoke_0);
        base.Start();
    }

    private void UppercutInvoke_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        ItrReset();
        pic = -9999;
        wait = 0.5f;
        next = Uppercut_1;
        BdyDefault();
        ItrDisable();
        SpawnOpoint(0, Opoint(x: 0, y: 0, z: 0.04f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Uppercut_1()
    {
        pic = 400;
        wait = 0.5f;
        next = Uppercut_2;
        BdyDefault();
    }
    private void Uppercut_2()
    {
        pic = 401;
        wait = 0.5f;
        next = Uppercut_3;
        BdyDefault();
    }
    private void Uppercut_3()
    {
        pic = 402;
        wait = 0.5f;
        next = Uppercut_4;
        BdyDefault();
    }

    private void Uppercut_4()
    {
        pic = 403;
        wait = 1f;
        next = Uppercut_5;
        BdyDefault();
    }
    private void Uppercut_5()
    {
        pic = 404;
        wait = 4f;
        next = Uppercut_6;
        BdyDefault();
        itr.x = 0.0654f; itr.y = 0.5173f; itr.z = 0;
        itr.w = 0.1757669f; itr.h = 0.5957753f; itr.zwidth = 0.22f;
        itr.dvx = -10; itr.dvy = 325; itr.dvz = 0; itr.action = 840;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 6; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault();
        ApplyDefaultPhysic(dvx: 25, dvy: 300, dvz: 0, facingRight);
    }
    private void Uppercut_6()
    {
        ItrDisable();
        pic = 405;
        wait = 10f;
        next = Remove_300; OnGround(Remove_300);
        BdyDefault();
    }

    private void DownercutInvoke_20()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        wait = 2f;
        next = Downercut_21;
        BdyDefault();
        ItrDisable();
        SpawnOpoint(0, Opoint(x: 0, y: 0, z: 0.04f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Downercut_21()
    {
        pic = 136; wait = 1; next = Downercut_22;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 200, dvy: 150, null, facingRight);
    }
    private void Downercut_22()
    {
        pic = 406; wait = 0.5f; next = Downercut_23;
        BdyDefault();
    }
    private void Downercut_23()
    {
        pic = 407; wait = 0.5f; next = Downercut_24;
        BdyDefault();
    }
    private void Downercut_24()
    {
        pic = 408; wait = 0.5f; next = Downercut_25;
        BdyDefault();
    }
    private void Downercut_25()
    {
        pic = 409; wait = 1; next = Downercut_26;
        BdyDefault();
        itr.x = 0.1273f; itr.y = 0.3239f; itr.z = 0;
        itr.w = 0.2994343f; itr.h = 0.6465725f; itr.zwidth = 0.22f;
        itr.dvx = 50; itr.dvy = 0; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault();
    }
    private void Downercut_26()
    {
        pic = 410; wait = 15; next = Remove_300; OnGround(Remove_300);
        BdyDefault();
        itr.x = 0.1273f; itr.y = 0.3239f; itr.z = 0;
        itr.w = 0.2994343f; itr.h = 0.6465725f; itr.zwidth = 0.22f;
        itr.dvx = 50; itr.dvy = 0; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault();
    }

    private void FrontAttackInvoke_40()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        wait = 2f;
        next = FrontAttack_41;
        BdyDefault();
        ItrDisable();
        SpawnOpoint(0, Opoint(x: 0, y: 0, z: 0.04f, oid: 0, facingFront: true, quantity: 1));
    }
    private void FrontAttack_41()
    {
        pic = 136; wait = 2; next = FrontAttack_42;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 200, dvy: 150, null, facingRight);
    }
    private void FrontAttack_42()
    {
        pic = 411; wait = 1; next = FrontAttack_43;
        BdyDefault();
    }
    private void FrontAttack_43()
    {
        pic = 412; wait = 1; next = FrontAttack_44;
        BdyDefault();
        itr.x = 0.1292f; itr.y = 0.2191f; itr.z = 0;
        itr.w = 0.3942767f; itr.h = 0.3500794f; itr.zwidth = 0.22f;
        itr.dvx = 300; itr.dvy = 150; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault();
    }
    private void FrontAttack_44()
    {
        pic = 413; wait = 10; next = FrontAttack_45;
        BdyDefault();
        itr.x = 0.1292f; itr.y = 0.2191f; itr.z = 0;
        itr.w = 0.3942767f; itr.h = 0.3500794f; itr.zwidth = 0.22f;
        itr.dvx = 300; itr.dvy = 150; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault();
    }
    private void FrontAttack_45()
    {
        ItrDisable();
        pic = 414; wait = 1; next = FrontAttack_46;
        BdyDefault();
    }
    private void FrontAttack_46()
    {
        pic = 415; wait = 5; next = Remove_300; OnGround(Remove_300);
        BdyDefault();
    }

    private void Remove_300()
    {
        ItrDisable();
        SpawnOpoint(0, Opoint(x: 0, y: 0, z: 0.04f, oid: 0, facingFront: true, quantity: 1));
        Delete();
    }
}
