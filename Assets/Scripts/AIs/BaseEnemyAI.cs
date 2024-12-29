using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using UnityEngine;

public class BaseEnemyAI : MonoBehaviour
{
    public CharController self;
    public List<CharController> enemies;
    public List<CharController> alies;
    public CharController target;
    public TeamEnum team;
    private float shortestDistance = Mathf.Infinity;
    private float distanceToMeleeAttack = 0.5f;
    private int option = 99;
    private int approachingOption = 99;
    private bool targetInRightSide;
    void Start()
    {
        self = gameObject.GetComponent<CharController>();
        team = self.team;
        var otherChars = GameObject.FindGameObjectsWithTag("Character").Select(chara => chara.GetComponent<CharController>()).ToList();
        enemies = otherChars.Where(charController => charController.team != team).ToList();
        alies = otherChars.Where(charController => charController.team == team).ToList();
    }

    void Update()
    {
        if (target == null)
        {
            target = FindNearestObject(enemies);
        }
        else
        {
            targetInRightSide = (target.transform.position.x - self.transform.position.x) >= 0;
            float distanceToTargetX = Mathf.Abs(target.transform.position.x - self.transform.position.x);
            float distanceToTargetZ = Mathf.Abs(target.transform.position.z - self.transform.position.z);
            switch (target.state)
            {
                case StateFrameEnum.FALLING_DOWN:
                case StateFrameEnum.FALLING:
                case StateFrameEnum.FALLING_FORWARD:
                case StateFrameEnum.LYING:
                    Distancing(distanceToTargetX, distanceToTargetZ);
                    break;
                case StateFrameEnum.ATTACK:
                    if (distanceToTargetX <= distanceToMeleeAttack && distanceToTargetZ <= self.zSizeDefault)
                    {
                        int randomValueAttackOrDefend = UnityEngine.Random.Range(1, 5);
                        if (option == 99)
                        {
                            switch (randomValueAttackOrDefend)
                            {
                                case 1:
                                case 2:
                                case 3:
                                    option = randomValueAttackOrDefend;
                                    CancelHitAttack();
                                    CancelHitJump();
                                    HitDefense();
                                    break;
                                case 4:
                                    option = randomValueAttackOrDefend;
                                    break;
                            }
                        }
                    }
                    ApplyBehavior(distanceToTargetX, distanceToTargetZ);
                    break;
                default:
                    ApplyBehavior(distanceToTargetX, distanceToTargetZ);
                    break;
            }

        }
    }

    private void Distancing(float distanceToTargetX, float distanceToTargetZ)
    {
        CancelHitAttack();
        CancelHitDefense();
        CancelHitJump();
        switch (self.state)
        {
            case StateFrameEnum.WALKING:
                int randomDistancingWay = UnityEngine.Random.Range(1, 3);
                CancelHitAttack();
                if (approachingOption == 99)
                {
                    if (randomDistancingWay == 1)
                    {
                        approachingOption = randomDistancingWay;
                        CancelHitRightLeft();
                        CancelHitUpDown();
                    }
                    else
                    {
                        approachingOption = randomDistancingWay;
                    }
                }

                break;
            case StateFrameEnum.STANDING:
                approachingOption = 99;
                CancelHitAttack();
                if (target.transform.position.x < self.transform.position.x)
                {
                    HitRight();
                }
                else if (target.transform.position.x > self.transform.position.x)
                {
                    HitLeft();
                }
                else
                {
                    CancelHitRightLeft();
                }

                if (target.transform.position.z < self.transform.position.z)
                {
                    HitUp();
                }
                else if (target.transform.position.z > self.transform.position.z)
                {
                    HitDown();
                }
                else
                {
                    CancelHitUpDown();
                }
                break;
        }

    }

