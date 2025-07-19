namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0660_JumpComboFalling 
    {
        private readonly NsKakashiBase _c;

        public F0660_JumpComboFalling(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpComboFalling_660()
        {
            _c.pic = 137;
            _c.wait = 0.5f;
            _c.next = JumpComboFalling_661;
            _c.Defense(300);
            _c.OnGround(290);
            _c.Jump(670);
            _c.Attack(590);
            _c.Power(1250);
            _c.PowerSide(1250);
            _c.BdyDefault();
        }

        private void JumpComboFalling_661()
        {
            _c.pic = 138;
            _c.wait = 1f;
            _c.next = JumpComboFalling_661;
            _c.Defense(300);
            _c.OnGround(290);
            _c.Jump(670);
            _c.Attack(590);
            _c.Power(1250);
            _c.PowerSide(1250);
            _c.BdyDefault();
        }
    }
}