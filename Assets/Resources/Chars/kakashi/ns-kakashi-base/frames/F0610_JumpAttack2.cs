using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0610_JumpAttack2 
    {
        private readonly NsKakashiBase _c;

        public F0610_JumpAttack2(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpAttack2_610()
        {
            _c.ResetMovementFromStop();
            _c.state = StateFrameEnum.ATTACK_RESET;
            _c.ItrDisable();
            _c.pic = 500;
            _c.wait = 1f;
            _c.next = JumpAttack2_611;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpAttack2_611()
        {
            _c.pic = 500;
            _c.wait = 0.5f;
            _c.next = JumpAttack2_612;
            _c.OnGround(290);
            _c.state = StateFrameEnum.ATTACK;
            _c.BdyDefault();
        }

        private void JumpAttack2_612()
        {
            _c.pic = 501;
            _c.wait = 0.5f;
            _c.next = JumpAttack2_613;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 100, 50, null, _c.facingRight);
            _c.itr.x = 0.518f;
            _c.itr.y = 0.348f;
            _c.itr.z = 0;
            _c.itr.w = 0.396165f;
            _c.itr.h = 0.3019446f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 25;
            _c.itr.dvy = 0;
            _c.itr.dvz = 0;
            _c.itr.action = 720;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 25;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 4;
            _c.itr.physic = ItrPhysicEnum.FIXED;
            _c.Itr();
        }

        private void JumpAttack2_613()
        {
            _c.StopMovement();
            _c.ItrDisable();
            _c.pic = 502;
            _c.wait = 0.5f;
            _c.next = JumpAttack2_614;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpAttack2_614()
        {
            _c.pic = 503;
            _c.wait = 1f;
            _c.next = JumpAttack2_615;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(1, null, null, _c.facingRight);
        }

        private void JumpAttack2_615()
        {
            _c.ResetMovementFromStop();
            _c.pic = 504;
            _c.wait = 0.5f;
            _c.next = JumpAttack2_616;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpAttack2_616()
        {
            _c.pic = 505;
            _c.wait = 2f;
            _c.next = JumpAttack2_617;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpAttack2_617()
        {
            _c.pic = 506;
            _c.wait = 1f;
            _c.next = JumpAttack2_617;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.DoubleTapAttack(630);
        }
    }
}