    private void ApplyBehavior(float distanceToTargetX, float distanceToTargetZ)
    {
        switch (self.state)
        {
            case StateFrameEnum.ATTACK:
                option = 99;
                approachingOption = 99;
                CancelHitUpDown();
                CancelHitRightLeft();
                Attacking();
                break;
            case StateFrameEnum.STANDING:
                approachingOption = 99;
                CancelHitAttack();
                CancelHitDefense();
                if (distanceToTargetX <= distanceToMeleeAttack && distanceToTargetZ <= self.zSizeDefault)
                {
                    if (targetInRightSide && self.facingRight)
                    {
                        Debug.Log("SJJSJSJ");
                        CancelHitDefense();
                        CancelHitJump();
                        Attacking();
                    }
                    else if (!targetInRightSide && !self.facingRight)
                    {
                        CancelHitDefense();
                        CancelHitJump();
                        Attacking();
                    }
                    else
                    {
                        Debug.Log("TEST");
                        if (targetInRightSide && !self.facingRight)
                        {
                            CancelHitRightLeft();
                            HitRight();
                        }
                        else if (!targetInRightSide && self.facingRight)
                        {
                            CancelHitRightLeft();
                            HitLeft();
                        }
                        self.CanFlip();
                    }
                }
                else
                {
                    ApproachingFromStanding();
                }
                break;

            case StateFrameEnum.WALKING:
                CancelHitAttack();
                CancelHitDefense();
                if (distanceToTargetX <= distanceToMeleeAttack && distanceToTargetZ <= self.zSizeDefault)
                {
                    if (targetInRightSide && self.facingRight)
                    {
                        CancelHitDefense();
                        CancelHitJump();
                        Attacking();
                    }
                    else if (!targetInRightSide && !self.facingRight)
                    {
                        CancelHitDefense();
                        CancelHitJump();
                        Attacking();
                    }
                }
                else
                {
                    if (approachingOption == 99)
                    {
                        int randomValueWeapon = UnityEngine.Random.Range(1, 5);
                        if (randomValueWeapon <= 2 && distanceToTargetX <= distanceToMeleeAttack * 5 && distanceToTargetZ <= self.zSizeDefault)
                        {
                            approachingOption = randomValueWeapon;
                            HitDefense();
                            WalkingApproaching();
                        }
                        else
                        {
                            approachingOption = randomValueWeapon;
                            WalkingApproaching();
                        }
                    }
                    else
                    {

                        WalkingApproaching();
                    }
                }
                break;
            case StateFrameEnum.COMBO_FINISH:
                Attacking();
                int randomValueCombo = UnityEngine.Random.Range(1, 4);
                if (option == 99)
                {
                    switch (randomValueCombo)
                    {
                        case 1:
                            option = randomValueCombo;
                            CancelHitRightLeft();
                            HitUp();
                            break;
                        case 2:
                            option = randomValueCombo;
                            CancelHitRightLeft();
                            HitDown();
                            break;
                        case 3:
                            option = randomValueCombo;
                            if (self.facingRight)
                            {
                                HitRight();
                            }
                            else
                            {
                                HitLeft();
                            }
                            CancelHitUpDown();
                            break;
                    }
                }
                break;
            case StateFrameEnum.UPPER_TO_JUMP_COMBO_FRONT:
                int randomValueJumpCombo = UnityEngine.Random.Range(1, 11);
                if (option == 99)
                {
                    if (randomValueJumpCombo <= 9)
                    {
                        option = randomValueJumpCombo;
                        if (self.facingRight)
                        {
                            HitRight();
                        }
                        else
                        {
                            HitLeft();
                        }
                        HitJump();

                    }
                    else
                    {
                        Distancing(distanceToTargetX, distanceToTargetZ);
                    }
                }
                break;
            case StateFrameEnum.UPPER_TO_JUMP_COMBO:
                int randomValueJumpComboFront = UnityEngine.Random.Range(1, 11);
                if (option == 99)
                {
                    if (randomValueJumpComboFront <= 9)
                    {
                        option = randomValueJumpComboFront;
                        HitJump();

                    }
                    else
                    {
                        Distancing(distanceToTargetX, distanceToTargetZ);
                    }
                }
                break;
            case StateFrameEnum.JUMP_COMBO_ATTACK:
                CancelHitJump();
                Attacking();
                break;
            case StateFrameEnum.CROUCH:
                CancelHitJump();
                option = 99;
                approachingOption = 99;
                break;
            case StateFrameEnum.SIMPLE_DASH:
                self.releaseHitLeft = false;
                self.releaseHitRight = false;
                int randomValue = approachingOption != 99 ? approachingOption : UnityEngine.Random.Range(1, 4);
                if (randomValue <= 2)
                {
                    CancelHitRightLeft();
                    CancelHitUpDown();
                    approachingOption = randomValue;
                    if (distanceToTargetX <= distanceToMeleeAttack * 3 && distanceToTargetZ <= self.zSizeDefault)
                    {
                        Attacking();
                    }
                }
                else if (randomValue == 3)
                {
                    approachingOption = randomValue;
                    self.holdForwardAfter = true;
                    if (self.facingRight)
                    {
                        HitRight();
                    }
                    else
                    {
                        HitLeft();
                    }
                }
                else
                {
                    approachingOption = 99;
                }
                break;
            case StateFrameEnum.RUNNING:
                int randomValueRunning = approachingOption != 99 ? approachingOption : UnityEngine.Random.Range(1, 4);
                if (randomValueRunning >= 2)
                {
                    approachingOption = randomValueRunning;
                    if (distanceToTargetX <= distanceToMeleeAttack * 4 && distanceToTargetZ <= self.zSizeDefault)
                    {
                        Attacking();
                    }
                }
                else if (randomValueRunning == 3)
                {
                    HitDefense();
                }
                else
                {
                    approachingOption = 99;
                }

                RunningApproaching();
                break;
            case StateFrameEnum.DASH:
            case StateFrameEnum.STOP_RUNNING:
                approachingOption = 99;
                CancelHitRightLeft();
                CancelHitUpDown();
                break;
            case StateFrameEnum.DEFEND:
                if (approachingOption <= 2)
                {
                    HitAttack();
                }
                else
                {
                    self.holdDefenseAfter = true;
                    int randomValueHoldDefend = option != 99 ? approachingOption : UnityEngine.Random.Range(1, 4);
                    if (option == 99)
                    {
                        switch (randomValueHoldDefend)
                        {
                            case 1:
                            case 2:
                            case 3:
                                CancelHitDefense();
                                Attacking();
                                option = randomValueHoldDefend;
                                break;
                            case 4:
                                CancelHitAttack();
                                HitDefense();
                                option = randomValueHoldDefend;
                                break;
                        }
                    }
                }
                break;
            case StateFrameEnum.JUMPING:
                approachingOption = 1;
                WalkingApproaching();
                if (distanceToTargetX <= distanceToMeleeAttack * 2 && distanceToTargetZ <= self.zSizeDefault)
                {
                    HitAttack();
                }
                else if (distanceToTargetX <= distanceToMeleeAttack * 5 && distanceToTargetZ <= self.zSizeDefault)
                {
                    HitDefense();
                }
                break;
            case StateFrameEnum.JUMP_DEFEND:
                if (approachingOption <= 2)
                {
                    HitAttack();
                }
                else
                {
                    self.holdDefenseAfter = true;
                    int randomValueHoldDefend = option != 99 ? approachingOption : UnityEngine.Random.Range(1, 4);
                    if (option == 99)
                    {
                        switch (randomValueHoldDefend)
                        {
                            case 1:
                            case 2:
                            case 3:
                                CancelHitDefense();
                                Attacking();
                                option = randomValueHoldDefend;
                                break;
                            case 4:
                                CancelHitAttack();
                                HitDefense();
                                option = randomValueHoldDefend;
                                break;
                        }
                    }
                }
                break;
            case StateFrameEnum.OTHER:
                CancelHitAttack();
                CancelHitDefense();
                CancelHitJump();
                break;
            case StateFrameEnum.ATTACK_RESET:
                CancelHitAttack();
                break;
        }
    }

