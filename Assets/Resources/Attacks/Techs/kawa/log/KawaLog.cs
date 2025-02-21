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

public class KawaLog : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/kawa/log/sprites");
        base.Awake();
        headerName = "Kawa Log";
        totalHp = -1;
        frames = PopulateFrames(this);
        opoints.Add(50, EnrichOpoint(1, "Effects/smoke/smoke_1/smoke_1"));
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
        pic = -9999; wait = 1f; next = Invoke_1;
        BdyDefault();
        ItrDisable();
        SpawnOpoint(50, Opoint(x: 0, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: false, attachToOwner: false));
    }
    private void Invoke_1()
    {
        pic = 100; wait = 1; next = Invoke_1;
        BdyDefault(); OnGround(InvokeGround_5);
    }

    private void InvokeGround_5()
    {
        pic = 101; wait = 1; next = InvokeGround_6;
        BdyDefault();
        ApplyDefaultPhysic(dvx = 0, dvy = 20, dvz = 0, facingRight);
    }
    private void InvokeGround_6()
    {
        repeatCount = 75;
        pic = 101; wait = 1; next = InvokeGround_6;
        BdyDefault(); OnGround(InvokeGround_7);
    }
    private void InvokeGround_7()
    {
        RepeatCountToFrame(Remove_300); Fadeout(0.05f);
        pic = 101; wait = 1; next = InvokeGround_7;
        BdyDefault();
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
