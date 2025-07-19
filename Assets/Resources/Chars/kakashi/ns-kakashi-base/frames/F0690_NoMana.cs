using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0690_NoMana
    {
        private readonly NsKakashiBase _c;

        public F0690_NoMana(NsKakashiBase c)
        {
            _c = c;
        }

        private void NoMana_690()
        {
            _c.pic = 602;
            _c.wait = 15f;
            _c.next = _c.frames[0];
            _c.state = StateFrameEnum.NO_MANA;
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.BdyDefault();
        }

        private void NoManaAir_692()
        {
            _c.pic = 602;
            _c.wait = 15f;
            _c.next = _c.frames[308];
            _c.state = StateFrameEnum.NO_MANA;
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void NoManaFloat_694()
        {
            _c.pic = 602;
            _c.wait = 15f;
            _c.next = _c.frames[1160];
            _c.state = StateFrameEnum.NO_MANA;
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.BdyDefault();
        }
    }
}