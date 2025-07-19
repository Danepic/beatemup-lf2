using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0240_DoubleJumpFalling 
    {
        private readonly NsKakashiBase _c;

        public F0240_DoubleJumpFalling(NsKakashiBase c)
        {
            _c = c;
        }

        private void DoubleJumpFalling_240()
        {
            _c.pic = 137;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 1f;
            _c.next = DoubleJumpFalling_241;
            _c.Defense(300);
            _c.OnGround(290);
            _c.Attack(550);
            _c.Power(1250);
            _c.PowerSide(1250);
            _c.BdyDefault();
            _c.CanFlip();
        }

        private void DoubleJumpFalling_241()
        {
            _c.pic = 138;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 1f;
            _c.next = DoubleJumpFalling_241;
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