namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0680_DoubleJumpComboFalling 
    {
        private readonly NsKakashiBase _c;

        public F0680_DoubleJumpComboFalling(NsKakashiBase c)
        {
            _c = c;
        }

        private void DoubleJumpComboFalling_680()
        {
            _c.pic = 137;
            _c.wait = 0.5f;
            _c.next = DoubleJumpComboFalling_681;
            _c.Defense(300);
            _c.OnGround(290);
            _c.Attack(590);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }

        private void DoubleJumpComboFalling_681()
        {
            _c.pic = 138;
            _c.wait = 1f;
            _c.next = DoubleJumpComboFalling_681;
            _c.Defense(300);
            _c.OnGround(290);
            _c.Attack(590);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }
    }
}