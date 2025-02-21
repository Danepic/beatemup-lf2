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
using UnityEngine.UIElements;

public class ImpactDown : EffectController
{
    void Awake()
    {
        palettes.Add("Etc/impact_down/sprites");
        base.Awake();
        headerName = "Impact Down";
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
        pic = 115; wait = 1f; next = Invoke_1;
    }

    private void Invoke_1()
    {
        pic = 104; wait = 1f; next = Invoke_2;
    }

    private void Invoke_2()
    {
        pic = 100; wait = 1f; next = Invoke_3;
    }

    private void Invoke_3()
    {
        pic = 101; wait = 1f; next = Invoke_4;
    }

    private void Invoke_4()
    {
        pic = 102; wait = 1f; next = Invoke_5;
    }

    private void Invoke_5()
    {
        pic = 103; wait = 0.5f; next = Invoke_6;
    }
    private void Invoke_6()
    {
        pic = 105; wait = 0.5f; next = Invoke_7;
    }

    private void Invoke_7()
    {
        Delete();
    }
}
