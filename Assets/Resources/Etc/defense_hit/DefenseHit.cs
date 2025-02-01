using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using AYellowpaper.SerializedCollections;
using Chars;
using Domains;
using Enums;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefenseHit : EffectController
{
    void Awake()
    {
        base.Awake();
        headerName = "Defense Hit";
        type = ObjTypeEnum.ETC;
    }

    public void Start()
    {
        ChangeFrame(Invoke_0);
        base.Start();
    }

    private void Invoke_0()
    {
        pic = 100;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_1;
    }

    private void Invoke_1()
    {
        pic = 101;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_2;
    }

    private void Invoke_2()
    {
        pic = 102;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_3;
    }

    private void Invoke_3()
    {
        pic = 103;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_4;
    }

    private void Invoke_4()
    {
        pic = 104;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_5;
    }

    private void Invoke_5()
    {
        Delete();
    }
}
