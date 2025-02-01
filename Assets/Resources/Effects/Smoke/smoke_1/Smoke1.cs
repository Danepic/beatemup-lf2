using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using AYellowpaper.SerializedCollections;
using Chars;
using Domains;
using Enums;
using UnityEngine;
using UnityEngine.InputSystem;

public class Smoke1 : EffectController
{
    void Awake()
    {
        base.Awake();
        headerName = "Smoke 1";
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
        wait = 0.5f;
        next = Invoke_1;
    }

    private void Invoke_1()
    {
        pic = 101;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_2;
    }

    private void Invoke_2()
    {
        pic = 102;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_3;
    }

    private void Invoke_3()
    {
        pic = 103;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_4;
    }

    private void Invoke_4()
    {
        pic = 104;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
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
        pic = 117;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_18;
    }

    private void Invoke_18()
    {
        pic = 118;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_19;
    }

    private void Invoke_19()
    {
        pic = 119;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_20;
    }

    private void Invoke_20()
    {
        pic = 120;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_21;
    }

    private void Invoke_21()
    {
        Delete();
    }


    private void InvokeSmall_40()
    {
        pic = 200;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_41;
    }

    private void InvokeSmall_41()
    {
        pic = 201;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_42;
    }

    private void InvokeSmall_42()
    {
        pic = 202;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_43;
    }

    private void InvokeSmall_43()
    {
        pic = 203;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_44;
    }

    private void InvokeSmall_44()
    {
        pic = 204;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_45;
    }

    private void InvokeSmall_45()
    {
        pic = 205;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_46;
    }

    private void InvokeSmall_46()
    {
        pic = 206;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_47;
    }

    private void InvokeSmall_47()
    {
        pic = 207;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_48;
    }

    private void InvokeSmall_48()
    {
        pic = 208;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_49;
    }

    private void InvokeSmall_49()
    {
        pic = 209;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_50;
    }

    private void InvokeSmall_50()
    {
        pic = 210;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_51;
    }

    private void InvokeSmall_51()
    {
        pic = 211;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_52;
    }

    private void InvokeSmall_52()
    {
        pic = 212;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_53;
    }

    private void InvokeSmall_53()
    {
        pic = 213;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_54;
    }

    private void InvokeSmall_54()
    {
        pic = 214;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_55;
    }

    private void InvokeSmall_55()
    {
        pic = 215;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_56;
    }

    private void InvokeSmall_56()
    {
        pic = 216;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_57;
    }

    private void InvokeSmall_57()
    {
        pic = 217;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_58;
    }

    private void InvokeSmall_58()
    {
        pic = 218;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_59;
    }

    private void InvokeSmall_59()
    {
        pic = 219;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = InvokeSmall_60;
    }

    private void InvokeSmall_60()
    {
        pic = 220;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_21;
    }
}
