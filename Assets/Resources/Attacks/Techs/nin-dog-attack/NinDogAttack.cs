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

public class NinDogAttack : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/nin-dog-attack/sprites");
        base.Awake();
        headerName = "Ninja Dog Attack";
        totalHp = 150;
        frames = PopulateFrames(this);
        opoints.Add(0, EnrichOpoint(3, "Effects/Smoke/smoke_1/smoke_1"));
    }

    public void Start()
    {
        ChangeFrame(DownercutInvoke_0);
        base.Start();
    }

    private void DownercutInvoke_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        wait = 2f;
        next = Downercut_21;
        BdyDefault();
        ItrDisable();
        SpawnOpoint(0, Opoint(x: 0, y: 0, z: 0.04f, oid: 40, facingFront: true, quantity: 1));
    }
    private void Downercut_21()
    {
        pic = 100; wait = 1; next = Downercut_22;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 200, dvy: 200, null, facingRight);
    }
    private void Downercut_22()
    {
        pic = 101; wait = 0.5f; next = Downercut_23;
        BdyDefault();
    }
    private void Downercut_23()
    {
        pic = 101; wait = 0.5f; next = Downercut_24;
        BdyDefault();
    }
    private void Downercut_24()
    {
        pic = 101; wait = 0.5f; next = Downercut_25;
        BdyDefault();
    }
    private void Downercut_25()
    {
        pic = 102; wait = 1; next = Downercut_26;
        BdyDefault();
        itr.dvx = 50; itr.dvy = 0; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault(zwidth: 0.22f);
    }
    private void Downercut_26()
    {
        pic = 102; wait = 15; next = Remove_300; OnGround(Remove_300);
        BdyDefault();
        itr.x = 0.1273f; itr.y = 0.3239f; itr.z = 0;
        itr.w = 0.2994343f; itr.h = 0.6465725f; itr.zwidth = 0.22f;
        itr.dvx = 50; itr.dvy = 0; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault(zwidth: 0.22f);
    }

    private void Remove_300()
    {
        ItrDisable();
        SpawnOpoint(0, Opoint(x: 0, y: 0, z: 0.04f, oid: 40, facingFront: true, quantity: 1));
        Delete();
    }
}
