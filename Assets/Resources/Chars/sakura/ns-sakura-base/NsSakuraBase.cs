using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using AYellowpaper.SerializedCollections;
using Chars;
using Domains;
using Enums;
using UnityEngine;
using UnityEngine.InputSystem;

public class NsSakuraBase : CharController
{
    public static string KUNAI_OPOINT = "kunai";
    void Awake()
    {
        palettes.Add("Chars/sakura/ns-sakura-base/sprites");
        base.Awake();
        header = new()
        {
            name = "Sakura Haruno",
            startHp = 1075,
            startMp = 1200,
        };
        stats = new()
        {
            aggressive = 8,
            technique = 4,
            intelligent = 8,
            speed = 8,
            resistance = 8,
            stamina = 9,
        };
        opoints.Add(KUNAI_OPOINT, EnrichOpoint(6, "Attacks/Weapons/kunai/kunai"));
        hitDefenseAction = HitDefense_160;
        jumpDefenseAction = HitJumpDefense_305;
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        ChangeFrame(Standing_0);
        base.Start();
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }

    public void Update()
    {
        base.Update();
    }

    #region Standing
    private void Standing_0()
    {
        StopMovement(); CancelOpoints();
        ResetMovementFromStop();
        pic = 107; state = StateFrameEnum.STANDING; wait = 2.5f; next = Standing_1;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        ResetParams();
    }

    private void Standing_1()
    {
        pic = 108; state = StateFrameEnum.STANDING; wait = 1.5f; next = Standing_2;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        ResetParams();
    }
    private void Standing_2()
    {
        pic = 109; state = StateFrameEnum.STANDING; wait = 2.5f; next = Standing_3;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        ResetParams();
    }
    private void Standing_3()
    {
        pic = 110; state = StateFrameEnum.STANDING; wait = 1.5f; next = Standing_4;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        ResetParams();
    }
    private void Standing_4()
    {
        pic = 111; state = StateFrameEnum.STANDING; wait = 2.5f; next = Standing_5;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        ResetParams();
    }
    private void Standing_5()
    {
        pic = 112; state = StateFrameEnum.STANDING; wait = 1.5f; next = Standing_6;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        ResetParams();
    }
    private void Standing_6()
    {
        pic = 113; state = StateFrameEnum.STANDING; wait = 2.5f; next = Standing_7;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        ResetParams();
    }
    private void Standing_7()
    {
        pic = 114; state = StateFrameEnum.STANDING; wait = 1f; next = Standing_8;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        ResetParams();
    }
    private void Standing_8()
    {
        pic = 115; state = StateFrameEnum.STANDING; wait = 1f; next = Standing_0;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        ResetParams();
    }
    #endregion

