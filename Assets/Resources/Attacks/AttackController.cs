using Enums;
using UnityEngine;
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using System.Linq;
using Domains;
using Chars;
using UnityEngine.InputSystem;

public class AttackController : PhysicsObjController
{
    protected string headerName;
    protected void Awake()
    {
        type = ObjTypeEnum.ATTACK;
        base.Awake();
        // opoints.Add(4, EnrichOpoint(10, "Etc/hit_normal/hit_normal"));
        // opoints.Add(5, EnrichOpoint(10, "Etc/hit_blood/hit_blood"));
    }

    public void Start()
    {
        originalLocalScale = transform.localScale;
        originalColor = spriteRenderer.color;
        currentHp = totalHp;
        base.Start();
    }

    public void Update()
    {
        base.Update();
        Timers();
        CheckPlatforms();
        CheckInteraction();
    }
    void FixedUpdate()
    {
        if (execMoveToPosition)
        {
            MovePosition();
            execMoveToPosition = false;
        }
        else if (execImpulseForce)
        {
            ImpulseForce();
            execImpulseForce = false;
        }
    }
}