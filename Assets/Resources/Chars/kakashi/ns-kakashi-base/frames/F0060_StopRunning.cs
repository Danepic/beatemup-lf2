using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0060_StopRunning 
    {
        private readonly NsKakashiBase _c;

        public F0060_StopRunning(NsKakashiBase c)
        {
            _c = c;
        }

        private void StopRunning_60()
        {
            _c.StopMovement();
            _c.pic = 133;
            _c.state = StateFrameEnum.STOP_RUNNING;
            _c.wait = 1f;
            _c.dvx = 0;
            _c.dvy = 0;
            _c.dvz = 0;
            _c.next = StopRunning_61;
            _c.Attack(330);
            _c.BdyDefault();
        }

        private void StopRunning_61()
        {
            _c.ResetMovementFromStop();
            _c.pic = 134;
            _c.state = StateFrameEnum.STOP_RUNNING;
            _c.wait = 4f;
            _c.dvx = 150f;
            _c.dvy = 0;
            _c.dvz = 0;
            _c.next = StopRunning_62;
            _c.Attack(330);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(_c.dvx, _c.dvy, _c.dvz, _c.facingRight);
        }

        private void StopRunning_62()
        {
            _c.pic = 133;
            _c.state = StateFrameEnum.STOP_RUNNING;
            _c.wait = 1f;
            _c.dvx = 0f;
            _c.dvy = 0f;
            _c.dvz = 0f;
            _c.next = _c.frames[0];
            _c.Attack(330);
            _c.BdyDefault();
            _c.StopMovement();
        }
    }
}