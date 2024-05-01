using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Helpers;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharProcess : HurtHitObjProcess
{
    protected int sideDashDirection = 0;
    public int lock_x_direction = 0;
    public int lock_z_direction = 0;

    // Update is called once per frame
    void Update()
    {
        this.CheckPlatforms();
        this.CheckInteraction();
        this.Timers();
        this.ApplyBdy();
        this.ApplyItr();
        this.ExternInteraction();
        this.StateHandle();
        this.ActionHandle();
        this.SpawnOpoint();
    }

    void FixedUpdate()
    {
        StateFrameEnum state = currentFrame.properties.state;
        this.velocity = Vector3.zero;
        switch (state)
        {
            case StateFrameEnum.STANDING:
                ApplyPhysicStanding();
                break;
            case StateFrameEnum.WALKING:
                ApplyPhysicWalking();
                break;
            case StateFrameEnum.RUNNING:
                ApplyPhysicRunning();
                break;
            case StateFrameEnum.SIDE_DASH:
                ApplyPhysicSideDash();
                break;
            case StateFrameEnum.JUMPING:
                ApplyPhysicJumping();
                break;
            default:
                ApplyDefaultPhysic(currentFrame.properties.dvx, currentFrame.properties.dvy, currentFrame.properties.dvz);
                break;
        }
    }

    private void StateHandle()
    {
        switch (currentFrame.properties.state)
        {
            case StateFrameEnum.STANDING:
                CanWalking();
                break;
            case StateFrameEnum.WALKING:
                CanFlip(dataHelper.hitLeft, dataHelper.hitRight);
                CanStanding();
                break;
            case StateFrameEnum.DEFEND:
                CanHoldDefenseAfter();
                CanCharge();
                break;
            case StateFrameEnum.JUMPING_CHARGE:
                LockDirections();
                break;
            case StateFrameEnum.HIT_DEFEND:
            case StateFrameEnum.JUMP_DEFEND:
                CanHoldDefenseAfter();
                break;
            case StateFrameEnum.HOLD_DEFENSE_AFTER:
                CanHoldDefenseAfter();
                break;
        }
    }

    private void ActionHandle()
    {
        if (dataHelper.hitDefense)
        {
            ChangeFrame(currentFrame.properties.hitDefense);
            dataHelper.hitDefense = false;
            return;
        }
        if (dataHelper.hitJump)
        {
            ChangeFrame(currentFrame.properties.hitJump);
            dataHelper.hitJump = false;
            return;
        }
        if (dataHelper.hitAttack)
        {
            ChangeFrame(currentFrame.properties.hitAttack);
            dataHelper.hitAttack = false;
            return;
        }
        if (dataHelper.hitPower)
        {
            ChangeFrame(currentFrame.properties.hitPower);
            dataHelper.hitPower = false;
            return;
        }
        if (dataHelper.hitSuperPower)
        {
            ChangeFrame(currentFrame.properties.hitSuperPower);
            dataHelper.hitSuperPower = false;
            return;
        }
        if (dataHelper.hitTaunt)
        {
            ChangeFrame(currentFrame.properties.hitTaunt);
            dataHelper.hitTaunt = false;
            return;
        }
    }

    private void LockDirections()
    {
        Lock_X();
        Lock_Z();
    }

    private void Lock_X()
    {
        if (dataHelper.hitRight && !dataHelper.hitLeft)
        {
            lock_x_direction = 1;
            return;
        }
        else if (dataHelper.hitLeft && !dataHelper.hitRight)
        {
            lock_x_direction = -1;
            return;
        }
        lock_x_direction = 0;
    }

    private void Lock_Z()
    {
        if (dataHelper.hitUp && !dataHelper.hitDown)
        {
            lock_z_direction = 1;
            return;
        }
        else if (dataHelper.hitDown && !dataHelper.hitUp)
        {
            lock_z_direction = -1;
            return;
        }
        lock_z_direction = 0;
    }

    private void CanWalking()
    {
        if ((dataHelper.hitLeft && dataHelper.hitRight) || (dataHelper.hitUp && dataHelper.hitDown))
        {
            return;
        }
        else if (dataHelper.hitLeft || dataHelper.hitRight || dataHelper.hitUp || dataHelper.hitDown)
        {
            ChangeFrame(StateHelper.WALKING);
            CanFlip(dataHelper.hitLeft, dataHelper.hitRight);
            dataHelper.inMovement = true;
        }
    }

    private void CanCharge()
    {
        if (dataHelper.hitPower)
        {
            dataHelper.hitPower = false;
            ChangeFrame(currentFrame.properties.hitPower);
        }
    }

    private void CanHoldDefenseAfter()
    {
        if (dataHelper.holdDefenseAfter)
        {
            ChangeFrame(currentFrame.properties.holdDefenseAfter);
        }
    }

    private void CanStanding()
    {
        if (!dataHelper.hitLeft && !dataHelper.hitRight && !dataHelper.hitUp && !dataHelper.hitDown)
        {
            ChangeFrame(StateHelper.STANDING);
            dataHelper.inMovement = false;
        }
        else if ((dataHelper.hitLeft && dataHelper.hitRight) || (dataHelper.hitUp && dataHelper.hitDown))
        {
            ChangeFrame(StateHelper.STANDING);
            dataHelper.inMovement = false;
        }
    }

    private void CanFlip(bool hitLeft, bool hitRight)
    {
        if (hitLeft && hitRight)
        {
            return;
        }

        if (hitLeft)
        {
            transform.localScale = new Vector3(-MathF.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            dataHelper.facingRight = false;
        }
        else if (hitRight)
        {
            transform.localScale = new Vector3(MathF.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            dataHelper.facingRight = true;
        }
    }

    private void ApplyPhysicStanding()
    {
        this.velocity = Vector3.zero;
        this.MovePosition();
    }

    private void ApplyPhysicSideDash()
    {
        if (sideDashDirection < 0)
        {
            this.velocity.z = currentFrame.properties.dvz.Value;
        }
        else
        {
            this.velocity.z = -currentFrame.properties.dvz.Value;
        }
        this.ImpulseForce();
    }

    private void ApplyPhysicJumping()
    {
        ApplyDefaultPhysic(currentFrame.properties.dvx * lock_x_direction, currentFrame.properties.dvy, currentFrame.properties.dvz * lock_z_direction);
    }

    private void ApplyPhysicRunning()
    {
        if (dataHelper.facingRight)
        {
            this.velocity.x = objHelper.stats.speed;
        }
        else
        {
            this.velocity.x = -objHelper.stats.speed;
        }

        if (dataHelper.hitUp && !dataHelper.hitDown)
        {
            this.velocity.z = currentFrame.properties.dvz.Value;
        }
        else if (dataHelper.hitDown && !dataHelper.hitUp)
        {
            this.velocity.z = -currentFrame.properties.dvz.Value;
        }
        else
        {
            this.velocity.z = 0;
        }
        this.MovePosition();
    }

    private void ApplyPhysicWalking()
    {
        if (dataHelper.hitRight && !dataHelper.hitLeft)
        {
            this.velocity.x = currentFrame.properties.dvx.Value;
        }
        else if (dataHelper.hitLeft && !dataHelper.hitRight)
        {
            this.velocity.x = -currentFrame.properties.dvx.Value;
        }
        else
        {
            this.velocity.x = 0;
        }

        if (dataHelper.hitUp && !dataHelper.hitDown)
        {
            this.velocity.z = -currentFrame.properties.dvz.Value;
        }
        else if (dataHelper.hitDown && !dataHelper.hitUp)
        {
            this.velocity.z = currentFrame.properties.dvz.Value;
        }
        else
        {
            this.velocity.z = 0;
        }
        this.MovePosition();
    }
}
