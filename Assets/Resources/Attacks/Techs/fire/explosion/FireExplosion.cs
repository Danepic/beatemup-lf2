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

public class FireExplosion : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/fire/explosion/sprites");
        base.Awake();
        headerName = "Fire Explosion";
        totalHp = -1;
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

    #region Idle
    private void Invoke_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        pic = 100;
        wait = 1f;
        next = Invoke_1;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
        ItrDisable();
        StopMovement();
    }
    private void Invoke_1()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 101; wait = 1; next = Invoke_2;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }
    private void Invoke_2()
    {
        pic = 102; wait = 1f; next = Invoke_3;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }
    private void Invoke_3()
    {
        pic = 103; wait = 1f; next = Invoke_4;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }
    private void Invoke_4()
    {
        pic = 104; wait = 1f; next = Invoke_5;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }
    private void Invoke_5()
    {
        pic = 105; wait = 1f; next = Invoke_6;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }
    private void Invoke_6()
    {
        pic = 106; wait = 1f; next = Invoke_7;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }
    private void Invoke_7()
    {
        pic = 107; wait = 1f; next = Invoke_8;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }  
    private void Invoke_8()
    {
        pic = 108; wait = 1f; next = Invoke_9;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }  
    private void Invoke_9()
    {
        pic = 109; wait = 1f; next = Invoke_10;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }  
    private void Invoke_10()
    {
        pic = 110; wait = 1f; next = Invoke_11;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }  
    private void Invoke_11()
    {
        pic = 111; wait = 1f; next = Invoke_12;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }
    private void Invoke_12()
    {
        pic = 112; wait = 1f; next = Invoke_13;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }
    private void Invoke_13()
    {
        pic = 113; wait = 1f; next = Remove_300;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }  
    #endregion

    #region Remove
    private void Remove_300()
    {
        Delete();
    }
    #endregion
}
