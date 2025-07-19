using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0630_JumpAttack3 
    {
        private readonly NsKakashiBase _c;

        public F0630_JumpAttack3(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpAttack3_630()
        {
            _c.ResetMovementFromStop();
            _c.state = StateFrameEnum.ATTACK_RESET;
            _c.ItrDisable();
            _c.pic = 507;
            _c.wait = 1f;
            _c.next = JumpAttack3_631;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 0, dvy: 100, dvz: 0, _c.facingRight);
        }

        private void JumpAttack3_631()
        {
            _c.pic = 507;
            _c.wait = 0.5f;
            _c.next = JumpAttack3_632;
            _c.OnGround(290);
            _c.state = StateFrameEnum.ATTACK;
            _c.BdyDefault();
        }

        private void JumpAttack3_632()
        {
            _c.pic = 507;
            _c.wait = 1f;
            _c.next = JumpAttack3_633;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 125, null, null, _c.facingRight);
        }

        private void JumpAttack3_633()
        {
            _c.StopMovement();
            _c.pic = 508;
            _c.wait = 1f;
            _c.next = JumpAttack3_634;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 1, null, null, _c.facingRight);
        }

        private void JumpAttack3_634()
        {
            _c.pic = 509;
            _c.wait = 0.5f;
            _c.next = JumpAttack3_635;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.itr.x = 0.2088f;
            _c.itr.y = 0.3524f;
            _c.itr.z = 0;
            _c.itr.w = 0.577767f;
            _c.itr.h = 0.4391482f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 100;
            _c.itr.dvy = -400;
            _c.itr.dvz = 0;
            _c.itr.action = 820;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 50;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 15;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.Itr();
        }

        private void JumpAttack3_635()
        {
            _c.pic = 510;
            _c.wait = 0.5f;
            _c.next = JumpAttack3_636;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void JumpAttack3_636()
        {
            _c.ItrDisable();
            _c.pic = 511;
            _c.wait = 8f;
            _c.next = JumpAttack3_637;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void JumpAttack3_637()
        {
            _c.pic = 511;
            _c.wait = 0.5f;
            _c.next = JumpAttack3_638;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void JumpAttack3_638()
        {
            _c.ResetMovementFromStop();
            _c.pic = 511;
            _c.wait = 0.5f;
            _c.next = JumpAttack3_639;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void JumpAttack3_639()
        {
            _c.pic = 511;
            _c.wait = 2f;
            _c.next = JumpAttack3_640;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void JumpAttack3_640()
        {
            _c.pic = 511;
            _c.wait = 1f;
            _c.next = JumpAttack3_640;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }
    }
}