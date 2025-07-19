using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0800_Falling 
    {
        private readonly NsKakashiBase _c;

        public F0800_Falling(NsKakashiBase c)
        {
            _c = c;
        }

        private void FallingHit_800()
        {
            _c.ResetMovementFromStop();
            _c.state = StateFrameEnum.FALLING;
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 605;
            _c.wait = 2f;
            _c.next = Falling_801;
            _c.BdyDefault();
            _c.ApplyExternPhysic();
        }

        private void Falling_801()
        {
            _c.ResetMovementFromStop();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 606;
            _c.wait = 2f;
            _c.next = Falling_802;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void Falling_802()
        {
            _c.pic = 607;
            _c.wait = 2f;
            _c.next = Falling_803;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void Falling_803()
        {
            _c.pic = 608;
            _c.wait = 0.5f;
            _c.next = Falling_804;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void Falling_804()
        {
            _c.pic = 609;
            _c.wait = 2f;
            _c.next = Falling_805;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void Falling_805()
        {
            _c.pic = 610;
            _c.wait = 0.5f;
            _c.next = Falling_806;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void Falling_806()
        {
            _c.pic = 611;
            _c.wait = 2f;
            _c.next = Falling_806;
            _c.OnGround(910);
            _c.BdyDefault();
        }
    }
}