    private void Attacking()
    {
        HitAttack();
    }

    private void RunningApproaching()
    {
        if (target.transform.position.x > self.transform.position.x)
        {
            HitRight();
        }
        else if (target.transform.position.x < self.transform.position.x)
        {
            HitLeft();
        }
        else
        {
            CancelHitRightLeft();
        }

        if (target.transform.position.z > self.transform.position.z)
        {
            HitUp();
        }
        else if (target.transform.position.z < self.transform.position.z)
        {
            HitDown();
        }
        else
        {
            CancelHitUpDown();
        }
    }

    private void WalkingApproaching()
    {
        int randomValue = approachingOption != 99 ? approachingOption : UnityEngine.Random.Range(1, 3);
        switch (randomValue)
        {
            case 1:
                approachingOption = randomValue;
                if (target.transform.position.x > self.transform.position.x)
                {
                    HitRight();
                }
                else if (target.transform.position.x < self.transform.position.x)
                {
                    HitLeft();
                }
                else
                {
                    CancelHitRightLeft();
                }

                if (target.transform.position.z > self.transform.position.z)
                {
                    HitUp();
                }
                else if (target.transform.position.z < self.transform.position.z)
                {
                    HitDown();
                }
                else
                {
                    CancelHitUpDown();
                }
                break;
            case 2:
                approachingOption = randomValue;
                CancelHitRightLeft();
                CancelHitUpDown();
                break;
            default:
                approachingOption = 99;
                break;
        }
    }

