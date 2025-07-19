using Enums;
using static CharController;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0820_FallingDown 
    {
        private readonly NsKakashiBase _c;

        public F0820_FallingDown(NsKakashiBase c)
        {
            _c = c;
        }

        private void FallingDown_820()
        {
            _c.ResetMovementFromStop();
            _c.state = StateFrameEnum.FALLING;
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 630;
            _c.wait = 2f;
            _c.next = FallingDown_821;
            _c.OnGround(FallingDownImpact_825);
            _c.BdyDefault();
            _c.ApplyExternPhysic();
        }

        private void FallingDown_821()
        {
            _c.pic = 617;
            _c.wait = 0.5f;
            _c.next = FallingDown_822;
            _c.OnGround(FallingDownImpact_825);
            _c.BdyDefault();
        }

        private void FallingDown_822()
        {
            _c.pic = 617;
            _c.wait = 2f;
            _c.next = FallingDown_822;
            _c.OnGround(FallingDownImpact_825);
            _c.BdyDefault();
        }

        private void FallingDownImpact_825()
        {
            _c.pic = 631;
            _c.wait = 2f;
            _c.next = FallingDownImpact_826;
            _c.state = StateFrameEnum.FALLING;
            _c.BdyDefault();
            _c.SpawnOpoint(IMPACT_DOWN_OPOINT, _c.Opoint(x: 0.13f, y: 0, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
        }

        private void FallingDownImpact_826()
        {
            _c.pic = 631;
            _c.wait = 2f;
            _c.next = FallingDownImpact_827;
            _c.BdyDefault();
        }

        private void FallingDownImpact_827()
        {
            _c.pic = 627;
            _c.wait = 2f;
            _c.next = FallingDownImpact_828;
            _c.BdyDefault();
        }

        private void FallingDownImpact_828()
        {
            _c.pic = 628;
            _c.wait = 2f;
            _c.next = FallingDownImpact_829;
            _c.BdyDefault();
        }

        private void FallingDownImpact_829()
        {
            _c.pic = 630;
            _c.wait = 2f;
            _c.next = _c.frames[910];
            _c.BdyDefault();
        }
    }
}