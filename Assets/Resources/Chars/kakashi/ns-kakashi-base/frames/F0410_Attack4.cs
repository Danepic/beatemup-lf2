using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0410_Attack4 
    {
        private readonly NsKakashiBase _c;

        public F0410_Attack4(NsKakashiBase c)
        {
            _c = c;
        }

        private void Attack4_410()
        {
            _c.ItrDisable();
            _c.state = StateFrameEnum.ATTACK_RESET;
            _c.pic = 321;
            _c.wait = 0.5f;
            _c.next = Attack4_411;
            _c.BdyDefault();
        }

        private void Attack4_411()
        {
            _c.pic = 322;
            _c.wait = 1f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = Attack4_419;
            _c.BdyDefault();
        }

        private void Attack4_419()
        {
            _c.pic = 323;
            _c.wait = 1f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = Attack4_420;
            _c.BdyDefault();
        }

        private void Attack4_420()
        {
            _c.pic = 324;
            _c.wait = 1f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = Attack4_421;
            _c.BdyDefault();
        }

        private void Attack4_421()
        {
            _c.pic = 324;
            _c.wait = 0.5f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = Attack4_412;
            _c.BdyDefault();
        }

        private void Attack4_412()
        {
            _c.pic = 325;
            _c.wait = 0.5f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = Attack4_413;
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 125, null, null, _c.facingRight);
        }

        private void Attack4_413()
        {
            _c.ItrDisable();
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.pic = 327;
            _c.wait = 1f;
            _c.next = Attack4_414;
            _c.BdyDefault();
            _c.itr.x = 0.0955f;
            _c.itr.y = 0.3224f;
            _c.itr.z = 0;
            _c.itr.w = 0.6545281f;
            _c.itr.h = 0.24537f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 25;
            _c.itr.dvy = 0;
            _c.itr.dvz = 0;
            _c.itr.action = 700;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 50 + _c.additionalDamage;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 5;
            _c.itr.physic = ItrPhysicEnum.FIXED;
            _c.Itr();
            _c.StopMovement();
        }

        private void Attack4_414()
        {
            _c.ItrDisable();
            _c.pic = 328;
            _c.wait = 3f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = Attack4_415;
            _c.BdyDefault();
        }

        private void Attack4_415()
        {
            _c.pic = 329;
            _c.wait = 0.5f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = Attack4_416;
            _c.BdyDefault();
        }

        private void Attack4_416()
        {
            _c.pic = 330;
            _c.wait = 2f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = Attack4_417;
            _c.BdyDefault();
        }

        private void Attack4_417()
        {
            _c.ResetMovementFromStop();
            _c.pic = 331;
            _c.wait = 2f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = Attack4_418;
            _c.DoubleTapAttack(429);
            _c.BdyDefault();
        }

        private void Attack4_418()
        {
            _c.ResetMovementFromStop();
            _c.pic = 332;
            _c.wait = 2f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = _c.frames[0];
            _c.DoubleTapAttack(429);
            _c.BdyDefault();
        }
    }
}