using Enums;
using static CharController;
using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0930_JumpRecover 
    {
        private readonly NsKakashiBase _c;

        public F0930_JumpRecover(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpRecover_930()
        {
            _c.spriteRenderer.color = _c.parryColor;
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 431;
            _c.wait = 1f;
            _c.next = JumpRecover_931;
            _c.BdyDefault();
            _c.SpawnOpoint(JUMP_RECOVER_OPOINT, _c.Opoint(x: 0.11f, y: 0.25f, z: 0.08f, oid: 0, facingFront: true, quantity: 1));
        }

        private void JumpRecover_931()
        {
            _c.pic = 431;
            _c.wait = 2f;
            _c.next = _c.frames[290];
            _c.BdyDefault();
        }
    }
}