using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0429_ComboFinish 
    {
        private readonly NsKakashiBase _c;

        public F0429_ComboFinish(NsKakashiBase c)
        {
            _c = c;
        }

        private void ComboFinish_429()
        {
            _c.pic = 332;
            _c.wait = 8f;
            _c.state = StateFrameEnum.COMBO_FINISH;
            _c.next = _c.frames[0];
            _c.Up(450);
            _c.Down(470);
            _c.Front(430);
            _c.BdyDefault();
        }
    }
}