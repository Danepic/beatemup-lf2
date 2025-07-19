using Enums;
using static CharController;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0840_FallingUp 
    {
        private readonly NsKakashiBase _c;

        public F0840_FallingUp(NsKakashiBase c)
        {
            _c = c;
        }

        private void FallingUp_840()
        {
            _c.ResetMovementFromStop();
            _c.state = StateFrameEnum.FALLING;
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 605;
            _c.wait = 2f;
            _c.next = FallingUp_841;
            _c.OnCeil(FallingUpImpact_850);
            _c.BdyDefault();
            _c.ApplyExternPhysic();
        }

        private void FallingUp_841()
        {
            _c.pic = 613;
            _c.wait = 0.5f;
            _c.next = FallingUp_842;
            _c.OnCeil(FallingUpImpact_850);
            _c.BdyDefault();
        }

        void FallingUp_842()
        {
            _c.pic = 613;
            _c.wait = 10f;
            _c.next = FallingUp_843;
            _c.OnGround(910);
            _c.OnCeil(FallingUpImpact_850);
            _c.BdyDefault();
        }

        private void FallingUp_843()
        {
            _c.pic = 614;
            _c.wait = 0.5f;
            _c.next = FallingUp_844;
            _c.OnGround(910);
            _c.OnCeil(FallingUpImpact_850);
            _c.BdyDefault();
        }

        private void FallingUp_844()
        {
            _c.pic = 614;
            _c.wait = 0.5f;
            _c.next = FallingUp_845;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void FallingUp_845()
        {
            _c.pic = 615;
            _c.wait = 0.5f;
            _c.next = FallingUp_846;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void FallingUp_846()
        {
            _c.pic = 616;
            _c.wait = 0.5f;
            _c.next = FallingUp_847;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void FallingUp_847()
        {
            _c.pic = 617;
            _c.wait = 0.5f;
            _c.next = FallingUp_848;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void FallingUp_848()
        {
            _c.pic = 618;
            _c.wait = 2f;
            _c.next = FallingUp_848;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void FallingUpImpact_850()
        {
            _c.pic = 631;
            _c.wait = 2f;
            _c.next = FallingUpImpact_851;
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 0, dvy: -320, dvz: 0, _c.facingRight);
            _c.SpawnOpoint(IMPACT_UP_OPOINT, _c.Opoint(x: 0.13f, y: 0, z: 0.094f, oid: 0, facingFront: true, quantity: 1));
        }

        private void FallingUpImpact_851()
        {
            _c.pic = 630;
            _c.wait = 2f;
            _c.next = FallingUpImpact_852;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void FallingUpImpact_852()
        {
            _c.pic = 617;
            _c.wait = 2f;
            _c.next = FallingUpImpact_853;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void FallingUpImpact_853()
        {
            _c.pic = 618;
            _c.wait = 2f;
            _c.next = FallingUpImpact_854;
            _c.OnGround(910);
            _c.BdyDefault();
        }

        private void FallingUpImpact_854()
        {
            _c.pic = 619;
            _c.wait = 2f;
            _c.next = FallingUpImpact_854;
            _c.OnGround(910);
            _c.BdyDefault();
        }
    }
}