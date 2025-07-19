using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0250_DashJump 
    {
        private readonly NsKakashiBase _c;

        public F0250_DashJump(NsKakashiBase c)
        {
            _c = c;
        }

        private void DashJump_250()
        {
            _c.pic = 133;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 2f;
            _c.next = DashJump_251;
            _c.Defense(130);
            _c.BdyDefault();
            _c.StopMovement();
            _c.PrepareJumpDash();
        }

        private void DashJump_251()
        {
            _c.pic = 134;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 0.5f;
            _c.next = DashJump_252;
            _c.Defense(130);
            _c.BdyDefault();
            _c.ResetMovementFromStop();
        }

        private void DashJump_252()
        {
            _c.pic = 135;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.dvx = 175;
            _c.dvy = 290;
            _c.dvz = 80;
            _c.next = DashJump_253;
            _c.DoubleTapJump(230);
            _c.BdyDefault();
            _c.ApplyPhysicDashJumping();
        }

        private void DashJump_253()
        {
            _c.pic = 136;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 3f;
            _c.next = DashJump_254;
            _c.DoubleTapJump(230);
            _c.BdyDefault();
            _c.CountJumpDash();
            _c.CanJumpDash(270);
            _c.CanFlip();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void DashJump_254()
        {
            _c.pic = 136;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 4f;
            _c.next = _c.frames[220];
            _c.Defense(300);
            _c.OnGround(290);
            _c.DoubleTapJump(230);
            _c.Attack(550);
            _c.BdyDefault();
            _c.CountJumpDash();
            _c.CanJumpDash(270);
            _c.CanFlip();
            _c.Power(1250);
            _c.PowerSide(1250);
        }
    }
}