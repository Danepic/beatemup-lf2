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

public class UltimateMugshot : EffectController
{
    private bool useInvSprite = false;

    void Awake()
    {
        palettes.Add("Etc/ultimate_mugshot/sprites");
        base.Awake();
        headerName = "Ultimate Mugshot";
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

    #region NsKakashiBase
    private void NsKakashiBase_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        pic = 100;
        wait = 8f; next = Remove_300;
    }
    #endregion

    #region Remove
    private void Remove_300()
    {
        Delete();
    }
    #endregion
}
