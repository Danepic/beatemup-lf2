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

public class GroundExtraLarge : EffectController
{
    void Awake()
    {
        base.Awake();
        headerName = "Ground Extra Large";
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        ChangeFrame(InvokeSmoke_0);
        base.Start();
    }

    #region Smoke
    private void InvokeSmoke_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 100;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeSmoke_1;
    }

    private void InvokeSmoke_1()
    {
        pic = 101;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeSmoke_2;
    }

    private void InvokeSmoke_2()
    {
        pic = 102;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeSmoke_3;
    }

    private void InvokeSmoke_3()
    {
        pic = 103;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeSmoke_4;
    }

    private void InvokeSmoke_4()
    {
        pic = 104;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeSmoke_5;
    }

    private void InvokeSmoke_5()
    {
        pic = 105;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeSmoke_6;
    }

    private void InvokeSmoke_6()
    {
        pic = 106;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeSmoke_7;
    }

    private void InvokeSmoke_7()
    {
        pic = 107;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeSmoke_8;
    }

    private void InvokeSmoke_8()
    {
        pic = 108;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Remove_300;
    }
    #endregion


    #region Impact
    private void InvokeImpact_50()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 200;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeImpact_51;
    }

    private void InvokeImpact_51()
    {
        pic = 201;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeImpact_52;
    }

    private void InvokeImpact_52()
    {
        pic = 202;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeImpact_53;
    }

    private void InvokeImpact_53()
    {
        pic = 203;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeImpact_54;
    }

    private void InvokeImpact_54()
    {
        pic = 204;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeImpact_55;
    }

    private void InvokeImpact_55()
    {
        pic = 205;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeImpact_56;
    }

    private void InvokeImpact_56()
    {
        pic = 206;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = InvokeImpact_57;
    }

    private void InvokeImpact_57()
    {
        pic = 207;
        state = StateFrameEnum.EFFECT_IDLE;
        wait = 1f;
        next = Remove_300;
    }

    #endregion


    private void Remove_300()
    {
        Delete();
    }
}
