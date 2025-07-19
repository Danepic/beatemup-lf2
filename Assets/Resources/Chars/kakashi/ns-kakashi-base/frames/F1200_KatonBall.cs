using Enums;
using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F1200_KatonBall
    {
        private readonly NsKakashiBase _c;

        public F1200_KatonBall(NsKakashiBase c)
        {
            _c = c;
        }

        private void KatonBall_1200()
        {
            _c.EnableManaPoints();
            _c.mp = 350;
            _c.pic = 743;
            _c.wait = 2f;
            _c.next = _c.CheckIfHaveMana(_c.mp) ? KatonBall_1201 : 
                _c.frames[690];
            _c.BdyDefault();
        }

        private void KatonBall_1201()
        {
            _c.UsageManaPoints(_c.mp);
            _c.pic = 744;
            _c.wait = 1f;
            _c.next = KatonBall_1202;
            _c.BdyDefault();
        }

        private void KatonBall_1202()
        {
            _c.EnableManaPoints();
            _c.pic = 745;
            _c.wait = 2f;
            _c.next = KatonBall_1203;
            _c.BdyDefault();
        }

        private void KatonBall_1203()
        {
            _c.pic = 746;
            _c.wait = 1f;
            _c.next = KatonBall_1204;
            _c.BdyDefault();
        }

        private void KatonBall_1204()
        {
            _c.pic = 747;
            _c.wait = 2f;
            _c.next = KatonBall_1205;
            _c.BdyDefault();
        }

        private void KatonBall_1205()
        {
            _c.pic = 748;
            _c.wait = 1f;
            _c.next = KatonBall_1206;
            _c.BdyDefault();
        }

        private void KatonBall_1206()
        {
            _c.pic = 749;
            _c.wait = 2f;
            _c.next = KatonBall_1207;
            _c.BdyDefault();
        }

        private void KatonBall_1207()
        {
            _c.pic = 750;
            _c.wait = 1f;
            _c.next = KatonBall_1208;
            _c.BdyDefault();
            _c.SpawnOpoint(FIRE_PREPARE_OPOINT,
                _c.Opoint(x: 0.65f, y: 0.451f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: false,
                    attachToOwner: false));
        }

        private void KatonBall_1208()
        {
            _c.pic = 751;
            _c.wait = 1f;
            _c.next = KatonBall_1209;
            _c.BdyDefault();
            _c.SpawnOpoint(FIRE_IMPACT_OPOINT,
                _c.Opoint(x: 0.65f, y: 0.451f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: false,
                    attachToOwner: false));
        }

        private void KatonBall_1209()
        {
            _c.pic = 752;
            _c.wait = 10f;
            _c.next = KatonBall_1210;
            _c.BdyDefault();
            _c.SpawnOpoint(FIRE_BALL_OPOINT,
                _c.Opoint(x: 0.55f, y: -0.15f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: false,
                    attachToOwner: false));
        }

        private void KatonBall_1210()
        {
            _c.pic = 753;
            _c.wait = 1f;
            _c.next = KatonBall_1211;
            _c.BdyDefault();
        }

        private void KatonBall_1211()
        {
            _c.pic = 754;
            _c.wait = 10f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}