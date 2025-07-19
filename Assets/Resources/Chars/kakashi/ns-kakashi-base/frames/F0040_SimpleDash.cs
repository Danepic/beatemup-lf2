using System;
using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0040_SimpleDash 
    {
        private readonly NsKakashiBase _c;

        public F0040_SimpleDash(NsKakashiBase c)
        {
            _c = c;
        }

        private void SimpleDash_40()
        {
            _c.pic = 119;
            _c.state = StateFrameEnum.SIMPLE_DASH;
            _c.wait = 0.5f;
            _c.dvx = 450f;
            _c.dvy = 0f;
            _c.dvz = 0f;
            _c.next = SimpleDash_41;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.ApplyDefaultPhysic(_c.dvx, _c.dvy, _c.dvz, _c.facingRight);
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
        }

        private void SimpleDash_41()
        {
            _c.pic = 131;
            _c.state = StateFrameEnum.SIMPLE_DASH;
            _c.wait = 1.5f;
            _c.dvx = 0f;
            _c.dvy = 0f;
            _c.dvz = 0f;
            _c.next = SimpleDash_42;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
        }

        private void SimpleDash_42()
        {
            _c.CanHoldForwardAfter(55);
            _c.pic = 132;
            _c.state = StateFrameEnum.SIMPLE_DASH;
            _c.wait = 0.5f;
            _c.dvx = 0f;
            _c.dvy = 0f;
            _c.dvz = 0f;
            _c.next = SimpleDash_43;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.BdyDefault();
        }

        private void SimpleDash_43()
        {
            _c.StopMovement();
            _c.CanHoldForwardAfter(55);
            _c.pic = 132;
            _c.state = StateFrameEnum.SIMPLE_DASH;
            _c.wait = 0.5f;
            _c.dvx = 0f;
            _c.dvy = 0f;
            _c.dvz = 0f;
            _c.next = SimpleDashStopRunning_44;
            _c.Jump(250);
            _c.Defense(70);
            _c.Attack(330);
            _c.BdyDefault();
        }

        private void SimpleDashStopRunning_44()
        {
            _c.ResetMovementFromStop();
            _c.CanHoldForwardAfter(55);
            _c.pic = 132;
            _c.state = StateFrameEnum.SIMPLE_DASH;
            _c.wait = 4f;
            _c.dvx = 150f;
            _c.dvy = 0;
            _c.dvz = 0;
            _c.next = _c.frames[62];
            _c.Attack(330);
            _c.Defense(70);
            _c.Jump(250);
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(_c.dvx, _c.dvy, _c.dvz, _c.facingRight);
        }
    }
}