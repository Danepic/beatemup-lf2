using Enums;
using UnityEngine;
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using System.Linq;
using System.Reflection;
using Domains;
using Chars;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class CharController : PhysicsObjController
{
    protected PlayerInput playerInput;
    public PlayerEnum playerEnum = PlayerEnum.COM;
    protected HeaderChar header;
    protected StatsChar stats;
    protected float runningSpeed;
    protected bool hitJump;
    public bool releaseJumpButton;
    public int additionalDamage;
    protected bool holdJump;
    public bool hitAttack;
    public bool releaseAttackButton;
    protected bool hitDefense;
    protected bool releaseDefenseButton;
    protected bool hitPower;
    public bool releasePowerButton;
    protected bool hitSuperPower;
    protected bool hitTaunt;
    public bool hitUp;
    public bool hitDown;
    public bool hitLeft;
    public bool hitRight;
    public bool holdDefenseAfter;
    public bool holdForwardAfter;
    public bool releaseHitLeft;
    protected bool startedHitLeft;
    protected bool startedHitRight;
    public bool releaseHitRight;
    protected bool inMovement;
    protected int walkingSideDirection;
    public float simpleDashToRightWaitTime;
    public bool runningRightEnable;
    public float simpleDashToLeftWaitTime;
    public bool runningLeftEnable;
    public readonly float doubleTabSimpleSideDash = 4f / 30;
    public int walkingUpDownDirection;
    public float sideDashToUpWaitTime;
    public bool sideDashUpEnable;
    public float sideDashToDownWaitTime;
    public bool sideDashDownEnable;
    protected int lock_x_direction = 0;
    protected int lock_z_direction = 0;
    protected bool jumpDashRightEnable;
    protected bool jumpDashLeftEnable;
    public Color parryColor = new(0, 213, 255);
    public Action soloTech;
    public Action soloTechSide;
    public Action soloTechUp;
    public Action soloTechDown;
    public Action airTech;
    public Action runningTech;
    public Action lyingTech;
    public Action superTech;

    public int manaTechniqueValue = 0;
    protected float speedValue = 0;
    
    public static string CHAKRA_CHARGE_OPOINT = "chakra_charge";
    public static string CHAKRA_CHARGE_AURA_OPOINT = "chakra_charge_aura";
    public static string CHAKRA_CHARGE_SMOKE_OPOINT = "chakra_charge_smoke";
    public static string JUMPING_COMBO_OPOINT = "jumping_combo";
    public static string HIT_NORMAL_OPOINT = "hit_normal";
    public static string HIT_BLOOD_OPOINT = "hit_blood";
    public static string DEFENSE_HIT_OPOINT = "defense_hit";
    public static string IMPACT_UP_OPOINT = "impact_up";
    public static string IMPACT_DOWN_OPOINT = "impact_down";
    public static string IMPACT_FORWARD_OPOINT = "impact_forward";
    public static string JUMP_RECOVER_OPOINT = "jump_recover";
    public static string GROUND_EXTRA_LARGE_OPOINT = "ground-extra-large";
    public static string GROUND_EXTRA_SMALL_OPOINT = "ground-extra-small";
    public static string GROUND_NORMAL_OPOINT = "ground-normal";
    public static string GROUND_LARGE_OPOINT = "ground-large";
    public static string GROUND_SMALL_OPOINT = "ground-small";
    public static string ULTIMATE_OPOINT = "ultimate";
    public static string ULTIMATE_MUGSHOT_OPOINT = "ultimate_mugshot";
    public static string KAWA_LOG_OPOINT = "kawa_log";

    protected void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        type = ObjTypeEnum.CHARACTER;
        base.Awake();
        opoints.Add(CHAKRA_CHARGE_OPOINT, EnrichOpoint(3, "Etc/chakra_charge/chakra_charge"));
        opoints.Add(CHAKRA_CHARGE_AURA_OPOINT, EnrichOpoint(3, "Etc/chakra_charge_aura/chakra_charge_aura"));
        opoints.Add(CHAKRA_CHARGE_SMOKE_OPOINT, EnrichOpoint(3, "Etc/chakra_charge_smoke/chakra_charge_smoke"));
        opoints.Add(JUMPING_COMBO_OPOINT, EnrichOpoint(1, "Etc/jumping_combo/jumping_combo"));
        opoints.Add(HIT_NORMAL_OPOINT, EnrichOpoint(10, "Etc/hit_normal/hit_normal"));
        opoints.Add(HIT_BLOOD_OPOINT, EnrichOpoint(10, "Etc/hit_blood/hit_blood"));
        opoints.Add(DEFENSE_HIT_OPOINT, EnrichOpoint(10, "Etc/defense_hit/defense_hit"));
        opoints.Add(IMPACT_UP_OPOINT, EnrichOpoint(2, "Etc/impact_up/impact_up"));
        opoints.Add(IMPACT_DOWN_OPOINT, EnrichOpoint(2, "Etc/impact_down/impact_down"));
        opoints.Add(IMPACT_FORWARD_OPOINT, EnrichOpoint(2, "Etc/impact_forward/impact_forward"));
        opoints.Add(JUMP_RECOVER_OPOINT, EnrichOpoint(1, "Etc/jump_recover/jump_recover"));
        opoints.Add(GROUND_EXTRA_LARGE_OPOINT, EnrichOpoint(1, "Effects/ground/normal/extra-large/ground-extra-large"));
        opoints.Add(GROUND_EXTRA_SMALL_OPOINT, EnrichOpoint(1, "Effects/ground/normal/extra-small/ground-extra-small"));
        opoints.Add(GROUND_NORMAL_OPOINT, EnrichOpoint(1, "Effects/ground/normal/normal/ground-normal"));
        opoints.Add(GROUND_LARGE_OPOINT, EnrichOpoint(1, "Effects/ground/normal/large/ground-large"));
        opoints.Add(GROUND_SMALL_OPOINT, EnrichOpoint(1, "Effects/ground/normal/small/ground-small"));
        opoints.Add(ULTIMATE_OPOINT, EnrichOpoint(1, "Etc/ultimate/ultimate"));
        opoints.Add(ULTIMATE_MUGSHOT_OPOINT, EnrichOpoint(1, "Etc/ultimate_mugshot/ultimate_mugshot"));
        opoints.Add(KAWA_LOG_OPOINT, EnrichOpoint(6, "Attacks/Techs/kawa/log/kawa_log"));
        switch (playerEnum)
        {
            case PlayerEnum.PLAYER_1:
                playerInput.SwitchCurrentControlScheme("P1", Keyboard.current);
                break;
            case PlayerEnum.PLAYER_2:
                playerInput.SwitchCurrentControlScheme("P2", Keyboard.current);
                break;
        }
    }

    protected void Start()
    {
        runningSpeed = stats.speed / 5;
        originalLocalScale = transform.localScale;
        originalColor = spriteRenderer.color;
        totalHp = ResolveHealthPoint();
        totalMp = ResolveManaPoint();
        currentHp = totalHp;
        currentMp = totalMp;
        base.Start();
    }
    protected void Update()
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
        else if (execFixedMoveToPosition)
        {
            FixedMovePosition();
            execFixedMoveToPosition = false;
        }
    }

    public void HitJump(InputAction.CallbackContext context)
    {
        HitJump(context.performed, context.started, context.canceled);
    }

    public void HitJump(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitJump = true;
        }
        else if (canceled)
        {
            hitJump = false;
            releaseJumpButton = true;
        }
    }

    public void HitAttack(InputAction.CallbackContext context)
    {
        HitAttack(context.performed, context.started, context.canceled);
    }

    public void HitAttack(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitAttack = true;
        }
        else if (canceled)
        {
            hitAttack = false;
            releaseAttackButton = true;
        }
    }

    public void HitPower(InputAction.CallbackContext context)
    {
        HitPower(context.performed, context.started, context.canceled);
    }

    public void HitPower(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitPower = true;
        }
        else if (canceled)
        {
            hitPower = false;
            releasePowerButton = true;
        }
    }

    public void HitDefense(InputAction.CallbackContext context)
    {
        HitDefense(context.performed, context.started, context.canceled);
    }

    public void HitDefense(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitDefense = true;
            holdDefenseAfter = true;
        }
        else if (canceled)
        {
            hitDefense = false;
            holdDefenseAfter = false;
            releaseDefenseButton = true;
        }
    }

    public void HitUp(InputAction.CallbackContext context)
    {
        HitUp(context.performed, context.started, context.canceled);
    }

    public void HitUp(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitUp = true;
        }
        else if (started)
        {
            hitUp = true;
        }
        else if (canceled)
        {
            hitUp = false;
        }
    }

    public void HitDown(InputAction.CallbackContext context)
    {
        HitDown(context.performed, context.started, context.canceled);
    }

    public void HitDown(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitDown = true;
        }
        else if (started)
        {
            hitDown = true;
        }
        else if (canceled)
        {
            hitDown = false;
        }
    }

    public void HitLeft(InputAction.CallbackContext context)
    {
        HitLeft(context.performed, context.started, context.canceled);
    }

    public void HitLeft(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitLeft = true;
            holdForwardAfter = true;
            releaseHitLeft = false;
        }
        else if (started)
        {
            hitLeft = true;
            releaseHitLeft = false;
            startedHitLeft = true;
        }
        else if (canceled)
        {
            hitLeft = false;
            holdForwardAfter = false;
            releaseHitLeft = true;
            startedHitLeft = false;
        }
    }

    public void HitRight(InputAction.CallbackContext context)
    {
        HitRight(context.performed, context.started, context.canceled);
    }

    public void HitRight(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitRight = true;
            holdForwardAfter = true;
            releaseHitRight = false;
        }
        else if (started)
        {
            hitRight = true;
            startedHitRight = true;
            releaseHitRight = false;
        }
        else if (canceled)
        {
            hitRight = false;
            holdForwardAfter = false;
            releaseHitRight = true;
            startedHitRight = false;
        }
    }

    public void HitTaunt(InputAction.CallbackContext context)
    {
        HitTaunt(context.performed, context.started, context.canceled);
    }

    public void HitTaunt(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitTaunt = true;
        }
        else if (started)
        {
            hitTaunt = true;
        }
        else if (canceled)
        {
            hitTaunt = false;
        }
    }

    public void HitSuperPower(InputAction.CallbackContext context)
    {
        HitSuperPower(context.performed, context.started, context.canceled);
    }

    public void HitSuperPower(bool performed, bool started, bool canceled)
    {
        if (performed)
        {
            hitSuperPower = true;
        }
        else if (started)
        {
            hitSuperPower = true;
        }
        else if (canceled)
        {
            hitSuperPower = false;
        }
    }

    public void CanFlip()
    {
        if (hitLeft && hitRight)
        {
            return;
        }

        if (hitLeft)
        {
            transform.localScale = new Vector3(-MathF.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            facingRight = false;
        }
        else if (hitRight)
        {
            transform.localScale = new Vector3(MathF.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            facingRight = true;
        }
    }

    public void CanWalking(int frame)
    {
        CanWalking(frames[frame]);
    }

    public void CanWalking(Action frame)
    {
        if ((hitLeft && hitRight) || (hitUp && hitDown))
        {
            return;
        }

        if (hitLeft || hitRight || hitUp || hitDown)
        {
            ChangeFrame(frame);
            CanFlip();
            inMovement = true;
        }
    }

    public void CanStandingFromWalking(int frame)
    {
        CanStandingFromWalking(frames[frame]);
    }

    public void CanStandingFromWalking(Action frame)
    {
        if (!hitLeft && !hitRight && !hitUp && !hitDown)
        {
            if (walkingSideDirection > 0)
            {
                simpleDashToRightWaitTime = doubleTabSimpleSideDash;
                simpleDashToLeftWaitTime = 0;
                runningLeftEnable = false;
            }
            else if (walkingSideDirection < 0)
            {
                simpleDashToLeftWaitTime = doubleTabSimpleSideDash;
                simpleDashToRightWaitTime = 0;
                runningRightEnable = false;
            }

            if (walkingUpDownDirection > 0)
            {
                sideDashToUpWaitTime = doubleTabSimpleSideDash;
                sideDashToDownWaitTime = 0;
                sideDashDownEnable = false;
            }
            else if (walkingUpDownDirection < 0)
            {
                sideDashToDownWaitTime = doubleTabSimpleSideDash;
                sideDashToUpWaitTime = 0;
                sideDashUpEnable = false;
            }

            ChangeFrame(frame);
            inMovement = false;
        }
        else if ((hitLeft && hitRight) || (hitUp && hitDown))
        {
            ChangeFrame(frame);
            inMovement = false;
        }
    }

    public void CountJumpDash()
    {
        if (startedHitRight)
        {
            jumpDashRightEnable = true;
            return;
        }

        if (jumpDashRightEnable && releaseHitRight && !hitLeft)
        {
            jumpDashRightEnable = false;
            simpleDashToLeftWaitTime = 0;
            simpleDashToRightWaitTime = doubleTabSimpleSideDash;
            return;
        }

        if (startedHitLeft)
        {
            jumpDashLeftEnable = true;
            return;
        }

        if (jumpDashLeftEnable && releaseHitLeft && !hitRight)
        {
            jumpDashLeftEnable = false;
            simpleDashToRightWaitTime = 0;
            simpleDashToLeftWaitTime = doubleTabSimpleSideDash;
            return;
        }
    }

    public void CanJumpDash(int frame)
    {
        CanJumpDash(frames[frame]);
    }

    public void CanJumpDash(Action frame)
    {
        if (hitRight && !hitLeft && simpleDashToRightWaitTime > 0)
        {
            simpleDashToLeftWaitTime = 0;
            simpleDashToRightWaitTime = 0;
            ChangeFrame(frame);
        }
        else if (hitLeft && !hitRight && simpleDashToLeftWaitTime > 0)
        {
            simpleDashToLeftWaitTime = 0;
            simpleDashToRightWaitTime = 0;
            ChangeFrame(frame);
        }
    }

    public void CanSimpleDash(int frame)
    {
        CanSimpleDash(frames[frame]);
    }

    public void CanSimpleDash(Action frame)
    {
        if (runningRightEnable && hitRight)
        {
            ChangeFrame(frame);
        }
        else if (runningLeftEnable && hitLeft)
        {
            ChangeFrame(frame);
        }
    }

    public void CanSideDash(int frame)
    {
        CanSideDash(frames[frame]);
    }

    public void CanSideDash(Action frame)
    {
        if (sideDashUpEnable && hitUp)
        {
            ChangeFrame(frame);
        }
        else if (sideDashDownEnable && hitDown)
        {
            ChangeFrame(frame);
        }
    }

    public void CanHoldDefenseAfter(Action action)
    {
        if (holdDefenseAfter)
        {
            ChangeFrame(action);
        }
    }

    public void CanHoldForwardAfter(int frame)
    {
        CanHoldForwardAfter(frames[frame]);
    }

    public void CanHoldForwardAfter(Action frame)
    {
        if (holdForwardAfter)
        {
            ChangeFrame(frame);
        }
    }

    public void CanStopRunning(int frame)
    {
        CanStopRunning(frames[frame]);
    }

    public void CanStopRunning(Action frame)
    {
        if (facingRight && hitLeft)
        {
            ChangeFrame(frame);
        }
        else if (!facingRight && hitRight)
        {
            ChangeFrame(frame);
        }
    }

    public void ManageWalking()
    {
        if (hitRight && !hitLeft)
        {
            walkingSideDirection = 1;
            walkingUpDownDirection = 0;
            return;
        }
        else if (hitLeft && !hitRight)
        {
            walkingSideDirection = -1;
            walkingUpDownDirection = 0;
            return;
        }

        if (hitUp && !hitDown)
        {
            walkingUpDownDirection = 1;
            return;
        }
        else if (hitDown && !hitUp)
        {
            walkingUpDownDirection = -1;
            return;
        }
    }

    protected void LockDirections()
    {
        Lock_X();
        Lock_Z();
    }

    protected void Lock_X()
    {
        if (hitRight && !hitLeft)
        {
            lock_x_direction = 1;
            return;
        }
        else if (hitLeft && !hitRight)
        {
            lock_x_direction = -1;
            return;
        }
        lock_x_direction = 0;
    }

    private void Lock_Z()
    {
        if (hitUp && !hitDown)
        {
            lock_z_direction = 1;
            return;
        }
        else if (hitDown && !hitUp)
        {
            lock_z_direction = -1;
            return;
        }
        lock_z_direction = 0;
    }

    public void ApplyPhysicStanding()
    {
        if (!execPhysicsOnceInFrame)
        {
            return;
        }
        this.velocity = Vector3.zero;
        execMoveToPosition = true;
        execPhysicsOnceInFrame = false;
    }

    public void ApplyPhysicWalking()
    {
        if (!execPhysicsOnceInFrame)
        {
            return;
        }

        if (hitRight && !hitLeft)
        {
            this.velocity.x = dvx;
        }
        else if (hitLeft && !hitRight)
        {
            this.velocity.x = -dvx;
        }
        else
        {
            this.velocity.x = 0;
        }

        if (hitUp && !hitDown)
        {
            this.velocity.z = dvz;
        }
        else if (hitDown && !hitUp)
        {
            this.velocity.z = -dvz;
        }
        else
        {
            this.velocity.z = 0;
        }
        execMoveToPosition = true;
        execPhysicsOnceInFrame = false;
    }

    public void ApplySideDashPhysic()
    {
        if (!execPhysicsOnceInFrame)
        {
            return;
        }
        if (!execPhysicsOnceInFrame)
        {
            return;
        }
        if (walkingUpDownDirection > 0)
        {
            this.velocity.z = dvz;
        }
        else if (walkingUpDownDirection < 0)
        {
            this.velocity.z = -dvz;
        }
        execImpulseForce = true;
        execPhysicsOnceInFrame = false;
    }

    public void ApplyPhysicDash()
    {
        if (hitUp && !hitDown)
        {
            this.velocity.z = dvz;
        }
        else if (!hitUp && hitDown)
        {
            this.velocity.z = -dvz;
        }
        else
        {
            this.velocity.z = 0;
        }
        ApplyDefaultPhysic(dvx, dvy, this.velocity.z, facingRight);
    }

    public void ApplyPhysicJumping()
    {
        var dvxLocal = hitRight || hitLeft ? dvx : 0f;
        var dvzLocal = 0f;

        if (hitUp && !hitDown)
        {
            dvzLocal = dvz;
        }
        else if (!hitUp && hitDown)
        {
            dvzLocal = -dvz;
        }
        ApplyDefaultPhysic(dvxLocal, dvy, dvzLocal, facingRight);
    }

    public void ApplyPhysicDashJumping()
    {
        var dvzLocal = 0f;

        if (hitUp && !hitDown)
        {
            dvzLocal = dvz;
        }
        else if (!hitUp && hitDown)
        {
            dvzLocal = -dvz;
        }
        ApplyDefaultPhysic(dvx, dvy, dvzLocal, facingRight);
    }

    protected void ApplyPhysicDoubleJumping()
    {
        if (!execPhysicsOnceInFrame)
        {
            return;
        }
        this.velocity.z = 0f;
        this.velocity.x = 0f;

        if (hitUp && !hitDown)
        {
            this.velocity.z = dvz;
        }
        else if (!hitUp && hitDown)
        {
            this.velocity.z = -dvz;
        }

        if (lock_x_direction > 0)
        {
            this.velocity.x = dvx;
        }
        else if (lock_x_direction < 0)
        {
            this.velocity.x = -dvx;
        }
        else if (hitRight && !hitLeft)
        {
            this.velocity.x = dvx;
        }
        else if (!hitRight && hitLeft)
        {
            this.velocity.x = -dvx;
        }

        this.velocity.y = dvy;

        execImpulseForce = true;
        execPhysicsOnceInFrame = false;
        Debug.Log(velocity);
    }

    public void ApplyPhysicRunning()
    {
        if (!execPhysicsOnceInFrame)
        {
            return;
        }
        if (facingRight)
        {
            this.velocity.x = dvx + runningSpeed;
        }
        else
        {
            this.velocity.x = -(dvx + runningSpeed);
        }

        if (hitUp && !hitDown)
        {
            this.velocity.z = dvz;
        }
        else if (hitDown && !hitUp)
        {
            this.velocity.z = -dvz;
        }
        else
        {
            this.velocity.z = 0;
        }

        execMoveToPosition = true;
        execPhysicsOnceInFrame = false;
    }

    protected void Timers()
    {
        if (simpleDashToRightWaitTime > 0)
        {
            simpleDashToRightWaitTime -= Time.deltaTime % 60;
            runningRightEnable = true;

            simpleDashToLeftWaitTime = 0;
            runningLeftEnable = false;
        }
        else
        {
            simpleDashToRightWaitTime = 0;
            runningRightEnable = false;
        }

        if (simpleDashToLeftWaitTime > 0)
        {
            simpleDashToLeftWaitTime -= Time.deltaTime % 60;
            runningLeftEnable = true;

            simpleDashToRightWaitTime = 0;
            runningRightEnable = false;
        }
        else
        {
            simpleDashToLeftWaitTime = 0;
            runningLeftEnable = false;
        }

        if (sideDashToUpWaitTime > 0)
        {
            sideDashToUpWaitTime -= Time.deltaTime % 60;
            sideDashUpEnable = true;

            sideDashToDownWaitTime = 0;
            sideDashDownEnable = false;
        }
        else
        {
            sideDashToUpWaitTime = 0;
            sideDashUpEnable = false;
        }

        if (sideDashToDownWaitTime > 0)
        {
            sideDashToDownWaitTime -= Time.deltaTime % 60;
            sideDashDownEnable = true;

            sideDashToUpWaitTime = 0;
            sideDashUpEnable = false;
        }
        else
        {
            sideDashToDownWaitTime = 0;
            sideDashDownEnable = false;
        }

        base.Timers();
    }

    private int ResolveManaPoint()
    {
        int mp = 0;
        switch (stats.stamina)
        {
            case 1:
                mp = 800;
                break;
            case 2:
                mp = 850;
                break;
            case 3:
                mp = 900;
                break;
            case 4:
                mp = 950;
                break;
            case 5:
                mp = 1000;
                break;
            case 6:
                mp = 1050;
                break;
            case 7:
                mp = 1100;
                break;
            case 8:
                mp = 1150;
                break;
            case 9:
                mp = 1200;
                break;
            case 10:
                mp = 1250;
                break;
        }
        return mp;
    }

    private int ResolveHealthPoint()
    {
        int hp = 0;
        switch (stats.resistance)
        {
            case 1:
                hp = 900;
                break;
            case 2:
                hp = 925;
                break;
            case 3:
                hp = 950;
                break;
            case 4:
                hp = 975;
                break;
            case 5:
                hp = 1000;
                break;
            case 6:
                hp = 1025;
                break;
            case 7:
                hp = 1050;
                break;
            case 8:
                hp = 1075;
                break;
            case 9:
                hp = 1100;
                break;
            case 10:
                hp = 1125;
                break;
        }
        return hp;
    }
    
    public int ResolveAdditionalDamagePoint()
    {
        int additionalDamagePoints = 0;
        switch (stats.aggressive)
        {
            case 1:
                additionalDamagePoints = 0;
                break;
            case 2:
                additionalDamagePoints = 10;
                break;
            case 3:
                additionalDamagePoints = 20;
                break;
            case 4:
                additionalDamagePoints = 30;
                break;
            case 5:
                additionalDamagePoints = 40;
                break;
            case 6:
                additionalDamagePoints = 50;
                break;
            case 7:
                additionalDamagePoints = 60;
                break;
            case 8:
                additionalDamagePoints = 70;
                break;
            case 9:
                additionalDamagePoints = 80;
                break;
            case 10:
                additionalDamagePoints = 90;
                break;
        }
        return additionalDamagePoints;
    }
    
    protected int ResolveAdditionalManaPoint()
    {
        int additionalManaPoints = 0;
        switch (stats.technique)
        {
            case 1:
                additionalManaPoints = 55;
                break;
            case 2:
                additionalManaPoints = 60;
                break;
            case 3:
                additionalManaPoints = 65;
                break;
            case 4:
                additionalManaPoints = 70;
                break;
            case 5:
                additionalManaPoints = 75;
                break;
            case 6:
                additionalManaPoints = 80;
                break;
            case 7:
                additionalManaPoints = 85;
                break;
            case 8:
                additionalManaPoints = 90;
                break;
            case 9:
                additionalManaPoints = 95;
                break;
            case 10:
                additionalManaPoints = 100;
                break;
        }
        return additionalManaPoints;
    }
    
    protected float ResolveAdditionalSpeedPoint()
    {
        float additionalSpeedPoints = 0;
        switch (stats.speed)
        {
            case 1:
                additionalSpeedPoints = 1;
                break;
            case 2:
                additionalSpeedPoints = 1.5f;
                break;
            case 3:
                additionalSpeedPoints = 2;
                break;
            case 4:
                additionalSpeedPoints = 2.5f;
                break;
            case 5:
                additionalSpeedPoints = 3;
                break;
            case 6:
                additionalSpeedPoints = 3.5f;
                break;
            case 7:
                additionalSpeedPoints = 4;
                break;
            case 8:
                additionalSpeedPoints = 4.5f;
                break;
            case 9:
                additionalSpeedPoints = 5;
                break;
            case 10:
                additionalSpeedPoints = 5.5f;
                break;
        }
        return additionalSpeedPoints;
    }

    public void Defense(int frame)
    {
        Defense(frames[frame]);
    }

    public void Defense(Action action)
    {
        if (hitDefense)
        {
            releaseDefenseButton = false;
            ChangeFrame(action);
        }
    }

    public void DoubleTapDefense(Action action)
    {
        if (hitDefense && releaseDefenseButton)
        {
            releaseDefenseButton = false;
            ChangeFrame(action);
            return;
        }
    }
    public void Jump(int frame)
    {
        Jump(frames[frame]);
    }
    public void Jump(Action frame)
    {
        if (hitJump)
        {
            releaseJumpButton = false;
            ChangeFrame(frame);
        }

    }
    
    public void DoubleTapJump(int frame)
    {
        DoubleTapJump(frames[frame]);
    }
    
    public void DoubleTapJump(Action frame)
    {
        if (hitJump && releaseJumpButton)
        {
            releaseJumpButton = false;
            ChangeFrame(frame);
        }

    }
    public void Attack(int frame)
    {
        Attack(frames[frame]);
    }
    public void Attack(Action frame)
    {
        if (hitAttack)
        {
            releaseAttackButton = false;
            ChangeFrame(frame);
        }
    }

    public void DoubleTapAttack(int frame)
    {
        DoubleTapAttack(frames[frame]);
    }

    public void DoubleTapAttack(Action frame)
    {
        if (hitAttack && releaseAttackButton)
        {
            releaseAttackButton = false;
            ChangeFrame(frame);
        }
    }

    public void Power(int frame)
    {
        Power(frames[frame]);
    }

    public void Power(Action frame)
    {
        if (hitPower && !hitLeft && !hitRight && !hitUp && !hitDown)
        {
            ChangeFrame(frame);
        }
    }

    public void DoubleTapPower(Action action)
    {
        if (releasePowerButton && hitPower && !hitLeft && !hitRight && !hitUp && !hitDown)
        {
            releasePowerButton = false;
            ChangeFrame(action);
            return;
        }
    }

    public void PowerSide(int frame)
    {
        PowerSide(frames[frame]);
    }

    public void PowerSide(Action frame)
    {
        if (hitPower && (hitRight || hitLeft))
        {
            ChangeFrame(frame);
        }
    }

    public void DoubleTapPowerSide(Action action)
    {

        if (releasePowerButton && hitPower && (hitRight || hitLeft))
        {
            releasePowerButton = false;
            ChangeFrame(action);
            return;
        }

    }

    public void PowerUp(int frame)
    {
        PowerUp(frames[frame]);
    }

    public void PowerUp(Action frame)
    {
        if (hitPower && hitUp)
        {
            ChangeFrame(frame);
        }
    }
    
    public void DoubleTapPowerUp(Action action)
    {
        if (hitPower && hitUp)
        {
            releasePowerButton = false;
            ChangeFrame(action);
            return;
        }
    }

    public void PowerDown(int frame)
    {
        PowerDown(frames[frame]);
    }

    public void PowerDown(Action action)
    {
        if (hitPower && hitDown)
        {
            ChangeFrame(action);
        }
    }

    public void DoubleTapPowerDown(Action action)
    {
        if (releasePowerButton && hitPower && hitDown)
        {
            releasePowerButton = false;
            ChangeFrame(action);
            return;
        }
    }

    public void SuperPower(int frame)
    {
        SuperPower(frames[frame]);
    }

    public void SuperPower(Action frame)
    {
        if (hitSuperPower)
        {
            ChangeFrame(frame);
        }
    }

    public void Taunt(int frame)
    {
        Taunt(frames[frame]);
    }

    public void Taunt(Action frame)
    {
        if (hitTaunt)
        {
            ChangeFrame(frame);
        }
    }

    public void Up(int frame)
    {
        Up(frames[frame]);
    }

    public void Up(Action frame)
    {
        if (hitUp)
        {
            ChangeFrame(frame);
        }
    }

    public void Down(int frame)
    {
        Down(frames[frame]);
    }

    public void Down(Action frame)
    {
        if (hitDown)
        {
            ChangeFrame(frame);
        }
    }

    public void Front(int frame)
    {
        Front(frames[frame]);
    }

    public void Front(Action frame)
    {
        if ((facingRight && hitRight) || (!facingRight && hitLeft))
        {
            ChangeFrame(frame);
        }
    }

    protected void Left(Action action)
    {
        if (hitLeft)
        {
            ChangeFrame(action);
            return;
        }
    }

    protected void Right(Action action)
    {
        if (hitRight)
        {
            ChangeFrame(action);
            return;
        }
    }

    public void ResetParams()
    {
        wasAttacked = false;
        lock_x_direction = 0;
        lock_z_direction = 0;
        spriteRenderer.color = originalColor;
        releaseJumpButton = false;
        releaseDefenseButton = false;
        releaseAttackButton = false;
        ResetMovementFromStop();
        enableNextIfHit = false;
        ItrDisable();
    }

    public void PrepareJumpDash()
    {
        jumpDashLeftEnable = false;
        jumpDashRightEnable = false;
        simpleDashToRightWaitTime = 0;
        simpleDashToLeftWaitTime = 0;
    }
}