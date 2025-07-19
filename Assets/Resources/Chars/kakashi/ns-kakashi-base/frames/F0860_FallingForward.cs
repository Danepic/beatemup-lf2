using Enums;
using static CharController;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0860_FallingForward 
    {
        private readonly NsKakashiBase _c;

        public F0860_FallingForward(NsKakashiBase c)
        {
            _c = c;
        }

        private void FallingForwardtHit_860()
        {
            _c.ResetMovementFromStop();
            _c.state = StateFrameEnum.FALLING;
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 620;
            _c.wait = 2f;
            _c.next = FallingForward_861;
            _c.BdyDefault();
            _c.ApplyExternPhysic();
        }

        private void FallingForward_861()
        {
            _c.pic = 621;
            _c.wait = 0.5f;
            _c.next = FallingForward_862;
            _c.OnGround(910);
            _c.OnWall(FallingForwardImpact_870);
            _c.BdyDefault();
        }

        private void FallingForward_862()
        {
            _c.pic = 622;
            _c.wait = 2f;
            _c.next = FallingForward_863;
            _c.OnGround(910);
            _c.OnWall(FallingForwardImpact_870);
            _c.BdyDefault();
        }

        private void FallingForward_863()
        {
            _c.pic = 623;
            _c.wait = 2f;
            _c.next = FallingForward_863;
            _c.OnGround(910);
            _c.OnWall(FallingForwardImpact_870);
            _c.BdyDefault();
        }

        private void FallingForwardImpact_870()
        {
            _c.pic = 613;
            _c.wait = 2f;
            _c.next = FallingForwardImpact_871;
            _c.BdyDefault();
            _c.SpawnOpoint(IMPACT_FORWARD_OPOINT, _c.Opoint(x: -0.17f, y: 0, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
        }

        private void FallingForwardImpact_871()
        {
            _c.pic = 613;
            _c.wait = 2f;
            _c.next = FallingForwardImpact_872;
            _c.BdyDefault();
        }

        private void FallingForwardImpact_872()
        {
            _c.pic = 627;
            _c.wait = 2f;
            _c.next = FallingForwardImpact_873;
            _c.BdyDefault();
        }

        private void FallingForwardImpact_873()
        {
            _c.pic = 628;
            _c.wait = 2f;
            _c.next = FallingForwardImpact_874;
            _c.BdyDefault();
        }

        private void FallingForwardImpact_874()
        {
            _c.pic = 630;
            _c.wait = 2f;
            _c.next = FallingForwardImpact_874;
            _c.OnGround(910);
            _c.BdyDefault();
        }
    }
}