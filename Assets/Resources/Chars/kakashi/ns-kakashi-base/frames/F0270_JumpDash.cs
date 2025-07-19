using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0270_JumpDash 
    {
        private readonly NsKakashiBase _c;

        public F0270_JumpDash(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpDash_270()
        {
            _c.StopMovement();
            _c.pic = 131;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = JumpDash_271;
            _c.Attack(590);
            _c.BdyDefault();
        }

        private void JumpDash_271()
        {
            _c.ResetMovementFromStop();
            _c.pic = 132;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = JumpDash_272;
            _c.Attack(590);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 250, dvy: 100, dvz: 0, _c.facingRight);
        }

        private void JumpDash_272()
        {
            _c.pic = 132;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 0.5f;
            _c.next = JumpDash_273;
            _c.Attack(590);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void JumpDash_273()
        {
            _c.pic = 132;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = JumpDash_274;
            _c.Attack(590);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void JumpDash_274()
        {
            _c.pic = 121;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 4f;
            _c.next = _c.frames[240];
            _c.Attack(590);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }
    }
}