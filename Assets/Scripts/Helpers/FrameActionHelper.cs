using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpers
{
    public class StateHelper
    {
        public static readonly int STANDING = 0; //OK
        public static readonly int WALKING = 20; //OK
        public static readonly int SIMPLE_DASH = 40; //OK
        public static readonly int RUNNING = 45; //OK
        public static readonly int STOP_RUNNING = 60; //OK
        public static readonly int RUNNING_DASH = 70; //OK
        public static readonly int SIDE_DASH = 90; //OK
        public static readonly int DASH_FORWARD = 110; //OK
        public static readonly int DASH_BACKWARD = 130; //OK
        public static readonly int DEFENSE = 150; //OK
        public static readonly int HIT_DEFENSE = 160; //OK
        public static readonly int CHARGE = 170; //OK
        public static readonly int TAUNT = 190;
        public static readonly int JUMPING = 210; //OK
        public static readonly int JUMPING_FALLING = 220; //OK
        public static readonly int DOUBLE_JUMPING = 230; //OK
        public static readonly int DOUBLE_JUMPING_FALLING = 240; //OK
        public static readonly int DASH_JUMP = 250; //OK
        public static readonly int JUMP_DASH = 270; //OK
        public static readonly int CROUCH = 290; //OK
        public static readonly int JUMP_FALLING_WHEN_X_MOVE = 298; //OK
        public static readonly int JUMP_DEFENSE = 300; //OK
        public static readonly int HIT_JUMP_DEFENSE = 305; //OK
        public static readonly int JUMP_FALLING_NO_ACTION = 308; //OK
        public static readonly int THROWING_WEAPON = 310; //OK
        public static readonly int RUNNING_ATTACK = 330; //OK
        public static readonly int ATTACK_1 = 350; //OK
        public static readonly int ATTACK_2 = 370; //OK
        public static readonly int ATTACK_3 = 390; //OK
        public static readonly int ATTACK_4 = 410; //OK
        public static readonly int COMBO_FINISH = 429; //OK
        public static readonly int FRONT_ATTACK = 430; //OK
        public static readonly int UPPERCUT = 450; //OK
        public static readonly int DOWNERCUT = 470; //OK
        public static readonly int JUMP_SUPER_ATTACK = 550; //OK
        public static readonly int JUMP_THROWING_WEAPON = 570; //OK
        public static readonly int JUMP_ATTACK_1 = 590; //OK
        public static readonly int JUMP_ATTACK_2 = 610; //OK
        public static readonly int JUMP_ATTACK_3 = 630; //OK
        public static readonly int JUMPING_COMBO = 650; //OK
        public static readonly int JUMPING_COMBO_FALLING = 660; //OK
        public static readonly int DOUBLE_JUMPING_COMBO = 670; //OK
        public static readonly int DOUBLE_JUMPING_COMBO_FALLING = 680; //OK
        public static readonly int JUMP_NO_ACTION = 690; //Nao sei onde aplicar, o JUMP_FALLING_NO_ACTION já faz isso
        public static readonly int INJURED_MANAGER = 700; //OK
        public static readonly int INJURED_1 = 702; //OK
        public static readonly int INJURED_2 = 710; //OK
        public static readonly int INJURED_SKY_MANAGER = 720; //OK
        public static readonly int INJURED_SKY_1 = 722; //OK
        public static readonly int INJURED_SKY_2 = 730; //OK
        public static readonly int STUN = 740;
        public static readonly int CONFUSE = 750;
        public static readonly int IGNITE = 760;
        public static readonly int POISON = 770;
        public static readonly int PARALYSIS = 780;
        public static readonly int FREEZE = 790;
        public static readonly int FALLING = 800; //OK
        public static readonly int FALLING_DOWN = 820; //OK
        public static readonly int FALLING_UP = 840; //OK
        public static readonly int FALLING_FORWARD = 860; //OK
        public static readonly int CRITICAL_DEFENSE = 880;  //OK
        public static readonly int JUMP_CRITICAL_DEFENSE = 885; //OK
        public static readonly int LYING = 910; //OK
        public static readonly int JUMP_RECOVER = 930; //OK
        public static readonly int CATCH_STANDING = 940;
        public static readonly int CATCH_INJURED = 950;
        public static readonly int CATCH_INJURED_2 = 960;
        public static readonly int CATCH_FALLING = 970;
        public static readonly int CATCH_FALL_FORWARD = 980;
        public static readonly int CATCH_FALL_DOWN = 990;
        public static readonly int CATCH_FALL_UP = 1000;
        public static readonly int CATCH_CHARGE_JUMP = 1010;
        public static readonly int CATCH_JUMP = 1020;
        public static readonly int CATCH_INVISIBLE = 1030;
        public static readonly int KAWARIMI = 1040;
        public static readonly int DEATH = 2000;
        public static readonly int DELETE = 3000;
        public static readonly int POWER_1 = 4000;
        public static readonly int POWER_2 = 4500;
        public static readonly int POWER_3 = 5000;
        public static readonly int POWER_4 = 6500;
        public static readonly int POWER_5 = 7000;
        public static readonly int SUPER_POWER = 7500;
    }
}