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

public class FirePrepare : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/fire/prepare/sprites");
        base.Awake();
        headerName = "Fire Prepare";
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
        pic = 100;
        wait = 1f;
        next = Invoke_1;
        BdyDefault();
        ItrDisable();
    }
    private void Invoke_1()
    {
        pic = 101; wait = 1; next = Invoke_2;
        BdyDefault();
    }
    private void Invoke_2()
    {
        pic = 102; wait = 1f; next = Invoke_3;
        BdyDefault();
    }
    private void Invoke_3()
    {
        pic = 103; wait = 1f; next = Invoke_4;
        BdyDefault();
    }
    private void Invoke_4()
    {
        pic = 104; wait = 1f; next = Invoke_5;
        BdyDefault();
    }
    private void Invoke_5()
    {
        pic = 105; wait = 1f; next = Invoke_6;
        BdyDefault();
    }
    private void Invoke_6()
    {
        pic = 106; wait = 1f; next = Invoke_7;
        BdyDefault();
    }
    private void Invoke_7()
    {
        pic = 107; wait = 1f; next = Invoke_8;
        BdyDefault();
    }
    private void Invoke_8()
    {
        pic = 108; wait = 1f; next = Invoke_9;
        BdyDefault();
    }
    private void Invoke_9()
    {
        pic = 109; wait = 1f; next = Remove_300;
        BdyDefault();
    }
    #endregion

    #region Remove
    private void Remove_300()
    {
        Delete();
    }
    #endregion
}
