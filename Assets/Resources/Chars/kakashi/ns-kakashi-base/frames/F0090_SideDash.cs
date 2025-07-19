using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0090_SideDash 
    {
        private readonly NsKakashiBase _c;

        public F0090_SideDash(NsKakashiBase c)
        {
            _c = c;
        }

        private void SideDash_90()
        {
            _c.pic = 700;
            _c.state = StateFrameEnum.SIDE_DASH;
            _c.wait = 1f;
            _c.next = SideDash_91;
            _c.BdyDefault();
        }

        private void SideDash_91()
        {
            _c.pic = 701;
            _c.state = StateFrameEnum.SIDE_DASH;
            _c.wait = 1f;
            _c.next = SideDash_92;
            _c.BdyDefault();
        }

        private void SideDash_92()
        {
            _c.pic = 702;
            _c.state = StateFrameEnum.SIDE_DASH;
            _c.wait = 5f;
            _c.dvx = 0f;
            _c.dvy = 0;
            _c.dvz = 500f;
            _c.next = SideDash_93;
            _c.BdyDefault();
            _c.ApplySideDashPhysic();
        }

        private void SideDash_93()
        {
            _c.pic = 701;
            _c.state = StateFrameEnum.SIDE_DASH;
            _c.wait = 0.5f;
            _c.next = _c.frames[290];
            _c.BdyDefault();
        }
    }
}