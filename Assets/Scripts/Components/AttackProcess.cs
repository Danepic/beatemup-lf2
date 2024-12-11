using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class AttackProcess : HurtHitObjProcess
{
    // Update is called once per frame
    void Update()
    {
        this.CheckPlatforms();
        this.Timers();
        this.ApplyBdy();
        this.ApplyItr();
        this.SpawnOpoint();
        this.ManageHealthManaPoints();
    }

    void FixedUpdate()
    {
        StateFrameEnum state = currentFrame.properties.state;
        this.velocity = Vector3.zero;
        switch (state)
        {
            case StateFrameEnum.ATTACK_IDLE:
                this.velocity = Vector3.zero;
                MovePosition();
                break;
            case StateFrameEnum.ATTACK_FLYING:
                ApplyDefaultPhysic(currentFrame.properties.dvx, currentFrame.properties.dvy, currentFrame.properties.dvz, dataHelper.facingRight, ForceMode.VelocityChange);
                break;
            case StateFrameEnum.ATTACK_REMOVE:
                this.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                break;
            default:
                ApplyDefaultPhysic(currentFrame.properties.dvx, currentFrame.properties.dvy, currentFrame.properties.dvz, dataHelper.facingRight, ForceMode.VelocityChange);
                break;
        }
    }
}
