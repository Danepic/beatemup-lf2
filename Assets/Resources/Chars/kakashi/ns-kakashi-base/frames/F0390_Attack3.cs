using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0390_Attack3 
    {
        private readonly NsKakashiBase _c;

        public F0390_Attack3(NsKakashiBase c)
        {
            _c = c;
        }

        private void Attack3_390()
        {
            _c.ItrDisable();
            _c.state = StateFrameEnum.ATTACK_RESET;
            _c.pic = 314;
            _c.wait = 1f;
            _c.next = Attack3_391;
            _c.BdyDefault();
        }

        private void Attack3_391()
        {
            _c.pic = 315;
            _c.wait = 0.5f;
            _c.state = StateFrameEnum.ATTACK;
            _c.next = Attack3_392;
            _c.BdyDefault();
        }

        private void Attack3_392()
        {
            _c.pic = 315;
            _c.wait = 0.5f;
            _c.next = Attack3_393;
            _c.BdyDefault();
        }

        private void Attack3_393()
        {
            _c.pic = 315;
            _c.wait = 0.5f;
            _c.next = Attack3_394;
            _c.BdyDefault();
        }

        private void Attack3_394()
        {
            _c.pic = 315;
            _c.wait = 1f;
            _c.next = Attack3_395;
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 200, null, null, _c.facingRight);
        }

        private void Attack3_395()
        {
            _c.pic = 317;
            _c.wait = 1f;
            _c.next = Attack3_396;
            _c.BdyDefault();
            _c.itr.x = 0.0001f;
            _c.itr.y = 0.4315f;
            _c.itr.z = 0;
            _c.itr.w = 0.9272251f;
            _c.itr.h = 0.2817348f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 40;
            _c.itr.dvy = 0;
            _c.itr.dvz = 0;
            _c.itr.action = 700;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 30;
            _c.itr.effect = ItrEffectEnum.BLOOD;
            _c.itr.rest = 5;
            _c.itr.physic = ItrPhysicEnum.FIXED;
            _c.Itr();
        }

        private void Attack3_396()
        {
            _c.ItrDisable();
            _c.pic = 318;
            _c.wait = 1f;
            _c.next = Attack3_399;
            _c.BdyDefault();
        }

        private void Attack3_399()
        {
            _c.StopMovement();
            _c.pic = 319;
            _c.wait = 0.5f;
            _c.next = Attack3_400;
            _c.BdyDefault();
        }

        private void Attack3_400()
        {
            _c.pic = 320;
            _c.wait = 0.5f;
            _c.next = Attack3_401;
            _c.BdyDefault();
        }

        private void Attack3_401()
        {
            _c.pic = 320;
            _c.wait = 1f;
            _c.next = Attack3_402;
            _c.BdyDefault();
        }

        private void Attack3_402()
        {
            _c.ResetMovementFromStop();
            _c.pic = 320;
            _c.wait = 11f;
            _c.next = _c.frames[0];
            _c.DoubleTapAttack(410);
            _c.BdyDefault();
        }
    }
}