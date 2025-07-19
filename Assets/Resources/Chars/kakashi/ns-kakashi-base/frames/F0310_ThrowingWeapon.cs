using Enums;
using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0310_ThrowingWeapon 
    {
        private readonly NsKakashiBase _c;

        public F0310_ThrowingWeapon(NsKakashiBase c)
        {
            _c = c;
        }

        private void ThrowingWeapon_310()
        {
            _c.pic = 205;
            _c.wait = 0.5f;
            _c.next = ThrowingWeapon_311;
            _c.state = StateFrameEnum.ATTACK;
            _c.BdyDefault();
        }

        private void ThrowingWeapon_311()
        {
            _c.pic = 206;
            _c.wait = 0.5f;
            _c.next = ThrowingWeapon_312;
            _c.BdyDefault();
        }

        private void ThrowingWeapon_312()
        {
            _c.pic = 206;
            _c.wait = 1f;
            _c.next = ThrowingWeapon_313;
            _c.BdyDefault();
        }

        private void ThrowingWeapon_313()
        {
            _c.pic = 207;
            _c.wait = 0.5f;
            _c.next = ThrowingWeapon_314;
            _c.BdyDefault();
            _c.SpawnOpoint(KUNAI_OPOINT, _c.Opoint(x: 0f, y: 0.4f, z: -0.1191684f, oid: 0, facingFront: true, quantity: 1));
        }

        private void ThrowingWeapon_314()
        {
            _c.pic = 208;
            _c.wait = 0.5f;
            _c.next = ThrowingWeapon_315;
            _c.BdyDefault();
        }

        private void ThrowingWeapon_315()
        {
            _c.pic = 209;
            _c.wait = 0.5f;
            _c.next = ThrowingWeapon_316;
            _c.BdyDefault();
            _c.SpawnOpoint(KUNAI_OPOINT, _c.Opoint(x: 0f, y: 0.4f, z: -0.1191684f, oid: 0, facingFront: true, quantity: 1));
        }

        private void ThrowingWeapon_316()
        {
            _c.pic = 210;
            _c.wait = 8f;
            _c.next = ThrowingWeapon_317;
            _c.BdyDefault();
        }

        private void ThrowingWeapon_317()
        {
            _c.pic = 210;
            _c.wait = 0.5f;
            _c.next = ThrowingWeapon_318;
            _c.BdyDefault();
        }

        private void ThrowingWeapon_318()
        {
            _c.pic = 210;
            _c.wait = 1f;
            _c.next = ThrowingWeapon_319;
            _c.BdyDefault();
        }

        private void ThrowingWeapon_319()
        {
            _c.pic = 210;
            _c.wait = 0.5f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}