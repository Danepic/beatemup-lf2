using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0290_Crouch 
    {
        private readonly NsKakashiBase _c;

        public F0290_Crouch(NsKakashiBase c)
        {
            _c = c;
        }

        private void Crouch_290()
        {
            _c.ItrDisable();
            _c.StopMovement();
            _c.pic = 133;
            _c.state = StateFrameEnum.CROUCH;
            _c.wait = 1f;
            _c.next = Crouch_291;
            _c.bdy.x = 0.0855f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.2873f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
            _c.releaseJumpButton = false;
        }

        private void Crouch_291()
        {
            _c.ResetMovementFromStop();
            _c.pic = 134;
            _c.state = StateFrameEnum.CROUCH;
            _c.wait = 3f;
            _c.next = _c.frames[0];
            _c.bdy.x = 0.0855f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.2873f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
            _c.releaseJumpButton = false;
        }
    }
}