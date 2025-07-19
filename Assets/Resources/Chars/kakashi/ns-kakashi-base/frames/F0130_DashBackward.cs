using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0130_DashBackward 
    {
        private readonly NsKakashiBase _c;

        public F0130_DashBackward(NsKakashiBase c)
        {
            _c = c;
        }

        private void DashBackward_130()
        {
            _c.StopMovement();
            _c.pic = 134;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 1.5f;
            _c.next = DashBackward_131;
            _c.BdyDefault();
        }

        private void DashBackward_131()
        {
            _c.ResetMovementFromStop();
            _c.pic = 135;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 1f;
            _c.dvx = -200;
            _c.dvy = 175;
            _c.dvz = 0;
            _c.next = DashBackward_132;
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(_c.dvx, _c.dvy, _c.dvz, _c.facingRight);
        }

        private void DashBackward_132()
        {
            _c.pic = 136;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 6f;
            _c.next = DashBackward_133;
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void DashBackward_133()
        {
            _c.pic = 137;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 0.5f;
            _c.next = DashBackward_134;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void DashBackward_134()
        {
            _c.pic = 138;
            _c.state = StateFrameEnum.JUMPING;
            _c.wait = 6f;
            _c.next = DashBackward_134;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }
    }
}