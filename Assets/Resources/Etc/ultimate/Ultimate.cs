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

public class Ultimate : EffectController
{
    void Awake()
    {
        palettes.Add("Etc/ultimate/sprites");
        base.Awake();
        headerName = "Ultimate Effect";
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

    #region UltimateInit
    private void UltimateInit_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 101;
        wait = 1f; next = UltimateInit_1;
    }
    private void UltimateInit_1()
    {
        pic = 100;
        wait = 1f; next = UltimateInit_2;
    }
    private void UltimateInit_2()
    {
        pic = 103;
        wait = 1f; next = UltimateInit_3;
    }
    private void UltimateInit_3()
    {
        pic = 102;
        wait = 1f; next = Remove_300;
    }

    #endregion

    #region Remove
    private void Remove_300()
    {
        Delete();
    }
    #endregion
}
