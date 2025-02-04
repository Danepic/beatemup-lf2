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
        opoints.Add(11, EnrichOpoint(1, "Effects/ground/normal/extra-large/ground-extra-large"));
        opoints.Add(12, EnrichOpoint(1, "Effects/ground/normal/extra-small/ground-extra-small"));
        opoints.Add(13, EnrichOpoint(1, "Effects/ground/normal/normal/ground-normal"));
        opoints.Add(14, EnrichOpoint(1, "Effects/ground/normal/large/ground-large"));
        opoints.Add(15, EnrichOpoint(1, "Effects/ground/normal/small/ground-small"));
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