    private void ApproachingFromStanding()
    {
        CancelHitAttack();
        int randomValue = UnityEngine.Random.Range(1, 10);
        if (approachingOption == 99)
        {
            if (randomValue <= 4)
            {
                WalkingApproaching();
                approachingOption = randomValue;
            }
            else if (randomValue <= 6)
            {
                approachingOption = randomValue;

                if (self.facingRight)
                {
                    CancelHitRightLeft();
                    HitRight();
                }
                else
                {
                    CancelHitRightLeft();
                    HitLeft();
                }
            }
            else if (randomValue <= 8)
            {
                approachingOption = randomValue;
                CancelHitRightLeft();
                CancelHitUpDown();
            }
            else
            {
                approachingOption = randomValue;
                HitJump();
                if (self.facingRight)
                {
                    CancelHitRightLeft();
                    HitRight();
                }
                else
                {
                    CancelHitRightLeft();
                    HitLeft();
                }
            }
        }
    }

    private void HitJump()
    {
        self.HitJump(true, true, false);
    }

    private void CancelHitJump()
    {
        self.HitJump(false, false, true);
    }

    private void HitAttack()
    {
        self.HitAttack(true, true, false);
    }

    private void CancelHitAttack()
    {
        Debug.Log(gameObject.name + ":" + "adjiisdhoiadsh");
        self.HitAttack(false, false, true);
    }

    private void CancelHitUpDown()
    {
        self.HitUp(false, false, true);
        self.HitDown(false, false, true);
    }

    private void CancelHitRightLeft()
    {
        self.HitRight(false, false, true);
        self.HitLeft(false, false, true);
    }

    private void HitUp()
    {
        self.HitUp(true, true, false);
        self.HitDown(false, false, true);
    }

    private void HitDown()
    {
        self.HitDown(true, true, false);
        self.HitUp(false, false, true);
    }

    private void HitRight()
    {
        self.HitRight(true, true, false);
    }

    private void HitLeft()
    {
        self.HitLeft(true, true, false);
    }

    private void HitDefense()
    {
        self.HitDefense(true, true, false);
    }

    private void CancelHitDefense()
    {
        self.HitDefense(false, false, true);
    }

    private CharController FindNearestObject(List<CharController> objects)
    {
        CharController nearestObject = null;
        foreach (var obj in objects)
        {
            if (obj == null) continue;

            float distance = Vector3.Distance(self.transform.position, obj.transform.position);

            if (distance < this.shortestDistance)
            {
                shortestDistance = distance;
                nearestObject = obj;
            }
        }

        return nearestObject;
    }
}
