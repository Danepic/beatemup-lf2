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

public class GroundNormal : EffectController
{
    void Awake()
    {
        palettes.Add("Effects/ground/normal/normal/sprites");
        base.Awake();
        headerName = "Ground Normal";
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
        pic = 105;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_6;
    }

    private void Invoke_6()
    {
        pic = 106;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_7;
    }

    private void Invoke_7()
    {
        pic = 107;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_8;
    }

    private void Invoke_8()
    {
        pic = 108;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Invoke_9;
    }

    private void Invoke_9()
    {
        pic = 109;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Remove_300;
    }

    private void Remove_300()
    {
        Delete();
    }
}
