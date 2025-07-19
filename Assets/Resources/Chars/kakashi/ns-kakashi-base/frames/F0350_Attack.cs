using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0350_Attack 
    {
        private readonly NsKakashiBase _c;

        public F0350_Attack(NsKakashiBase c)
        {
            _c = c;
        }

        private void Attack1_350()
        {
            _c.StopMovement();
            _c.state = StateFrameEnum.ATTACK;
            _c.ItrDisable();
            _c.pic = 300;
            _c.wait = 5f;
            _c.next = Attack1_351;
            _c.BdyDefault();
        }

        private void Attack1_351()
        {
            _c.pic = 301;
            _c.wait = 0.5f;
            _c.next = Attack1_352;
            _c.BdyDefault();
        }

        private void Attack1_352()
        {
            _c.pic = 302;
            _c.wait = 0.5f;
            _c.next = Attack1_353;
            _c.BdyDefault();
            _c.itr.x = 0.3433f;
            _c.itr.y = 0.4133f;
            _c.itr.z = 0;
            _c.itr.w = 0.4044166f;
            _c.itr.h = 0.2453708f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 40;
            _c.itr.dvy = 0;
            _c.itr.dvz = 0;
            _c.itr.action = 700;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 25;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 4;
            _c.itr.physic = ItrPhysicEnum.FIXED;
            _c.Itr();
        }

        private void Attack1_353()
        {
            _c.ItrDisable();
            _c.pic = 303;
            _c.wait = 0.5f;
            _c.state = StateFrameEnum.STANDING;
            _c.next = Attack1_354;
            _c.IfHit(Attack1Next_360);
            _c.BdyDefault();
        }

        private void Attack1_354()
        {
            _c.pic = 304;
            _c.wait = 1f;
            _c.next = Attack1_355;
            _c.IfHit(Attack1Next_361);
            _c.BdyDefault();
        }

        private void Attack1_355()
        {
            _c.pic = 305;
            _c.wait = 0.5f;
            _c.next = Attack1_356;
            _c.IfHit(Attack1Next_362);
            _c.BdyDefault();
        }

        private void Attack1_356()
        {
            _c.pic = 306;
            _c.wait = 3f;
            _c.next = _c.frames[0];
            _c.IfHit(Attack1Next_363);
            _c.BdyDefault();
        }

        private void Attack1Next_360()
        {
            _c.pic = 303;
            _c.wait = 0.5f;
            _c.next = Attack1Next_361;
            _c.BdyDefault();
            _c.enableNextIfHit = false;
        }

        private void Attack1Next_361()
        {
            _c.pic = 304;
            _c.wait = 1f;
            _c.next = Attack1Next_362;
            _c.BdyDefault();
        }

        private void Attack1Next_362()
        {
            _c.pic = 304;
            _c.wait = 0.5f;
            _c.next = Attack1Next_363;
            _c.BdyDefault();
        }

        private void Attack1Next_363()
        {
            _c.pic = 304;
            _c.wait = 6f;
            _c.state = StateFrameEnum.ATTACK;
            _c.next = _c.frames[0];
            _c.DoubleTapAttack(370);
            _c.BdyDefault();
        }
    }
}