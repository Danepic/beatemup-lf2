using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0590_JumpAttack1 
    {
        private readonly NsKakashiBase _c;

        public F0590_JumpAttack1(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpAttack1_590()
        {
            _c.ResetMovementFromStop();
            _c.state = StateFrameEnum.ATTACK_RESET;
            _c.ItrDisable();
            _c.pic = 440;
            _c.wait = 1f;
            _c.next = JumpAttack1_591;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpAttack1_591()
        {
            _c.pic = 441;
            _c.wait = 0.5f;
            _c.next = JumpAttack1_592;
            _c.OnGround(290);
            _c.state = StateFrameEnum.ATTACK;
            _c.BdyDefault();
        }

        private void JumpAttack1_592()
        {
            _c.pic = 442;
            _c.wait = 1f;
            _c.next = JumpAttack1_593;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 100, 50, null, _c.facingRight);
            _c.itr.x = 0.1226f;
            _c.itr.y = 0.509f;
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

        private void JumpAttack1_593()
        {
            _c.StopMovement();
            _c.ItrDisable();
            _c.pic = 443;
            _c.wait = 0.5f;
            _c.next = JumpAttack1_594;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpAttack1_594()
        {
            _c.pic = 444;
            _c.wait = 0.5f;
            _c.next = JumpAttack1_595;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(1, null, null, _c.facingRight);
        }

        private void JumpAttack1_595()
        {
            _c.ResetMovementFromStop();
            _c.pic = 445;
            _c.wait = 2f;
            _c.next = JumpAttack1_595;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.DoubleTapAttack(610);
        }
    }
}