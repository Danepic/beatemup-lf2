using System.Linq;
using Resources.Chars.kakashi.ns_kakashi_base.frames;
using UnityEngine;

public class NsKakashiBase : CharController
{
    public static string KUNAI_OPOINT = "kunai";
    public static string NIN_DOG_OPOINT = "nin-dog-attack";
    public static string RAIKIRI_OPOINT = "raikiri";
    public static string FOG_OPOINT = "fog";
    public static string EVASIVE_OPOINT = "evasive";
    public static string FIRE_PREPARE_OPOINT = "fire-prepare";
    public static string FIRE_IMPACT_OPOINT = "fire-impact";
    public static string FIRE_BALL_OPOINT = "fire-ball";
    public static string KAMUI_EYE_OPOINT = "kamui-eye";
    public static string KAMUI_TARGET_OPOINT = "kamui-target";
    void Awake()
    {
        palettes.Add("Chars/kakashi/ns-kakashi-base/sprites");
        base.Awake();
        header = new()
        {
            name = "Kakashi Hatake"
        };
        stats = new()
        {
            aggressive = 8,
            technique = 8,
            intelligent = 9,
            speed = 8,
            resistance = 6,
            stamina = 6,
        };

        manaTechniqueValue = ResolveAdditionalManaPoint();
        speedValue = ResolveAdditionalSpeedPoint();
        additionalDamage = ResolveAdditionalDamagePoint();

        opoints.Add(KUNAI_OPOINT, EnrichOpoint(6, "Attacks/Weapons/kunai/kunai"));
        opoints.Add(NIN_DOG_OPOINT, EnrichOpoint(2, "Attacks/Techs/nin-dog-attack/nin-dog-attack"));
        opoints.Add(RAIKIRI_OPOINT, EnrichOpoint(12, "Attacks/Techs/raikiri/raikiri"));
        opoints.Add(FOG_OPOINT, EnrichOpoint(4, "Attacks/Techs/fog/fog"));
        opoints.Add(EVASIVE_OPOINT, EnrichOpoint(4, "Etc/status/evasive/evasive"));
        opoints.Add(FIRE_PREPARE_OPOINT, EnrichOpoint(1, "Attacks/Techs/fire/prepare/fire-prepare"));
        opoints.Add(FIRE_IMPACT_OPOINT, EnrichOpoint(1, "Attacks/Techs/fire/impact/fire-impact"));
        opoints.Add(FIRE_BALL_OPOINT, EnrichOpoint(6, "Attacks/Techs/fire/ball/fire-ball"));
        opoints.Add(KAMUI_EYE_OPOINT, EnrichOpoint(1, "Attacks/Techs/sharingan/kamui/eye/kamui-eye"));
        opoints.Add(KAMUI_TARGET_OPOINT, EnrichOpoint(1, "Attacks/Techs/sharingan/kamui/target/kamui-target"));

        BuildFrames();
    }

    public void Start()
    {
        ChangeFrame(0);
        base.Start();
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }

    public void Update()
    {
        base.Update();
    }

