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

public class ChakraChargeAura : EffectController
{
    void Awake()
    {
        palettes.Add("Etc/chakra_charge_aura/sprites");
        base.Awake();
        headerName = "Chakra Charge Aura";
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
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 117;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_1;
    }

    private void Invoke_1()
    {
        pic = 116;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_2;
    }

    private void Invoke_2()
    {
        pic = 114;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_3;
    }

    private void Invoke_3()
    {
        pic = 113;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_4;
    }

    private void Invoke_4()
    {
        pic = 112;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_5;
    }

    private void Invoke_5()
    {
        pic = 110;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_6;
    }

    private void Invoke_6()
    {
        pic = 107;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_7;
    }

    private void Invoke_7()
    {
        pic = 106;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_8;
    }

    private void Invoke_8()
    {
        pic = 103;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_9;
    }

    private void Invoke_9()
    {
        pic = 102;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_10;
    }

    private void Invoke_10()
    {
        pic = 101;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_11;
    }

    private void Invoke_11()
    {
        pic = 100;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 0.5f;
        next = Invoke_12;
    }

    private void Invoke_12()
    {
        Delete();
    }
}
