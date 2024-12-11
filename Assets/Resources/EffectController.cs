using Enums;
using Helpers;
using UnityEngine;
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using System.Linq;
using Domains;
using Chars;
using UnityEngine.InputSystem;

public class EffectController : ObjController
{
    protected string headerName;
    protected void Awake()
    {
        type = ObjTypeEnum.EFFECT;
        base.Awake();
    }

    void Update()
    {
        base.Update();
        Timers();
    }
}