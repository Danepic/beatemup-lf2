using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Helpers;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharProcess : HurtHitObjProcess
{
    public int lock_x_direction = 0;
    public int lock_z_direction = 0;
    public readonly float doubleTabSimpleSideDash = 4f / 30;

    public float simpleDashToRightWaitTime = 0;

    public float simpleDashToLeftWaitTime = 0;

    public float walkingSideDirection = 0;

    public float walkingUpDownDirection = 0;

    public float sideDashToUpWaitTime = 0;

    public float sideDashToDownWaitTime = 0;

    public Color parryColor = new Color(0, 213, 255);

    // Update is called once per frame
    void Update()
    {
        this.CheckPlatforms();
        this.CheckInteraction();
        this.CheckIfNextHitEnable();
        this.Timers();
        this.ApplyBdy();
        this.ApplyItr();
        this.StateHandle();
        this.ActionHandle();
        this.SpawnOpoint();
        this.ManageHealthManaPoints();
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
            case StateFrameEnum.DASH:
                ApplyPhysicDash();
                break;
            case StateFrameEnum.JUMPING:
                ApplyPhysicJumping();
                break;
            case StateFrameEnum.DASH_JUMPING_IMPULSE:
                ApplyPhysicDashJumping();
                break;
            case StateFrameEnum.DOUBLE_JUMPING_IMPULSE:
                ApplyPhysicDoubleJumping();
                break;
            case StateFrameEnum.HIT_DEFEND:
                ApplyDefaultPhysic(dataHelper.externItr.dvx / 2, currentFrame.properties.dvy, currentFrame.properties.dvz, dataHelper.externFacingRight, ForceMode.VelocityChange);
                break;
            case StateFrameEnum.INJURED:
                ApplyDefaultPhysic(dataHelper.externItr.dvx, dataHelper.externItr.dvy, dataHelper.externItr.dvz, dataHelper.externFacingRight, ForceMode.VelocityChange);
                break;
            case StateFrameEnum.JUMP_ATTACK:
                rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
                ApplyDefaultPhysic(currentFrame.properties.dvx, currentFrame.properties.dvy, currentFrame.properties.dvz, dataHelper.facingRight, ForceMode.VelocityChange);
                break;
            case StateFrameEnum.INJURED_SKY:
                rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
                ApplyDefaultPhysic(dataHelper.externItr.dvx, 0, dataHelper.externItr.dvz, dataHelper.externFacingRight, ForceMode.VelocityChange);
                break;
            case StateFrameEnum.FALLING:
                ApplyDefaultPhysic(currentFrame.properties.dvx, currentFrame.properties.dvy, currentFrame.properties.dvz, dataHelper.facingRight, ForceMode.VelocityChange);
                break;
            case StateFrameEnum.FALLING_EXTERN_FORCE:
                ApplyDefaultPhysic(dataHelper.externItr.dvx, dataHelper.externItr.dvy, dataHelper.externItr.dvz, dataHelper.externFacingRight, ForceMode.VelocityChange);
                break;
            case StateFrameEnum.STOP_DV:
                rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                rigidbody.linearVelocity = Vector3.zero;
                break;
            case StateFrameEnum.JUMP_RECOVER:
                ApplyDefaultPhysic(dataHelper.externItr.dvx / 2, 0f, dataHelper.externItr.dvz / 2, dataHelper.externFacingRight, ForceMode.VelocityChange);
                break;
            default:
                ApplyDefaultPhysic(currentFrame.properties.dvx, currentFrame.properties.dvy, currentFrame.properties.dvz, dataHelper.facingRight, ForceMode.VelocityChange);
                break;
        }
    }

    private void StateHandle()
    {
        switch (currentFrame.properties.state)
        {
            case StateFrameEnum.STANDING:
                dataHelper.isDefending = false;
                dataHelper.wasAttacked = false;
                ManageStanding();
                CanWalking();
                CanSimpleDash();
                CanSideDash();
                lock_x_direction = 0;
                lock_z_direction = 0;
                spriteRenderer.color = originalColor;
                break;
            case StateFrameEnum.STOP_DV:
                dataHelper.isDefending = false;
                dataHelper.wasAttacked = false;
                lock_x_direction = 0;
                lock_z_direction = 0;
                break;
            case StateFrameEnum.WALKING:
                ManageWalking();
                CanFlip(dataHelper.hitLeft, dataHelper.hitRight);
                CanStandingFromWalking();
                break;
            case StateFrameEnum.RUNNING:
                CanStopRunning();
                break;
            case StateFrameEnum.JUMP_DEFEND:
            case StateFrameEnum.DEFEND:
                dataHelper.isDefending = true;
                CanHoldDefenseAfter();
                CanCharge();
                break;
            case StateFrameEnum.JUMPING_CHARGE:
                LockDirections();
                dataHelper.jumpDashLeftEnable = false;
                dataHelper.jumpDashRightEnable = false;
                simpleDashToRightWaitTime = 0;
                simpleDashToLeftWaitTime = 0;
                break;
            case StateFrameEnum.JUMPING_FALLING:
                CanFlip(dataHelper.hitLeft, dataHelper.hitRight);
                CountJumpDash();
                CanJumpDash();
                break;
            case StateFrameEnum.DASH_JUMPING:
                CanFlip(dataHelper.hitLeft, dataHelper.hitRight);
                break;
            case StateFrameEnum.DASH_JUMPING_IMPULSE:
                lock_x_direction = dataHelper.facingRight ? 1 : -1;
                Debug.Log(lock_x_direction);
                break;
            case StateFrameEnum.JUMPING:
            case StateFrameEnum.DOUBLE_JUMPING_FALLING:
            case StateFrameEnum.DOUBLE_JUMPING:
                CanFlip(dataHelper.hitLeft, dataHelper.hitRight);
                break;
            case StateFrameEnum.JUMP_HIT_DEFEND:
            case StateFrameEnum.HIT_DEFEND:
                spriteRenderer.color = originalColor;
                dataHelper.isDefending = true;
                CanHoldDefenseAfter();
                if (dataHelper.execHitSpawnOneTimeInFrame)
                {
                    dataHelper.execHitSpawnOneTimeInFrame = false;
                    SpawnHitOpoint(dataHelper.contactPoint, ItrEffectEnum.DEFENSE);
                }
                break;
            case StateFrameEnum.HOLD_DEFENSE_AFTER:
                spriteRenderer.color = originalColor;
                CanHoldDefenseAfter();
                break;
            case StateFrameEnum.HOLD_FORWARD_AFTER:
                spriteRenderer.color = originalColor;
                CanHoldForwardAfter();
                break;
            case StateFrameEnum.FALLING_EXTERN_FORCE:
                spriteRenderer.color = originalColor;
                if (dataHelper.execHitSpawnOneTimeInFrame)
                {
                    dataHelper.execHitSpawnOneTimeInFrame = false;
                    SpawnHitOpoint(dataHelper.contactPoint, dataHelper.externItr.effect);
                }
                break;
            case StateFrameEnum.INJURED_MANAGER:
                spriteRenderer.color = originalColor;
                var optionInjured = UnityEngine.Random.value;
                ChangeFrame(optionInjured > 0.5f ? StateHelper.INJURED_1 : StateHelper.INJURED_2);
                if (dataHelper.execHitSpawnOneTimeInFrame)
                {
                    dataHelper.execHitSpawnOneTimeInFrame = false;
                    SpawnHitOpoint(dataHelper.contactPoint, dataHelper.externItr.effect);
                }
                break;
            case StateFrameEnum.INJURED_SKY_MANAGER:
                spriteRenderer.color = originalColor;
                var optionInjuredSky = UnityEngine.Random.value;
                ChangeFrame(optionInjuredSky > 0.5f ? StateHelper.INJURED_SKY_1 : StateHelper.INJURED_SKY_2);
                if (dataHelper.execHitSpawnOneTimeInFrame)
                {
                    dataHelper.execHitSpawnOneTimeInFrame = false;
                    SpawnHitOpoint(dataHelper.contactPoint, dataHelper.externItr.effect);
                }
                break;
            case StateFrameEnum.LYING:
                spriteRenderer.color = originalColor;
                dataHelper.isDefending = false;
                dataHelper.wasAttacked = false;
                dataHelper.hitAttack = false;
                dataHelper.hitDefense = false;
                dataHelper.hitJump = false;
                dataHelper.hitPower = false;
                break;
            case StateFrameEnum.COMBO_FINISH:
                if (dataHelper.hitUp)
                {
                    dataHelper.hitUp = false;
                    ChangeFrame(StateHelper.UPPERCUT);
                }
                else if (dataHelper.hitDown)

                {
                    dataHelper.hitDown = false;
                    ChangeFrame(StateHelper.DOWNERCUT);
                }
                else if (dataHelper.hitRight && !dataHelper.hitLeft && dataHelper.facingRight)
                {
                    dataHelper.hitRight = false;
                    ChangeFrame(StateHelper.FRONT_ATTACK);
                }
                else if (!dataHelper.hitRight && dataHelper.hitLeft && !dataHelper.facingRight)
                {
                    dataHelper.hitLeft = false;
                    ChangeFrame(StateHelper.FRONT_ATTACK);
                }
                break;
            case StateFrameEnum.CRITICAL_DEFENSE:
                spriteRenderer.color = parryColor;
                if (canParry) {
                    base.currentHp += lastDamage > 0 ? lastDamage : 0;
                    base.canParry = false;
                }
                break;
        }
    }

    private void ActionHandle()
    {
        if (dataHelper.hitDefense)
        {
            ChangeFrame(currentFrame.properties.hitDefense, ref dataHelper.hitDefense);
            return;
        }
        if (dataHelper.hitJump)
        {
            ChangeFrame(currentFrame.properties.hitJump, ref dataHelper.hitJump);
            return;
        }
        if (dataHelper.hitAttack)
        {
            ChangeFrame(currentFrame.properties.hitAttack, ref dataHelper.hitAttack);
            return;
        }
        if (dataHelper.hitPower)
        {
            ChangeFrame(currentFrame.properties.hitPower, ref dataHelper.hitPower);
            return;
        }
        if (dataHelper.hitSuperPower)
        {
            ChangeFrame(currentFrame.properties.hitSuperPower, ref dataHelper.hitSuperPower);
            return;
        }
        if (dataHelper.hitTaunt)
        {
            ChangeFrame(currentFrame.properties.hitTaunt, ref dataHelper.hitTaunt);
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

    private void CanHoldForwardAfter()
    {
        if (dataHelper.holdForwardAfter)
        {
            ChangeFrame(currentFrame.properties.holdForwardAfter);
        }
    }

    private void CanStopRunning()
    {
        if (dataHelper.facingRight && dataHelper.hitLeft)
        {
            ChangeFrame(StateHelper.STOP_RUNNING);
        }
        else if (!dataHelper.facingRight && dataHelper.hitRight)
        {
            ChangeFrame(StateHelper.STOP_RUNNING);
        }
    }

    private void ManageStanding()
    {
    }

    private void ManageWalking()
    {
        if (dataHelper.hitRight && !dataHelper.hitLeft)
        {
            walkingSideDirection = 1;
            walkingUpDownDirection = 0;
            return;
        }
        else if (dataHelper.hitLeft && !dataHelper.hitRight)
        {
            walkingSideDirection = -1;
            walkingUpDownDirection = 0;
            return;
        }

        if (dataHelper.hitUp && !dataHelper.hitDown)
        {
            walkingUpDownDirection = 1;
            walkingSideDirection = 0;
            return;
        }
        else if (dataHelper.hitDown && !dataHelper.hitUp)
        {
            walkingUpDownDirection = -1;
            walkingSideDirection = 0;
            return;
        }
    }

    private void CanStandingFromWalking()
    {
        if (!dataHelper.hitLeft && !dataHelper.hitRight && !dataHelper.hitUp && !dataHelper.hitDown)
        {
            if (walkingSideDirection > 0)
            {
                simpleDashToRightWaitTime = doubleTabSimpleSideDash;
                simpleDashToLeftWaitTime = 0;
                dataHelper.runningLeftEnable = false;
            }
            else if (walkingSideDirection < 0)
            {
                simpleDashToLeftWaitTime = doubleTabSimpleSideDash;
                simpleDashToRightWaitTime = 0;
                dataHelper.runningRightEnable = false;
            }

            if (walkingUpDownDirection > 0)
            {
                sideDashToUpWaitTime = doubleTabSimpleSideDash;
                sideDashToDownWaitTime = 0;
                dataHelper.sideDashDownEnable = false;
            }
            else if (walkingUpDownDirection < 0)
            {
                sideDashToDownWaitTime = doubleTabSimpleSideDash;
                sideDashToUpWaitTime = 0;
                dataHelper.sideDashUpEnable = false;
            }

            ChangeFrame(StateHelper.STANDING);
            dataHelper.inMovement = false;
        }
        else if ((dataHelper.hitLeft && dataHelper.hitRight) || (dataHelper.hitUp && dataHelper.hitDown))
        {
            ChangeFrame(StateHelper.STANDING);
            dataHelper.inMovement = false;
        }
    }


    private void CountJumpDash()
    {
        if (dataHelper.startedHitRight)
        {
            dataHelper.jumpDashRightEnable = true;
            return;
        }

        if (dataHelper.jumpDashRightEnable && dataHelper.releaseHitRight && !dataHelper.hitLeft)
        {
            dataHelper.jumpDashRightEnable = false;
            simpleDashToLeftWaitTime = 0;
            simpleDashToRightWaitTime = doubleTabSimpleSideDash;
            return;
        }

        if (dataHelper.startedHitLeft)
        {
            dataHelper.jumpDashLeftEnable = true;
            return;
        }

        if (dataHelper.jumpDashLeftEnable && dataHelper.releaseHitLeft && !dataHelper.hitRight)
        {
            dataHelper.jumpDashLeftEnable = false;
            simpleDashToRightWaitTime = 0;
            simpleDashToLeftWaitTime = doubleTabSimpleSideDash;
            return;
        }
    }

    private void CanJumpDash()
    {
        if (dataHelper.hitRight && !dataHelper.hitLeft && simpleDashToRightWaitTime > 0)
        {
            simpleDashToLeftWaitTime = 0;
            simpleDashToRightWaitTime = 0;
            ChangeFrame(StateHelper.JUMP_DASH);
        }
        else if (dataHelper.hitLeft && !dataHelper.hitRight && simpleDashToLeftWaitTime > 0)
        {
            simpleDashToLeftWaitTime = 0;
            simpleDashToRightWaitTime = 0;
            ChangeFrame(StateHelper.JUMP_DASH);
        }
    }

    private void CanSimpleDash()
    {
        if (dataHelper.runningRightEnable && dataHelper.hitRight)
        {
            ChangeFrame(StateHelper.SIMPLE_DASH);
        }
        else if (dataHelper.runningLeftEnable && dataHelper.hitLeft)
        {
            ChangeFrame(StateHelper.SIMPLE_DASH);
        }
    }

    private void CanSideDash()
    {
        if (dataHelper.sideDashUpEnable && dataHelper.hitUp)
        {
            ChangeFrame(StateHelper.SIDE_DASH);
        }
        else if (dataHelper.sideDashDownEnable && dataHelper.hitDown)
        {
            ChangeFrame(StateHelper.SIDE_DASH);
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
        if (walkingUpDownDirection < 0)
        {
            this.velocity.z = -currentFrame.properties.dvz.Value;
        }
        else
        {
            this.velocity.z = currentFrame.properties.dvz.Value;
        }
        this.ImpulseForce(ForceMode.VelocityChange);
    }

    private void ApplyPhysicDash()
    {
        if (dataHelper.hitUp && !dataHelper.hitDown)
        {
            this.velocity.z = currentFrame.properties.dvz.Value;
        }
        else if (!dataHelper.hitUp && dataHelper.hitDown)
        {
            this.velocity.z = -currentFrame.properties.dvz.Value;
        }
        else
        {
            this.velocity.z = 0;
        }
        ApplyDefaultPhysic(currentFrame.properties.dvx, currentFrame.properties.dvy, this.velocity.z, dataHelper.facingRight, ForceMode.VelocityChange);
    }

    private void ApplyPhysicJumping()
    {
        var dvx = dataHelper.hitRight || dataHelper.hitLeft ? currentFrame.properties.dvx : 0f;
        var dvz = 0f;

        if (currentFrame.properties.dvz.HasValue)
        {
            if (dataHelper.hitUp && !dataHelper.hitDown)
            {
                dvz = currentFrame.properties.dvz.Value;
            }
            else if (!dataHelper.hitUp && dataHelper.hitDown)
            {
                dvz = -currentFrame.properties.dvz.Value;
            }
        }
        ApplyDefaultPhysic(dvx, currentFrame.properties.dvy, dvz, dataHelper.facingRight, ForceMode.VelocityChange);
    }

    private void ApplyPhysicDashJumping()
    {
        var dvz = 0f;

        if (currentFrame.properties.dvz.HasValue)
        {
            if (dataHelper.hitUp && !dataHelper.hitDown)
            {
                dvz = currentFrame.properties.dvz.Value;
            }
            else if (!dataHelper.hitUp && dataHelper.hitDown)
            {
                dvz = -currentFrame.properties.dvz.Value;
            }
        }
        ApplyDefaultPhysic(currentFrame.properties.dvx, currentFrame.properties.dvy, dvz, dataHelper.facingRight, ForceMode.VelocityChange);
    }

    private void ApplyPhysicDoubleJumping()
    {
        this.velocity.z = 0f;
        this.velocity.x = 0f;

        if (currentFrame.properties.dvz.HasValue)
        {
            if (dataHelper.hitUp && !dataHelper.hitDown)
            {
                this.velocity.z = currentFrame.properties.dvz.Value;
            }
            else if (!dataHelper.hitUp && dataHelper.hitDown)
            {
                this.velocity.z = -currentFrame.properties.dvz.Value;
            }
        }

        if (currentFrame.properties.dvx != null)
        {
            if (lock_x_direction > 0)
            {
                this.velocity.x = currentFrame.properties.dvx.Value;
            }
            else if (lock_x_direction < 0)
            {
                this.velocity.x = -currentFrame.properties.dvx.Value;
            }
            else if (dataHelper.hitRight && !dataHelper.hitLeft)
            {
                this.velocity.x = currentFrame.properties.dvx.Value;
            }
            else if (!dataHelper.hitRight && dataHelper.hitLeft)
            {
                this.velocity.x = -currentFrame.properties.dvx.Value;
            }
        }

        if (currentFrame.properties.dvy != null)
        {
            this.velocity.y = currentFrame.properties.dvy.Value;
        }

        this.ImpulseForce(ForceMode.VelocityChange);
    }

    private void ApplyPhysicRunning()
    {
        if (dataHelper.facingRight)
        {
            this.velocity.x = currentFrame.properties.dvx.Value + runningSpeed;
        }
        else
        {
            this.velocity.x = -(currentFrame.properties.dvx.Value + runningSpeed);
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

    protected void Timers()
    {
        if (simpleDashToRightWaitTime > 0)
        {
            simpleDashToRightWaitTime -= Time.deltaTime % 60;
            dataHelper.runningRightEnable = true;

            simpleDashToLeftWaitTime = 0;
            dataHelper.runningLeftEnable = false;
        }
        else
        {
            simpleDashToRightWaitTime = 0;
            dataHelper.runningRightEnable = false;
        }

        if (simpleDashToLeftWaitTime > 0)
        {
            simpleDashToLeftWaitTime -= Time.deltaTime % 60;
            dataHelper.runningLeftEnable = true;

            simpleDashToRightWaitTime = 0;
            dataHelper.runningRightEnable = false;
        }
        else
        {
            simpleDashToLeftWaitTime = 0;
            dataHelper.runningLeftEnable = false;
        }

        if (sideDashToUpWaitTime > 0)
        {
            sideDashToUpWaitTime -= Time.deltaTime % 60;
            dataHelper.sideDashUpEnable = true;

            sideDashToDownWaitTime = 0;
            dataHelper.sideDashDownEnable = false;
        }
        else
        {
            sideDashToUpWaitTime = 0;
            dataHelper.sideDashUpEnable = false;
        }

        if (sideDashToDownWaitTime > 0)
        {
            sideDashToDownWaitTime -= Time.deltaTime % 60;
            dataHelper.sideDashDownEnable = true;

            sideDashToUpWaitTime = 0;
            dataHelper.sideDashUpEnable = false;
        }
        else
        {
            sideDashToDownWaitTime = 0;
            dataHelper.sideDashDownEnable = false;
        }

        base.Timers();
    }
}
