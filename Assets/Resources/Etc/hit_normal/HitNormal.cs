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

public class HitNormal : EffectController
{
    void Awake()
    {
        base.Awake();
        headerName = "Hit Normal";
        type = ObjTypeEnum.ETC;
        frames = PopulateFrames(this);
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
        wait = 0.25f;
        next = Invoke_1;
    }

    private void Invoke_1()
    {
        pic = 101;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.25f;
        next = Invoke_2;
    }

    private void Invoke_2()
    {
        pic = 102;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.25f;
        next = Invoke_3;
    }

    private void Invoke_3()
    {
        pic = 103;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.25f;
        next = Invoke_4;
    }

    private void Invoke_4()
    {
        pic = 104;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.25f;
        next = Invoke_5;
    }

    private void Invoke_5()
    {
        pic = 105;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_6;
    }

    private void Invoke_6()
    {
        pic = 106;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_7;
    }

    private void Invoke_7()
    {
        pic = 107;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_8;
    }

    private void Invoke_8()
    {
        pic = 108;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_9;
    }

    private void Invoke_9()
    {
        pic = 109;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_10;
    }

    private void Invoke_10()
    {
        pic = 110;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_11;
    }

    private void Invoke_11()
    {
        pic = 111;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_12;
    }

    private void Invoke_12()
    {
        pic = 112;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_13;
    }

    private void Invoke_13()
    {
        pic = 113;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_14;
    }

    private void Invoke_14()
    {
        pic = 114;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_15;
    }

    private void Invoke_15()
    {
        pic = 115;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_16;
    }

    private void Invoke_16()
    {
        pic = 116;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_17;
    }

    private void Invoke_17()
    {
        Delete();
    }
}
