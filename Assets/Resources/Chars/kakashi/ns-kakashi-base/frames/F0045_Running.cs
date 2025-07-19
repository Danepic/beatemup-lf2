using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0045_Running 
    {
        private readonly NsKakashiBase _c;
        private readonly float _speedValue;

        public F0045_Running(NsKakashiBase c, float speedValue)
        {
            _c = c;
            _speedValue = speedValue;
        }

        private void Running_45()
        {
            _c.pic = 119;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 1.5f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_46;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
        }

        private void Running_46()
        {
            _c.pic = 120;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 0.5f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_47;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
        }

        private void Running_47()
        {
            _c.pic = 121;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 1f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_48;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.BdyDefault();
        }

        private void Running_48()
        {
            _c.pic = 122;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 0.5f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_49;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.BdyDefault();
        }

        private void Running_49()
        {
            _c.pic = 123;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 1f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_50;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.BdyDefault();
        }

        private void Running_50()
        {
            _c.pic = 124;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 0.5f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_51;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.BdyDefault();
        }

        private void Running_51()
        {
            _c.pic = 125;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 1f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_52;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.BdyDefault();
        }

        private void Running_52()
        {
            _c.pic = 126;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 0.5f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_53;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.BdyDefault();
        }

        private void Running_53()
        {
            _c.pic = 127;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 1f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_54;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.BdyDefault();
        }

        private void Running_54()
        {
            _c.pic = 128;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 0.5f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_55;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.BdyDefault();
        }

        private void Running_55()
        {
            _c.pic = 130;
            _c.state = StateFrameEnum.RUNNING;
            _c.wait = 1f;
            _c.dvx = _speedValue;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.next = Running_45;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.InAir(298);
            _c.CanStopRunning(60);
            _c.ApplyPhysicRunning();
            _c.BdyDefault();
        }
    }
}