using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0650_JumpCombo 
    {
        private readonly NsKakashiBase _c;

        public F0650_JumpCombo(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpCombo_650()
        {
            _c.pic = 133;
            _c.wait = 4f;
            _c.next = JumpCombo_651;
            _c.Defense(130);
            _c.BdyDefault();
        }

        private void JumpCombo_651()
        {
            _c.pic = 134;
            _c.wait = 0.5f;
            _c.next = JumpCombo_652;
            _c.BdyDefault();
        }

        private void JumpCombo_652()
        {
            _c.pic = 135;
            _c.wait = 0.5f;
            _c.next = JumpCombo_653;
            _c.BdyDefault();
        }

        private void JumpCombo_653()
        {
            _c.pic = 136;
            _c.wait = 2f;
            _c.next = JumpCombo_654;
            _c.dvx = 80;
            _c.dvy = 300;
            _c.dvz = 80;
            _c.BdyDefault();
            _c.ApplyPhysicJumping();
            _c.DoubleTapJump(670);
        }

        private void JumpCombo_654()
        {
            _c.pic = 136;
            _c.wait = 8f;
            _c.next = _c.frames[660];
            _c.Defense(300);
            _c.state = StateFrameEnum.JUMP_COMBO_ATTACK;
            _c.DoubleTapJump(670);
            _c.Attack(590);
            _c.Power(1250);
            _c.PowerSide(1250);
            _c.BdyDefault();
        }
    }
}