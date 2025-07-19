namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0670_DoubleJumpCombo 
    {
        private readonly NsKakashiBase _c;

        public F0670_DoubleJumpCombo(NsKakashiBase c)
        {
            _c = c;
        }

        private void DoubleJumpCombo_670()
        {
            _c.pic = 133;
            _c.wait = 1;
            _c.next = DoubleJumpCombo_671;
            _c.BdyDefault();
        }

        private void DoubleJumpCombo_671()
        {
            _c.pic = 134;
            _c.wait = 0.5f;
            _c.next = DoubleJumpCombo_672;
            _c.BdyDefault();
        }

        private void DoubleJumpCombo_672()
        {
            _c.pic = 135;
            _c.wait = 1f;
            _c.next = DoubleJumpCombo_673;
            _c.dvx = 80;
            _c.dvy = 225;
            _c.dvz = 80;
            _c.BdyDefault();
            _c.ApplyPhysicJumping();
        }

        private void DoubleJumpCombo_673()
        {
            _c.pic = 136;
            _c.wait = 8f;
            _c.next = _c.frames[680];
            _c.Defense(300);
            _c.Attack(590);
            _c.BdyDefault();
            _c.Power(1250);
            _c.PowerSide(1250);
        }
    }
}