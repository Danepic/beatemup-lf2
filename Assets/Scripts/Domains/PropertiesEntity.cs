using System;
using Enums;
using UnityEngine;

namespace Domains
{
    [System.Serializable]
    public class PropertiesEntity
    {
        public int pic;
        public int? next;
        public StateFrameEnum state;
        public float wait;

        public float? dvx;
        public float? dvy;
        public float? dvz;

        public int? hitTaunt;
        public int? hitJump;
        public int? hitSuperPower;
        public int? hitDefense;
        public int? hitAttack;
        public int? hitPower;
        public int? hitJumpDefense;
        public int? hitDefensePower;
        public int? hitDefenseAttack;
        public int? holdForwardAfter;
        public int? holdDefenseAfter;
        public int? holdPowerAfter;
        public int? hitGround;
        public int? hitAir;
        public bool delete = false;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}