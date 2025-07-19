using Enums;
using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F1100_Kirigakure 
    {
        private readonly NsKakashiBase _c;

        public F1100_Kirigakure(NsKakashiBase c)
        {
            _c = c;
        }

        private void Kirigakure_1100()
        {
            _c.EnableManaPoints();
            _c.mp = 300;
            _c.pic = 731;
            _c.wait = 1f;
            _c.next = _c.CheckIfHaveMana(_c.mp) ? Kirigakure_1101 : 
                _c.frames[690];
            _c.BdyDefault();
        }

        private void Kirigakure_1101()
        {
            _c.UsageManaPoints(_c.mp);
            _c.pic = 732;
            _c.wait = 1f;
            _c.next = Kirigakure_1102;
            _c.BdyDefault();
        }

        private void Kirigakure_1102()
        {
            _c.EnableManaPoints();
            _c.pic = 733;
            _c.wait = 1f;
            _c.next = Kirigakure_1103;
            _c.BdyDefault();
        }

        private void Kirigakure_1103()
        {
            _c.pic = 734;
            _c.wait = 1f;
            _c.next = Kirigakure_1104;
            _c.BdyDefault();
            _c.SpawnOpoint(EVASIVE_OPOINT,
                _c.Opoint(x: 0f, y: 2.61f, z: 0f, oid: 0, facingFront: false, quantity: 1, cancellable: false,
                    attachToOwner: false));
        }

        private void Kirigakure_1104()
        {
            _c.pic = 739;
            _c.wait = 1f;
            _c.next = Kirigakure_1105;
            _c.BdyDefault();
            _c.SpawnOpoint(FOG_OPOINT,
                _c.Opoint(x: 0.25f, y: 0.35f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: false,
                    attachToOwner: false));
        }

        private void Kirigakure_1105()
        {
            _c.pic = 740;
            _c.wait = 10f;
            _c.next = Kirigakure_1106;
            _c.SpawnOpoint(FOG_OPOINT,
                _c.Opoint(x: -0.20f, y: 0.35f, z: 0f, oid: 0, facingFront: false, quantity: 1, cancellable: false,
                    attachToOwner: false));
            _c.BdyDefault();
        }

        private void Kirigakure_1106()
        {
            _c.pic = 741;
            _c.wait = 1f;
            _c.next = Kirigakure_1107;
            _c.BdyDefault();
        }

        private void Kirigakure_1107()
        {
            _c.pic = 742;
            _c.wait = 2f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}