using Enums;
using UnityEngine;

public class NsGaaraBase : CharController
{
    public static string SAND_BULLET_OPOINT = "sand_bullet";
    public static string DEMON_ARM_SAND_OPOINT = "demon_arm_sand";
    public static string SHIELD_2_OPOINT = "shield_2";
    public static string ATTACKSAND_1_OPOINT = "attackSand_1";
    public static string ATTACKSAND_2_OPOINT = "attackSand_2";
    public static string ATTACKSAND_3_OPOINT = "attackSand_3";
    public static string ATTACKSAND_4_OPOINT = "attackSand_4";
    public static string ATTACKSAND_5_OPOINT = "attackSand_5";
    public static string ATTACKSAND_6_OPOINT = "attackSand_6";
    public static string SHIELD_ATTACK_2_OPOINT = "shield_attack_2";
    public static string SHIELD_1_OPOINT = "shield_1";
    public static string SAND_FLOAT_OPOINT = "sand_float";
    public static string SAND_SPEAR_OPOINT = "sand_spear";
    public static string SAND_PRISON_OPOINT = "sand_prison";
    public static string DEMON_ARM_SAND_ROTATE_OPOINT = "demon_arm_sand_rotate"; //For rotate in float
    public static string SAND_SPEAR_ROTATE_OPOINT = "sand_spear_rotate";//For rotate in float
    void Awake()
    {
        palettes.Add("Chars/gaara/ns-gaara-base/sprites");
        base.Awake();
        header = new()
        {
            name = "Gaara",
        };
        stats = new()
        {
            aggressive = 5,
            technique = 10,
            intelligent = 8,
            speed = 5,
            resistance = 7,
            stamina = 10,
        };

        manaTechniqueValue = ResolveAdditionalManaPoint();
        speedValue = ResolveAdditionalSpeedPoint();
        additionalDamage = ResolveAdditionalDamagePoint();
        
        opoints.Add(SAND_BULLET_OPOINT, EnrichOpoint(6, "Attacks/Weapons/sand-bullet/sand-bullet"));
        opoints.Add(DEMON_ARM_SAND_OPOINT, EnrichOpoint(2, "Attacks/Techs/sand/demon-arm/demon-arm-sand"));
        opoints.Add(SHIELD_2_OPOINT, EnrichOpoint(2, "Attacks/Techs/sand/shield-2/shield-2"));
        opoints.Add(ATTACKSAND_1_OPOINT, EnrichOpoint(4, "Attacks/Techs/sand/attack-1/attackSand-1"));
        opoints.Add(ATTACKSAND_2_OPOINT, EnrichOpoint(4, "Attacks/Techs/sand/attack-2/attackSand-2"));
        opoints.Add(ATTACKSAND_3_OPOINT, EnrichOpoint(4, "Attacks/Techs/sand/attack-3/attackSand-3"));
        opoints.Add(ATTACKSAND_4_OPOINT, EnrichOpoint(4, "Attacks/Techs/sand/attack-4/attackSand-4"));
        opoints.Add(ATTACKSAND_5_OPOINT, EnrichOpoint(4, "Attacks/Techs/sand/attack-5/attackSand-5"));
        opoints.Add(ATTACKSAND_6_OPOINT, EnrichOpoint(8, "Attacks/Techs/sand/attack-6/attackSand-6"));
        opoints.Add(SHIELD_ATTACK_2_OPOINT, EnrichOpoint(2, "Attacks/Techs/sand/shield-2/shield-attack-2"));
        opoints.Add(SHIELD_1_OPOINT, EnrichOpoint(2, "Attacks/Techs/sand/shield-1/shield-1"));
        opoints.Add(SAND_FLOAT_OPOINT, EnrichOpoint(2, "Attacks/Techs/sand/float/sand-float"));
        opoints.Add(SAND_SPEAR_OPOINT, EnrichOpoint(4, "Attacks/Techs/sand/spear/sand-spear"));
        opoints.Add(SAND_PRISON_OPOINT, EnrichOpoint(2, "Attacks/Techs/sand/prison/sand-prison"));
        opoints.Add(DEMON_ARM_SAND_ROTATE_OPOINT, EnrichOpoint(2, "Attacks/Techs/sand/demon-arm/demon-arm-sand")); //For rotate in float
        opoints.Add(SAND_SPEAR_ROTATE_OPOINT, EnrichOpoint(4, "Attacks/Techs/sand/spear/sand-spear"));//For rotate in float

        soloTechSide = SandSpear_1200;
        soloTech = SandShield_1100;
        soloTechDown = Erupcao_1250;
        soloTechUp = ArmMonster_1000;
        airTech = SandFloat_1150;
        superTech = SandPrison_1300;

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
        StopMovement(); CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
        ResetMovementFromStop();
        pic = 112; state = StateFrameEnum.STANDING; wait = 3f; next = Standing_1;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        DoubleTapPowerSide(soloTechSide); DoubleTapPower(soloTech); DoubleTapPowerDown(soloTechDown); DoubleTapPowerUp(soloTechUp); SuperPower(superTech);
        ResetParams();
    }