    #region Walking
    private void Walking_20()
    {
        pic = 116; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_21;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0; CancelOpoints();
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_21()
    {
        pic = 117; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_22;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_22()
    {
        pic = 118; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_23;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_23()
    {
        pic = 119; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_24;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_24()
    {
        pic = 120; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_25;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_25()
    {
        pic = 121; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_26;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_26()
    {
        pic = 122; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_27;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_27()
    {
        pic = 123; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_28;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_28()
    {
        pic = 124; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_29;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_29()
    {
        pic = 125; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_30;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_30()
    {
        pic = 126; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_20;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        ApplyPhysicWalking();
        ManageWalking();
    }
    #endregion

    #region SimpleDash
    private void SimpleDash_40()
    {
        pic = 127; state = StateFrameEnum.SIMPLE_DASH; wait = 0.5f; dvx = 450f; dvy = 0f; dvz = 0f;
        next = SimpleDash_41;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(Attack1_350);
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
    }

    private void SimpleDash_41()
    {
        pic = 128; state = StateFrameEnum.SIMPLE_DASH; wait = 1.5f; dvx = 0f; dvy = 0f; dvz = 0f;
        next = SimpleDash_42;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(Attack1_350);
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
    }

    private void SimpleDash_42()
    {
        CanHoldForwardAfter(Running_55);
        pic = 128; state = StateFrameEnum.SIMPLE_DASH; wait = 0.5f; dvx = 0f; dvy = 0f; dvz = 0f;
        next = SimpleDash_43;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(Attack1_350);
        BdyDefault();
    }

    private void SimpleDash_43()
    {
        StopMovement();
        CanHoldForwardAfter(Running_55);
        pic = 128; state = StateFrameEnum.SIMPLE_DASH; wait = 0.5f; dvx = 0f; dvy = 0f; dvz = 0f;
        next = SimpleDashStopRunning_44;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(Attack1_350);
        BdyDefault();
    }

    private void SimpleDashStopRunning_44()
    {
        ResetMovementFromStop();
        CanHoldForwardAfter(Running_55);
        pic = 118; state = StateFrameEnum.SIMPLE_DASH; wait = 4f; dvx = 150f; dvy = 0; dvz = 0;
        next = StopRunning_62;
        Attack(Attack1_350); Defense(RunningDash_70); Jump(DashJump_250);
        BdyDefault();
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    #endregion

    #region Running
    private void Running_45()
    {
        pic = 116; state = StateFrameEnum.RUNNING; wait = 1.5f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_46;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
    }
    private void Running_46()
    {
        pic = 117; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_47;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
    }
    private void Running_47()
    {
        pic = 118; state = StateFrameEnum.RUNNING; wait = 1f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_48;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_48()
    {
        pic = 119; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_49;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_49()
    {
        pic = 120; state = StateFrameEnum.RUNNING; wait = 1f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_50;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_50()
    {
        pic = 121; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_51;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_51()
    {
        pic = 122; state = StateFrameEnum.RUNNING; wait = 1f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_52;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_52()
    {
        pic = 123; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_53;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_53()
    {
        pic = 124; state = StateFrameEnum.RUNNING; wait = 1f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_54;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }
    private void Running_54()
    {
        pic = 125; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_55;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }
    private void Running_55()
    {
        pic = 126; state = StateFrameEnum.RUNNING; wait = 1f; dvx = 3f; dvy = 0f; dvz = 3f;
        next = Running_45;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }
    #endregion

    #region StopRunning
    private void StopRunning_60()
    {
        StopMovement();
        pic = 129; state = StateFrameEnum.STOP_RUNNING; wait = 1f; dvx = 0; dvy = 0; dvz = 0;
        next = StopRunning_61;
        Attack(RunningAttack_330);
        BdyDefault();
    }
    private void StopRunning_61()
    {
        ResetMovementFromStop();
        pic = 129; state = StateFrameEnum.STOP_RUNNING; wait = 4f; dvx = 150f; dvy = 0; dvz = 0;
        next = StopRunning_62;
        Attack(RunningAttack_330);
        BdyDefault();
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    private void StopRunning_62()
    {
        pic = 129; state = StateFrameEnum.STOP_RUNNING; wait = 1f; dvx = 0f; dvy = 0f; dvz = 0f;
        next = Standing_0;
        Attack(RunningAttack_330);
        BdyDefault();
        StopMovement();
    }
    #endregion

    #region RunningDash
    private void RunningDash_70()
    {
        pic = 116; state = StateFrameEnum.DASH; wait = 2f;
        next = RunningDash_71;
        BdyDefault();
        StopMovement();
    }
    private void RunningDash_71()
    {
        ResetMovementFromStop();
        pic = 127; state = StateFrameEnum.DASH; wait = 0.5f; dvx = 600; dvy = 0; dvz = 200;
        next = RunningDash_72;
        BdyDefault();
        ApplyPhysicDash();
    }
    private void RunningDash_72()
    {
        pic = 128; state = StateFrameEnum.DASH; wait = 5f;
        next = RunningDash_73;
        BdyDefault();
    }
    private void RunningDash_73()
    {
        pic = 212; state = StateFrameEnum.DASH; wait = 0.5f;
        next = StopRunning_60;
        BdyDefault();
    }
    #endregion

    #region SideDash
    private void SideDash_90()
    {
        pic = 700; state = StateFrameEnum.SIDE_DASH; wait = 1f;
        next = SideDash_91;
        BdyDefault();
    }
    private void SideDash_91()
    {
        pic = 701; state = StateFrameEnum.SIDE_DASH; wait = 1f;
        next = SideDash_92;
        BdyDefault();
    }
    private void SideDash_92()
    {
        pic = 702; state = StateFrameEnum.SIDE_DASH; wait = 5f; dvx = 0f; dvy = 0; dvz = 500f;
        next = SideDash_93;
        BdyDefault();
        ApplySideDashPhysic();
    }
    private void SideDash_93()
    {
        pic = 701; state = StateFrameEnum.SIDE_DASH; wait = 0.5f;
        next = Crouch_290;
        BdyDefault();
    }
    #endregion

    #region DashBackward
    private void DashBackward_130()
    {
        StopMovement();
        pic = 132; state = StateFrameEnum.JUMPING; wait = 1.5f;
        next = DashBackward_131;
        BdyDefault();
    }
    private void DashBackward_131()
    {
        ResetMovementFromStop();
        pic = 133; state = StateFrameEnum.JUMPING; wait = 1f; dvx = -200; dvy = 175; dvz = 0;
        next = DashBackward_132;
        BdyDefault(); ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    private void DashBackward_132()
    {
        pic = 134; state = StateFrameEnum.JUMPING; wait = 6f;
        next = DashBackward_133;
        BdyDefault();
    }
    private void DashBackward_133()
    {
        pic = 135; state = StateFrameEnum.JUMPING; wait = 0.5f;
        next = DashBackward_134; OnGround(Crouch_290);
        BdyDefault();
    }
    private void DashBackward_134()
    {
        pic = 135; state = StateFrameEnum.JUMPING; wait = 6f;
        next = DashBackward_134; OnGround(Crouch_290);
        BdyDefault();
    }
    #endregion

    #region Defense
    private void Start_Defense_150()
    {
        pic = 136; state = StateFrameEnum.DEFEND; wait = 1f;
        next = Defense_151; Attack(ThrowingWeapon_310); Power(ChargeStart_170);
        Jump(DashBackward_130);
        BdyDefault();
    }
    private void Defense_151()
    {
        pic = 137; state = StateFrameEnum.DEFEND; wait = 2f;
        next = StopDefense_152; CanHoldDefenseAfter(DefenseHold_155);
        Attack(ThrowingWeapon_310); Power(ChargeStart_170); Jump(DashBackward_130);
        BdyDefault();
    }
    private void StopDefense_152()
    {
        pic = 136; state = StateFrameEnum.OTHER; wait = 1f;
        next = Standing_0; Attack(ThrowingWeapon_310); Power(ChargeStart_170);
        Jump(DashBackward_130);
        BdyDefault();
    }
    private void DefenseHold_155()
    {
        pic = 137; state = StateFrameEnum.DEFEND; wait = 1f;
        next = Defense_151;
        Attack(ThrowingWeapon_310); Power(ChargeStart_170); Jump(DashBackward_130);
        BdyDefault();
    }

    private void HitDefense_160()
    {
        pic = 137; state = StateFrameEnum.DEFEND; wait = 1f;
        next = HitDefense_161; CanHoldDefenseAfter(Defense_151);
        Attack(ThrowingWeapon_310); Power(ChargeStart_170); Jump(DashBackward_130);
        BdyDefault();
    }
    private void HitDefense_161()
    {
        pic = 137; state = StateFrameEnum.DEFEND; wait = 2.5f;
        next = StopDefense_152; CanHoldDefenseAfter(Defense_151);
        Attack(ThrowingWeapon_310); Power(ChargeStart_170); Jump(DashBackward_130);
        BdyDefault();
    }
    #endregion

    #region Charge
    private void ChargeStart_170()
    {
        pic = 200; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStart_171;
        BdyDefault();
    }
    private void ChargeStart_171()
    {
        pic = 201; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStart_172;
        BdyDefault();
    }
    private void ChargeStart_172()
    {
        pic = 202; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStart_173;
        BdyDefault();
    }
    private void ChargeStart_173()
    {
        pic = 203; state = StateFrameEnum.OTHER; wait = 1f;
        next = Charge_175;
        BdyDefault();
    }

    private void Charge_175()
    {
        pic = 204; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = Charge_176; Attack(ChargeStop_190); Power(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
        SpawnOpoint(CHAKRA_CHARGE_OPOINT, Opoint(x: 0.025f, y: 0.389f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Charge_176()
    {
        pic = 205; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = Charge_177; Attack(ChargeStop_190); Power(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
        SpawnOpoint(CHAKRA_CHARGE_AURA_OPOINT, Opoint(x: 0f, y: 0.014f, z: 0f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Charge_177()
    {
        pic = 206; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = Charge_178; Attack(ChargeStop_190); Power(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
        SpawnOpoint(CHAKRA_CHARGE_SMOKE_OPOINT, Opoint(x: 0f, y: 0.109f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Charge_178()
    {
        pic = 207; state = StateFrameEnum.OTHER; wait = 3f;
        next = Charge_179; Attack(ChargeStop_190); Power(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }
    private void Charge_179()
    {
        pic = 208; state = StateFrameEnum.OTHER; wait = 2f;
        next = Charge_180; Attack(ChargeStop_190); Power(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }
    private void Charge_180()
    {
        pic = 209; state = StateFrameEnum.OTHER; wait = 2f;
        next = Charge_181; Attack(ChargeStop_190); Power(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }
    private void Charge_181()
    {
        pic = 210; state = StateFrameEnum.OTHER; wait = 2f;
        next = Charge_182; Attack(ChargeStop_190); Power(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }
    private void Charge_182()
    {
        pic = 211; state = StateFrameEnum.OTHER; wait = 2f;
        next = Charge_175; Attack(ChargeStop_190); Power(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }

    private void ChargeStop_190()
    {
        pic = 212; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStop_191;
        BdyDefault();
    }
    private void ChargeStop_191()
    {
        pic = 213; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStop_192;
        BdyDefault();
    }
    private void ChargeStop_192()
    {
        pic = 214; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStop_193;
        BdyDefault();
    }
    private void ChargeStop_193()
    {
        pic = 215; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = ChargeStop_194;
        BdyDefault();
    }
    private void ChargeStop_194()
    {
        pic = 216; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Taunt
    private void Taunt_195()
    {
        pic = 100; wait = 2f; next = Taunt_196;
        BdyDefault();
    }
    private void Taunt_196()
    {
        pic = 100; wait = 0.5f; next = Taunt_197;
        BdyDefault();
    }
    private void Taunt_197()
    {
        pic = 100; wait = 2f; next = Taunt_198;
        BdyDefault();
    }
    private void Taunt_198()
    {
        pic = 101; wait = 0.5f; next = Taunt_199;
        BdyDefault();
    }
    private void Taunt_199()
    {
        pic = 101; wait = 2f; next = Taunt_200;
        BdyDefault();
    }
    private void Taunt_200()
    {
        pic = 101; wait = 0.5f; next = Taunt_201;
        BdyDefault();
    }
    private void Taunt_201()
    {
        pic = 102; wait = 2f; next = Taunt_202;
        BdyDefault();
    }
    private void Taunt_202()
    {
        pic = 102; wait = 2f; next = Taunt_203;
        BdyDefault();
    }
    private void Taunt_203()
    {
        pic = 103; wait = 2f; next = Taunt_204;
        BdyDefault();
    }
    private void Taunt_204()
    {
        pic = 104; wait = 2f; next = Taunt_205;
        BdyDefault();
    }
    private void Taunt_205()
    {
        pic = 105; wait = 2f; next = Taunt_206;
        BdyDefault();
    }
    private void Taunt_206()
    {
        pic = 106; wait = 2f; next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Jump
    private void Jump_210()
    {
        StopMovement();
        pic = 129; state = StateFrameEnum.JUMPING; wait = 4f;
        next = Jump_211; Defense(DashBackward_130);
        BdyDefault();
    }
    private void Jump_211()
    {
        pic = 130; state = StateFrameEnum.JUMPING; wait = 0.5f;
        next = Jump_212; Defense(DashBackward_130);
        BdyDefault();
    }
    private void Jump_212()
    {
        ResetMovementFromStop();
        pic = 131; state = StateFrameEnum.JUMPING; wait = 0.5f; dvx = 80; dvy = 300; dvz = 80;
        next = Jump_213;
        BdyDefault();
        ApplyPhysicJumping();
    }
    private void Jump_213()
    {
        pic = 132; state = StateFrameEnum.JUMPING; wait = 1f;
        next = Jump_214; DoubleTapJump(DoubleJump_230);
        BdyDefault();
        CanFlip(); CountJumpDash(); CanJumpDash(JumpDash_270);
    }
    private void Jump_214()
    {
        pic = 133; state = StateFrameEnum.JUMPING; wait = 8f;
        next = JumpFalling_220; DoubleTapJump(DoubleJump_230);
        Defense(StartJumpDefense_300); Attack(JumpSuperAttack_550);
        BdyDefault();
        CanFlip(); CountJumpDash(); CanJumpDash(JumpDash_270);
    }

    private void JumpFalling_220()
    {
        pic = 134; state = StateFrameEnum.JUMPING; wait = 1f;
        next = JumpFalling_221; DoubleTapJump(DoubleJump_230);
        Defense(StartJumpDefense_300); OnGround(Crouch_290); Attack(JumpSuperAttack_550);
        BdyDefault();
        CanFlip(); CountJumpDash(); CanJumpDash(JumpDash_270);
    }
    private void JumpFalling_221()
    {
        pic = 135; state = StateFrameEnum.JUMPING; wait = 1f;
        next = JumpFalling_221; DoubleTapJump(DoubleJump_230);
        Defense(StartJumpDefense_300); OnGround(Crouch_290); Attack(JumpSuperAttack_550);
        BdyDefault();
        CanFlip(); CountJumpDash(); CanJumpDash(JumpDash_270);
    }
    #endregion

    #region DoubleJump
    private void DoubleJump_230()
    {
        pic = 129; state = StateFrameEnum.JUMPING; wait = 2f;
        next = DoubleJump_231; OnGround(Crouch_290);
        BdyDefault();
        StopMovement();
        ApplyDefaultPhysic(0, 0, 0, facingRight);
    }
    private void DoubleJump_231()
    {
        pic = 130; state = StateFrameEnum.JUMPING; wait = 0.5f;
        next = DoubleJump_232; OnGround(Crouch_290);
        BdyDefault();
        ResetMovementFromStop();
    }
    private void DoubleJump_232()
    {
        pic = 132; state = StateFrameEnum.JUMPING; wait = 0.5f; dvx = 80; dvy = 225; dvz = 80;
        next = DoubleJump_233; OnGround(Crouch_290);
        BdyDefault();
        ApplyPhysicJumping();
    }
    private void DoubleJump_233()
    {
        pic = 133; state = StateFrameEnum.JUMPING; wait = 8f;
        next = DoubleJumpFalling_240; Defense(StartJumpDefense_300); OnGround(Crouch_290);
        Attack(JumpSuperAttack_550);
        BdyDefault();
        CanFlip();
    }
    #endregion

    #region DoubleJumpFalling
    private void DoubleJumpFalling_240()
    {
        pic = 134; state = StateFrameEnum.JUMPING; wait = 1f;
        next = DoubleJumpFalling_241; Defense(StartJumpDefense_300); OnGround(Crouch_290);
        Attack(JumpSuperAttack_550);
        BdyDefault();
        CanFlip();
    }
    private void DoubleJumpFalling_241()
    {
        pic = 135; state = StateFrameEnum.JUMPING; wait = 1f;
        next = DoubleJumpFalling_241; Defense(StartJumpDefense_300); OnGround(Crouch_290);
        Attack(JumpSuperAttack_550);
        BdyDefault();
        CanFlip();
    }
    #endregion

    #region DashJump
    private void DashJump_250()
    {
        pic = 129; state = StateFrameEnum.OTHER; wait = 2f;
        next = DashJump_251; Defense(DashBackward_130);
        BdyDefault();
        StopMovement();
        PrepareJumpDash();
    }
    private void DashJump_251()
    {
        pic = 130; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = DashJump_252; Defense(DashBackward_130);
        BdyDefault();
        ResetMovementFromStop();
    }
    private void DashJump_252()
    {
        pic = 131; state = StateFrameEnum.OTHER; wait = 1f; dvx = 175; dvy = 290; dvz = 80;
        next = DashJump_253; DoubleTapJump(DoubleJump_230);
        BdyDefault();
        ApplyPhysicDashJumping();
    }
    private void DashJump_253()
    {
        pic = 132; state = StateFrameEnum.OTHER; wait = 3f;
        next = DashJump_254; DoubleTapJump(DoubleJump_230);
        BdyDefault(); CountJumpDash(); CanJumpDash(JumpDash_270);
        CanFlip();
    }
    private void DashJump_254()
    {
        pic = 132; state = StateFrameEnum.OTHER; wait = 4f;
        next = JumpFalling_220; Defense(StartJumpDefense_300); OnGround(Crouch_290);
        DoubleTapJump(DoubleJump_230); Attack(JumpSuperAttack_550);
        BdyDefault(); CountJumpDash(); CanJumpDash(JumpDash_270);
        CanFlip();
    }
    #endregion

    #region JumpDash
    private void JumpDash_270()
    {
        StopMovement();
        pic = 127; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpDash_271; Attack(JumpAttack1_590);
        BdyDefault();
    }
    private void JumpDash_271()
    {
        ResetMovementFromStop();
        pic = 128; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpDash_272; Attack(JumpAttack1_590);
        BdyDefault();
        ApplyDefaultPhysic(dvx: 250, dvy: 100, dvz: 0, facingRight);
    }
    private void JumpDash_272()
    {
        pic = 128; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = JumpDash_273; Attack(JumpAttack1_590);
        BdyDefault();
    }
    private void JumpDash_273()
    {
        pic = 128; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpDash_274; Attack(JumpAttack1_590);
        BdyDefault();
    }
    private void JumpDash_274()
    {
        pic = 124; state = StateFrameEnum.OTHER; wait = 4f;
        next = DoubleJumpFalling_240; Attack(JumpAttack1_590);
        BdyDefault();
    }
    #endregion

    #region Crouch
    private void Crouch_290()
    {
        ItrDisable();
        StopMovement();
        pic = 129; state = StateFrameEnum.CROUCH; wait = 1f;
        next = Crouch_291;
        bdy.x = 0.0855f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.2873f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
        releaseJumpButton = false;
    }
    private void Crouch_291()
    {
        ResetMovementFromStop();
        pic = 129; state = StateFrameEnum.CROUCH; wait = 3f;
        next = Standing_0;
        bdy.x = 0.0855f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.2873f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
        releaseJumpButton = false;
    }
    #endregion

    #region JumpFallingWhenXMove
    private void JumpFallingWhenXMove_298()
    {
        pic = 134; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = JumpFallingWhenXMove_299; OnGround(Crouch_290); Defense(StartJumpDefense_300); DoubleTapJump(DoubleJump_230);
        BdyDefault();
    }
    private void JumpFallingWhenXMove_299()
    {
        pic = 135; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpFallingWhenXMove_299; OnGround(Crouch_290);
        BdyDefault();
        ApplyDefaultPhysic(dvx: 10, 0, 0, facingRight);
    }
    #endregion

    #region Jump_Defense
    private void StartJumpDefense_300()
    {
        pic = 138; state = StateFrameEnum.JUMP_DEFEND; wait = 1f;
        next = JumpDefense_301; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
    }
    private void JumpDefense_301()
    {
        pic = 139; state = StateFrameEnum.JUMP_DEFEND; wait = 5f;
        CanHoldDefenseAfter(JumpDefenseHold_303);
        next = StopJumpDefense_302; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
    }
    private void StopJumpDefense_302()
    {
        pic = 138; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpFallingNoAction_308; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
    }

    private void JumpDefenseHold_303()
    {
        pic = 139; state = StateFrameEnum.JUMP_DEFEND; wait = 1f;
        CanHoldDefenseAfter(JumpDefenseHold_303);
        next = StopJumpDefense_302; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
    }

    private void HitJumpDefense_305()
    {
        pic = 139; state = StateFrameEnum.JUMP_DEFEND; wait = 1f;
        next = HitJumpDefense_306; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
    }
    private void HitJumpDefense_306()
    {
        pic = 139; state = StateFrameEnum.JUMP_DEFEND; wait = 2.5f;
        CanHoldDefenseAfter(JumpDefenseHold_303);
        next = StopJumpDefense_302; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
    }
    #endregion

    #region JumpFallingNoAction
    private void JumpFallingNoAction_308()
    {
        pic = 134; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = JumpFallingNoAction_309;
        BdyDefault();
    }
    private void JumpFallingNoAction_309()
    {
        pic = 135; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpFallingNoAction_309; OnGround(Crouch_290);
        BdyDefault();
    }
    #endregion

    #region ThrowingWeapon
    private void ThrowingWeapon_310()
    {
        pic = 217; wait = 0.5f; next = ThrowingWeapon_311; state = StateFrameEnum.ATTACK;
        BdyDefault();
    }
    private void ThrowingWeapon_311()
    {
        pic = 218; wait = 0.5f; next = ThrowingWeapon_312;
        BdyDefault();
    }
    private void ThrowingWeapon_312()
    {
        pic = 219; wait = 1f; next = ThrowingWeapon_313;
        BdyDefault();
    }
    private void ThrowingWeapon_313()
    {
        pic = 220; wait = 0.5f; next = ThrowingWeapon_314;
        BdyDefault();
        SpawnOpoint(KUNAI_OPOINT, Opoint(x: 0.13f, y: 0.4f, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
    }
    private void ThrowingWeapon_314()
    {
        pic = 221; wait = 0.5f; next = ThrowingWeapon_315;
        BdyDefault();
    }
    private void ThrowingWeapon_315()
    {
        pic = 222; wait = 0.5f; next = ThrowingWeapon_316;
        BdyDefault();
        SpawnOpoint(KUNAI_OPOINT, Opoint(x: 0.13f, y: 0.4f, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
    }
    private void ThrowingWeapon_316()
    {
        pic = 223; wait = 8f; next = ThrowingWeapon_317;
        BdyDefault();
    }
    private void ThrowingWeapon_317()
    {
        pic = 224; wait = 0.5f; next = ThrowingWeapon_318;
        BdyDefault();
    }
    private void ThrowingWeapon_318()
    {
        pic = 225; wait = 1f; next = ThrowingWeapon_319;
        BdyDefault();
    }
    private void ThrowingWeapon_319()
    {
        pic = 226; wait = 0.5f; next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region RunningAttack
    private void RunningAttack_330()
    {
        pic = 227; wait = 1f; state = StateFrameEnum.ATTACK;
        next = RunningAttack_331;
        BdyDefault();
        ItrDisable();
    }
    private void RunningAttack_331()
    {
        StopMovement();
        pic = 227; wait = 0.5f;
        next = RunningAttack_332;
        BdyDefault();
    }
    private void RunningAttack_332()
    {
        ResetMovementFromStop();
        pic = 227; wait = 1f; dvx = 350;
        next = RunningAttack_333;
        BdyDefault();
        ApplyDefaultPhysic(dvx, null, null, facingRight);
    }
    private void RunningAttack_333()
    {
        pic = 227; wait = 0.5f;
        next = RunningAttack_334;
        BdyDefault();
    }
    private void RunningAttack_334()
    {
        pic = 227; wait = 1f;
        next = RunningAttack_335;
        BdyDefault();
    }
    private void RunningAttack_335()
    {
        pic = 228; wait = 0.5f;
        next = RunningAttack_336;
        BdyDefault();
    }
    private void RunningAttack_336()
    {
        pic = 229; wait = 1f;
        next = RunningAttack_337;
        BdyDefault();
        itr.x = 0.2098f; itr.y = 0.2994f; itr.z = 0;
        itr.w = 0.4802928f; itr.h = 0.3247183f; itr.zwidth = 0.22f;
        itr.dvx = 250; itr.dvy = 200; itr.dvz = 0; itr.action = 860;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 7; itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
    }
    private void RunningAttack_337()
    {
        ItrDisable();
        pic = 230; wait = 1f;
        next = RunningAttack_338;
        BdyDefault();
        itr.x = 0.2098f; itr.y = 0.2994f; itr.z = 0;
        itr.w = 0.4802928f; itr.h = 0.3247183f; itr.zwidth = 0.22f;
        itr.dvx = 250; itr.dvy = 200; itr.dvz = 0; itr.action = 860;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 7; itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
    }
    private void RunningAttack_338()
    {
        pic = 231; wait = 1f;
        next = RunningAttack_339;
        BdyDefault();
        itr.x = 0.2098f; itr.y = 0.2994f; itr.z = 0;
        itr.w = 0.4802928f; itr.h = 0.3247183f; itr.zwidth = 0.22f;
        itr.dvx = 250; itr.dvy = 200; itr.dvz = 0; itr.action = 860;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 7; itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
    }

    private void RunningAttack_339()
    {
        pic = 232; wait = 1f;
        next = RunningAttack_340;
        BdyDefault();
        itr.x = 0.2098f; itr.y = 0.2994f; itr.z = 0;
        itr.w = 0.4802928f; itr.h = 0.3247183f; itr.zwidth = 0.22f;
        itr.dvx = 250; itr.dvy = 200; itr.dvz = 0; itr.action = 860;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 7; itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
    }
    private void RunningAttack_340()
    {
        StopMovement();
        pic = 233; wait = 0.5f;
        next = RunningAttack_341;
        BdyDefault();
    }
    private void RunningAttack_341()
    {
        pic = 234; wait = 1f;
        next = RunningAttack_342;
        BdyDefault();
    }
    private void RunningAttack_342()
    {
        pic = 235; wait = 0.5f;
        next = RunningAttack_343;
        BdyDefault();
    }
    private void RunningAttack_343()
    {
        pic = 236; wait = 1f;
        next = RunningAttack_344;
        BdyDefault();
    }
    private void RunningAttack_344()
    {
        pic = 237; wait = 0.5f;
        next = RunningAttack_345;
        BdyDefault();
    }
    private void RunningAttack_345()
    {
        pic = 238; wait = 1f;
        next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Attack
    private void Attack1_350()
    {
        StopMovement(); state = StateFrameEnum.ATTACK;
        ItrDisable();
        pic = 300; wait = 5f;
        next = Attack1_351;
        BdyDefault();
    }
    private void Attack1_351()
    {
        pic = 301; wait = 0.5f;
        next = Attack1_352;
        BdyDefault();
    }
    private void Attack1_352()
    {
        pic = 302; wait = 0.5f;
        next = Attack1_353;
        BdyDefault();
        itr.x = 0.3433f; itr.y = 0.4133f; itr.z = 0;
        itr.w = 0.4044166f; itr.h = 0.2453708f; itr.zwidth = 0.22f;
        itr.dvx = 25; itr.dvy = 0; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 50;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 4; itr.physic = ItrPhysicEnum.FIXED;
        Itr();
    }
    private void Attack1_353()
    {
        ItrDisable();
        pic = 303; wait = 0.5f; state = StateFrameEnum.STANDING;
        next = Attack1_354; IfHit(Attack1Next_360);
        BdyDefault();
    }
    private void Attack1_354()
    {
        pic = 304; wait = 1f;
        next = Attack1_355; IfHit(Attack1Next_361);
        BdyDefault();
    }
    private void Attack1_355()
    {
        pic = 305; wait = 0.5f;
        next = Attack1_356; IfHit(Attack1Next_362);
        BdyDefault();
    }
    private void Attack1_356()
    {
        pic = 306; wait = 3f;
        next = Standing_0; IfHit(Attack1Next_363);
        BdyDefault();
    }

    private void Attack1Next_360()
    {
        pic = 303; wait = 0.5f;
        next = Attack1Next_361;
        BdyDefault();
        enableNextIfHit = false;
    }
    private void Attack1Next_361()
    {
        pic = 304; wait = 1f;
        next = Attack1Next_362;
        BdyDefault();
    }
    private void Attack1Next_362()
    {
        pic = 304; wait = 0.5f;
        next = Attack1Next_363;
        BdyDefault();
    }
    private void Attack1Next_363()
    {
        pic = 304; wait = 6f; state = StateFrameEnum.ATTACK;
        next = Standing_0; DoubleTapAttack(Attack2_370);
        BdyDefault();
    }
    #endregion

    #region Attack2
    private void Attack2_370()
    {
        ItrDisable(); state = StateFrameEnum.ATTACK_RESET;
        pic = 307; wait = 1f;
        next = Attack2_371;
        BdyDefault();
    }
    private void Attack2_371()
    {
        pic = 308; wait = 0.5f; state = StateFrameEnum.ATTACK;
        next = Attack2_372;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 150, null, null, facingRight);
    }
    private void Attack2_372()
    {
        pic = 310; wait = 1f;
        next = Attack2_373;
        BdyDefault();
        itr.x = 0.3433f; itr.y = 0.4133f; itr.z = 0;
        itr.w = 0.4044166f; itr.h = 0.2453708f; itr.zwidth = 0.22f;
        itr.dvx = 25; itr.dvy = 0; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 50;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 8; itr.physic = ItrPhysicEnum.FIXED;
        Itr();
    }
    private void Attack2_373()
    {
        StopMovement();
        ItrDisable();
        pic = 309; wait = 0.5f;
        next = Attack2_374;
        BdyDefault();
    }
    private void Attack2_374()
    {
        pic = 312; wait = 0.5f;
        next = Attack2_375;
        BdyDefault();
    }
    private void Attack2_375()
    {
        pic = 311; wait = 0.5f;
        next = Attack2_376;
        BdyDefault();
    }
    private void Attack2_376()
    {
        pic = 311; wait = 0.5f;
        next = Attack2_377;
        BdyDefault();
    }
    private void Attack2_377()
    {
        pic = 314; wait = 0.75f;
        next = Attack2_378;
        BdyDefault();
    }
    private void Attack2_378()
    {
        pic = 313; wait = 1f;
        next = Attack2_379;
        BdyDefault();
    }
    private void Attack2_379()
    {
        ResetMovementFromStop();
        pic = 313; wait = 4f;
        next = Standing_0; DoubleTapAttack(Attack3_390);
        BdyDefault();
    }
    #endregion

    #region Attack3
    private void Attack3_390()
    {
        ItrDisable(); state = StateFrameEnum.ATTACK_RESET;
        pic = 316; wait = 1f;
        next = Attack3_391;
        BdyDefault();
    }
    private void Attack3_391()
    {
        pic = 315; wait = 0.5f; state = StateFrameEnum.ATTACK;
        next = Attack3_392;
        BdyDefault();
    }
    private void Attack3_392()
    {
        pic = 317; wait = 0.5f;
        next = Attack3_393;
        BdyDefault();
    }
    private void Attack3_393()
    {
        pic = 318; wait = 0.5f;
        next = Attack3_394;
        BdyDefault();
    }

    private void Attack3_394()
    {
        pic = 319; wait = 1f;
        next = Attack3_395;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 200, null, null, facingRight);
    }
    private void Attack3_395()
    {
        pic = 320; wait = 1f;
        next = Attack3_396;
        BdyDefault();
        itr.x = 0.0001f; itr.y = 0.4315f; itr.z = 0;
        itr.w = 0.9272251f; itr.h = 0.2817348f; itr.zwidth = 0.22f;
        itr.dvx = 30; itr.dvy = 0; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 50;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 5; itr.physic = ItrPhysicEnum.FIXED;
        Itr();
    }
    private void Attack3_396()
    {
        ItrDisable();
        pic = 321; wait = 1f;
        next = Attack3_399;
        BdyDefault();
    }

    private void Attack3_399()
    {
        StopMovement();
        pic = 322; wait = 0.5f;
        next = Attack3_400;
        BdyDefault();
    }
    private void Attack3_400()
    {
        pic = 322; wait = 0.5f;
        next = Attack3_401;
        BdyDefault();
    }
    private void Attack3_401()
    {
        pic = 324; wait = 1f;
        next = Attack3_402;
        BdyDefault();
    }
    private void Attack3_402()
    {
        ResetMovementFromStop();
        pic = 325; wait = 11f;
        next = Standing_0; DoubleTapAttack(Attack4_410);
        BdyDefault();
    }
    #endregion

    #region Attack4
    private void Attack4_410()
    {
        ItrDisable(); state = StateFrameEnum.ATTACK_RESET;
        pic = 326; wait = 0.5f;
        next = Attack4_411;
        BdyDefault();
    }
    private void Attack4_411()
    {
        pic = 327; wait = 1f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_412;
        BdyDefault();
    }
    private void Attack4_412()
    {
        pic = 328; wait = 1f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_413;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 125, null, null, facingRight);
    }

    private void Attack4_413()
    {
        ItrDisable(); state = StateFrameEnum.COMBO_FINISH;
        pic = 329; wait = 1f;
        next = Attack4_414;
        BdyDefault();
        itr.x = 0.0955f; itr.y = 0.3224f; itr.z = 0;
        itr.w = 0.6545281f; itr.h = 0.24537f; itr.zwidth = 0.22f;
        itr.dvx = 20; itr.dvy = 0; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 50;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 5; itr.physic = ItrPhysicEnum.FIXED;
        Itr();
        StopMovement();
    }
    private void Attack4_414()
    {
        ItrDisable();
        pic = 330; wait = 1f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_415;
        BdyDefault();
    }
    private void Attack4_415()
    {
        pic = 331; wait = 0.5f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_416;
        BdyDefault();
    }
    private void Attack4_416()
    {
        pic = 332; wait = 2f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_417;
        BdyDefault();
    }
    private void Attack4_417()
    {
        ResetMovementFromStop();
        pic = 333; wait = 4f; state = StateFrameEnum.COMBO_FINISH;
        next = Standing_0; DoubleTapAttack(ComboFinish_429);
        BdyDefault();
    }
    #endregion

    #region ComboFinish
    private void ComboFinish_429()
    {
        pic = 333; wait = 8f; state = StateFrameEnum.COMBO_FINISH;
        next = Standing_0; Up(Uppercut_450); Down(Downercut_470); Front(FrontAttack_430);
        BdyDefault();
    }
    #endregion

    #region FrontAttack
    private void FrontAttack_430()
    {
        pic = 423; wait = 0.5f; state = StateFrameEnum.ATTACK;
        next = FrontAttack_431;
        BdyDefault();
    }
    private void FrontAttack_431()
    {
        pic = 425; wait = 0.5f;
        next = FrontAttack_432;
        BdyDefault();
    }
    private void FrontAttack_432()
    {
        pic = 426; wait = 0.5f;
        next = FrontAttack_433;
        BdyDefault();
        ResetMovementFromStop();
    }
    private void FrontAttack_433()
    {
        pic = 427; wait = 0.5f;
        next = FrontAttack_434;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 200, dvy: 0, dvz: 0, facingRight);
    }
    private void FrontAttack_434()
    {
        pic = 428; wait = 2f; next = FrontAttack_435;
        BdyDefault();
        itr.x = 0.2114f; itr.y = 0.3655f; itr.z = 0;
        itr.w = 0.4590549f; itr.h = 0.5135916f; itr.zwidth = 0.22f;
        itr.dvx = 600; itr.dvy = 200; itr.dvz = 0; itr.action = 860;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault();
    }
    private void FrontAttack_435()
    {
        ItrDisable();
        pic = 429; wait = 0.5f;
        next = FrontAttack_436;
        BdyDefault();
    }
    private void FrontAttack_436()
    {
        pic = 430; wait = 1.5f;
        next = FrontAttack_437;
        BdyDefault();
    }
    private void FrontAttack_437()
    {
        pic = 431; wait = 0.5f;
        next = FrontAttack_438;
        BdyDefault();
        StopMovement();
    }
    private void FrontAttack_438()
    {
        pic = 432; wait = 5.5f;
        next = FrontAttack_439;
        BdyDefault();
    }
    private void FrontAttack_439()
    {
        pic = 433; wait = 1f;
        next = FrontAttack_440;
        BdyDefault();
    }
    private void FrontAttack_440()
    {
        pic = 434; wait = 4.5f;
        next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Uppercut
    private void Uppercut_450()
    {
        pic = 400; wait = 0.5f; next = Uppercut_451; state = StateFrameEnum.ATTACK;
        BdyDefault();
    }
    private void Uppercut_451()
    {
        pic = 401; wait = 0.5f; next = Uppercut_452;
        BdyDefault();
    }
    private void Uppercut_452()
    {
        pic = 402; wait = 0.5f; next = Uppercut_453;
        BdyDefault();
        ResetMovementFromStop();
    }
    private void Uppercut_453()
    {
        pic = 403; wait = 0.5f; next = Uppercut_454;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 175f, dvy: 0, dvz: 0, facingRight);
    }
    private void Uppercut_454()
    {
        pic = 404; wait = 0.5f; next = Uppercut_455;
        BdyDefault();
        itr.x = 0.1614f; itr.y = 0.5224f; itr.z = 0;
        itr.w = 0.1953547f; itr.h = 0.7817728f; itr.zwidth = 0.22f;
        itr.dvx = 5; itr.dvy = 350; itr.dvz = 0; itr.action = 840;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault();
    }
    private void Uppercut_455()
    {
        ItrDisable();
        pic = 405; wait = 0.5f; next = Uppercut_456;
        BdyDefault();
        StopMovement();
    }
    private void Uppercut_456()
    {
        pic = 405; wait = 1f; next = Uppercut_457;
        BdyDefault();
    }
    private void Uppercut_457()
    {
        pic = 406; wait = 5f; next = Uppercut_458;
        BdyDefault();
    }
    private void Uppercut_458()
    {
        pic = 407; wait = 1f; next = Uppercut_459;
        BdyDefault();
    }
    private void Uppercut_459()
    {
        pic = 408; wait = 13f; next = Standing_0; Jump(JumpCombo_650); state = StateFrameEnum.UPPER_TO_JUMP_COMBO;
        BdyDefault();
        SpawnOpoint(JUMPING_COMBO_OPOINT, Opoint(x: 0.11f, y: 0.25f, z: -0.08f, oid: 0, facingFront: true, quantity: 1));
    }
    #endregion

    #region Downercut
    private void Downercut_470()
    {
        pic = 131; wait = 0.5f; next = Downercut_471; state = StateFrameEnum.ATTACK;
        BdyDefault();
        ResetMovementFromStop();
    }
    private void Downercut_471()
    {
        pic = 132; wait = 0.5f; next = Downercut_472;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 30, dvy: 200, dvz: 0f, facingRight);
    }
    private void Downercut_472()
    {
        pic = 409; wait = 0.25f; next = Downercut_473;
        BdyDefault();
    }
    private void Downercut_473()
    {
        pic = 410; wait = 0.25f; next = Downercut_474;
        BdyDefault();
    }
    private void Downercut_474()
    {
        pic = 411; wait = 0.25f; next = Downercut_475;
        BdyDefault();
    }
    private void Downercut_475()
    {
        pic = 412; wait = 0.25f; next = Downercut_476;
        BdyDefault();
    }
    private void Downercut_476()
    {
        pic = 413; wait = 0.25f; next = Downercut_477;
        BdyDefault();
    }
    private void Downercut_477()
    {
        pic = 414; wait = 0.25f; next = Downercut_478;
        BdyDefault();
    }
    private void Downercut_478()
    {
        pic = 415; wait = 0.25f; next = Downercut_479;
        BdyDefault();
    }
    private void Downercut_479()
    {
        pic = 416; wait = 0.25f; next = Downercut_480;
        BdyDefault();
    }
    private void Downercut_480()
    {
        pic = 417; wait = 0.5f; next = Downercut_481;
        BdyDefault();
    }
    private void Downercut_481()
    {
        pic = 418; wait = 0.5f; next = Downercut_482;
        BdyDefault();
    }
    private void Downercut_482()
    {
        pic = 419; wait = 0.5f; next = Downercut_483;
        BdyDefault();
        itr.x = 0.124f; itr.y = 0.1783f; itr.z = 0;
        itr.w = 0.3973392f; itr.h = 0.5426754f; itr.zwidth = 0.22f;
        itr.dvx = 50; itr.dvy = 0; itr.dvz = 0; itr.action = 820;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        ItrDefault();
    }
    private void Downercut_483()
    {
        pic = 420; wait = 0.5f; next = Downercut_484;
        BdyDefault();
    }
    private void Downercut_484()
    {
        ItrDisable();
        pic = 421; wait = 0.5f; next = Downercut_485;
        BdyDefault();
    }
    private void Downercut_485()
    {
        pic = 422; wait = 8f; next = Downercut_485; OnGround(Crouch_290);
        BdyDefault();
    }
    #endregion

    #region JumpSuperAttack
    private void JumpSuperAttack_550()
    {
        pic = 435; wait = 0.5f; next = JumpSuperAttack_551; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpSuperAttack_551()
    {
        pic = 435; wait = 1f; next = JumpSuperAttack_552; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpSuperAttack_552()
    {
        pic = 435; wait = 0.5f; next = JumpSuperAttack_553; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpSuperAttack_553()
    {
        pic = 409; wait = 1f; next = JumpSuperAttack_554; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpSuperAttack_554()
    {
        pic = 419; wait = 0.5f; next = JumpSuperAttack_555; OnGround(Crouch_290);
        bdy.x = 0.1047f; bdy.y = 0.1856f; bdy.z = 0;
        bdy.w = 0.4125906f; bdy.h = 0.371265f; bdy.zwidth = 0.22f;
        Bdy();
        itr.x = 0.244f; itr.y = 0.2647f; itr.z = 0;
        itr.w = 0.34172f; itr.h = 0.7125095f; itr.zwidth = 0.22f;
        itr.dvx = 50; itr.dvy = -50; itr.dvz = 0; itr.action = 820;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
    }
    private void JumpSuperAttack_555()
    {
        pic = 420; wait = 1f; next = JumpSuperAttack_556; OnGround(Crouch_290);
        bdy.x = 0.1047f; bdy.y = 0.1856f; bdy.z = 0;
        bdy.w = 0.4125906f; bdy.h = 0.371265f; bdy.zwidth = 0.22f;
        Bdy();
        itr.x = 0.244f; itr.y = 0.2647f; itr.z = 0;
        itr.w = 0.34172f; itr.h = 0.7125095f; itr.zwidth = 0.22f;
        itr.dvx = 50; itr.dvy = -50; itr.dvz = 0; itr.action = 820;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
    }
    private void JumpSuperAttack_556()
    {
        pic = 421; wait = 0.5f; next = JumpSuperAttack_557; OnGround(Crouch_290);
        bdy.x = 0.1047f; bdy.y = 0.1856f; bdy.z = 0;
        bdy.w = 0.4125906f; bdy.h = 0.371265f; bdy.zwidth = 0.22f;
        Bdy();
    }
    private void JumpSuperAttack_557()
    {
        pic = 422; wait = 1f; next = JumpSuperAttack_557; OnGround(Crouch_290);
        bdy.x = 0.1047f; bdy.y = 0.1856f; bdy.z = 0;
        bdy.w = 0.4125906f; bdy.h = 0.371265f; bdy.zwidth = 0.22f;
        Bdy();
    }
    #endregion

    #region JumpThrowingAttack
    private void JumpThrowingAttack_570()
    {
        pic = 514; wait = 1.5f; next = JumpThrowingAttack_571; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_571()
    {
        pic = 515; wait = 0.5f; next = JumpThrowingAttack_572; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_572()
    {
        pic = 516; wait = 1.5f; next = JumpThrowingAttack_573; OnGround(Crouch_290);
        BdyDefault();
        SpawnOpoint(KUNAI_OPOINT, Opoint(x: 0.065f, y: 0.25f, z: 0f, oid: 20, facingFront: true, quantity: 1));
    }
    private void JumpThrowingAttack_573()
    {
        pic = 517; wait = 0.5f; next = JumpThrowingAttack_574; OnGround(Crouch_290);
        BdyDefault();
        SpawnOpoint(KUNAI_OPOINT, Opoint(x: 0.065f, y: 0.25f, z: 0f, oid: 20, facingFront: true, quantity: 1));
    }
    private void JumpThrowingAttack_574()
    {
        pic = 518; wait = 0.5f; next = JumpThrowingAttack_575; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_575()
    {
        pic = 519; wait = 0.5f; next = JumpThrowingAttack_576; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_576()
    {
        pic = 520; wait = 0.5f; next = JumpThrowingAttack_577; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_577()
    {
        pic = 521; wait = 1f; next = JumpThrowingAttack_577; OnGround(Crouch_290);
        BdyDefault();
    }
    #endregion

    #region JumpAttack1
    private void JumpAttack1_590()
    {
        ResetMovementFromStop(); state = StateFrameEnum.ATTACK_RESET;
        ItrDisable();
        pic = 435; wait = 1f; next = JumpAttack1_591; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack1_591()
    {
        pic = 436; wait = 0.5f; next = JumpAttack1_592; OnGround(Crouch_290); state = StateFrameEnum.ATTACK;
        BdyDefault();
    }
    private void JumpAttack1_592()
    {
        pic = 437; wait = 1f; next = JumpAttack1_593; OnGround(Crouch_290);
        BdyDefault();
        ApplyDefaultPhysic(dvx: 100, 50, null, facingRight);
        itr.x = 0.3613f; itr.y = 0.4408f; itr.z = 0;
        itr.w = 0.4356876f; itr.h = 0.1593104f; itr.zwidth = 0.22f;
        itr.dvx = 25; itr.dvy = 0; itr.dvz = 0; itr.action = 720;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 4; itr.physic = ItrPhysicEnum.FIXED;
        Itr();
    }
    private void JumpAttack1_593()
    {
        StopMovement();
        ItrDisable();
        pic = 438; wait = 0.5f; next = JumpAttack1_594; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack1_594()
    {
        pic = 439; wait = 0.5f; next = JumpAttack1_595; OnGround(Crouch_290);
        BdyDefault();
        ApplyDefaultPhysic(1, null, null, facingRight);
    }
    private void JumpAttack1_595()
    {
        ResetMovementFromStop();
        pic = 440; wait = 2f; next = JumpAttack1_595; OnGround(Crouch_290);
        BdyDefault(); DoubleTapAttack(JumpAttack2_610);
    }
    #endregion

    #region JumpAttack2
    private void JumpAttack2_610()
    {
        ResetMovementFromStop(); state = StateFrameEnum.ATTACK_RESET;
        ItrDisable();
        pic = 505; wait = 1f; next = JumpAttack2_611; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack2_611()
    {
        pic = 506; wait = 0.5f; next = JumpAttack2_612; OnGround(Crouch_290); state = StateFrameEnum.ATTACK;
        BdyDefault();
    }
    private void JumpAttack2_612()
    {
        pic = 500; wait = 0.5f; next = JumpAttack2_613; OnGround(Crouch_290);
        BdyDefault();
        ApplyDefaultPhysic(dvx: 100, 50, null, facingRight);
        itr.x = 0.3304f; itr.y = 0.3804f; itr.z = 0;
        itr.w = 0.3914549f; itr.h = 0.4217526f; itr.zwidth = 0.22f;
        itr.dvx = 25; itr.dvy = 0; itr.dvz = 0; itr.action = 720;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 4; itr.physic = ItrPhysicEnum.FIXED;
        Itr();
    }
    private void JumpAttack2_613()
    {
        StopMovement();
        ItrDisable();
        pic = 501; wait = 0.5f; next = JumpAttack2_614; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack2_614()
    {
        pic = 502; wait = 1f; next = JumpAttack2_615; OnGround(Crouch_290);
        BdyDefault();
        ApplyDefaultPhysic(1, null, null, facingRight);
    }
    private void JumpAttack2_615()
    {
        ResetMovementFromStop();
        pic = 503; wait = 0.5f; next = JumpAttack2_616; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack2_616()
    {
        pic = 504; wait = 2f; next = JumpAttack2_617; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack2_617()
    {
        pic = 505; wait = 1f; next = JumpAttack2_617; OnGround(Crouch_290);
        BdyDefault(); DoubleTapAttack(JumpAttack3_630);
    }
    #endregion

    #region JumpAttack3
    private void JumpAttack3_630()
    {
        ResetMovementFromStop(); state = StateFrameEnum.ATTACK_RESET;
        ItrDisable();
        pic = 505; wait = 1f; next = JumpAttack3_631; OnGround(Crouch_290);
        BdyDefault();
        ApplyDefaultPhysic(dvx: 0, dvy: 100, dvz: 0, facingRight);
    }
    private void JumpAttack3_631()
    {
        pic = 506; wait = 0.5f; next = JumpAttack3_632; OnGround(Crouch_290); state = StateFrameEnum.ATTACK;
        BdyDefault();
    }
    private void JumpAttack3_632()
    {
        pic = 507; wait = 1f; next = JumpAttack3_633; OnGround(Crouch_290);
        BdyDefault();
        ApplyDefaultPhysic(dvx: 125, null, null, facingRight);
    }
    private void JumpAttack3_633()
    {
        StopMovement();
        pic = 508; wait = 1f; next = JumpAttack3_634; OnGround(Crouch_290);
        BdyDefault();
        ApplyDefaultPhysic(dvx: 1, null, null, facingRight);
    }
    private void JumpAttack3_634()
    {
        pic = 509; wait = 0.5f; next = JumpAttack3_635; OnGround(Crouch_290);
        BdyDefault();
        itr.x = 0.3009f; itr.y = 0.2021f; itr.z = 0;
        itr.w = 0.3324678f; itr.h = 0.3716239f; itr.zwidth = 0.22f;
        itr.dvx = 100; itr.dvy = -400; itr.dvz = 0; itr.action = 820;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.NORMAL; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
    }
    private void JumpAttack3_635()
    {
        pic = 510; wait = 0.5f; next = JumpAttack3_636; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack3_636()
    {
        ItrDisable();
        pic = 511; wait = 8f; next = JumpAttack3_637; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack3_637()
    {
        pic = 512; wait = 0.5f; next = JumpAttack3_638; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack3_638()
    {
        ResetMovementFromStop();
        pic = 513; wait = 0.5f; next = JumpAttack3_639; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack3_639()
    {
        pic = 513; wait = 2f; next = JumpAttack3_640; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpAttack3_640()
    {
        pic = 513; wait = 1f; next = JumpAttack3_640; OnGround(Crouch_290);
        BdyDefault();
    }
    #endregion

    #region JumpCombo
    private void JumpCombo_650()
    {
        pic = 129; wait = 4f; next = JumpCombo_651; Defense(DashBackward_130);
        BdyDefault();
    }
    private void JumpCombo_651()
    {
        pic = 130; wait = 0.5f; next = JumpCombo_652;
        BdyDefault();
    }
    private void JumpCombo_652()
    {
        pic = 131; wait = 0.5f; next = JumpCombo_653;
        BdyDefault();
    }
    private void JumpCombo_653()
    {
        pic = 132; wait = 2f; next = JumpCombo_654; dvx = 80; dvy = 300; dvz = 80;
        BdyDefault();
        ApplyPhysicJumping(); DoubleTapJump(DoubleJumpCombo_670);
    }
    private void JumpCombo_654()
    {
        ;
        pic = 133; wait = 8f; next = JumpComboFalling_660; Defense(StartJumpDefense_300); state = StateFrameEnum.JUMP_COMBO_ATTACK;
        DoubleTapJump(DoubleJumpCombo_670); Attack(JumpAttack1_590);
        BdyDefault();
    }
    #endregion

    #region JumpComboFalling
    private void JumpComboFalling_660()
    {
        pic = 134; wait = 0.5f; next = JumpComboFalling_661; Defense(StartJumpDefense_300);
        OnGround(Crouch_290); Jump(DoubleJumpCombo_670); Attack(JumpAttack1_590);
        BdyDefault();
    }
    private void JumpComboFalling_661()
    {
        pic = 135; wait = 1f; next = JumpComboFalling_661; Defense(StartJumpDefense_300);
        OnGround(Crouch_290); Jump(DoubleJumpCombo_670); Attack(JumpAttack1_590);
        BdyDefault();
    }
    #endregion

    #region DoubleJumpCombo
    private void DoubleJumpCombo_670()
    {
        pic = 129; wait = 1; next = DoubleJumpCombo_671;
        BdyDefault();
    }
    private void DoubleJumpCombo_671()
    {
        pic = 130; wait = 0.5f; next = DoubleJumpCombo_672;
        BdyDefault();
    }
    private void DoubleJumpCombo_672()
    {
        pic = 132; wait = 1f; next = DoubleJumpCombo_673; dvx = 80; dvy = 225; dvz = 80;
        BdyDefault();
        ApplyPhysicJumping();
    }
    private void DoubleJumpCombo_673()
    {
        pic = 133; wait = 8f; next = DoubleJumpCombo_673; Defense(StartJumpDefense_300); Attack(JumpAttack1_590);
        BdyDefault();
    }
    #endregion

    #region DoubleJumpFalling
    private void DoubleJumpFalling_680()
    {
        pic = 134; wait = 0.5f; next = DoubleJumpFalling_681; Defense(StartJumpDefense_300);
        OnGround(Crouch_290); Attack(JumpAttack1_590);
        BdyDefault();
    }
    private void DoubleJumpFalling_681()
    {
        pic = 135; wait = 1f; next = DoubleJumpFalling_681; Defense(StartJumpDefense_300);
        OnGround(Crouch_290); Attack(JumpAttack1_590);
        BdyDefault();
    }
    #endregion

    #region InjuredManager
    private void InjuredManager_700()
    {
        var optionInjured = UnityEngine.Random.value; CancelOpoints();
        pic = 107; wait = 2f; next = optionInjured > 0.5f ? Injured1_702 : Injured2_710;
        BdyDefault();
    }
    #endregion

    #region Injured1
    private void Injured1_702()
    {
        ResetMovementFromStop();
        pic = 600; wait = 3f; next = Injured1_703; Defense(CriticalDefense_880);
        BdyDefault();
        ApplyExternPhysic();
    }
    private void Injured1_703()
    {
        pic = 600; wait = 15f; next = Standing_0; InAir(Falling_801);
        BdyDefault();
        StopMovement();
    }
    #endregion

    #region Injured2
    private void Injured2_710()
    {
        ResetMovementFromStop();
        pic = 601; wait = 3f; next = Injured2_711; Defense(CriticalDefense_880);
        BdyDefault();
        ApplyExternPhysic();
    }

    private void Injured2_711()
    {
        pic = 601; wait = 15f; next = Standing_0; InAir(Falling_801);
        BdyDefault();
        StopMovement();
    }
    #endregion

    #region InjuredSkyManager
    private void InjuredSkyManager_720()
    {
        var optionInjured = UnityEngine.Random.value; CancelOpoints();
        pic = 107; wait = 2f; next = optionInjured > 0.5f ? InjuredSky1_722 : InjuredSky2_730;
        BdyDefault();
    }
    #endregion

    #region InjuredSky1
    private void InjuredSky1_722()
    {
        ResetMovementFromStop();
        pic = 600; wait = 3f; next = InjuredSky1_723; Defense(JumpCriticalDefense_885);
        BdyDefault();
        ApplyExternPhysic();
    }

    private void InjuredSky1_723()
    {
        pic = 600; wait = 1f; next = InjuredSky1_724;
        BdyDefault();
        StopMovement();
    }
    private void InjuredSky1_724()
    {
        pic = 600; wait = 10f; next = Falling_801;
        BdyDefault();
    }
    #endregion

    #region InjuredSky2
    private void InjuredSky2_730()
    {
        ResetMovementFromStop();
        pic = 601; wait = 3f; next = InjuredSky2_731; Defense(JumpCriticalDefense_885);
        BdyDefault();
        ApplyExternPhysic();
    }
    private void InjuredSky2_731()
    {
        pic = 601; wait = 1f; next = InjuredSky2_733;
        BdyDefault();
        StopMovement();
    }
    private void InjuredSky2_733()
    {
        pic = 601; wait = 10f; next = Falling_801;
        BdyDefault();
    }
    #endregion

    #region Falling
    private void FallingHit_800()
    {
        ResetMovementFromStop(); CancelOpoints();
        pic = 603; wait = 2f; next = Falling_801;
        BdyDefault();
        ApplyExternPhysic();
    }
    private void Falling_801()
    {
        ResetMovementFromStop();
        pic = 604; wait = 2f; next = Falling_802; OnGround(Lying_910);
        BdyDefault();
    }
    private void Falling_802()
    {
        pic = 605; wait = 2f; next = Falling_803; OnGround(Lying_910);
        BdyDefault();
    }
    private void Falling_803()
    {
        pic = 606; wait = 0.5f; next = Falling_804; OnGround(Lying_910);
        BdyDefault();
    }
    private void Falling_804()
    {
        pic = 607; wait = 2f; next = Falling_805; OnGround(Lying_910);
        BdyDefault();
    }
    private void Falling_805()
    {
        pic = 608; wait = 0.5f; next = Falling_806; OnGround(Lying_910);
        BdyDefault();
    }
    private void Falling_806()
    {
        pic = 608; wait = 2f; next = Falling_806; OnGround(Lying_910);
        BdyDefault();
    }
    #endregion

    #region FallingDown
    private void FallingDown_820()
    {
        ResetMovementFromStop(); CancelOpoints();
        pic = 623; wait = 2f; next = FallingDown_821; OnGround(FallingDownImpact_825);
        BdyDefault();
        ApplyExternPhysic();
    }
    private void FallingDown_821()
    {
        pic = 614; wait = 0.5f; next = FallingDown_822; OnGround(FallingDownImpact_825);
        BdyDefault();
    }
    private void FallingDown_822()
    {
        pic = 615; wait = 2f; next = FallingDown_822; OnGround(FallingDownImpact_825);
        BdyDefault();
    }

    private void FallingDownImpact_825()
    {
        pic = 626; wait = 2f; next = FallingDownImpact_826;
        BdyDefault();
        SpawnOpoint(IMPACT_DOWN_OPOINT, Opoint(x: 0.13f, y: 0, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
    }
    private void FallingDownImpact_826()
    {
        pic = 627; wait = 2f; next = FallingDownImpact_827;
        BdyDefault();
    }
    private void FallingDownImpact_827()
    {
        pic = 628; wait = 2f; next = FallingDownImpact_828;
        BdyDefault();
    }
    private void FallingDownImpact_828()
    {
        pic = 629; wait = 2f; next = FallingDownImpact_829;
        BdyDefault();
    }
    private void FallingDownImpact_829()
    {
        pic = 630; wait = 2f; next = Lying_910;
        BdyDefault();
    }
    #endregion

    #region FallingUp
    private void FallingUp_840()
    {
        ResetMovementFromStop(); CancelOpoints();
        pic = 609; wait = 2f; next = FallingUp_841;
        OnCeil(FallingUpImpact_850);
        BdyDefault();
        ApplyExternPhysic();
    }
    private void FallingUp_841()
    {
        pic = 609; wait = 0.5f; next = FallingUp_842;
        OnCeil(FallingUpImpact_850);
        BdyDefault();
    }
    void FallingUp_842()
    {
        pic = 610; wait = 10f; next = FallingUp_843; OnGround(Lying_910);
        OnCeil(FallingUpImpact_850);
        BdyDefault();
    }
    private void FallingUp_843()
    {
        pic = 611; wait = 0.5f; next = FallingUp_844; OnGround(Lying_910);
        OnCeil(FallingUpImpact_850);
        BdyDefault();
    }
    private void FallingUp_844()
    {
        pic = 612; wait = 0.5f; next = FallingUp_845; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUp_845()
    {
        pic = 613; wait = 0.5f; next = FallingUp_846; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUp_846()
    {
        pic = 614; wait = 0.5f; next = FallingUp_847; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUp_847()
    {
        pic = 615; wait = 0.5f; next = FallingUp_848; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUp_848()
    {
        pic = 615; wait = 2f; next = FallingUp_848; OnGround(Lying_910);
        BdyDefault();
    }

    private void FallingUpImpact_850()
    {
        pic = 602; wait = 2f; next = FallingUpImpact_851;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 0, dvy: -320, dvz: 0, facingRight);
        SpawnOpoint(IMPACT_UP_OPOINT, Opoint(x: 0.13f, y: 0, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
    }
    private void FallingUpImpact_851()
    {
        pic = 605; wait = 2f; next = FallingUpImpact_852; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUpImpact_852()
    {
        pic = 606; wait = 2f; next = FallingUpImpact_853; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUpImpact_853()
    {
        pic = 614; wait = 2f; next = FallingUpImpact_854; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUpImpact_854()
    {
        pic = 615; wait = 2f; next = FallingUpImpact_854; OnGround(Lying_910);
        BdyDefault();
    }
    #endregion

    #region FallingForwardImpact
    private void FallingForwardtHit_860()
    {
        ResetMovementFromStop(); CancelOpoints();
        pic = 616; wait = 2f; next = FallingForward_861;
        BdyDefault();
        ApplyExternPhysic();
    }
    private void FallingForward_861()
    {
        pic = 617; wait = 0.5f; next = FallingForward_862; OnGround(Lying_910);
        OnWall(FallingForwardImpact_870);
        BdyDefault();
    }
    private void FallingForward_862()
    {
        pic = 618; wait = 2f; next = FallingForward_863; OnGround(Lying_910);
        OnWall(FallingForwardImpact_870);
        BdyDefault();
    }
    private void FallingForward_863()
    {
        pic = 619; wait = 2f; next = FallingForward_863; OnGround(Lying_910);
        OnWall(FallingForwardImpact_870);
        BdyDefault();
    }

    private void FallingForwardImpact_870()
    {
        pic = 601; wait = 2f; next = FallingForwardImpact_871;
        BdyDefault();
        SpawnOpoint(IMPACT_FORWARD_OPOINT, Opoint(x: -0.17f, y: 0, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
    }
    private void FallingForwardImpact_871()
    {
        pic = 611; wait = 2f; next = FallingForwardImpact_872;
        BdyDefault();
    }
    private void FallingForwardImpact_872()
    {
        pic = 621; wait = 2f; next = FallingForwardImpact_873;
        BdyDefault();
    }
    private void FallingForwardImpact_873()
    {
        pic = 622; wait = 2f; next = FallingForwardImpact_874;
        BdyDefault();
    }
    private void FallingForwardImpact_874()
    {
        pic = 623; wait = 2f; next = FallingForwardImpact_874; OnGround(Lying_910);
        BdyDefault();
    }
    #endregion

    #region CriticalDefense
    private void CriticalDefense_880()
    {
        if (canParry)
        {
            spriteRenderer.color = parryColor;
            currentHp += lastDamage > 0 ? lastDamage : 0;
            canParry = false;
        }
        pic = 136; wait = 1f; next = CriticalDefense_881; Attack(Attack1_350);
        BdyDefault();
    }
    private void CriticalDefense_881()
    {
        pic = 136; wait = 1f; next = StopDefense_152; Attack(Attack1_350);
        BdyDefault();
        SpawnOpoint(JUMPING_COMBO_OPOINT, Opoint(x: 0f, y: 0.3f, z: -0.13f, oid: 0, facingFront: true, quantity: 1));
    }
    #endregion

    #region JumpCriticalDefense
    private void JumpCriticalDefense_885()
    {
        if (canParry)
        {
            spriteRenderer.color = parryColor;
            currentHp += lastDamage > 0 ? lastDamage : 0;
            canParry = false;
        }
        pic = 137; wait = 1f; next = JumpCriticalDefense_886; Attack(JumpAttack1_590);
        BdyDefault();
    }
    private void JumpCriticalDefense_886()
    {
        pic = 137; wait = 1f; next = StopJumpDefense_302; Attack(JumpAttack1_590);
        BdyDefault();
        SpawnOpoint(JUMPING_COMBO_OPOINT, Opoint(x: 0.11f, y: 0.25f, z: -0.12f, oid: 0, facingFront: true, quantity: 1));
    }
    #endregion

    #region Lying
    private void Lying_910()
    {
        StopMovement(); CancelOpoints();
        pic = 626; wait = 2f; next = Lying_911; Jump(JumpRecover_930);
        BdyDefault();
    }
    private void Lying_911()
    {
        ResetMovementFromStop();
        pic = 627; wait = 2f; next = Lying_912;
        BdyDefault();
    }
    private void Lying_912()
    {
        pic = 628; wait = 2f; next = Lying_913;
        BdyDefault();
    }
    private void Lying_913()
    {
        pic = 629; wait = 2f; next = Lying_914;
        BdyDefault();
    }
    private void Lying_914()
    {
        pic = 630; wait = 50f; next = LyingUp_920;
        BdyDefault();
    }

    private void LyingUp_920()
    {
        pic = 631; wait = 2f; next = LyingUp_921;
        BdyDefault();
    }
    private void LyingUp_921()
    {
        pic = 632; wait = 2f; next = LyingUp_922;
        BdyDefault();
    }
    private void LyingUp_922()
    {
        pic = 633; wait = 2f; next = LyingUp_923;
        BdyDefault();
    }
    private void LyingUp_923()
    {
        pic = 634; wait = 1f; next = LyingUp_924;
        BdyDefault();
    }
    private void LyingUp_924()
    {
        pic = 634; wait = 1f; next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region JumpRecover
    private void JumpRecover_930()
    {
        spriteRenderer.color = parryColor; CancelOpoints();
        pic = 129; wait = 1f; next = JumpRecover_931;
        BdyDefault();
        SpawnOpoint(JUMP_RECOVER_OPOINT, Opoint(x: 0.11f, y: 0.25f, z: 0.08f, oid: 0, facingFront: true, quantity: 1));
    }
    private void JumpRecover_931()
    {
        pic = 129; wait = 2f; next = Crouch_290;
        BdyDefault();
    }
    #endregion

    #region Catch Invisible
    private void CatchInvisible_950()
    {
        repeatCount = 250;
        ResetMovementFromStop(); CancelOpoints();
        pic = -9999; wait = 2f; next = CatchInvisible_951;
        BdyDefault();
        bdy.kind = BdyKindEnum.INVULNERABLE;
    }
    private void CatchInvisible_951()
    {
        RepeatCountToFrame(Falling_801);
        ResetMovementFromStop(); CancelOpoints();
        pic = -9999; wait = 2f; next = CatchInvisible_951;
        BdyDefault();
        bdy.kind = BdyKindEnum.INVULNERABLE;
    }
    #endregion
}