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

public class FireGround : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/fire/ground/sprites");
        base.Awake();
        headerName = "Fire Ground";
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
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        pic = 108;
        wait = 1f;
        next = Invoke_1;
        BdyDefault();
        ItrDisable();
        repeatCount = 300;
    }
    private void Invoke_1()
    {
        RepeatCountToFrame(Remove_300);
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 101; wait = 1; next = Invoke_2;
        BdyDefault();
    }
    private void Invoke_2()
    {
        RepeatCountToFrame(Remove_300);
        pic = 102; wait = 1f; next = Invoke_3;
        BdyDefault();
    }
    private void Invoke_3()
    {
        RepeatCountToFrame(Remove_300);
        pic = 103; wait = 1f; next = Invoke_4;
        BdyDefault();
    }
    private void Invoke_4()
    {
        RepeatCountToFrame(Remove_300);
        pic = 104; wait = 1f; next = Invoke_5;
        BdyDefault();
    }
    private void Invoke_5()
    {
        RepeatCountToFrame(Remove_300);
        pic = 105; wait = 1f; next = Invoke_6;
        BdyDefault();
    }
    private void Invoke_6()
    {
        RepeatCountToFrame(Remove_300);
        pic = 106; wait = 1f; next = Invoke_7;
        BdyDefault();
    }
    private void Invoke_7()
    {
        RepeatCountToFrame(Remove_300);
        pic = 107; wait = 1f; next = Invoke_8;
        BdyDefault();
    }  
    private void Invoke_8()
    {
        RepeatCountToFrame(Remove_300);
        pic = 100; wait = 1f; next = Invoke_1;
        BdyDefault();
    }  
    #endregion

    #region Remove
    private void Remove_300()
    {
        pic = 108; wait = 1f;
        Delete();
    }
    #endregion
}