    private void Standing_1()
    {
        pic = 113; state = StateFrameEnum.STANDING; wait = 3f; next = Standing_2;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        DoubleTapPowerSide(soloTechSide); DoubleTapPower(soloTech); DoubleTapPowerDown(soloTechDown); DoubleTapPowerUp(soloTechUp); SuperPower(superTech);
        ResetParams();
    }
    private void Standing_2()
    {
        pic = 114; state = StateFrameEnum.STANDING; wait = 3f; next = Standing_3;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        DoubleTapPowerSide(soloTechSide); DoubleTapPower(soloTech); DoubleTapPowerDown(soloTechDown); DoubleTapPowerUp(soloTechUp); SuperPower(superTech);
        ResetParams();
    }
    private void Standing_3()
    {
        pic = 115; state = StateFrameEnum.STANDING; wait = 3f; next = Standing_4;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        DoubleTapPowerSide(soloTechSide); DoubleTapPower(soloTech); DoubleTapPowerDown(soloTechDown); DoubleTapPowerUp(soloTechUp); SuperPower(superTech);
        ResetParams();
    }
    private void Standing_4()
    {
        pic = 116; state = StateFrameEnum.STANDING; wait = 3f; next = Standing_5;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        DoubleTapPowerSide(soloTechSide); DoubleTapPower(soloTech); DoubleTapPowerDown(soloTechDown); DoubleTapPowerUp(soloTechUp); SuperPower(superTech);
        ResetParams();
    }
    private void Standing_5()
    {
        pic = 117; state = StateFrameEnum.STANDING; wait = 3f; next = Standing_0;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanWalking(Walking_20);
        ApplyPhysicStanding();
        CanSimpleDash(SimpleDash_40); CanSideDash(SideDash_90); Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingNoAction_308);
        DoubleTapPowerSide(soloTechSide); DoubleTapPower(soloTech); DoubleTapPowerDown(soloTechDown); DoubleTapPowerUp(soloTechUp); SuperPower(superTech);
        ResetParams();
    }
    #endregion

    #region Walking
    private void Walking_20()
    {
        pic = 118; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_21; CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_21()
    {
        pic = 119; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_22;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_22()
    {
        pic = 120; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_23;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_23()
    {
        pic = 121; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_24;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_24()
    {
        pic = 122; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_25;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_25()
    {
        pic = 123; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_26;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_26()
    {
        pic = 124; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_27;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_27()
    {
        pic = 125; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_28;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_28()
    {
        pic = 126; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_29;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_29()
    {
        pic = 127; state = StateFrameEnum.WALKING; wait = 0.5f; dvx = 3f; dvz = 3f; next = Walking_30;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    private void Walking_30()
    {
        pic = 128; state = StateFrameEnum.WALKING; wait = 2f; dvx = 3f; dvz = 3f; next = Walking_20;
        BdyDefault();
        CanFlip();
        CanStandingFromWalking(Standing_0);
        Jump(Jump_210); Taunt(Taunt_195);
        Defense(Start_Defense_150); Attack(Attack1_350); InAir(JumpFallingWhenXMove_298);
        PowerSide(soloTechSide); Power(soloTech); PowerDown(soloTechDown); PowerUp(soloTechUp); SuperPower(superTech);
        ApplyPhysicWalking();
        ManageWalking();
    }
    #endregion

    #region SimpleDash
    private void SimpleDash_40()
    {
        pic = 118; state = StateFrameEnum.SIMPLE_DASH; wait = 0.5f; dvx = 450f; dvy = 0f; dvz = 0f;
        next = SimpleDash_41;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
    }

    private void SimpleDash_41()
    {
        pic = 129; state = StateFrameEnum.SIMPLE_DASH; wait = 1.5f; dvx = 0f; dvy = 0f; dvz = 0f;
        next = SimpleDash_42;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
    }

    private void SimpleDash_42()
    {
        CanHoldForwardAfter(Running_55);
        pic = 130; state = StateFrameEnum.SIMPLE_DASH; wait = 0.5f; dvx = 0f; dvy = 0f; dvz = 0f;
        next = SimpleDash_43;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        BdyDefault();
    }

    private void SimpleDash_43()
    {
        StopMovement();
        CanHoldForwardAfter(Running_55);
        pic = 131; state = StateFrameEnum.SIMPLE_DASH; wait = 0.5f; dvx = 0f; dvy = 0f; dvz = 0f;
        next = SimpleDashStopRunning_44;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        BdyDefault();
    }

    private void SimpleDashStopRunning_44()
    {
        ResetMovementFromStop();
        CanHoldForwardAfter(Running_55);
        pic = 131; state = StateFrameEnum.SIMPLE_DASH; wait = 4f; dvx = 150f; dvy = 0; dvz = 0;
        next = StopRunning_62;
        Attack(RunningAttack_330); Defense(RunningDash_70); Jump(DashJump_250);
        BdyDefault();
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    #endregion

    #region Running
    private void Running_45()
    {
        pic = 118; state = StateFrameEnum.RUNNING; wait = 1.5f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_46;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
    }
    private void Running_46()
    {
        pic = 119; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_47;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
    }
    private void Running_47()
    {
        pic = 120; state = StateFrameEnum.RUNNING; wait = 1f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_48;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_48()
    {
        pic = 121; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_49;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_49()
    {
        pic = 122; state = StateFrameEnum.RUNNING; wait = 1f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_50;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_50()
    {
        pic = 123; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_51;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_51()
    {
        pic = 124; state = StateFrameEnum.RUNNING; wait = 1f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_52;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_52()
    {
        pic = 125; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_53;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }

    private void Running_53()
    {
        pic = 126; state = StateFrameEnum.RUNNING; wait = 1f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_54;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }
    private void Running_54()
    {
        pic = 127; state = StateFrameEnum.RUNNING; wait = 0.5f; dvx = speedValue; dvy = 0f; dvz = 3f;
        next = Running_55;
        Jump(DashJump_250); Defense(RunningDash_70); Attack(RunningAttack_330);
        InAir(JumpFallingWhenXMove_298); CanStopRunning(StopRunning_60); ApplyPhysicRunning();
        BdyDefault();
    }
    private void Running_55()
    {
        pic = 128; state = StateFrameEnum.RUNNING; wait = 1f; dvx = speedValue; dvy = 0f; dvz = 3f;
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
        pic = 131; state = StateFrameEnum.STOP_RUNNING; wait = 1f; dvx = 0; dvy = 0; dvz = 0;
        next = StopRunning_61;
        Attack(RunningAttack_330);
        BdyDefault();
    }
    private void StopRunning_61()
    {
        ResetMovementFromStop();
        pic = 131; state = StateFrameEnum.STOP_RUNNING; wait = 4f; dvx = 150f; dvy = 0; dvz = 0;
        next = StopRunning_62;
        Attack(RunningAttack_330);
        BdyDefault();
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    private void StopRunning_62()
    {
        pic = 131; state = StateFrameEnum.STOP_RUNNING; wait = 1f; dvx = 0f; dvy = 0f; dvz = 0f;
        next = Standing_0;
        Attack(RunningAttack_330);
        BdyDefault();
        StopMovement();
    }
    #endregion

    #region RunningDash
    private void RunningDash_70()
    {
        pic = 118; state = StateFrameEnum.DASH; wait = 2f;
        next = RunningDash_71;
        BdyDefault();
        StopMovement();
    }
    private void RunningDash_71()
    {
        ResetMovementFromStop();
        pic = 129; state = StateFrameEnum.DASH; wait = 0.5f; dvx = 600; dvy = 0; dvz = 200;
        next = RunningDash_72;
        BdyDefault();
        ApplyPhysicDash();
    }
    private void RunningDash_72()
    {
        pic = 130; state = StateFrameEnum.DASH; wait = 5f;
        next = RunningDash_73;
        BdyDefault();
    }
    private void RunningDash_73()
    {
        pic = 130; state = StateFrameEnum.DASH; wait = 0.5f;
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
        pic = 131; state = StateFrameEnum.JUMPING; wait = 1.5f;
        next = DashBackward_131;
        BdyDefault();
    }
    private void DashBackward_131()
    {
        ResetMovementFromStop();
        pic = 132; state = StateFrameEnum.JUMPING; wait = 1f; dvx = -200; dvy = 175; dvz = 0;
        next = DashBackward_132;
        BdyDefault(); ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    private void DashBackward_132()
    {
        pic = 136; state = StateFrameEnum.JUMPING; wait = 0.5f;
        next = DashBackward_133;
        BdyDefault(); Power(airTech); PowerSide(airTech);
    }
    private void DashBackward_133()
    {
        pic = 137; state = StateFrameEnum.JUMPING; wait = 6f;
        next = DashBackward_134; OnGround(Crouch_290);
        BdyDefault(); Power(airTech); PowerSide(airTech);
    }
    private void DashBackward_134()
    {
        pic = 137; state = StateFrameEnum.JUMPING; wait = 6f;
        next = DashBackward_134; OnGround(Crouch_290);
        BdyDefault(); Power(airTech); PowerSide(airTech);
    }
    #endregion

    #region Defense
    private void Start_Defense_150()
    {
        releaseDefenseButton = false;
        pic = 301; state = StateFrameEnum.DEFEND; wait = 1f;
        next = Defense_151; Attack(ThrowingWeapon_310); Power(ChargeStart_170);
        Jump(DashBackward_130);
        BdyDefault();
        opointsControl = null;
    }
    private void Defense_151()
    {
        StopMovement();
        releaseDefenseButton = false;
        pic = 302; state = StateFrameEnum.DEFEND; wait = 2f;
        next = StopDefense_152; CanHoldDefenseAfter(DefenseHold_155);
        Attack(ThrowingWeapon_310); Power(ChargeStart_170); Jump(DashBackward_130);
        BdyDefault();
        if (opointsControl == null)
        {
            opointsControl = SpawnOpoint(SHIELD_2_OPOINT, Opoint(x: 0.25f, y: 0f, z: -0.05f, oid: 0, facingFront: true, quantity: 1));
        }
    }
    private void StopDefense_152()
    {
        pic = 301; state = StateFrameEnum.OTHER; wait = 1f;
        next = Standing_0; Attack(ThrowingWeapon_310); Power(ChargeStart_170);
        Jump(DashBackward_130);
        BdyDefault();
        if (opointsControl != null && opointsControl.Count > 0)
        {
            opointsControl = null;
        }
    }
    private void DefenseHold_155()
    {
        releaseDefenseButton = false;
        if (opointsControl.Count > 0)
        {
            opointsControl[0].currentRepeat = 0;
        }
        pic = 302; state = StateFrameEnum.DEFEND; wait = 1f;
        next = Defense_151;
        Attack(ThrowingWeapon_310); Power(ChargeStart_170); Jump(DashBackward_130);
        BdyDefault();
    }

    private void HitDefense_160()
    {
        pic = 302; state = StateFrameEnum.DEFEND; wait = 1f;
        next = HitDefense_161; CanHoldDefenseAfter(Defense_151);
        Attack(ThrowingWeapon_310); Power(ChargeStart_170); Jump(DashBackward_130);
        BdyDefault();
        SpawnOpoint(DEFENSE_HIT_OPOINT, Opoint(x: 0f, y: 0.35f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
        ApplyExternPhysic();
    }
    private void HitDefense_161()
    {
        StopMovement();
        pic = 302; state = StateFrameEnum.DEFEND; wait = 2.5f;
        next = StopDefense_152; CanHoldDefenseAfter(Defense_151);
        Attack(ThrowingWeapon_310); Power(ChargeStart_170); Jump(DashBackward_130);
        BdyDefault();
    }
    #endregion

    #region Charge
    private void ChargeStart_170()
    {
        pic = 201; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStart_171;
        BdyDefault();
    }
    private void ChargeStart_171()
    {
        pic = 202; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStart_172;
        BdyDefault();
    }
    private void ChargeStart_172()
    {
        pic = 203; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStart_173;
        BdyDefault();
    }
    private void ChargeStart_173()
    {
        pic = 204; state = StateFrameEnum.OTHER; wait = 1f;
        next = Charge_175;
        BdyDefault();
    }

    private void Charge_175()
    {
        AddManaPoints(manaTechniqueValue);
        pic = 203; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = Charge_176; Attack(ChargeStop_190); DoubleTapPower(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
        SpawnOpoint(CHAKRA_CHARGE_OPOINT, Opoint(x: 0.05f, y: 0.4f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Charge_176()
    {
        EnableManaPoints();
        pic = 202; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = Charge_177; Attack(ChargeStop_190); DoubleTapPower(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
        SpawnOpoint(CHAKRA_CHARGE_AURA_OPOINT, Opoint(x: 0f, y: 0.014f, z: 0f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Charge_177()
    {
        pic = 203; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = Charge_178; Attack(ChargeStop_190); DoubleTapPower(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
        SpawnOpoint(CHAKRA_CHARGE_SMOKE_OPOINT, Opoint(x: 0f, y: 0.109f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Charge_178()
    {
        pic = 204; state = StateFrameEnum.OTHER; wait = 3f;
        next = Charge_179; Attack(ChargeStop_190); DoubleTapPower(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }
    private void Charge_179()
    {
        pic = 203; state = StateFrameEnum.OTHER; wait = 2f;
        next = Charge_180; Attack(ChargeStop_190); DoubleTapPower(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }
    private void Charge_180()
    {
        pic = 202; state = StateFrameEnum.OTHER; wait = 2f;
        next = Charge_181; Attack(ChargeStop_190); DoubleTapPower(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }
    private void Charge_181()
    {
        pic = 203; state = StateFrameEnum.OTHER; wait = 2f;
        next = Charge_182; Attack(ChargeStop_190); DoubleTapPower(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }
    private void Charge_182()
    {
        pic = 204; state = StateFrameEnum.OTHER; wait = 2f;
        next = Charge_175; Attack(ChargeStop_190); DoubleTapPower(ChargeStop_190); Defense(ChargeStop_190);
        Jump(ChargeStop_190);
        BdyDefault();
    }

    private void ChargeStop_190()
    {
        pic = 203; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStop_191;
        BdyDefault();
    }
    private void ChargeStop_191()
    {
        pic = 202; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStop_192;
        BdyDefault();
    }
    private void ChargeStop_192()
    {
        pic = 201; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeStop_193;
        BdyDefault();
    }
    private void ChargeStop_193()
    {
        pic = 201; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = ChargeStop_194;
        BdyDefault();
    }
    private void ChargeStop_194()
    {
        pic = 201; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Taunt
    private void Taunt_195()
    {
        pic = 102; wait = 2f; next = Taunt_196;
        BdyDefault();
    }
    private void Taunt_196()
    {
        pic = 103; wait = 0.5f; next = Taunt_197;
        BdyDefault();
    }
    private void Taunt_197()
    {
        pic = 104; wait = 2f; next = Taunt_198;
        BdyDefault();
    }
    private void Taunt_198()
    {
        pic = 105; wait = 0.5f; next = Taunt_199;
        BdyDefault();
    }
    private void Taunt_199()
    {
        pic = 106; wait = 2f; next = Taunt_200;
        BdyDefault();
    }
    private void Taunt_200()
    {
        pic = 107; wait = 0.5f; next = Taunt_201;
        BdyDefault();
    }
    private void Taunt_201()
    {
        pic = 108; wait = 2f; next = Taunt_202;
        BdyDefault();
    }
    private void Taunt_202()
    {
        pic = 109; wait = 2f; next = Taunt_203;
        BdyDefault();
    }
    private void Taunt_203()
    {
        pic = 110; wait = 2f; next = Taunt_204;
        BdyDefault();
    }
    private void Taunt_204()
    {
        pic = 111; wait = 2f; next = Taunt_205;
        BdyDefault();
    }
    private void Taunt_205()
    {
        pic = 111; wait = 2f; next = Taunt_206;
        BdyDefault();
    }
    private void Taunt_206()
    {
        pic = 111; wait = 2f; next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Jump
    private void Jump_210()
    {
        StopMovement();
        pic = 131; state = StateFrameEnum.JUMPING; wait = 4f;
        next = Jump_211; Defense(DashBackward_130);
        BdyDefault();
    }
    private void Jump_211()
    {
        pic = 131; state = StateFrameEnum.JUMPING; wait = 0.5f;
        next = Jump_212; Defense(DashBackward_130);
        BdyDefault();
    }
    private void Jump_212()
    {
        ResetMovementFromStop();
        pic = 132; state = StateFrameEnum.JUMPING; wait = 0.5f; dvx = 80; dvy = 300; dvz = 80;
        next = Jump_213;
        BdyDefault();
        ApplyPhysicJumping();
    }
    private void Jump_213()
    {
        pic = 133; state = StateFrameEnum.JUMPING; wait = 1f;
        next = Jump_214; DoubleTapJump(DoubleJump_230);
        BdyDefault();
        CanFlip(); CountJumpDash(); CanJumpDash(JumpDash_270); Power(airTech); PowerSide(airTech);
    }
    private void Jump_214()
    {
        pic = 133; state = StateFrameEnum.JUMPING; wait = 8f;
        next = JumpFalling_220; DoubleTapJump(DoubleJump_230);
        Defense(StartJumpDefense_300); Attack(JumpSuperAttack_550);
        BdyDefault();
        CanFlip(); CountJumpDash(); CanJumpDash(JumpDash_270); Power(airTech); PowerSide(airTech);
    }

    private void JumpFalling_220()
    {
        pic = 134; state = StateFrameEnum.JUMPING; wait = 1f;
        next = JumpFalling_221; DoubleTapJump(DoubleJump_230);
        Defense(StartJumpDefense_300); OnGround(Crouch_290); Attack(JumpSuperAttack_550);
        BdyDefault();
        CanFlip(); CountJumpDash(); CanJumpDash(JumpDash_270); Power(airTech); PowerSide(airTech);
    }
    private void JumpFalling_221()
    {
        pic = 135; state = StateFrameEnum.JUMPING; wait = 1f;
        next = JumpFalling_221; DoubleTapJump(DoubleJump_230);
        Defense(StartJumpDefense_300); OnGround(Crouch_290); Attack(JumpSuperAttack_550);
        BdyDefault();
        CanFlip(); CountJumpDash(); CanJumpDash(JumpDash_270); Power(airTech); PowerSide(airTech);
    }
    #endregion

    #region DoubleJump
    private void DoubleJump_230()
    {
        pic = 131; state = StateFrameEnum.JUMPING; wait = 2f;
        next = DoubleJump_231; OnGround(Crouch_290);
        BdyDefault();
        StopMovement();
        ApplyDefaultPhysic(0, 0, 0, facingRight);
    }
    private void DoubleJump_231()
    {
        pic = 131; state = StateFrameEnum.JUMPING; wait = 0.5f;
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
        Attack(JumpSuperAttack_550); Power(airTech); PowerSide(airTech);
        BdyDefault();
        CanFlip();
    }
    #endregion

    #region DoubleJumpFalling
    private void DoubleJumpFalling_240()
    {
        pic = 134; state = StateFrameEnum.JUMPING; wait = 1f;
        next = DoubleJumpFalling_241; Defense(StartJumpDefense_300); OnGround(Crouch_290);
        Attack(JumpSuperAttack_550); Power(airTech); PowerSide(airTech);
        BdyDefault();
        CanFlip();
    }
    private void DoubleJumpFalling_241()
    {
        pic = 135; state = StateFrameEnum.JUMPING; wait = 1f;
        next = DoubleJumpFalling_241; Defense(StartJumpDefense_300); OnGround(Crouch_290);
        Attack(JumpSuperAttack_550); Power(airTech); PowerSide(airTech);
        BdyDefault();
        CanFlip();
    }
    #endregion

    #region DashJump
    private void DashJump_250()
    {
        pic = 131; state = StateFrameEnum.OTHER; wait = 2f;
        next = DashJump_251; Defense(DashBackward_130);
        BdyDefault();
        StopMovement();
        PrepareJumpDash();
    }
    private void DashJump_251()
    {
        pic = 131; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = DashJump_252; Defense(DashBackward_130);
        BdyDefault();
        ResetMovementFromStop();
    }
    private void DashJump_252()
    {
        pic = 138; state = StateFrameEnum.OTHER; wait = 1f; dvx = 175; dvy = 290; dvz = 80;
        next = DashJump_253; DoubleTapJump(DoubleJump_230);
        BdyDefault();
        ApplyPhysicDashJumping();
    }
    private void DashJump_253()
    {
        pic = 139; state = StateFrameEnum.OTHER; wait = 3f;
        next = DashJump_254; DoubleTapJump(DoubleJump_230);
        BdyDefault(); CountJumpDash(); CanJumpDash(JumpDash_270);
        CanFlip(); Power(airTech); PowerSide(airTech);
    }
    private void DashJump_254()
    {
        pic = 139; state = StateFrameEnum.OTHER; wait = 4f;
        next = JumpFalling_220; Defense(StartJumpDefense_300); OnGround(Crouch_290);
        DoubleTapJump(DoubleJump_230); Attack(JumpSuperAttack_550);
        BdyDefault(); CountJumpDash(); CanJumpDash(JumpDash_270);
        CanFlip(); Power(airTech); PowerSide(airTech);
    }
    #endregion

    #region JumpDash
    private void JumpDash_270()
    {
        StopMovement();
        pic = 129; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpDash_271; Attack(JumpAttack1_590);
        BdyDefault();
    }
    private void JumpDash_271()
    {
        ResetMovementFromStop();
        pic = 129; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpDash_272; Attack(JumpAttack1_590);
        BdyDefault();
        ApplyDefaultPhysic(dvx: 250, dvy: 100, dvz: 0, facingRight);
    }
    private void JumpDash_272()
    {
        pic = 130; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = JumpDash_273; Attack(JumpAttack1_590);
        BdyDefault(); Power(airTech); PowerSide(airTech);
    }
    private void JumpDash_273()
    {
        pic = 130; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpDash_274; Attack(JumpAttack1_590);
        BdyDefault(); Power(airTech); PowerSide(airTech);
    }
    private void JumpDash_274()
    {
        pic = 139; state = StateFrameEnum.OTHER; wait = 4f;
        next = DoubleJumpFalling_240; Attack(JumpAttack1_590);
        BdyDefault(); Power(airTech); PowerSide(airTech);
    }
    #endregion

    #region Crouch
    private void Crouch_290()
    {
        if (opointsControl != null && opointsControl.Count > 0)
        {
            opointsControl[0].ChangeFrame(27);
            opointsControl = null;
        }
        ItrDisable();
        StopMovement();
        pic = 131; state = StateFrameEnum.CROUCH; wait = 1f;
        next = Crouch_291;
        bdy.x = 0.0855f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.2873f; bdy.h = 0.4834f; bdy.zwidth = 0.44f;
        Bdy();
        releaseJumpButton = false;
    }
    private void Crouch_291()
    {
        ResetMovementFromStop();
        pic = 131; state = StateFrameEnum.CROUCH; wait = 3f;
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
        releaseDefenseButton = false;
        pic = 132; state = StateFrameEnum.JUMP_DEFEND; wait = 1f;
        next = JumpDefense_301; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
        opointsControl = null;
    }
    private void JumpDefense_301()
    {
        releaseDefenseButton = false;
        pic = 133; state = StateFrameEnum.JUMP_DEFEND; wait = 5f;
        CanHoldDefenseAfter(JumpDefenseHold_303);
        next = StopJumpDefense_302; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
        if (opointsControl == null)
        {
            opointsControl = SpawnOpoint(SHIELD_2_OPOINT, Opoint(x: 0.25f, y: 0f, z: -0.05f, oid: 0, facingFront: true, quantity: 1, attachToOwner: true));
        }
    }
    private void StopJumpDefense_302()
    {
        pic = 132; state = StateFrameEnum.OTHER; wait = 1f;
        next = JumpFallingNoAction_308; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
        if (opointsControl != null && opointsControl.Count > 0)
        {
            opointsControl = null;
        }
    }

    private void JumpDefenseHold_303()
    {
        releaseDefenseButton = false;
        if (opointsControl.Count > 0)
        {
            opointsControl[0].currentRepeat = 0;
        }
        pic = 133; state = StateFrameEnum.JUMP_DEFEND; wait = 1f;
        CanHoldDefenseAfter(JumpDefenseHold_303);
        next = StopJumpDefense_302; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
    }

    private void HitJumpDefense_305()
    {
        pic = 133; state = StateFrameEnum.JUMP_DEFEND; wait = 1f;
        next = HitJumpDefense_306; OnGround(Crouch_290); Attack(JumpThrowingAttack_570);
        BdyDefault();
        SpawnOpoint(DEFENSE_HIT_OPOINT, Opoint(x: 0f, y: 0.35f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
        ApplyExternPhysic();
    }
    private void HitJumpDefense_306()
    {
        pic = 133; state = StateFrameEnum.JUMP_DEFEND; wait = 2.5f;
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
        pic = 301; wait = 0.5f; next = ThrowingWeapon_311; state = StateFrameEnum.ATTACK;
        BdyDefault();
    }
    private void ThrowingWeapon_311()
    {
        pic = 301; wait = 0.5f; next = ThrowingWeapon_312;
        BdyDefault();
    }
    private void ThrowingWeapon_312()
    {
        pic = 302; wait = 1f; next = ThrowingWeapon_313;
        BdyDefault();
    }
    private void ThrowingWeapon_313()
    {
        pic = 303; wait = 0.5f; next = ThrowingWeapon_314;
        BdyDefault();
        SpawnOpoint(SAND_BULLET_OPOINT, Opoint(x: 0f, y: 0.4f, z: -0.1191684f, oid: 0, facingFront: true, quantity: 1));
    }
    private void ThrowingWeapon_314()
    {
        pic = 304; wait = 0.5f; next = ThrowingWeapon_315;
        BdyDefault();
    }
    private void ThrowingWeapon_315()
    {
        pic = 305; wait = 0.5f; next = ThrowingWeapon_316;
        BdyDefault();
        SpawnOpoint(SAND_BULLET_OPOINT, Opoint(x: 0f, y: 0.4f, z: -0.1191684f, oid: 0, facingFront: true, quantity: 1));
    }
    private void ThrowingWeapon_316()
    {
        pic = 306; wait = 8f; next = ThrowingWeapon_317;
        BdyDefault();
    }
    private void ThrowingWeapon_317()
    {
        pic = 307; wait = 0.5f; next = ThrowingWeapon_318;
        BdyDefault();
    }
    private void ThrowingWeapon_318()
    {
        pic = 308; wait = 1f; next = ThrowingWeapon_319;
        BdyDefault();
    }
    private void ThrowingWeapon_319()
    {
        pic = 308; wait = 0.5f; next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region RunningAttack
    private void RunningAttack_330()
    {
        pic = 211; wait = 1f; state = StateFrameEnum.ATTACK;
        next = RunningAttack_331;
        BdyDefault();
        ItrDisable();
    }
    private void RunningAttack_331()
    {
        StopMovement();
        pic = 126; wait = 0.5f;
        next = RunningAttack_332;
        BdyDefault();
    }
    private void RunningAttack_332()
    {
        ResetMovementFromStop();
        pic = 212; wait = 1f; dvx = 350;
        next = RunningAttack_333;
        BdyDefault();
        ApplyDefaultPhysic(dvx, null, null, facingRight);
    }
    private void RunningAttack_333()
    {
        pic = 212; wait = 0.5f;
        next = RunningAttack_334;
        BdyDefault();
    }
    private void RunningAttack_334()
    {
        pic = 212; wait = 1f;
        next = RunningAttack_335;
        BdyDefault();
    }
    private void RunningAttack_335()
    {
        pic = 212; wait = 0.5f;
        next = RunningAttack_336;
        BdyDefault();
    }
    private void RunningAttack_336()
    {
        pic = 213; wait = 1f;
        next = RunningAttack_337;
        BdyDefault();
        SpawnOpoint(ATTACKSAND_5_OPOINT, Opoint(x: 0.401f, y: -0.005600005f, z: -0.1191684f, oid: 60, facingFront: true, quantity: 1, attachToOwner: true, cancellable: true));
    }
    private void RunningAttack_337()
    {
        pic = 214; wait = 1f;
        next = RunningAttack_338;
        BdyDefault();
    }
    private void RunningAttack_338()
    {
        pic = 215; wait = 1f;
        next = RunningAttack_339;
        BdyDefault();
    }

    private void RunningAttack_339()
    {
        pic = 216; wait = 1f;
        next = RunningAttack_340;
        BdyDefault();
    }
    private void RunningAttack_340()
    {
        StopMovement();
        pic = 217; wait = 0.5f;
        next = RunningAttack_341;
        BdyDefault();
    }
    private void RunningAttack_341()
    {
        pic = 217; wait = 1f;
        next = RunningAttack_342;
        BdyDefault();
    }
    private void RunningAttack_342()
    {
        pic = 218; wait = 0.5f;
        next = RunningAttack_343;
        BdyDefault();
    }
    private void RunningAttack_343()
    {
        pic = 218; wait = 1f;
        next = RunningAttack_344;
        BdyDefault();
    }
    private void RunningAttack_344()
    {
        pic = 219; wait = 0.5f;
        next = RunningAttack_345;
        BdyDefault();
    }
    private void RunningAttack_345()
    {
        pic = 219; wait = 1f;
        next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Attack
    private void Attack1_350()
    {
        StopMovement(); state = StateFrameEnum.ATTACK;
        ItrDisable();
        pic = 301; wait = 0.5f;
        next = Attack1_351;
        BdyDefault();
    }
    private void Attack1_351()
    {
        pic = 302; wait = 5f;
        next = Attack1_352;
        BdyDefault();
    }
    private void Attack1_352()
    {
        pic = 303; wait = 0.5f;
        next = Attack1_353;
        BdyDefault();
        SpawnOpoint(ATTACKSAND_1_OPOINT, Opoint(x: 0.3399999f, y: 0.01600018f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Attack1_353()
    {
        ItrDisable();
        pic = 304; wait = 0.5f; state = StateFrameEnum.STANDING;
        next = Attack1_354; IfHit(Attack1Next_360);
        BdyDefault();
    }
    private void Attack1_354()
    {
        pic = 305; wait = 1f;
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
        pic = 306; wait = 0.5f;
        next = Attack1Next_361;
        BdyDefault();
        enableNextIfHit = false;
    }
    private void Attack1Next_361()
    {
        pic = 306; wait = 1f;
        next = Attack1Next_362;
        BdyDefault();
    }
    private void Attack1Next_362()
    {
        pic = 307; wait = 0.5f;
        next = Attack1Next_363;
        BdyDefault();
    }
    private void Attack1Next_363()
    {
        pic = 308; wait = 6f; state = StateFrameEnum.ATTACK;
        next = Standing_0; DoubleTapAttack(Attack2_370);
        BdyDefault();
    }
    #endregion

    #region Attack2
    private void Attack2_370()
    {
        ItrDisable(); state = StateFrameEnum.ATTACK_RESET;
        pic = 205; wait = 0.5f;
        next = Attack2_371;
        BdyDefault();
    }
    private void Attack2_371()
    {
        pic = 206; wait = 1f; state = StateFrameEnum.ATTACK;
        next = Attack2_372;
        BdyDefault();
    }
    private void Attack2_372()
    {
        SpawnOpoint(ATTACKSAND_2_OPOINT, Opoint(x: -0.532f, y: 0.157f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
        pic = 207; wait = 1f;
        next = Attack2_373;
        BdyDefault();
    }
    private void Attack2_373()
    {
        StopMovement();
        ItrDisable();
        pic = 208; wait = 0.5f;
        next = Attack2_374;
        BdyDefault();
    }
    private void Attack2_374()
    {
        pic = 209; wait = 0.5f;
        next = Attack2_375;
        BdyDefault();
    }
    private void Attack2_375()
    {
        pic = 209; wait = 0.5f;
        next = Attack2_376;
        BdyDefault();
    }
    private void Attack2_376()
    {
        pic = 209; wait = 0.5f;
        next = Attack2_377;
        BdyDefault();
    }
    private void Attack2_377()
    {
        pic = 209; wait = 1.75f;
        next = Attack2_378;
        BdyDefault();
    }
    private void Attack2_378()
    {
        pic = 210; wait = 1f;
        next = Attack2_379;
        BdyDefault();
    }
    private void Attack2_379()
    {
        ResetMovementFromStop();
        pic = 211; wait = 4f;
        next = Standing_0; DoubleTapAttack(Attack3_390);
        BdyDefault();
    }
    #endregion

    #region Attack3
    private void Attack3_390()
    {
        ItrDisable(); state = StateFrameEnum.ATTACK_RESET;
        pic = 400; wait = 1f;
        next = Attack3_391;
        BdyDefault();
    }
    private void Attack3_391()
    {
        pic = 400; wait = 0.5f; state = StateFrameEnum.ATTACK;
        next = Attack3_392;
        BdyDefault();
    }
    private void Attack3_392()
    {
        pic = 400; wait = 0.5f;
        next = Attack3_393;
        BdyDefault();
    }
    private void Attack3_393()
    {
        pic = 400; wait = 0.5f;
        next = Attack3_394;
        BdyDefault();
    }

    private void Attack3_394()
    {
        pic = 401; wait = 1f;
        next = Attack3_395;
        BdyDefault();
    }
    private void Attack3_395()
    {
        pic = 402; wait = 1f;
        next = Attack3_396;
        BdyDefault();
        SpawnOpoint(ATTACKSAND_3_OPOINT, Opoint(x: -0.532f, y: 0.157f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Attack3_396()
    {
        ItrDisable();
        pic = 403; wait = 1f;
        next = Attack3_399;
        BdyDefault();
    }

    private void Attack3_399()
    {
        StopMovement();
        pic = 403; wait = 0.5f;
        next = Attack3_400;
        BdyDefault();
    }
    private void Attack3_400()
    {
        pic = 404; wait = 0.5f;
        next = Attack3_401;
        BdyDefault();
    }
    private void Attack3_401()
    {
        pic = 404; wait = 1f;
        next = Attack3_402;
        BdyDefault();
    }
    private void Attack3_402()
    {
        ResetMovementFromStop();
        pic = 404; wait = 11f;
        next = Standing_0; DoubleTapAttack(Attack4_410);
        BdyDefault();
    }
    #endregion

    #region Attack4
    private void Attack4_410()
    {
        ItrDisable(); state = StateFrameEnum.ATTACK_RESET;
        pic = 318; wait = 0.5f;
        next = Attack4_411;
        BdyDefault();
    }
    private void Attack4_411()
    {
        pic = 318; wait = 1f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_419;
        BdyDefault();
    }
    private void Attack4_419()
    {
        pic = 318; wait = 1f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_420;
        BdyDefault();
    }
    private void Attack4_420()
    {
        pic = 319; wait = 1f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_421;
        BdyDefault();
    }
    private void Attack4_421()
    {
        pic = 319; wait = 0.5f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_412;
        BdyDefault();
    }
    private void Attack4_412()
    {
        pic = 320; wait = 0.5f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_413;
        BdyDefault();
    }

    private void Attack4_413()
    {
        ItrDisable(); state = StateFrameEnum.COMBO_FINISH;
        pic = 320; wait = 1f;
        next = Attack4_414;
        BdyDefault();
        SpawnOpoint(ATTACKSAND_4_OPOINT, Opoint(x: -0.532f, y: 0.157f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
        StopMovement();
    }
    private void Attack4_414()
    {
        ItrDisable();
        pic = 321; wait = 3f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_415;
        BdyDefault();
    }
    private void Attack4_415()
    {
        pic = 321; wait = 0.5f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_416;
        BdyDefault();
    }
    private void Attack4_416()
    {
        pic = 322; wait = 2f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_417;
        BdyDefault();
    }
    private void Attack4_417()
    {
        ResetMovementFromStop();
        pic = 323; wait = 2f; state = StateFrameEnum.COMBO_FINISH;
        next = Attack4_418; DoubleTapAttack(ComboFinish_429);
        BdyDefault();
    }
    private void Attack4_418()
    {
        ResetMovementFromStop();
        pic = 324; wait = 2f; state = StateFrameEnum.COMBO_FINISH;
        next = Standing_0; DoubleTapAttack(ComboFinish_429);
        BdyDefault();
    }
    #endregion

    #region ComboFinish
    private void ComboFinish_429()
    {
        pic = 324; wait = 8f; state = StateFrameEnum.COMBO_FINISH;
        next = Standing_0; Up(Uppercut_450); Down(Downercut_470); Front(FrontAttack_430);
        BdyDefault();
    }
    #endregion

    #region FrontAttack
    private void FrontAttack_430()
    {
        pic = 212; wait = 0.5f; state = StateFrameEnum.ATTACK;
        next = FrontAttack_431;
        BdyDefault();
    }
    private void FrontAttack_431()
    {
        pic = 212; wait = 0.5f;
        next = FrontAttack_432;
        BdyDefault();
    }
    private void FrontAttack_432()
    {
        pic = 213; wait = 0.5f;
        next = FrontAttack_433;
        BdyDefault();
    }
    private void FrontAttack_433()
    {
        pic = 213; wait = 0.5f;
        next = FrontAttack_434;
        BdyDefault();
    }
    private void FrontAttack_434()
    {
        pic = 214; wait = 2f; next = FrontAttack_435;
        BdyDefault();
        SpawnOpoint(ATTACKSAND_6_OPOINT, Opoint(x: 0.122f, y: 0.192f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void FrontAttack_435()
    {
        ItrDisable();
        pic = 215; wait = 0.5f;
        next = FrontAttack_436;
        BdyDefault();
    }
    private void FrontAttack_436()
    {
        pic = 216; wait = 1.5f;
        next = FrontAttack_437;
        BdyDefault();
    }
    private void FrontAttack_437()
    {
        pic = 217; wait = 0.5f;
        next = FrontAttack_438;
        BdyDefault();
        StopMovement();
    }
    private void FrontAttack_438()
    {
        pic = 217; wait = 5.5f;
        next = FrontAttack_439;
        BdyDefault();
    }
    private void FrontAttack_439()
    {
        pic = 218; wait = 1f;
        next = FrontAttack_440;
        BdyDefault();
    }
    private void FrontAttack_440()
    {
        pic = 218; wait = 4.5f;
        next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Uppercut
    private void Uppercut_450()
    {
        pic = 405; wait = 1f; next = Uppercut_451; state = StateFrameEnum.ATTACK;
        BdyDefault();
        ItrDisable();
    }
    private void Uppercut_451()
    {
        pic = 405; wait = 1f; next = Uppercut_452;
        BdyDefault();
    }
    private void Uppercut_452()
    {
        pic = 406; wait = 1f; next = Uppercut_453;
        BdyDefault();
    }
    private void Uppercut_453()
    {
        pic = 407; wait = 1f; next = Uppercut_454;
        BdyDefault();
    }
    private void Uppercut_454()
    {
        pic = 407; wait = 0.5f; next = Uppercut_455;
        BdyDefault();
        SpawnOpoint(SHIELD_ATTACK_2_OPOINT, Opoint(x: 0.667f, y: -0.107f, z: -0.102f, oid: 40, facingFront: true, quantity: 1));
        Itr();
    }
    private void Uppercut_455()
    {
        ItrDisable();
        pic = 408; wait = 5f; next = Uppercut_456;
        BdyDefault();
        StopMovement();
    }
    private void Uppercut_456()
    {
        pic = 409; wait = 1f; next = Uppercut_457;
        BdyDefault();
    }
    private void Uppercut_457()
    {
        pic = 409; wait = 0.5f; next = Uppercut_458;
        BdyDefault();
    }
    private void Uppercut_458()
    {
        pic = 410; wait = 2f; next = Uppercut_459;
        BdyDefault();
    }
    private void Uppercut_459()
    {
        pic = 411; wait = 2f; next = Uppercut_460;
        BdyDefault();
    }
    private void Uppercut_460()
    {
        pic = 412; wait = 10f; next = Standing_0; Jump(JumpCombo_650); state = StateFrameEnum.UPPER_TO_JUMP_COMBO;
        BdyDefault();
    }
    #endregion

    #region Downercut
    private void Downercut_470()
    {
        pic = 420; wait = 1f; next = Downercut_471; state = StateFrameEnum.ATTACK;
        BdyDefault();
        ResetMovementFromStop();
    }
    private void Downercut_471()
    {
        pic = 421; wait = 1f; next = Downercut_478;
        BdyDefault();
    }
    private void Downercut_478()
    {
        pic = 422; wait = 1f; next = Downercut_481;
        BdyDefault();
    }
    private void Downercut_481()
    {
        pic = 423; wait = 0.5f; next = Downercut_482;
        BdyDefault();
    }
    private void Downercut_482()
    {
        pic = 424; wait = 0.5f; next = Downercut_483;
        BdyDefault();
        SpawnOpoint(ATTACKSAND_5_OPOINT, Opoint(x: 0.556f, y: 0.04440001f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Downercut_483()
    {
        pic = 425; wait = 1f; next = Downercut_484;
        BdyDefault();
    }
    private void Downercut_484()
    {
        ItrDisable();
        pic = 425; wait = 1.5f; next = Downercut_485;
        BdyDefault();
    }
    private void Downercut_485()
    {
        pic = 427; wait = 1f; next = Downercut_486;
        BdyDefault();
    }
    private void Downercut_486()
    {
        pic = 428; wait = 1f; next = Downercut_487;
        BdyDefault();
    }
    private void Downercut_487()
    {
        pic = 428; wait = 1f; next = Downercut_488;
        BdyDefault();
    }
    private void Downercut_488()
    {
        pic = 430; wait = 4f; next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region JumpSuperAttack
    private void JumpSuperAttack_550()
    {
        pic = 438; wait = 0.5f; next = JumpSuperAttack_551; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpSuperAttack_551()
    {
        pic = 438; wait = 1f; next = JumpSuperAttack_552; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpSuperAttack_552()
    {
        pic = 439; wait = 0.5f; next = JumpSuperAttack_553; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpSuperAttack_553()
    {
        pic = 439; wait = 1f; next = JumpSuperAttack_554; OnGround(Crouch_290);
        BdyDefault();
        SpawnOpoint(ATTACKSAND_5_OPOINT, Opoint(x: 0.5560001f, y: -0.432f, z: -0.102f, oid: 30, facingFront: true, quantity: 1, attachToOwner: true));
    }
    private void JumpSuperAttack_554()
    {
        pic = 440; wait = 0.5f; next = JumpSuperAttack_555; OnGround(Crouch_290);
        bdy.x = 0.1047f; bdy.y = 0.1856f; bdy.z = 0;
        bdy.w = 0.4125906f; bdy.h = 0.371265f; bdy.zwidth = 0.22f;
        Bdy();
    }
    private void JumpSuperAttack_555()
    {
        pic = 441; wait = 1f; next = JumpSuperAttack_556; OnGround(Crouch_290);
        bdy.x = 0.1047f; bdy.y = 0.1856f; bdy.z = 0;
        bdy.w = 0.4125906f; bdy.h = 0.371265f; bdy.zwidth = 0.22f;
        Bdy();
    }
    private void JumpSuperAttack_556()
    {
        pic = 442; wait = 0.5f; next = JumpSuperAttack_557; OnGround(Crouch_290);
        bdy.x = 0.1047f; bdy.y = 0.1856f; bdy.z = 0;
        bdy.w = 0.4125906f; bdy.h = 0.371265f; bdy.zwidth = 0.22f;
        Bdy();
    }
    private void JumpSuperAttack_557()
    {
        pic = 443; wait = 1f; next = JumpSuperAttack_558; OnGround(Crouch_290);
        bdy.x = 0.1047f; bdy.y = 0.1856f; bdy.z = 0;
        bdy.w = 0.4125906f; bdy.h = 0.371265f; bdy.zwidth = 0.22f;
        Bdy();
    }
    private void JumpSuperAttack_558()
    {
        pic = 444; wait = 1f; next = JumpSuperAttack_558; OnGround(Crouch_290);
        bdy.x = 0.1047f; bdy.y = 0.1856f; bdy.z = 0;
        bdy.w = 0.4125906f; bdy.h = 0.371265f; bdy.zwidth = 0.22f;
        Bdy();
    }
    #endregion

    #region JumpThrowingAttack
    private void JumpThrowingAttack_570()
    {
        pic = 414; wait = 1.5f; next = JumpThrowingAttack_571; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_571()
    {
        pic = 415; wait = 0.5f; next = JumpThrowingAttack_572; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_572()
    {
        pic = 416; wait = 1.5f; next = JumpThrowingAttack_573; OnGround(Crouch_290);
        BdyDefault();
        SpawnOpoint(SAND_BULLET_OPOINT, Opoint(x: 0.065f, y: 0.25f, z: 0f, oid: 20, facingFront: true, quantity: 1));
    }
    private void JumpThrowingAttack_573()
    {
        pic = 417; wait = 0.5f; next = JumpThrowingAttack_574; OnGround(Crouch_290);
        BdyDefault();
        SpawnOpoint(SAND_BULLET_OPOINT, Opoint(x: 0.065f, y: 0.25f, z: 0f, oid: 20, facingFront: true, quantity: 1));
    }
    private void JumpThrowingAttack_574()
    {
        pic = 418; wait = 0.5f; next = JumpThrowingAttack_575; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_575()
    {
        pic = 418; wait = 0.5f; next = JumpThrowingAttack_576; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_576()
    {
        pic = 418; wait = 0.5f; next = JumpThrowingAttack_577; OnGround(Crouch_290);
        BdyDefault();
    }
    private void JumpThrowingAttack_577()
    {
        pic = 418; wait = 1f; next = JumpThrowingAttack_577; OnGround(Crouch_290);
        BdyDefault();
    }
    #endregion

    #region JumpAttack1 go to Jump Super Attack
    private void JumpAttack1_590()
    {
        pic = 438; wait = 0.5f; next = JumpSuperAttack_551; OnGround(Crouch_290);
        BdyDefault();
    }
    #endregion

    #region JumpCombo
    private void JumpCombo_650()
    {
        pic = 131; wait = 4f; next = JumpCombo_651; Defense(DashBackward_130);
        BdyDefault();
    }
    private void JumpCombo_651()
    {
        pic = 131; wait = 0.5f; next = JumpCombo_652;
        BdyDefault();
    }
    private void JumpCombo_652()
    {
        pic = 132; wait = 0.5f; next = JumpCombo_653;
        BdyDefault();
    }
    private void JumpCombo_653()
    {
        pic = 133; wait = 2f; next = JumpCombo_654; dvx = 80; dvy = 300; dvz = 80;
        BdyDefault();
        ApplyPhysicJumping(); DoubleTapJump(DoubleJumpCombo_670);
    }
    private void JumpCombo_654()
    {
        pic = 133; wait = 8f; next = JumpComboFalling_660; Defense(StartJumpDefense_300); state = StateFrameEnum.JUMP_COMBO_ATTACK;
        DoubleTapJump(DoubleJumpCombo_670); Attack(JumpAttack1_590); Power(airTech); PowerSide(airTech);
        BdyDefault();
    }
    #endregion

    #region JumpComboFalling
    private void JumpComboFalling_660()
    {
        pic = 134; wait = 0.5f; next = JumpComboFalling_661; Defense(StartJumpDefense_300);
        OnGround(Crouch_290); Jump(DoubleJumpCombo_670); Attack(JumpAttack1_590); Power(airTech); PowerSide(airTech);
        BdyDefault();
    }
    private void JumpComboFalling_661()
    {
        pic = 135; wait = 1f; next = JumpComboFalling_661; Defense(StartJumpDefense_300);
        OnGround(Crouch_290); Jump(DoubleJumpCombo_670); Attack(JumpAttack1_590); Power(airTech); PowerSide(airTech);
        BdyDefault();
    }
    #endregion

    #region DoubleJumpCombo
    private void DoubleJumpCombo_670()
    {
        pic = 131; wait = 1; next = DoubleJumpCombo_671;
        BdyDefault();
    }
    private void DoubleJumpCombo_671()
    {
        pic = 131; wait = 0.5f; next = DoubleJumpCombo_672;
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
        pic = 133; wait = 8f; next = DoubleJumpFalling_680; Defense(StartJumpDefense_300); Attack(JumpAttack1_590);
        BdyDefault(); Power(airTech); PowerSide(airTech);
    }
    #endregion

    #region DoubleJumpFalling
    private void DoubleJumpFalling_680()
    {
        pic = 134; wait = 0.5f; next = DoubleJumpFalling_681; Defense(StartJumpDefense_300);
        OnGround(Crouch_290); Attack(JumpAttack1_590);
        BdyDefault(); Power(airTech); PowerSide(airTech);
    }
    private void DoubleJumpFalling_681()
    {
        pic = 135; wait = 1f; next = DoubleJumpFalling_681; Defense(StartJumpDefense_300);
        OnGround(Crouch_290); Attack(JumpAttack1_590);
        BdyDefault(); Power(airTech); PowerSide(airTech);
    }
    #endregion
    
    #region NoMana
    private void NoMana_690()
    {
        pic = 600; wait = 15f; next = Standing_0; state = StateFrameEnum.NO_MANA;
        bdy.kind = BdyKindEnum.NORMAL;
        BdyDefault();
    }
    
    private void NoManaAir_692()
    {
        pic = 600; wait = 15f; next = JumpFallingNoAction_308; state = StateFrameEnum.NO_MANA;
        bdy.kind = BdyKindEnum.NORMAL; OnGround(Crouch_290);
        BdyDefault();
    }
    
    private void NoManaFloat_694()
    {
        pic = 600; wait = 15f; next = SandFloatIdle_1160; state = StateFrameEnum.NO_MANA;
        bdy.kind = BdyKindEnum.NORMAL;
        BdyDefault();
    }
    #endregion

    #region InjuredManager
    private void InjuredManager_700()
    {
        var optionInjured = Random.value; state = StateFrameEnum.INJURED; CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
        wait = 2f; next = optionInjured > 0.5f ? Injured1_702 : Injured2_710;
        BdyDefault(); DoubleTapDefense(CriticalDefense_880);
    }
    #endregion

    #region Injured1
    private void Injured1_702()
    {
        ResetMovementFromStop();
        pic = 600; wait = 3f; next = Injured1_703;
        BdyDefault();
        ApplyExternPhysic(); DoubleTapDefense(Kawa_1500);
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
        pic = 601; wait = 3f; next = Injured2_711;
        BdyDefault();
        ApplyExternPhysic(); DoubleTapDefense(Kawa_1500);
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
        var optionInjured = Random.value; state = StateFrameEnum.INJURED; CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
        pic = 600; wait = 2f; next = optionInjured > 0.5f ? InjuredSky1_722 : InjuredSky2_730;
        BdyDefault(); DoubleTapDefense(CriticalDefense_880);
    }
    #endregion

    #region InjuredSky1
    private void InjuredSky1_722()
    {
        ResetMovementFromStop();
        pic = 600; wait = 3f; next = InjuredSky1_723; Defense(JumpCriticalDefense_885);
        BdyDefault();
        ApplyExternPhysic(); DoubleTapDefense(Kawa_1500);
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
        ApplyExternPhysic(); DoubleTapDefense(Kawa_1500);
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
        ResetMovementFromStop(); state = StateFrameEnum.FALLING; CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
        pic = 601; wait = 2f; next = Falling_801;
        BdyDefault();
        ApplyExternPhysic();
    }
    private void Falling_801()
    {
        ResetMovementFromStop(); bdy.kind = BdyKindEnum.NORMAL;
        pic = 603; wait = 2f; next = Falling_802; OnGround(Lying_910);
        BdyDefault();
    }
    private void Falling_802()
    {
        pic = 604; wait = 2f; next = Falling_803; OnGround(Lying_910);
        BdyDefault();
    }
    private void Falling_803()
    {
        pic = 605; wait = 0.5f; next = Falling_804; OnGround(Lying_910);
        BdyDefault();
    }
    private void Falling_804()
    {
        pic = 606; wait = 2f; next = Falling_805; OnGround(Lying_910);
        BdyDefault();
    }
    private void Falling_805()
    {
        pic = 607; wait = 0.5f; next = Falling_806; OnGround(Lying_910);
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
        ResetMovementFromStop(); state = StateFrameEnum.FALLING; CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
        pic = 621; wait = 2f; next = FallingDown_821; OnGround(FallingDownImpact_825);
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
        pic = 625; wait = 2f; next = FallingDownImpact_826; state = StateFrameEnum.FALLING;
        BdyDefault();
        SpawnOpoint(IMPACT_DOWN_OPOINT, Opoint(x: 0.13f, y: 0, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
    }
    private void FallingDownImpact_826()
    {
        pic = 628; wait = 2f; next = FallingDownImpact_827;
        BdyDefault();
    }
    private void FallingDownImpact_827()
    {
        pic = 626; wait = 2f; next = FallingDownImpact_828;
        BdyDefault();
    }
    private void FallingDownImpact_828()
    {
        pic = 627; wait = 2f; next = FallingDownImpact_829;
        BdyDefault();
    }
    private void FallingDownImpact_829()
    {
        pic = 628; wait = 2f; next = Lying_910;
        BdyDefault();
    }
    #endregion

    #region FallingUp
    private void FallingUp_840()
    {
        ResetMovementFromStop(); state = StateFrameEnum.FALLING; CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
        pic = 601; wait = 2f; next = FallingUp_841;
        OnCeil(FallingUpImpact_850);
        BdyDefault();
        ApplyExternPhysic();
    }
    private void FallingUp_841()
    {
        pic = 601; wait = 0.5f; next = FallingUp_842;
        OnCeil(FallingUpImpact_850);
        BdyDefault();
    }
    void FallingUp_842()
    {
        pic = 609; wait = 10f; next = FallingUp_843; OnGround(Lying_910);
        OnCeil(FallingUpImpact_850);
        BdyDefault();
    }
    private void FallingUp_843()
    {
        pic = 610; wait = 0.5f; next = FallingUp_844; OnGround(Lying_910);
        OnCeil(FallingUpImpact_850);
        BdyDefault();
    }
    private void FallingUp_844()
    {
        pic = 611; wait = 0.5f; next = FallingUp_845; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUp_845()
    {
        pic = 612; wait = 0.5f; next = FallingUp_846; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUp_846()
    {
        pic = 613; wait = 0.5f; next = FallingUp_847; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUp_847()
    {
        pic = 614; wait = 0.5f; next = FallingUp_848; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUp_848()
    {
        pic = 615; wait = 2f; next = FallingUp_848; OnGround(Lying_910);
        BdyDefault();
    }

    private void FallingUpImpact_850()
    {
        pic = 612; wait = 2f; next = FallingUpImpact_851;
        BdyDefault();
        ApplyDefaultPhysic(dvx: 0, dvy: -320, dvz: 0, facingRight);
        SpawnOpoint(IMPACT_UP_OPOINT, Opoint(x: 0.13f, y: 0, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
    }
    private void FallingUpImpact_851()
    {
        pic = 622; wait = 2f; next = FallingUpImpact_852; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUpImpact_852()
    {
        pic = 623; wait = 2f; next = FallingUpImpact_853; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUpImpact_853()
    {
        pic = 624; wait = 2f; next = FallingUpImpact_854; OnGround(Lying_910);
        BdyDefault();
    }
    private void FallingUpImpact_854()
    {
        pic = 625; wait = 2f; next = FallingUpImpact_854; OnGround(Lying_910);
        BdyDefault();
    }
    #endregion

    #region FallingForward
    private void FallingForwardtHit_860()
    {
        ResetMovementFromStop(); state = StateFrameEnum.FALLING; CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
        pic = 617; wait = 2f; next = FallingForward_861;
        BdyDefault();
        ApplyExternPhysic();
    }
    private void FallingForward_861()
    {
        pic = 618; wait = 0.5f; next = FallingForward_862; OnGround(Lying_910);
        OnWall(FallingForwardImpact_870);
        BdyDefault();
    }
    private void FallingForward_862()
    {
        pic = 619; wait = 2f; next = FallingForward_863; OnGround(Lying_910);
        OnWall(FallingForwardImpact_870);
        BdyDefault();
    }
    private void FallingForward_863()
    {
        pic = 620; wait = 2f; next = FallingForward_863; OnGround(Lying_910);
        OnWall(FallingForwardImpact_870);
        BdyDefault();
    }

    private void FallingForwardImpact_870()
    {
        pic = 610; wait = 2f; next = FallingForwardImpact_871;
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
        pic = 613; wait = 2f; next = FallingForwardImpact_873;
        BdyDefault();
    }
    private void FallingForwardImpact_873()
    {
        pic = 614; wait = 2f; next = FallingForwardImpact_874;
        BdyDefault();
    }
    private void FallingForwardImpact_874()
    {
        pic = 615; wait = 2f; next = FallingForwardImpact_874; OnGround(Lying_910);
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
        pic = 302; wait = 1f; next = CriticalDefense_881; Attack(Attack1_350);
        BdyDefault();
    }
    private void CriticalDefense_881()
    {
        pic = 302; wait = 1f; next = StopDefense_152; Attack(Attack1_350);
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
            base.currentHp += lastDamage > 0 ? lastDamage : 0;
            base.canParry = false;
        }
        pic = 133; wait = 1f; next = JumpCriticalDefense_886; Attack(JumpAttack1_590);
        BdyDefault();
    }
    private void JumpCriticalDefense_886()
    {
        pic = 133; wait = 1f; next = StopJumpDefense_302; Attack(JumpAttack1_590);
        BdyDefault();
        SpawnOpoint(JUMPING_COMBO_OPOINT, Opoint(x: 0.11f, y: 0.25f, z: -0.12f, oid: 0, facingFront: true, quantity: 1));
    }
    #endregion

    #region Lying
    private void Lying_910()
    {
        StopMovement(); state = StateFrameEnum.LYING; CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
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
        pic = 628; wait = 2f; next = Lying_914;
        BdyDefault();
    }
    private void Lying_914()
    {
        pic = 629; wait = 50f; next = LyingUp_920;
        BdyDefault();
    }

    private void LyingUp_920()
    {
        pic = 630; wait = 2f; next = LyingUp_921;
        BdyDefault();
    }
    private void LyingUp_921()
    {
        pic = 630; wait = 2f; next = LyingUp_922;
        BdyDefault();
    }
    private void LyingUp_922()
    {
        pic = 630; wait = 2f; next = LyingUp_923;
        BdyDefault();
    }
    private void LyingUp_923()
    {
        pic = 630; wait = 1f; next = LyingUp_924;
        BdyDefault();
    }
    private void LyingUp_924()
    {
        pic = 631; wait = 1f; next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region JumpRecover
    private void JumpRecover_930()
    {
        spriteRenderer.color = parryColor; CancelOpoints(); bdy.kind = BdyKindEnum.NORMAL;
        pic = 131; wait = 1f; next = JumpRecover_931;
        BdyDefault();
        SpawnOpoint(JUMP_RECOVER_OPOINT, Opoint(x: 0.11f, y: 0.25f, z: 0.08f, oid: 0, facingFront: true, quantity: 1));
    }
    private void JumpRecover_931()
    {
        pic = 131; wait = 2f; next = Crouch_290;
        BdyDefault();
    }
    #endregion
    
    #region Catch Invisible
    private void CatchInvisible_950()
    {
        Debug.Log("test");
        repeatCount = 250;
        ResetMovementFromStop(); CancelOpoints();
        pic = -9999; wait = 2f; next = CatchInvisible_951;
        BdyDefault();
        bdy.kind = BdyKindEnum.INVULNERABLE;
    }
    private void CatchInvisible_951()
    {
        RepeatCountToFrame(frames[801]);
        ResetMovementFromStop(); CancelOpoints();
        pic = -9999; wait = 2f; next = CatchInvisible_951;
        BdyDefault();
        bdy.kind = BdyKindEnum.INVULNERABLE;
    }
    #endregion

    #region ArmMonster
    private void ArmMonster_1000()
    {
        EnableManaPoints();
        mp = 200;
        state = StateFrameEnum.CANCEL_OPOINTS_IF_CHANGE_CONTEXT_FRAMES;
        pic = 318; wait = 5f; next = CheckIfHaveMana(mp) ? ArmMonster_1001 : NoMana_690;
        BdyDefault();
        ItrDisable();
    }
    private void ArmMonster_1001()
    {
        UsageManaPoints(mp);
        pic = 319; wait = 2f; next = ArmMonster_1002;
        BdyDefault();
    }
    private void ArmMonster_1002()
    {
        EnableManaPoints();
        pic = 320; wait = 2f; next = ArmMonster_1003;
        BdyDefault();
    }
    private void ArmMonster_1003()
    {
        pic = 321; wait = 2; next = ArmMonster_1004;
        BdyDefault();
        SpawnOpoint(DEMON_ARM_SAND_OPOINT, Opoint(x: 0.2080002f, y: 0.3660002f, z: -0.058f, oid: 0, facingFront: true, quantity: 1));
    }

    private void ArmMonster_1004()
    {
        pic = 322; wait = 9f; next = ArmMonster_1005;
        BdyDefault();
    }

    private void ArmMonster_1005()
    {
        pic = 323; wait = 2f; next = ArmMonster_1006;
        BdyDefault();
    }

    private void ArmMonster_1006()
    {
        pic = 324; wait = 10f; next = Standing_0;
        BdyDefault();
    }

    #endregion

    #region ArmMonster Float
    private void ArmMonsterFloat_1010()
    {
        EnableManaPoints();
        mp = 200;
        state = StateFrameEnum.CANCEL_OPOINTS_IF_CHANGE_CONTEXT_FRAMES;
        next = CheckIfHaveMana(mp) ? ArmMonsterFloat_1011 : NoManaFloat_694;
        pic = 318; wait = 5f;
        BdyDefault();
        ItrDisable();
    }
    private void ArmMonsterFloat_1011()
    {
        UsageManaPoints(mp);
        pic = 319; wait = 2f; next = ArmMonsterFloat_1012;
        BdyDefault();
    }
    private void ArmMonsterFloat_1012()
    {
        EnableManaPoints();
        pic = 320; wait = 2f; next = ArmMonsterFloat_1013;
        BdyDefault();
    }
    private void ArmMonsterFloat_1013()
    {
        pic = 321; wait = 2; next = ArmMonsterFloat_1014;
        BdyDefault();
        SpawnOpoint(DEMON_ARM_SAND_ROTATE_OPOINT, Opoint(x: 0.2080002f, y: 0.3660002f, z: -0.058f, oid: 20, facingFront: true, quantity: 1, rotationZ: -45f));
    }

    private void ArmMonsterFloat_1014()
    {
        pic = 322; wait = 9f; next = ArmMonsterFloat_1015;
        BdyDefault();
    }

    private void ArmMonsterFloat_1015()
    {
        pic = 323; wait = 2f; next = ArmMonsterFloat_1016;
        BdyDefault();
    }

    private void ArmMonsterFloat_1016()
    {
        pic = 324; wait = 10f; next = SandFloatIdle_1160;
        BdyDefault();
    }
    #endregion

    #region Sand Shield
    private void SandShield_1100()
    {
        EnableManaPoints();
        mp = 150;
        next = CheckIfHaveMana(mp) ? SandShield_1101 : NoMana_690;
        pic = 201; wait = 1f;
        BdyDefault();
    }
    private void SandShield_1101()
    {
        UsageManaPoints(mp);
        pic = 202; wait = 1f; next = SandShield_1102;
        BdyDefault();
    }
    private void SandShield_1102()
    {
        EnableManaPoints();
        pic = 203; wait = 1f; next = SandShield_1103;
        BdyDefault();
        SpawnOpoint(SHIELD_1_OPOINT, Opoint(x: 0f, y: 0f, z: 0f, oid: 0, facingFront: false, quantity: 1, cancellable: false, attachToOwner: false));
    }
    private void SandShield_1103()
    {
        pic = 204; wait = 2f; next = SandShield_1104;
        BdyDefault();
        bdy.kind = BdyKindEnum.NORMAL;
    }
    private void SandShield_1104()
    {
        bdy.kind = BdyKindEnum.INVULNERABLE;
        pic = -9999; wait = 40f; next = SandShield_1109;
        BdyDefault(); Attack(SandShieldArmMonster_1120);
    }
    private void SandShield_1109()
    {
        bdy.kind = BdyKindEnum.INVULNERABLE;
        pic = -9999; wait = 40f; next = SandShield_1105;
        BdyDefault(); Attack(SandShieldArmMonster_1120);
    }
    private void SandShield_1105()
    {
        bdy.kind = BdyKindEnum.NORMAL;
        pic = 203; wait = 1f; next = SandShield_1107;
        BdyDefault();
    }

    private void SandShield_1107()
    {
        pic = 202;
        wait = 1f;
        next = SandShield_1108;
        BdyDefault(); 
    }

    private void SandShield_1108()
    {
        pic = 201;
        wait = 1f;
        next = Standing_0;
        BdyDefault(); 
    }
    #endregion

    #region SandShieldArmMonster
    private void SandShieldArmMonster_1120()
    {
        EnableManaPoints();
        mp = 200;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        next = CheckIfHaveMana(mp) ? SandShieldArmMonster_1124 : NoMana_690;
        pic = -9999; wait = 1f;
        BdyDefault();
    }
    private void SandShieldArmMonster_1124()
    {
        UsageManaPoints(mp);
        bdy.kind = BdyKindEnum.INVULNERABLE;
        next = SandShieldArmMonster_1121;
        pic = -9999; wait = 39f;
        BdyDefault();
        SpawnOpoint(DEMON_ARM_SAND_OPOINT, Opoint(x: 0.2080002f, y: 0.3660002f, z: -0.058f, oid: 0, facingFront: true, quantity: 1));
    }
    private void SandShieldArmMonster_1121()
    {
        EnableManaPoints();
        bdy.kind = BdyKindEnum.NORMAL;
        pic = 203; wait = 1f; next = SandShieldArmMonster_1121;
        BdyDefault();
    }

    private void SandShieldArmMonster_1122()
    {
        EnableManaPoints();
        pic = 202;
        wait = 1f;
        next = SandShieldArmMonster_1123;
        BdyDefault(); 
    }

    private void SandShieldArmMonster_1123()
    {
        EnableManaPoints();
        pic = 201;
        wait = 1f;
        next = Standing_0;
        BdyDefault(); 
    }
    #endregion

    #region SandFloat
    private void SandFloat_1150() {
        EnableManaPoints();
        mp = 100;
        pic = 531; wait = 1f; next = CheckIfHaveMana(mp) ? SandFloat_1151 : NoMana_690;
        BdyDefault();
    }

    private void SandFloat_1151()
    {
        UsageManaPoints(mp);
        pic = 532; wait = 1f; next = SandFloat_1152;
        BdyDefault();
    }

    private void SandFloat_1152()
    {
        EnableManaPoints();
        pic = 533; wait = 1f; next = SandFloat_1153;
        BdyDefault();
        opointsControl = null;
    }

    private void SandFloat_1153()
    {
        pic = 534; wait = 1f; next = SandFloatIdle_1160;
        BdyDefault();
        if (opointsControl == null)
        {
            opointsControl = SpawnOpoint(SAND_FLOAT_OPOINT, Opoint(x: 0f, y: -0.2f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: true, attachToOwner: true));
        }
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    

    private void SandFloatIdle_1160()
    {
        pic = 535; wait = 5f; next = SandFloatIdle_1161;
        BdyDefault();
        CanWalking(SandFloatWalking_1170); Jump(SandFloatExit_1190); Defense(ChargeFloatStart_1800);
        Attack(SandFloatAttack_1180); PowerUp(ArmMonsterFloat_1010); Power(FloatSandShield_1600); PowerSide(FloatSandSpear_1650);
        CanSimpleDash(SandFloatRunning_1175); PowerDown(FloatErupcao_1700); SuperPower(FloatSandPrison_1750);
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    
    private void SandFloatIdle_1161()
    {
        pic = 534; wait = 5f; next = SandFloatIdle_1162;
        BdyDefault(); Defense(ChargeFloatStart_1800);
        CanWalking(SandFloatWalking_1170); Jump(SandFloatExit_1190); PowerSide(FloatSandSpear_1650);
        Attack(SandFloatAttack_1180); PowerUp(ArmMonsterFloat_1010); Power(FloatSandShield_1600);
        CanSimpleDash(SandFloatRunning_1175); PowerDown(FloatErupcao_1700); SuperPower(FloatSandPrison_1750);
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    
    private void SandFloatIdle_1162()
    {
        pic = 535; wait = 5f; next = SandFloatIdle_1163;
        BdyDefault(); Defense(ChargeFloatStart_1800);
        CanWalking(SandFloatWalking_1170); Jump(SandFloatExit_1190); PowerSide(FloatSandSpear_1650);
        Attack(SandFloatAttack_1180); PowerUp(ArmMonsterFloat_1010); Power(FloatSandShield_1600);
        CanSimpleDash(SandFloatRunning_1175); PowerDown(FloatErupcao_1700); SuperPower(FloatSandPrison_1750);
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    private void SandFloatIdle_1163()
    {
        pic = 534; wait = 5f; next = SandFloatIdle_1160;
        BdyDefault(); Defense(ChargeFloatStart_1800);
        CanWalking(SandFloatWalking_1170); Jump(SandFloatExit_1190); PowerSide(FloatSandSpear_1650);
        Attack(SandFloatAttack_1180); PowerUp(ArmMonsterFloat_1010); Power(FloatSandShield_1600);
        CanSimpleDash(SandFloatRunning_1175); PowerDown(FloatErupcao_1700); SuperPower(FloatSandPrison_1750);
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    
    private void SandFloatWalking_1170()
    {
        pic = 534; state = StateFrameEnum.WALKING; wait = 1f; dvx = 4f; dvz = 3f; next = SandFloatWalking_1171; bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
        CanFlip(); Defense(ChargeFloatStart_1800);
        CanStandingFromWalking(SandFloatIdle_1160); Power(FloatSandShield_1600); PowerSide(FloatSandSpear_1650);
        Jump(SandFloatExit_1190); Taunt(Taunt_195); PowerUp(ArmMonsterFloat_1010); SuperPower(FloatSandPrison_1750);
        Defense(Start_Defense_150); Attack(SandFloatAttack_1180); OnCeil(Standing_0); PowerDown(FloatErupcao_1700);
        ApplyPhysicWalking();
        ManageWalking();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    private void SandFloatWalking_1171()
    {
        pic = 534; state = StateFrameEnum.WALKING; wait = 1f; dvx = 4f; dvz = 3f; next = SandFloatWalking_1170; bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
        CanFlip(); Defense(ChargeFloatStart_1800);
        CanStandingFromWalking(SandFloatIdle_1160); Power(FloatSandShield_1600); PowerSide(FloatSandSpear_1650);
        Jump(SandFloatExit_1190); Taunt(Taunt_195); PowerUp(ArmMonsterFloat_1010); SuperPower(FloatSandPrison_1750);
        Defense(Start_Defense_150); Attack(SandFloatAttack_1180); OnCeil(Standing_0); PowerDown(FloatErupcao_1700);
        ApplyPhysicWalking();
        ManageWalking();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    
    private void SandFloatRunning_1175()
    {
        pic = 534; state = StateFrameEnum.RUNNING; wait = .75f; dvx = 4f; dvy = 0f; dvz = 3f;
        next = SandFloatRunning_1176;
        Jump(SandFloatExit_1190); Attack(SandFloatAttack_1180);
        CanStopRunning(SandFloatIdle_1160); ApplyPhysicRunning();
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    
    private void SandFloatRunning_1176()
    {
        pic = 534; state = StateFrameEnum.RUNNING; wait = .75f; dvx = 4f; dvy = 0f; dvz = 3f;
        next = SandFloatRunning_1175;
        Jump(SandFloatExit_1190);Attack(SandFloatAttack_1180);
        CanStopRunning(SandFloatIdle_1160); ApplyPhysicRunning();
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.22f;
        Bdy();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    private void SandFloatAttack_1180()
    {
        pic = 400; wait = 1f; next = SandFloatAttack_1181;
        BdyDefault();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    private void SandFloatAttack_1181()
    {
        pic = 401; wait = 1f; next = SandFloatAttack_1182;
        BdyDefault();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    private void SandFloatAttack_1182()
    {
        pic = 402; wait = 1f; next = SandFloatAttack_1183;
        BdyDefault();
        SpawnOpoint(ATTACKSAND_5_OPOINT, Opoint(x: 0.608f, y: -0.884f, z: -0.102f, oid: 30, facingFront: true, quantity: 1, attachToOwner: true));
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    private void SandFloatAttack_1183()
    {
        pic = 403; wait = 1f; next = SandFloatAttack_1184;
        BdyDefault();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    private void SandFloatAttack_1184()
    {
        pic = 404; wait = 10f; next = SandFloatAttack_1185;
        BdyDefault();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    private void SandFloatAttack_1185()
    {
        pic = 533; wait = 2f; next = SandFloatIdle_1160;
        BdyDefault();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    private void SandFloatExit_1190()
    {
        if (opointsControl != null && opointsControl[0] != null) 
        {
            opointsControl[0].ChangeFrame(8);
            opointsControl = null;
        }
        ResetMovementFromStop();
        pic = 533; wait = 2f; next = JumpFallingNoAction_308;
        BdyDefault();
    }
    
    #endregion

    #region SandSpear
    private void SandSpear_1200()
    {
        EnableManaPoints();
        mp = 150;
        next = CheckIfHaveMana(mp) ? SandSpear_1201 : NoMana_690;
        pic = 201; wait = 1f;
        BdyDefault();
    }

    private void SandSpear_1201()
    {
        UsageManaPoints(mp);
        pic = 202; wait = 8f; next = SandSpear_1202;
        BdyDefault();
        SpawnOpoint(SAND_SPEAR_OPOINT, Opoint(x: 0f, y: 0f, z: -0.04116842f, oid: 0, facingFront: true, quantity: 1));
    }

    private void SandSpear_1202()
    {
        EnableManaPoints();
        pic = 203; wait = 1f; next = SandSpear_1203;
        BdyDefault();
    }

    private void SandSpear_1203()
    {
        pic = 204; wait = 2f; next = SandSpear_1204;
        BdyDefault();
    }

    private void SandSpear_1204()
    {
        pic = 205; wait = 2f; next = SandSpear_1205;
        BdyDefault();
    }

    private void SandSpear_1205()
    {
        pic = 206; wait = 1f; next = SandSpear_1206;
        BdyDefault();
    }

    private void SandSpear_1206()
    {
        pic = 207; wait = 1f; next = SandSpear_1207;
        BdyDefault();
    }

    private void SandSpear_1207()
    {
        pic = 208; wait = 1f; next = SandSpear_1208;
        BdyDefault();
    }

    private void SandSpear_1208()
    {
        pic = 209; wait = 10f; next = SandSpear_1209;
        BdyDefault();
    }

    private void SandSpear_1209()
    {
        pic = 210; wait = 1f; next = SandSpear_1210;
        BdyDefault();
    }

    private void SandSpear_1210()
    {
        pic = 211; wait = 8f; next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Erupcao
    private void Erupcao_1250()
    {
        EnableManaPoints();
        mp = 350;
        state = StateFrameEnum.CANCEL_OPOINTS_IF_CHANGE_CONTEXT_FRAMES;
        pic = 531; wait = 1f;
        next = CheckIfHaveMana(mp) ? Erupcao_1251 : NoMana_690;
        BdyDefault();
        ItrDisable();
    }

    private void Erupcao_1251()
    {
        UsageManaPoints(mp);
        pic = 532;
        wait = 10;
        next = Erupcao_1252;
        BdyDefault();
    }

    private void Erupcao_1252()
    {
        EnableManaPoints();
        pic = 533;
        wait = 2;
        next = Erupcao_1253;
        BdyDefault();
    }

    private void Erupcao_1253()
    {
        pic = 534;
        wait = 0.5f;
        next = Erupcao_1260;
        BdyDefault();
        if (onGround)
        {
            SpawnOpoint(ATTACKSAND_6_OPOINT, Opoint(x: 0f, y: 0f, z: 0.8f, oid: 20, facingFront: true, quantity: 1));
        }
    }

    private void Erupcao_1260()
    {
        pic = 534;
        wait = 0.5f;
        next = Erupcao_1261;
        BdyDefault();
        if (onGround)
        {
            SpawnOpoint(ATTACKSAND_6_OPOINT, Opoint(x: 0f, y: 0f, z: -0.8f, oid: 20, facingFront: true, quantity: 1));
        }
    }

    private void Erupcao_1261()
    {
        pic = 534;
        wait = 0.5f;
        next = Erupcao_1262;
        BdyDefault();
        if (onGround)
        {
            SpawnOpoint(ATTACKSAND_6_OPOINT, Opoint(x: -0.8f, y: 0f, z: 0f, oid: 20, facingFront: true, quantity: 1));
        }
    }

    private void Erupcao_1262()
    {
        pic = 534;
        wait = 0.5f;
        next = Erupcao_1254;
        BdyDefault();
        if (onGround)
        {
            SpawnOpoint(ATTACKSAND_6_OPOINT, Opoint(x: 0.8f, y: 0f, z: 0f, oid: 20, facingFront: true, quantity: 1));
        }
    }

    private void Erupcao_1254()
    {
        pic = 535;
        wait = 8;
        next = Erupcao_1255;
        BdyDefault();
    }

    private void Erupcao_1255()
    {
        pic = 533;
        wait = 2;
        next = Standing_0;
        BdyDefault();
    }
    
    #endregion

    #region Ult Sand Prision
    private void SandPrison_1300()
    {
        EnableManaPoints();
        mp = 800;
        state = StateFrameEnum.CANCEL_OPOINTS_IF_CHANGE_CONTEXT_FRAMES; ResetMovementFromStop();
        pic = 521; wait = 2f;
        next = CheckIfHaveMana(mp) ? SandPrison_1301 : NoMana_690;
        BdyDefault();
        ItrDisable();
        SpawnOpoint(ULTIMATE_OPOINT, Opoint(x: 0f, y: 0.371f, z: -0.094f, oid: 0, facingFront: true, quantity: 1));
        StageFadeOut(0.05f);
    }
    private void SandPrison_1301()
    {
        UsageManaPoints(mp);
        pic = 522;
        wait = 1;
        next = SandPrison_1315;
        BdyDefault();
        SpawnOpoint(ULTIMATE_MUGSHOT_OPOINT, Opoint(x: 0f, y: 0f, z: 0f, oid: 1, facingFront: true, quantity: 1));
        StageFadeOut(0.05f);
    }
    private void SandPrison_1315()
    {
        EnableManaPoints();
        BlackoutStage();
        pic = 522;
        wait = 3;
        next = SandPrison_1317;
        BdyDefault();
    }
    private void SandPrison_1317()
    {
        pic = 522;
        wait = 6;
        next = SandPrison_1302;
        BdyDefault();
        StageFadeIn(0.1f);
    }

    private void SandPrison_1302()
    {
        ResetStageColor();
        pic = 523;
        wait = 2;
        next = SandPrison_1303;
        BdyDefault();
    }

    private void SandPrison_1303()
    {
        pic = 524;
        wait = 2;
        next = SandPrison_1304;
        BdyDefault();
    }

    private void SandPrison_1304()
    {
        pic = 525;
        wait = 2;
        next = SandPrison_1305;
        BdyDefault();
        SpawnOpoint(SAND_PRISON_OPOINT, Opoint(x: 0f, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1));
    }

    private void SandPrison_1305()
    {
        pic = 526;
        wait = 2;
        next = SandPrison_1306;
        BdyDefault();
    }

    private void SandPrison_1306()
    {
        pic = 527;
        wait = 2;
        next = SandPrison_1307;
        BdyDefault();
    }

    private void SandPrison_1307()
    {
        pic = 528;
        wait = 2;
        next = SandPrison_1308;
        BdyDefault();
    }

    private void SandPrison_1308()
    {
        pic = 529;
        wait = 2;
        next = SandPrison_1309;
        BdyDefault();
    }

    private void SandPrison_1309()
    {
        pic = 530;
        wait = 10;
        next = SandPrison_1310;
        BdyDefault();
    }

    private void SandPrison_1310()
    {
        pic = 531;
        wait = 4;
        next = SandPrison_1311;
        BdyDefault();
    }

    private void SandPrison_1311()
    {
        pic = 532;
        wait = 4;
        next = SandPrison_1312;
        BdyDefault();
    }

    private void SandPrison_1312()
    {
        pic = 533;
        wait = 2;
        next = SandPrison_1313;
        BdyDefault();
    }

    private void SandPrison_1313()
    {
        pic = 534;
        wait = 5;
        next = SandPrison_1314;
        BdyDefault();
    }

    private void SandPrison_1314()
    {
        pic = 535;
        wait = 15;
        next = SandPrison_1316;
        BdyDefault();
    }

    private void SandPrison_1316()
    {
        pic = 533;
        wait = 2;
        next = Standing_0;
        BdyDefault();
    }
    #endregion

    #region Kawarimi
    private void Kawa_1500()
    {
        pic = -9999; wait = 1f; next = Kawa_1501;
        BdyDefault(); bdy.kind = BdyKindEnum.INVULNERABLE;
        ItrDisable();
        SpawnOpoint(KAWA_LOG_OPOINT, Opoint(x: 0f, y: 0.5f, z: 0f, oid: 0, facingFront: true, quantity: 1));
    }
    private void Kawa_1501()
    {
        pic = -9999; wait = 2f; next = Kawa_1502;
        BdyDefault(); bdy.kind = BdyKindEnum.INVULNERABLE;
        ItrDisable();
        if (hitRight)
        {
            dvx = 300f;
            ApplyDefaultPhysic(dvx, dvy: 0f, dvz: 0f, facingRight, ItrPhysicEnum.DEFAULT, ignoreFacing: true);
        }
        else if (hitLeft)
        {
            dvx = -300f;
            ApplyDefaultPhysic(dvx, dvy: 0f, dvz: 0f, facingRight, ItrPhysicEnum.DEFAULT, ignoreFacing: true);
        }
        else
        {
            ApplyDefaultPhysic(dvx: -300f, dvy: 0f, dvz: 0f, facingRight, ItrPhysicEnum.DEFAULT);
        }
    }
    private void Kawa_1502()
    {
        pic = 702; wait = 1f; next = Kawa_1503;
        BdyDefault(); bdy.kind = BdyKindEnum.NORMAL;
        ItrDisable();
    }
    private void Kawa_1503()
    {
        pic = 701; wait = 1f; next = Kawa_1504;
        BdyDefault(); bdy.kind = BdyKindEnum.NORMAL;
        ItrDisable();
    }
    private void Kawa_1504()
    {
        StopMovement();
        pic = 700; wait = 1f; next = Standing_0;
        BdyDefault(); bdy.kind = BdyKindEnum.NORMAL;
        ItrDisable();
    }
    #endregion
    
    #region Float Sand Shield
    private void FloatSandShield_1600()
    {
        EnableManaPoints();
        mp = 150;
        pic = 201; wait = 1f;
        next = CheckIfHaveMana(mp) ? FloatSandShield_1601 : NoManaFloat_694;
        BdyDefault();
    }
    private void FloatSandShield_1601()
    {
        UsageManaPoints(mp);
        pic = 202; wait = 1f; next = FloatSandShield_1602;
        BdyDefault();
    }
    private void FloatSandShield_1602()
    {
        EnableManaPoints();
        pic = 203; wait = 1f; next = FloatSandShield_1603;
        BdyDefault();
        SpawnOpoint(SHIELD_1_OPOINT, Opoint(x: 0f, y: 0f, z: 0f, oid: 0, facingFront: false, quantity: 1, cancellable: false, attachToOwner: false));
    }
    private void FloatSandShield_1603()
    {
        pic = 204; wait = 2f; next = FloatSandShield_1604;
        BdyDefault();
        bdy.kind = BdyKindEnum.NORMAL;
    }
    private void FloatSandShield_1604()
    {
        bdy.kind = BdyKindEnum.INVULNERABLE;
        pic = -9999; wait = 40f; next = FloatSandShield_1609;
        BdyDefault(); Attack(FloatSandShieldArmMonster_1620);
    }
    private void FloatSandShield_1609()
    {
        bdy.kind = BdyKindEnum.INVULNERABLE;
        pic = -9999; wait = 40f; next = FloatSandShield_1605;
        BdyDefault(); Attack(FloatSandShieldArmMonster_1620);
    }
    private void FloatSandShield_1605()
    {
        bdy.kind = BdyKindEnum.NORMAL;
        pic = 203; wait = 1f; next = FloatSandShield_1607;
        BdyDefault();
    }

    private void FloatSandShield_1607()
    {
        pic = 202;
        wait = 1f;
        next = FloatSandShield_1608;
        BdyDefault(); 
    }

    private void FloatSandShield_1608()
    {
        pic = 201;
        wait = 1f;
        next = SandFloatIdle_1160;
        BdyDefault(); 
    }
    #endregion

    #region Float SandShieldArmMonster
    private void FloatSandShieldArmMonster_1620()
    {
        EnableManaPoints();
        mp = 200;
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        pic = -9999; wait = 1f;
        next = CheckIfHaveMana(mp) ? FloatSandShieldArmMonster_1624 : NoManaFloat_694;
        BdyDefault();
    }
    private void FloatSandShieldArmMonster_1624()
    {
        UsageManaPoints(mp);
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        pic = -9999; wait = 39f;
        next = FloatSandShieldArmMonster_1621;
        BdyDefault();
        SpawnOpoint(DEMON_ARM_SAND_ROTATE_OPOINT, Opoint(x: 0.2080002f, y: 0.3660002f, z: -0.058f, oid: 20, facingFront: true, quantity: 1, rotationZ: -45));
    }
    private void FloatSandShieldArmMonster_1621()
    {
        EnableManaPoints();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        bdy.kind = BdyKindEnum.NORMAL;
        pic = 203; wait = 1f; next = FloatSandShieldArmMonster_1621;
        BdyDefault();
    }

    private void FloatSandShieldArmMonster_1622()
    {
        EnableManaPoints();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 202;
        wait = 1f;
        next = FloatSandShieldArmMonster_1623;
        BdyDefault(); 
    }

    private void FloatSandShieldArmMonster_1623()
    {
        EnableManaPoints();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 201;
        wait = 1f;
        next = SandFloatIdle_1160;
        BdyDefault(); 
    }
    #endregion
    
    #region Float SandSpear
    private void FloatSandSpear_1650()
    {
        EnableManaPoints();
        mp = 150;
        pic = 201; wait = 1f;
        next = CheckIfHaveMana(mp) ? FloatSandSpear_1651 : NoManaFloat_694;
        BdyDefault();
    }

    private void FloatSandSpear_1651()
    {
        UsageManaPoints(mp);
        pic = 202; wait = 8f; next = FloatSandSpear_1652;
        BdyDefault();
        SpawnOpoint(SAND_SPEAR_ROTATE_OPOINT, Opoint(x: 0f, y: 0f, z: -0.04116842f, oid: 20, facingFront: true, quantity: 1, rotationZ: -45));
    }

    private void FloatSandSpear_1652()
    {
        EnableManaPoints();
        pic = 203; wait = 1f; next = FloatSandSpear_1653;
        BdyDefault();
    }

    private void FloatSandSpear_1653()
    {
        pic = 204; wait = 2f; next = FloatSandSpear_1654;
        BdyDefault();
    }

    private void FloatSandSpear_1654()
    {
        pic = 205; wait = 2f; next = FloatSandSpear_1655;
        BdyDefault();
    }

    private void FloatSandSpear_1655()
    {
        pic = 206; wait = 1f; next = FloatSandSpear_1656;
        BdyDefault();
    }

    private void FloatSandSpear_1656()
    {
        pic = 207; wait = 1f; next = FloatSandSpear_1657;
        BdyDefault();
    }

    private void FloatSandSpear_1657()
    {
        pic = 208; wait = 1f; next = FloatSandSpear_1658;
        BdyDefault();
    }

    private void FloatSandSpear_1658()
    {
        pic = 209; wait = 10f; next = FloatSandSpear_1659;
        BdyDefault();
    }

    private void FloatSandSpear_1659()
    {
        pic = 210; wait = 1f; next = FloatSandSpear_1660;
        BdyDefault();
    }

    private void FloatSandSpear_1660()
    {
        pic = 211; wait = 8f; next = SandFloatIdle_1160;
        BdyDefault();
    }
    #endregion
    
    #region Float Erupcao
    private void FloatErupcao_1700()
    {
        EnableManaPoints();
        mp = 350;
        state = StateFrameEnum.CANCEL_OPOINTS_IF_CHANGE_CONTEXT_FRAMES;
        pic = 531; wait = 1f;
        next = CheckIfHaveMana(mp) ? FloatErupcao_1701 : NoManaFloat_694;
        BdyDefault();
        ItrDisable();
    }

    private void FloatErupcao_1701()
    {
        UsageManaPoints(mp);
        pic = 532;
        wait = 10;
        next = FloatErupcao_1702;
        BdyDefault();
    }

    private void FloatErupcao_1702()
    {
        EnableManaPoints();
        pic = 533;
        wait = 2;
        next = FloatErupcao_1703;
        BdyDefault();
    }

    private void FloatErupcao_1703()
    {
        pic = 534;
        wait = 0.5f;
        next = FloatErupcao_1710;
        BdyDefault();
        if (onGround)
        {
            SpawnOpoint(ATTACKSAND_6_OPOINT, Opoint(x: 0f, y: 0f, z: 0.8f, oid: 20, facingFront: true, quantity: 1));
        }
    }

    private void FloatErupcao_1710()
    {
        pic = 534;
        wait = 0.5f;
        next = FloatErupcao_1711;
        BdyDefault();
        if (onGround)
        {
            SpawnOpoint(ATTACKSAND_6_OPOINT, Opoint(x: 0f, y: 0f, z: -0.8f, oid: 20, facingFront: true, quantity: 1));
        }
    }

    private void FloatErupcao_1711()
    {
        pic = 534;
        wait = 0.5f;
        next = FloatErupcao_1712;
        BdyDefault();
        if (onGround)
        {
            SpawnOpoint(ATTACKSAND_6_OPOINT, Opoint(x: -0.8f, y: 0f, z: 0f, oid: 20, facingFront: true, quantity: 1));
        }
    }

    private void FloatErupcao_1712()
    {
        pic = 534;
        wait = 0.5f;
        next = FloatErupcao_1704;
        BdyDefault();
        if (onGround)
        {
            SpawnOpoint(ATTACKSAND_6_OPOINT, Opoint(x: 0.8f, y: 0f, z: 0f, oid: 20, facingFront: true, quantity: 1));
        }
    }

    private void FloatErupcao_1704()
    {
        pic = 535;
        wait = 8;
        next = SandFloatIdle_1160;
        BdyDefault();
    }
    #endregion

    #region Ult Float Sand Prision
    private void FloatSandPrison_1750()
    {
        EnableManaPoints();
        mp = 800;
        state = StateFrameEnum.CANCEL_OPOINTS_IF_CHANGE_CONTEXT_FRAMES;
        pic = 521; wait = 2f;
        next = CheckIfHaveMana(mp) ? FloatSandPrison_1751 : NoManaFloat_694;
        BdyDefault();
        ItrDisable();
        SpawnOpoint(ULTIMATE_OPOINT, Opoint(x: 0f, y: 0.371f, z: -0.094f, oid: 0, facingFront: true, quantity: 1));
        StageFadeOut(0.05f);
    }
    private void FloatSandPrison_1751()
    {
        UsageManaPoints(mp);
        pic = 522;
        wait = 1;
        next = FloatSandPrison_1715;
        BdyDefault();
        SpawnOpoint(ULTIMATE_MUGSHOT_OPOINT, Opoint(x: 0f, y: 0f, z: 0f, oid: 1, facingFront: true, quantity: 1));
        StageFadeOut(0.05f);
    }
    private void FloatSandPrison_1715()
    {
        EnableManaPoints();
        BlackoutStage();
        pic = 522;
        wait = 3;
        next = FloatSandPrison_1717;
        BdyDefault();
    }
    private void FloatSandPrison_1717()
    {
        pic = 522;
        wait = 6;
        next = FloatSandPrison_1752;
        BdyDefault();
        StageFadeIn(0.1f);
    }

    private void FloatSandPrison_1752()
    {
        ResetStageColor();
        pic = 523;
        wait = 2;
        next = FloatSandPrison_1753;
        BdyDefault();
    }

    private void FloatSandPrison_1753()
    {
        pic = 524;
        wait = 2;
        next = FloatSandPrison_1754;
        BdyDefault();
    }

    private void FloatSandPrison_1754()
    {
        pic = 525;
        wait = 2;
        next = FloatSandPrison_1755;
        BdyDefault();
        SpawnOpoint(SAND_PRISON_OPOINT, Opoint(x: 0f, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1));
    }

    private void FloatSandPrison_1755()
    {
        pic = 526;
        wait = 2;
        next = FloatSandPrison_1756;
        BdyDefault();
    }

    private void FloatSandPrison_1756()
    {
        pic = 527;
        wait = 2;
        next = FloatSandPrison_1757;
        BdyDefault();
    }

    private void FloatSandPrison_1757()
    {
        pic = 528;
        wait = 2;
        next = FloatSandPrison_1758;
        BdyDefault();
    }

    private void FloatSandPrison_1758()
    {
        pic = 529;
        wait = 2;
        next = FloatSandPrison_1759;
        BdyDefault();
    }

    private void FloatSandPrison_1759()
    {
        pic = 530;
        wait = 10;
        next = FloatSandPrison_1760;
        BdyDefault();
    }

    private void FloatSandPrison_1760()
    {
        pic = 531;
        wait = 4;
        next = FloatSandPrison_1761;
        BdyDefault();
    }

    private void FloatSandPrison_1761()
    {
        pic = 532;
        wait = 4;
        next = FloatSandPrison_1762;
        BdyDefault();
    }

    private void FloatSandPrison_1762()
    {
        pic = 533;
        wait = 2;
        next = FloatSandPrison_1763;
        BdyDefault();
    }

    private void FloatSandPrison_1763()
    {
        pic = 534;
        wait = 5;
        next = FloatSandPrison_1764;
        BdyDefault();
    }

    private void FloatSandPrison_1764()
    {
        pic = 535;
        wait = 15;
        next = FloatSandPrison_1766;
        BdyDefault();
    }

    private void FloatSandPrison_1766()
    {
        pic = 535;
        wait = 2;
        next = SandFloatIdle_1160;
        BdyDefault();
    }
    #endregion
    
    #region Charge Float
    private void ChargeFloatStart_1800()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 201; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeFloatStart_1801;
        BdyDefault();
    }
    private void ChargeFloatStart_1801()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 202; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeFloatStart_1802;
        BdyDefault();
    }
    private void ChargeFloatStart_1802()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 203; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeFloatStart_1803;
        BdyDefault();
    }
    private void ChargeFloatStart_1803()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 204; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeFloat_1805;
        BdyDefault();
    }

    private void ChargeFloat_1805()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        AddManaPoints(manaTechniqueValue);
        pic = 203; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = ChargeFloat_1806; Attack(ChargeFloatStop_1820); DoubleTapPower(ChargeFloatStop_1820); Defense(ChargeFloatStop_1820);
        Jump(ChargeFloatStop_1820);
        BdyDefault();
        SpawnOpoint(CHAKRA_CHARGE_OPOINT, Opoint(x: 0.05f, y: 0.4f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void ChargeFloat_1806()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        EnableManaPoints();
        pic = 202; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = ChargeFloat_1807; Attack(ChargeFloatStop_1820); DoubleTapPower(ChargeFloatStop_1820); Defense(ChargeFloatStop_1820);
        Jump(ChargeFloatStop_1820);
        BdyDefault();
        SpawnOpoint(CHAKRA_CHARGE_AURA_OPOINT, Opoint(x: 0f, y: 0.014f, z: 0f, oid: 0, facingFront: true, quantity: 1));
    }
    private void ChargeFloat_1807()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 203; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = ChargeFloat_1808; Attack(ChargeFloatStop_1820); DoubleTapPower(ChargeFloatStop_1820); Defense(ChargeFloatStop_1820);
        Jump(ChargeFloatStop_1820);
        BdyDefault();
        SpawnOpoint(CHAKRA_CHARGE_SMOKE_OPOINT, Opoint(x: 0f, y: 0.109f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
    }
    private void ChargeFloat_1808()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 204; state = StateFrameEnum.OTHER; wait = 3f;
        next = ChargeFloat_1809; Attack(ChargeFloatStop_1820); DoubleTapPower(ChargeFloatStop_1820); Defense(ChargeFloatStop_1820);
        Jump(ChargeFloatStop_1820);
        BdyDefault();
    }
    private void ChargeFloat_1809()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 203; state = StateFrameEnum.OTHER; wait = 2f;
        next = ChargeFloatStop_1810; Attack(ChargeFloatStop_1820); DoubleTapPower(ChargeFloatStop_1820); Defense(ChargeFloatStop_1820);
        Jump(ChargeFloatStop_1820);
        BdyDefault();
    }
    private void ChargeFloatStop_1810()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 202; state = StateFrameEnum.OTHER; wait = 2f;
        next = ChargeFloat_1811; Attack(ChargeFloatStop_1820); DoubleTapPower(ChargeFloatStop_1820); Defense(ChargeFloatStop_1820);
        Jump(ChargeFloatStop_1820);
        BdyDefault();
    }
    private void ChargeFloat_1811()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 203; state = StateFrameEnum.OTHER; wait = 2f;
        next = ChargeFloat_1812; Attack(ChargeFloatStop_1820); DoubleTapPower(ChargeFloatStop_1820); Defense(ChargeFloatStop_1820);
        Jump(ChargeFloatStop_1820);
        BdyDefault();
    }
    private void ChargeFloat_1812()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 204; state = StateFrameEnum.OTHER; wait = 2f;
        next = ChargeFloat_1805; Attack(ChargeFloatStop_1820); DoubleTapPower(ChargeFloatStop_1820); Defense(ChargeFloatStop_1820);
        Jump(ChargeFloatStop_1820);
        BdyDefault();
    }

    private void ChargeFloatStop_1820()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 203; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeFloatStop_1821;
        BdyDefault();
    }
    private void ChargeFloatStop_1821()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 202; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeFloatStop_1822;
        BdyDefault();
    }
    private void ChargeFloatStop_1822()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 201; state = StateFrameEnum.OTHER; wait = 1f;
        next = ChargeFloatStop_1823;
        BdyDefault();
    }
    private void ChargeFloatStop_1823()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 201; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = ChargeFloatStop_1824;
        BdyDefault();
    }
    private void ChargeFloatStop_1824()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        pic = 201; state = StateFrameEnum.OTHER; wait = 0.5f;
        next = SandFloatIdle_1160;
        BdyDefault();
    }
    #endregion
}