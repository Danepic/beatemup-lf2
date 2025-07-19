using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0308_JumpFallingNoAction 
    {
        private readonly NsKakashiBase _c;

        public F0308_JumpFallingNoAction(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpFallingNoAction_308()
        {
            _c.pic = 137;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 0.5f;
            _c.next = JumpFallingNoAction_309;
            _c.BdyDefault();
        }

        private void JumpFallingNoAction_309()
        {
            _c.pic = 138;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = JumpFallingNoAction_309;
            _c.OnGround(290);
            _c.BdyDefault();
        }
    }
}