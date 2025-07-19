using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0210_Jump 
    {
        private readonly NsKakashiBase _c;

        public F0210_Jump(NsKakashiBase c)
        {
            _c = c;
        }

        private void Jump_210()
        {
            _c.StopMovement();
            _c.pic = 133;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 4f;
            _c.next = Jump_211;
            _c.Defense(130);
            _c.BdyDefault();
        }

        private void Jump_211()
        {
            _c.pic = 134;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 0.5f;
            _c.next = Jump_212;
            _c.Defense(130);
            _c.BdyDefault();
        }

        private void Jump_212()
        {
            _c.ResetMovementFromStop();
            _c.pic = 135;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 0.5f;
            _c.dvx = 80;
            _c.dvy = 300;
            _c.dvz = 80;
            _c.next = Jump_213;
            _c.BdyDefault();
            _c.ApplyPhysicJumping();
        }

        private void Jump_213()
        {
            _c.pic = 136;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 1f;
            _c.next = Jump_214;
            _c.DoubleTapJump(230);
            _c.BdyDefault();
            _c.CanFlip();
            _c.CountJumpDash();
            _c.CanJumpDash(270);
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void Jump_214()
        {
            _c.pic = 136;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 8f;
            _c.next = JumpFalling_220;
            _c.DoubleTapJump(230);
            _c.Defense(300);
            _c.Attack(550);
            _c.BdyDefault();
            _c.CanFlip();
            _c.CountJumpDash();
            _c.CanJumpDash(270);
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void JumpFalling_220()
        {
            _c.pic = 137;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 1f;
            _c.next = JumpFalling_221;
            _c.DoubleTapJump(230);
            _c.Defense(300);
            _c.OnGround(290);
            _c.Attack(550);
            _c.BdyDefault();
            _c.CanFlip();
            _c.CountJumpDash();
            _c.CanJumpDash(270);
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void JumpFalling_221()
        {
            _c.pic = 138;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 1f;
            _c.next = JumpFalling_221;
            _c.DoubleTapJump(230);
            _c.Defense(300);
            _c.OnGround(290);
            _c.Attack(550);
            _c.BdyDefault();
            _c.CanFlip();
            _c.CountJumpDash();
            _c.CanJumpDash(270);
            _c.Power(1250);
            _c.PowerSide(1250);
        }
    }
}