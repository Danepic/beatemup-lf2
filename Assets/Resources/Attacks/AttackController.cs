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
    
    public static string GROUND_EXTRA_LARGE_OPOINT = "ground_extra_large";
    public static string GROUND_EXTRA_SMALL_OPOINT = "ground_extra_small";
    public static string GROUND_NORMAL_OPOINT = "ground_normal";
    public static string GROUND_LARGE_OPOINT = "ground_large";
    public static string GROUND_SMALL_OPOINT = "ground_small";
    
    protected void Awake()
    {
        type = ObjTypeEnum.ATTACK;
        base.Awake();
        opoints.Add(GROUND_EXTRA_LARGE_OPOINT, EnrichOpoint(1, "Effects/ground/normal/extra-large/ground-extra-large"));
        opoints.Add(GROUND_EXTRA_SMALL_OPOINT, EnrichOpoint(1, "Effects/ground/normal/extra-small/ground-extra-small"));
        opoints.Add(GROUND_NORMAL_OPOINT, EnrichOpoint(1, "Effects/ground/normal/normal/ground-normal"));
        opoints.Add(GROUND_LARGE_OPOINT, EnrichOpoint(1, "Effects/ground/normal/large/ground-large"));
        opoints.Add(GROUND_SMALL_OPOINT, EnrichOpoint(1, "Effects/ground/normal/small/ground-small"));
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