using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0070_RunningDash 
    {
        private readonly NsKakashiBase _c;

        public F0070_RunningDash(NsKakashiBase c)
        {
            _c = c;
        }

        private void RunningDash_70()
        {
            _c.pic = 119;
            _c.state = StateFrameEnum.DASH;
            _c.wait = 2f;
            _c.next = RunningDash_71;
            _c.BdyDefault();
            _c.StopMovement();
        }

        private void RunningDash_71()
        {
            _c.ResetMovementFromStop();
            _c.pic = 131;
            _c.state = StateFrameEnum.DASH;
            _c.wait = 0.5f;
            _c.dvx = 600;
            _c.dvy = 0;
            _c.dvz = 200;
            _c.next = RunningDash_72;
            _c.BdyDefault();
            _c.ApplyPhysicDash();
        }

        private void RunningDash_72()
        {
            _c.pic = 132;
            _c.state = StateFrameEnum.DASH;
            _c.wait = 5f;
            _c.next = RunningDash_73;
            _c.BdyDefault();
        }

        private void RunningDash_73()
        {
            _c.pic = 133;
            _c.state = StateFrameEnum.DASH;
            _c.wait = 0.5f;
            _c.next = _c.frames[60];
            _c.BdyDefault();
        }
    }
}