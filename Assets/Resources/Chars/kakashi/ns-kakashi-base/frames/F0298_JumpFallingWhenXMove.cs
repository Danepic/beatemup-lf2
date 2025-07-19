using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0298_JumpFallingWhenXMove 
    {
        private readonly NsKakashiBase _c;

        public F0298_JumpFallingWhenXMove(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpFallingWhenXMove_298()
        {
            _c.pic = 137;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 0.5f;
            _c.next = JumpFallingWhenXMove_299;
            _c.OnGround(290);
            _c.Defense(300);
            _c.DoubleTapJump(230);
            _c.BdyDefault();
        }

        private void JumpFallingWhenXMove_299()
        {
            _c.pic = 138;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = JumpFallingWhenXMove_299;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 10, 0, 0, _c.facingRight);
        }
    }
}