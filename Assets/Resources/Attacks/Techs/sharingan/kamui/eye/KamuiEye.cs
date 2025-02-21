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

public class KamuiEye : EffectController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/sharingan/kamui/eye/sprites");
        base.Awake();
        headerName = "Kamui Eye";
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

    #region Invoke
    private void Invoke_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 100;
        wait = 0.5f; next = Invoke_1;
    }
    private void Invoke_1()
    {
        pic = 101;
        wait = 0.5f; next = Invoke_2;
    }
    private void Invoke_2()
    {
        pic = 102;
        wait = 9f; next = Invoke_3;
    }
    private void Invoke_3()
    {
        pic = 101;
        wait = 0.25f; next = Invoke_4;
    }
    private void Invoke_4()
    {
        pic = 100;
        wait = 0.25f; next = Remove_300;
    }
    #endregion

    #region Remove
    private void Remove_300()
    {
        Delete();
    }
    #endregion
}
