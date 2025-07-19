using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0230_DoubleJump 
    {
        private readonly NsKakashiBase _c;

        public F0230_DoubleJump(NsKakashiBase c)
        {
            _c = c;
        }

        private void DoubleJump_230()
        {
            _c.pic = 133;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 2f;
            _c.next = DoubleJump_231;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.StopMovement();
            _c.ApplyDefaultPhysic(0, 0, 0, _c.facingRight);
        }

        private void DoubleJump_231()
        {
            _c.pic = 134;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 0.5f;
            _c.next = DoubleJump_232;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ResetMovementFromStop();
        }

        private void DoubleJump_232()
        {
            _c.pic = 135;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 0.5f;
            _c.dvx = 80;
            _c.dvy = 225;
            _c.dvz = 80;
            _c.next = DoubleJump_233;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ApplyPhysicJumping();
        }

        private void DoubleJump_233()
        {
            _c.pic = 136;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 8f;
            _c.next = _c.frames[240];
            _c.Defense(300);
            _c.OnGround(290);
            _c.Attack(550);
            _c.Power(1250);
            _c.PowerSide(1250);
            _c.BdyDefault();
            _c.CanFlip();
        }
    }
}