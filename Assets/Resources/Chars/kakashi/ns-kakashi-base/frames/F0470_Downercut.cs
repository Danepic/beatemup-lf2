using Enums;
using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0470_Downercut 
    {
        private readonly NsKakashiBase _c;

        public F0470_Downercut(NsKakashiBase c)
        {
            _c = c;
        }

        private void Downercut_470()
        {
            _c.pic = 420;
            _c.wait = 0.25f;
            _c.next = Downercut_471;
            _c.state = StateFrameEnum.ATTACK;
            _c.BdyDefault();
            _c.ResetMovementFromStop();
        }

        private void Downercut_471()
        {
            _c.pic = 420;
            _c.wait = 0.25f;
            _c.next = Downercut_472;
            _c.BdyDefault();
        }

        private void Downercut_472()
        {
            _c.pic = 421;
            _c.wait = 0.25f;
            _c.next = Downercut_473;
            _c.BdyDefault();
        }

        private void Downercut_473()
        {
            _c.pic = 421;
            _c.wait = 0.25f;
            _c.next = Downercut_474;
            _c.BdyDefault();
        }

        private void Downercut_474()
        {
            _c.pic = 421;
            _c.wait = 0.25f;
            _c.next = Downercut_475;
            _c.BdyDefault();
        }

        private void Downercut_475()
        {
            _c.pic = 421;
            _c.wait = 0.25f;
            _c.next = Downercut_476;
            _c.BdyDefault();
        }

        private void Downercut_476()
        {
            _c.pic = 421;
            _c.wait = 0.25f;
            _c.next = Downercut_477;
            _c.BdyDefault();
        }

        private void Downercut_477()
        {
            _c.pic = 425;
            _c.wait = 0.25f;
            _c.next = Downercut_478;
            _c.BdyDefault();
        }

        private void Downercut_478()
        {
            _c.pic = 426;
            _c.wait = 0.25f;
            _c.next = Downercut_479;
            _c.BdyDefault();
        }

        private void Downercut_479()
        {
            _c.pic = 427;
            _c.wait = 0.25f;
            _c.next = Downercut_481;
            _c.BdyDefault();
        }

        private void Downercut_481()
        {
            _c.pic = 431;
            _c.wait = 0.5f;
            _c.next = Downercut_482;
            _c.BdyDefault();
        }

        private void Downercut_482()
        {
            _c.pic = 431;
            _c.wait = 0.5f;
            _c.next = Downercut_483;
            _c.BdyDefault();
            _c.SpawnOpoint(NIN_DOG_OPOINT, _c.Opoint(x: 0.11f, y: 0f, z: -0.08f, oid: 0, facingFront: true, quantity: 1));
        }

        private void Downercut_483()
        {
            _c.SpawnGroundExtraSmall(_c.Opoint(x: 0, y: -0.128f, z: -0.08f, oid: 0, facingFront: true, quantity: 1));
            _c.pic = 431;
            _c.wait = 0.5f;
            _c.next = Downercut_484;
            _c.BdyDefault();
        }

        private void Downercut_484()
        {
            _c.ItrDisable();
            _c.pic = 431;
            _c.wait = 0.5f;
            _c.next = Downercut_485;
            _c.BdyDefault();
        }

        private void Downercut_485()
        {
            _c.pic = 431;
            _c.wait = 8f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}