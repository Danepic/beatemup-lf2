using Enums;
using UnityEngine;
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using System.Linq;
using Domains;
using Chars;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class CharController : PhysicsObjController
{
    public PlayerInput playerInput;
    public PlayerEnum playerEnum = PlayerEnum.COM;
    protected HeaderChar header;
    protected StatsChar stats;
    protected float runningSpeed;
    protected bool hitJump;
    protected bool releaseJumpButton;
    protected bool holdJump;
    public bool hitAttack;
    public bool releaseAttackButton;
    protected bool hitDefense;
    protected bool releaseDefenseButton;
    protected bool hitPower;
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

    protected void Awake()
    {
        type = ObjTypeEnum.CHARACTER;
        base.Awake();
        opoints.Add(0, EnrichOpoint(3, "Etc/chakra_charge/chakra_charge"));
        opoints.Add(1, EnrichOpoint(3, "Etc/chakra_charge_aura/chakra_charge_aura"));
        opoints.Add(2, EnrichOpoint(3, "Etc/chakra_charge_smoke/chakra_charge_smoke"));
        opoints.Add(3, EnrichOpoint(1, "Etc/jumping_combo/jumping_combo"));
        opoints.Add(4, EnrichOpoint(10, "Etc/hit_normal/hit_normal"));
        opoints.Add(5, EnrichOpoint(10, "Etc/hit_blood/hit_blood"));
        opoints.Add(6, EnrichOpoint(10, "Etc/defense_hit/defense_hit"));
        opoints.Add(7, EnrichOpoint(2, "Etc/impact_up/impact_up"));
        opoints.Add(8, EnrichOpoint(2, "Etc/impact_down/impact_down"));
        opoints.Add(9, EnrichOpoint(2, "Etc/impact_forward/impact_forward"));
        opoints.Add(10, EnrichOpoint(1, "Etc/jump_recover/jump_recover"));
        opoints.Add(11, EnrichOpoint(1, "Effects/ground/normal/extra-large/ground-extra-large"));
        opoints.Add(12, EnrichOpoint(1, "Effects/ground/normal/extra-small/ground-extra-small"));
        opoints.Add(13, EnrichOpoint(1, "Effects/ground/normal/normal/ground-normal"));
        opoints.Add(14, EnrichOpoint(1, "Effects/ground/normal/large/ground-large"));
        opoints.Add(15, EnrichOpoint(1, "Effects/ground/normal/small/ground-small"));
        opoints.Add(16, EnrichOpoint(1, "Etc/ultimate/ultimate"));
        opoints.Add(17, EnrichOpoint(1, "Etc/ultimate_mugshot/ultimate_mugshot"));
        opoints.Add(18, EnrichOpoint(6, "Attacks/Techs/kawa/log/kawa_log"));
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
        currentHp = header.startHp;
        currentMp = header.startMp;
        totalHp = ResolveHealthPoint();
        totalMp = ResolveManaPoint();
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
        else if (started)
        {
            hitPower = true;
        }
        else if (canceled)
        {
            hitPower = false;
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

    protected void CanWalking(Action walking)
    {
        if ((hitLeft && hitRight) || (hitUp && hitDown))
        {
            return;
        }
        else if (hitLeft || hitRight || hitUp || hitDown)
        {
            ChangeFrame(walking);
            CanFlip();
            inMovement = true;
        }
    }

    protected void CanStandingFromWalking(Action standing)
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

            ChangeFrame(standing);
            inMovement = false;
        }
        else if ((hitLeft && hitRight) || (hitUp && hitDown))
        {
            ChangeFrame(standing);
            inMovement = false;
        }
    }

    protected void CountJumpDash()
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

    protected void CanJumpDash(Action action)
    {
        if (hitRight && !hitLeft && simpleDashToRightWaitTime > 0)
        {
            simpleDashToLeftWaitTime = 0;
            simpleDashToRightWaitTime = 0;
            ChangeFrame(action);
        }
        else if (hitLeft && !hitRight && simpleDashToLeftWaitTime > 0)
        {
            simpleDashToLeftWaitTime = 0;
            simpleDashToRightWaitTime = 0;
            ChangeFrame(action);
        }
    }

    protected void CanSimpleDash(Action action)
    {
        if (runningRightEnable && hitRight)
        {
            ChangeFrame(action);
        }
        else if (runningLeftEnable && hitLeft)
        {
            ChangeFrame(action);
        }
    }

    protected void CanSideDash(Action action)
    {
        if (sideDashUpEnable && hitUp)
        {
            ChangeFrame(action);
        }
        else if (sideDashDownEnable && hitDown)
        {
            ChangeFrame(action);
        }
    }

    protected void CanCharge(Action action)
    {
        if (hitPower)
        {
            hitPower = false;
            ChangeFrame(action);
        }
    }

    protected void CanHoldDefenseAfter(Action action)
    {
        if (holdDefenseAfter)
        {
            ChangeFrame(action);
        }
    }

    protected void CanHoldForwardAfter(Action action)
    {
        if (holdForwardAfter)
        {
            ChangeFrame(action);
        }
    }

    protected void CanStopRunning(Action action)
    {
        if (facingRight && hitLeft)
        {
            ChangeFrame(action);
        }
        else if (!facingRight && hitRight)
        {
            ChangeFrame(action);
        }
    }

    protected void InAir(Action action)
    {
        if (!onGround)
        {
            ChangeFrame(action);
        }
    }

    protected void ManageWalking()
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

    protected void ApplyPhysicStanding()
    {
        if (!execPhysicsOnceInFrame)
        {
            return;
        }
        this.velocity = Vector3.zero;
        execMoveToPosition = true;
        execPhysicsOnceInFrame = false;
    }

    protected void ApplyPhysicWalking()
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

    protected void ApplySideDashPhysic()
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

    protected void ApplyPhysicDash()
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

    protected void ApplyPhysicJumping()
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

    protected void ApplyPhysicDashJumping()
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

    protected void ApplyPhysicRunning()
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
        switch (stats.stamina)
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

    protected void Defense(Action action)
    {
        if (hitDefense)
        {
            releaseDefenseButton = false;
            ChangeFrame(action);
            return;
        }
    }

    protected void DoubleTapDefense(Action action)
    {
        if (hitDefense && releaseDefenseButton)
        {
            releaseDefenseButton = false;
            ChangeFrame(action);
            return;
        }
    }
    protected void Jump(Action action)
    {
        if (hitJump)
        {
            releaseJumpButton = false;
            ChangeFrame(action);
            return;
        }

    }
    protected void DoubleTapJump(Action action)
    {
        if (hitJump && releaseJumpButton)
        {
            releaseJumpButton = false;
            ChangeFrame(action);
            return;
        }

    }
    protected void Attack(Action action)
    {
        if (hitAttack)
        {
            releaseAttackButton = false;
            ChangeFrame(action);
            return;
        }
    }

    protected void DoubleTapAttack(Action action)
    {
        if (hitAttack && releaseAttackButton)
        {
            releaseAttackButton = false;
            ChangeFrame(action);
            return;
        }
    }

    protected void Power(Action action)
    {

        if (hitPower && !hitLeft && !hitRight && !hitUp && !hitDown)
        {
            ChangeFrame(action);
            return;
        }

    }

    protected void PowerSide(Action action)
    {

        if (hitPower && (hitRight || hitLeft))
        {
            ChangeFrame(action);
            return;
        }

    }

    protected void PowerUp(Action action)
    {

        if (hitPower && hitUp)
        {
            ChangeFrame(action);
            return;
        }

    }

    protected void PowerDown(Action action)
    {

        if (hitPower && hitDown)
        {
            ChangeFrame(action);
            return;
        }

    }

    protected void SuperPower(Action action)
    {
        if (hitSuperPower)
        {
            ChangeFrame(action);
            return;
        }
    }

    protected void Taunt(Action action)
    {

        if (hitTaunt)
        {
            ChangeFrame(action);
            return;
        }
    }

    protected void Up(Action action)
    {

        if (hitUp)
        {
            ChangeFrame(action);
            return;
        }
    }

    protected void Down(Action action)
    {

        if (hitDown)
        {
            ChangeFrame(action);
            return;
        }
    }

    protected void Front(Action action)
    {
        if ((facingRight && hitRight) || (!facingRight && hitLeft))
        {
            ChangeFrame(action);
            return;
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

    protected void ResetParams()
    {
        isDefending = false;
        wasAttacked = false;
        lock_x_direction = 0;
        lock_z_direction = 0;
        spriteRenderer.color = originalColor;
        releaseJumpButton = false;
        ResetMovementFromStop();
        enableNextIfHit = false;
        ItrDisable();
    }

    protected void PrepareJumpDash()
    {
        jumpDashLeftEnable = false;
        jumpDashRightEnable = false;
        simpleDashToRightWaitTime = 0;
        simpleDashToLeftWaitTime = 0;
    }
}