using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0370_Attack2 
    {
        private readonly NsKakashiBase _c;

        public F0370_Attack2(NsKakashiBase c)
        {
            _c = c;
        }

        private void Attack2_370()
        {
            _c.ItrDisable();
            _c.state = StateFrameEnum.ATTACK_RESET;
            _c.pic = 307;
            _c.wait = 0.5f;
            _c.next = Attack2_371;
            _c.BdyDefault();
        }

        private void Attack2_371()
        {
            _c.pic = 308;
            _c.wait = 1f;
            _c.state = StateFrameEnum.ATTACK;
            _c.next = Attack2_372;
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 150, null, null, _c.facingRight);
        }

        private void Attack2_372()
        {
            _c.pic = 309;
            _c.wait = 1f;
            _c.next = Attack2_373;
            _c.BdyDefault();
            _c.itr.x = 0.3433f;
            _c.itr.y = 0.4133f;
            _c.itr.z = 0;
            _c.itr.w = 0.4044166f;
            _c.itr.h = 0.2453708f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 25;
            _c.itr.dvy = 0;
            _c.itr.dvz = 0;
            _c.itr.action = 700;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 25;
            _c.itr.effect = ItrEffectEnum.BLOOD;
            _c.itr.rest = 8;
            _c.itr.physic = ItrPhysicEnum.FIXED;
            _c.Itr();
        }

        private void Attack2_373()
        {
            _c.StopMovement();
            _c.ItrDisable();
            _c.pic = 311;
            _c.wait = 0.5f;
            _c.next = Attack2_374;
            _c.BdyDefault();
        }

        private void Attack2_374()
        {
            _c.pic = 312;
            _c.wait = 0.5f;
            _c.next = Attack2_375;
            _c.BdyDefault();
        }

        private void Attack2_375()
        {
            _c.pic = 313;
            _c.wait = 0.5f;
            _c.next = Attack2_376;
            _c.BdyDefault();
        }

        private void Attack2_376()
        {
            _c.pic = 313;
            _c.wait = 0.5f;
            _c.next = Attack2_377;
            _c.BdyDefault();
        }

        private void Attack2_377()
        {
            _c.pic = 313;
            _c.wait = 0.75f;
            _c.next = Attack2_378;
            _c.BdyDefault();
        }

        private void Attack2_378()
        {
            _c.pic = 313;
            _c.wait = 2f;
            _c.next = Attack2_379;
            _c.BdyDefault();
        }

        private void Attack2_379()
        {
            _c.ResetMovementFromStop();
            _c.pic = 313;
            _c.wait = 4f;
            _c.next = _c.frames[0];
            _c.DoubleTapAttack(390);
            _c.BdyDefault();
        }
    }
}