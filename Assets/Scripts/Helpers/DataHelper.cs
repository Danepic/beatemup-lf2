using System;
using System.Collections.Generic;
using Domains;
using Enums;
using UnityEngine;

namespace Helpers
{
    [System.Serializable]
    public class DataHelper
    {
        private Color originalColor;
        private Color fadeOutColor;

        public bool execOpointOneTimeInFrame;
        public bool execImpulseForceOneTimeInFrame;
        public bool execHitSpawnOneTimeInFrame;
        public bool execHealthManaPointsOneTimeInFrame;

        public int previousId; //TODO

        public float repeatAnimationAt; //TODO
        public bool repeatAnimationStart; //TODO
        public bool repeatAnimationReady; //TODO
        public bool facingRight = true;

        // Extern Interaction
        public int? summonAction;
        public Vector3 originLocalPosition;
        public bool externAction;
        public ItrEntity externItr;
        public bool externFacingRight;
        public TeamEnum externTeam;
        public int? externId;
        public int? externOwnerId;
        public Vector3 contactPoint;
        public float damageRestTU;

        public bool attacking; //TODO
        public bool wasAttacked; //TODO
        public bool damageInSingleTarget;
        public int? targetId;

        public bool onGround;

        public bool runningRightEnable;

        public bool runningLeftEnable;

        public bool jumpDashRightEnable;

        public bool jumpDashLeftEnable;

        // Side Dash
        public bool sideDashUpEnable; //TODO

        public bool sideDashDownEnable; //TODO

        public bool enableNextIfHit; //TODO

        //Hit
        public bool hitJump;
        public bool hitDefense;
        public bool holdDefense;
        public bool hitAttack;
        public bool hitTaunt;
        public bool hitPower;
        public bool hitSuperPower;
        public bool hitUp;
        public bool hitDown;
        public bool hitLeft;
        public bool releaseHitLeft;
        public bool startedHitLeft;
        public bool hitRight;
        public bool releaseHitRight;
        public bool startedHitRight;

        //Hit State
        public bool inMovement;

        //Hold
        public bool holdForwardAfter; //TODO
        public bool holdDefenseAfter; //TODO
        public bool holdPowerAfter; //TODO

        //Team
        public TeamEnum team;
        public int? ownerId;
        public Queue<ObjProcess> originPool;
        public int selfId;

        //Injured
        public int injuredCount; //TODO
        public static int INJURED_COUNT_LIMIT = 5; //TODO
        public bool injuredCountOneTimePerState; //TODO
        public bool isDeath; //TODO
        public bool isDefending;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}