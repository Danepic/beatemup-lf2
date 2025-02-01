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

public class JumpingRecover : EffectController
{
    void Awake()
    {
        base.Awake();
        headerName = "Jumping Recover";
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
        pic = 100; wait = 3f; next = Invoke_1;
        ScaleDown(propScalex: 0.1f, propScaley: 0.1f);
        Fadeout(fadeout: 0.1f);
    }

    private void Invoke_1()
    {
        Delete();
    }
}
