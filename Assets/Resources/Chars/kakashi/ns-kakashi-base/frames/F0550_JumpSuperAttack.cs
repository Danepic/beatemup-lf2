using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0550_JumpSuperAttack 
    {
        private readonly NsKakashiBase _c;

        public F0550_JumpSuperAttack(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpSuperAttack_550()
        {
            _c.pic = 500;
            _c.wait = 0.5f;
            _c.next = JumpSuperAttack_551;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpSuperAttack_551()
        {
            _c.pic = 500;
            _c.wait = 1f;
            _c.next = JumpSuperAttack_552;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpSuperAttack_552()
        {
            _c.pic = 500;
            _c.wait = 0.5f;
            _c.next = JumpSuperAttack_553;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpSuperAttack_553()
        {
            _c.pic = 500;
            _c.wait = 1f;
            _c.next = JumpSuperAttack_554;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpSuperAttack_554()
        {
           _c.pic = 501;
           _c.wait = 0.5f;
           _c.next = JumpSuperAttack_555;
           _c.OnGround(290);
           _c.bdy.x = 0.1047f;
           _c.bdy.y = 0.1856f;
           _c.bdy.z = 0;
           _c.bdy.w = 0.4125906f;
           _c.bdy.h = 0.371265f;
           _c.bdy.zwidth = 0.22f;
           _c.Bdy();
           _c.itr.x = 0.4922f;
           _c.itr.y = 0.3392f;
           _c.itr.z = 0;
           _c.itr.w = 0.2629879f;
           _c.itr.h = 0.3019446f;
           _c.itr.zwidth = 0.44f;
           _c.itr.dvx = 100;
           _c.itr.dvy = -50;
           _c.itr.dvz = 0;
           _c.itr.action = 800;
           _c.itr.applyInSingleEnemy = false;
           _c.itr.defensable = true;
           _c.itr.level = 1;
           _c.itr.injury = 60;
           _c.itr.effect = ItrEffectEnum.NORMAL;
           _c.itr.rest = 15;
           _c.itr.physic = ItrPhysicEnum.DEFAULT;
           _c.Itr();
        }

        private void JumpSuperAttack_555()
        {
            _c.pic = 502;
            _c.wait = 1f;
            _c.next = JumpSuperAttack_556;
            _c.OnGround(290);
            _c.bdy.x = 0.1047f;
            _c.bdy.y = 0.1856f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4125906f;
            _c.bdy.h = 0.371265f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
            _c.itr.x = 0.4922f;
            _c.itr.y = 0.3392f;
            _c.itr.z = 0;
            _c.itr.w = 0.2629879f;
            _c.itr.h = 0.3019446f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 100;
            _c.itr.dvy = -50;
            _c.itr.dvz = 0;
            _c.itr.action = 800;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 60;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 15;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.Itr();
        }

        private void JumpSuperAttack_556()
        {
            _c.pic = 503;
            _c.wait = 0.5f;
            _c.next = JumpSuperAttack_557;
            _c.OnGround(290);
            _c.bdy.x = 0.1047f;
            _c.bdy.y = 0.1856f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4125906f;
            _c.bdy.h = 0.371265f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
        }

        private void JumpSuperAttack_557()
        {
            _c.pic = 504;
            _c.wait = 1f;
            _c.next = JumpSuperAttack_557;
            _c.OnGround(290);
            _c.bdy.x = 0.1047f;
            _c.bdy.y = 0.1856f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4125906f;
            _c.bdy.h = 0.371265f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
        }
    }
}