using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0430_FrontAttack 
    {
        private readonly NsKakashiBase _c;

        public F0430_FrontAttack(NsKakashiBase c)
        {
            _c = c;
        }

        private void FrontAttack_430()
        {
            _c.pic = 427;
            _c.wait = 0.5f;
            _c.state = StateFrameEnum.ATTACK;
            _c.next = FrontAttack_431;
            _c.BdyDefault();
        }

        private void FrontAttack_431()
        {
            _c.pic = 431;
            _c.wait = 0.5f;
            _c.next = FrontAttack_432;
            _c.BdyDefault();
        }

        private void FrontAttack_432()
        {
            _c.pic = 432;
            _c.wait = 0.5f;
            _c.next = FrontAttack_433;
            _c.BdyDefault();
            _c.ResetMovementFromStop();
        }

        private void FrontAttack_433()
        {
            _c.pic = 433;
            _c.wait = 0.5f;
            _c.next = FrontAttack_434;
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 200, dvy: 0, dvz: 0, _c.facingRight);
        }

        private void FrontAttack_434()
        {
            _c.pic = 434;
            _c.wait = 2f;
            _c.next = FrontAttack_435;
            _c.BdyDefault();
            _c.itr.x = 0.2114f;
            _c.itr.y = 0.3655f;
            _c.itr.z = 0;
            _c.itr.w = 0.4590549f;
            _c.itr.h = 0.5135916f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 400;
            _c.itr.dvy = 150;
            _c.itr.dvz = 0;
            _c.itr.action = 860;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 50;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 15;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.ItrDefault();
        }

        private void FrontAttack_435()
        {
            _c.ItrDisable();
            _c.pic = 435;
            _c.wait = 0.5f;
            _c.next = FrontAttack_436;
            _c.BdyDefault();
        }

        private void FrontAttack_436()
        {
            _c.pic = 436;
            _c.wait = 1.5f;
            _c.next = FrontAttack_437;
            _c.BdyDefault();
        }

        private void FrontAttack_437()
        {
            _c.pic = 437;
            _c.wait = 0.5f;
            _c.next = FrontAttack_438;
            _c.BdyDefault();
            _c.StopMovement();
        }

        private void FrontAttack_438()
        {
            _c.pic = 437;
            _c.wait = 5.5f;
            _c.next = FrontAttack_439;
            _c.BdyDefault();
        }

        private void FrontAttack_439()
        {
            _c.pic = 438;
            _c.wait = 1f;
            _c.next = FrontAttack_440;
            _c.BdyDefault();
        }

        private void FrontAttack_440()
        {
            _c.pic = 439;
            _c.wait = 4.5f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}