    private void BuildFrames()
    {
        var standingFrames = PopulateFrames(new F0000_Standing(this));
        var walkingFrames = PopulateFrames(new F0020_Walking(this));
        var simpleDashFrames = PopulateFrames(new F0040_SimpleDash(this));
        var runningFrames = PopulateFrames(new F0045_Running(this, speedValue));
        var stopRunningFrames = PopulateFrames(new F0060_StopRunning(this));
        var runningDashFrames = PopulateFrames(new F0070_RunningDash(this));
        var sideDashFrames = PopulateFrames(new F0090_SideDash(this));
        var dashBackwardFrames = PopulateFrames(new F0130_DashBackward(this));
        var defenseFrames = PopulateFrames(new F0150_Defense(this));
        var chargeFrames = PopulateFrames(new F0170_Charge(this));
        var tauntFrames = PopulateFrames(new F0195_Taunt(this));
        var jumpFrames = PopulateFrames(new F0210_Jump(this));
        var doubleJumpFrames = PopulateFrames(new F0230_DoubleJump(this));
        var doubleJumpFallingFrames = PopulateFrames(new F0240_DoubleJumpFalling(this));
        var dashJumpFrames = PopulateFrames(new F0250_DashJump(this));
        var jumpDashFrames = PopulateFrames(new F0270_JumpDash(this));
        var crouchFrames = PopulateFrames(new F0290_Crouch(this));
        var jumpFallingWhenXMoveFrames = PopulateFrames(new F0298_JumpFallingWhenXMove(this));
        var jumpDefenseFrames = PopulateFrames(new F0300_JumpDefense(this));
        var jumpFallingNoActionFrames = PopulateFrames(new F0308_JumpFallingNoAction(this));
        var throwingWeaponFrames = PopulateFrames(new F0310_ThrowingWeapon(this));
        var runningAttackFrames = PopulateFrames(new F0330_RunningAttack(this));
        var attackFrames = PopulateFrames(new F0350_Attack(this));
        var attack2Frames = PopulateFrames(new F0370_Attack2(this));
        var attack3Frames = PopulateFrames(new F0390_Attack3(this));
        var attack4Frames = PopulateFrames(new F0410_Attack4(this));
        var comboFinishFrames = PopulateFrames(new F0429_ComboFinish(this));
        var frontAttackFrames = PopulateFrames(new F0430_FrontAttack(this));
        var uppercutFrames = PopulateFrames(new F0450_Uppercut(this));
        var downercutFrames = PopulateFrames(new F0470_Downercut(this));
        var jumpSuperAttackFrames = PopulateFrames(new F0550_JumpSuperAttack(this));
        var jumpThrowingAttackFrames = PopulateFrames(new F0570_JumpThrowingAttack(this));
        var jumpAttack1Frames = PopulateFrames(new F0590_JumpAttack1(this));
        var jumpAttack2Frames = PopulateFrames(new F0610_JumpAttack2(this));
        var jumpAttack3Frames = PopulateFrames(new F0630_JumpAttack3(this));
        var jumpComboFrames = PopulateFrames(new F0650_JumpCombo(this));
        var jumpComboFallingFrames = PopulateFrames(new F0660_JumpComboFalling(this));
        var doubleJumpComboFrames = PopulateFrames(new F0670_DoubleJumpCombo(this));
        var doubleJumpComboFallingFrames = PopulateFrames(new F0680_DoubleJumpComboFalling(this));
        var injuredFrames = PopulateFrames(new F0700_Injured(this));
        var injuredSkyFrames = PopulateFrames(new F0720_InjuredSky(this));
        var kawarimiFrames = PopulateFrames(new F0750_Kawarimi(this));
        var fallingFrames = PopulateFrames(new F0800_Falling(this));
        var fallingDownFrames = PopulateFrames(new F0820_FallingDown(this));
        var fallingUpFrames = PopulateFrames(new F0840_FallingUp(this));
        var fallingForwardFrames = PopulateFrames(new F0860_FallingForward(this));
        var criticalDefenseFrames = PopulateFrames(new F0880_CriticalDefense(this));
        var lyingFrames = PopulateFrames(new F0910_Lying(this));
        var jumpRecoverFrames = PopulateFrames(new F0930_JumpRecover(this));
        var catchFrames = PopulateFrames(new F0950_Catch(this));
        var raikiriFrames = PopulateFrames(new F1000_Raikiri(this));
        var kirigakureFrames = PopulateFrames(new F1100_Kirigakure(this));
        var cortePresaBrocaFrames = PopulateFrames(new F1150_CortePresaBroca(this));
        var katonBallFrames = PopulateFrames(new F1200_KatonBall(this));
        var raikiriAirFrames = PopulateFrames(new F1250_RaikiriAir(this));
        var superKamuiFrames = PopulateFrames(new F1300_SuperKamui(this));

        frames = standingFrames
            .Concat(walkingFrames)
            .Concat(simpleDashFrames)
            .Concat(runningFrames)
            .Concat(stopRunningFrames)
            .Concat(runningDashFrames)
            .Concat(sideDashFrames)
            .Concat(dashBackwardFrames)
            .Concat(defenseFrames)
            .Concat(chargeFrames)
            .Concat(tauntFrames)
            .Concat(jumpFrames)
            .Concat(doubleJumpFrames)
            .Concat(doubleJumpFallingFrames)
            .Concat(dashJumpFrames)
            .Concat(jumpDashFrames)
            .Concat(crouchFrames)
            .Concat(jumpFallingWhenXMoveFrames)
            .Concat(jumpDefenseFrames)
            .Concat(jumpFallingNoActionFrames)
            .Concat(throwingWeaponFrames)
            .Concat(runningAttackFrames)
            .Concat(attackFrames)
            .Concat(attack2Frames)
            .Concat(attack3Frames)
            .Concat(attack4Frames)
            .Concat(comboFinishFrames)
            .Concat(frontAttackFrames)
            .Concat(uppercutFrames)
            .Concat(downercutFrames)
            .Concat(jumpSuperAttackFrames)
            .Concat(jumpThrowingAttackFrames)
            .Concat(jumpAttack1Frames)
            .Concat(jumpAttack2Frames)
            .Concat(jumpAttack3Frames)
            .Concat(jumpComboFrames)
            .Concat(jumpComboFallingFrames)
            .Concat(doubleJumpComboFrames)
            .Concat(doubleJumpComboFallingFrames)
            .Concat(injuredFrames)
            .Concat(injuredSkyFrames)
            .Concat(kawarimiFrames)
            .Concat(fallingFrames)
            .Concat(fallingDownFrames)
            .Concat(fallingUpFrames)
            .Concat(fallingForwardFrames)
            .Concat(criticalDefenseFrames)
            .Concat(lyingFrames)
            .Concat(jumpRecoverFrames)
            .Concat(catchFrames)
            .Concat(raikiriFrames)
            .Concat(kirigakureFrames)
            .Concat(cortePresaBrocaFrames)
            .Concat(katonBallFrames)
            .Concat(raikiriAirFrames)
            .Concat(superKamuiFrames)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}