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

        public int previousId;

        public float repeatAnimationAt;
        public bool repeatAnimationStart;
        public bool repeatAnimationReady;

        public int currentHp;
        public int currentMp;
        public bool facingRight = true;
        public bool? facingUp;

        // Extern Interaction
        public int? summonAction;
        public Vector3 originLocalPosition;
        public bool externAction;
        public ItrEntity externItr;
        public bool externFacingRight;
        public TeamEnum externTeam;
        public int? externId;
        public int? externOwnerId;

        public bool attacked;
        public bool wasAttacked;

        public bool onGround;

        public bool runningRightEnable;
        public bool countRightEnable;

        public bool runningLeftEnable;
        public bool countLeftEnable;

        // Side Dash
        public float sideDashUpCount;
        public bool sideDashUpEnable;
        public bool countSideDashUpEnable;

        public float sideDashDownCount;
        public bool sideDashDownEnable;
        public bool countSideDashDownEnable;

        public bool enableNextIfHit;

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
        public bool hitRight;

        //Hit State
        public bool inMovement;

        //Hold
        public bool holdForwardAfter;
        public bool holdDefenseAfter;
        public bool holdPowerAfter;

        //Team
        public TeamEnum team;
        public int? ownerId;
        public Queue<ObjProcess> originPool;
        public int selfId;
        // public ObjectPointController ownerOpointController;
        // public ObjectPointCache objectPointCache;

        //Injured
        public int injuredCount;
        public static int INJURED_COUNT_LIMIT = 5;
        public bool injuredCountOneTimePerState;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}