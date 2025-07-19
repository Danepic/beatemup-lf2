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

public class KamuiTarget : AttackController
{
    public static string KAMUI_SUCTION_OPOINT = "kamui_suction";
    public static string KAMUI_ATTACK_OPOINT = "kamui_attack";
    
    private Transform enemyTarget;
    void Awake()
    {
        palettes.Add("Attacks/Techs/sharingan/kamui/target/sprites");
        base.Awake();
        headerName = "Kamui Target";
        totalHp = -1;
        frames = PopulateFrames(this);
        opoints.Add(KAMUI_SUCTION_OPOINT, EnrichOpoint(1, "Attacks/Techs/sharingan/kamui/suction/kamui-suction"));
        opoints.Add(KAMUI_ATTACK_OPOINT, EnrichOpoint(1, "Attacks/Techs/sharingan/kamui/attack/kamui-attack"));
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
        enemyTarget = FindNearestEnemy()?.transform;
    }

    public void Update()
    {
        base.Update();
    }

    #region Idle
    private void Invoke_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 100; wait = 1f; next = Invoke_1;
        BdyDefault();
        ItrDisable();
        repeatCount = 250;
        SpawnOpoint(KAMUI_SUCTION_OPOINT, Opoint(x: 0f, y: 0.166f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: true, attachToOwner: true));
    }
    private void Invoke_1()
    {
        RepeatCountToFrame(Remove_300);
        pic = 101; wait = 1; next = Invoke_2;
        BdyDefault();
        FollowTargetPhysic(enemyTarget, 3f, 1.5f, 3f);
    }

    private void Invoke_2()
    {
        pic = 102; wait = 1; next = Invoke_3;
        BdyDefault();
        FollowTargetPhysic(enemyTarget, 3f, 1.5f, 3f);
    }
    private void Invoke_3()
    {
        pic = 103; wait = 1; next = Invoke_4;
        BdyDefault();
        FollowTargetPhysic(enemyTarget, 3f, 1.5f, 3f);
    }
    private void Invoke_4()
    {
        pic = 104; wait = 1; next = Invoke_5;
        BdyDefault();
        FollowTargetPhysic(enemyTarget, 3f, 1.5f, 3f);
    }
    private void Invoke_5()
    {
        pic = 105; wait = 1; next = Invoke_6;
        BdyDefault();
        FollowTargetPhysic(enemyTarget, 3f, 1.5f, 3f);
    }
    private void Invoke_6()
    {
        pic = 106; wait = 1; next = Invoke_7;
        BdyDefault();
        FollowTargetPhysic(enemyTarget, 3f, 1.5f, 3f);
    }
    private void Invoke_7()
    {
        pic = 107; wait = 1; next = Invoke_8;
        BdyDefault();
        FollowTargetPhysic(enemyTarget, 3f, 1.5f, 3f);
    }
    private void Invoke_8()
    {
        pic = 108; wait = 1; next = Invoke_9;
        BdyDefault();
        FollowTargetPhysic(enemyTarget, 3f, 1.5f, 3f);
    }
    private void Invoke_9()
    {
        pic = 109; wait = 1; next = Invoke_1;
        BdyDefault();
        FollowTargetPhysic(enemyTarget, 3f, 1.5f, 3f);
    }
    #endregion


    #region Attack
    private void Attack_50()
    {
        pic = -9999; wait = 1f; next = Remove_300;
        BdyDefault();
        ItrDisable();
        SpawnOpoint(KAMUI_ATTACK_OPOINT, Opoint(x: 0f, y: 0.216f, z: 0f, oid: 0, facingFront: true, quantity: 1));
    }
    #endregion


    #region Remove
    private void Remove_300()
    {
        CancelOpoints();
        ItrDisable();
        Delete();
    }
    #endregion
}
