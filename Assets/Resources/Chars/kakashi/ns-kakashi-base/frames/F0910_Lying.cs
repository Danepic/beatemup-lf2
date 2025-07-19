using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0910_Lying 
    {
        private readonly NsKakashiBase _c;

        public F0910_Lying(NsKakashiBase c)
        {
            _c = c;
        }

        private void Lying_910()
        {
            _c.StopMovement();
            _c.state = StateFrameEnum.LYING;
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 626;
            _c.wait = 2f;
            _c.next = Lying_911;
            _c.Jump(930);
            _c.BdyDefault();
        }

        private void Lying_911()
        {
            _c.ResetMovementFromStop();
            _c.pic = 631;
            _c.wait = 2f;
            _c.next = Lying_912;
            _c.BdyDefault();
        }

        private void Lying_912()
        {
            _c.pic = 632;
            _c.wait = 2f;
            _c.next = Lying_913;
            _c.BdyDefault();
        }

        private void Lying_913()
        {
            _c.pic = 633;
            _c.wait = 2f;
            _c.next = Lying_914;
            _c.BdyDefault();
        }

        private void Lying_914()
        {
            _c.pic = 635;
            _c.wait = 50f;
            _c.next = LyingUp_920;
            _c.BdyDefault();
        }

        private void LyingUp_920()
        {
            _c.pic = 636;
            _c.wait = 2f;
            _c.next = LyingUp_921;
            _c.BdyDefault();
        }

        private void LyingUp_921()
        {
            _c.pic = 637;
            _c.wait = 2f;
            _c.next = LyingUp_922;
            _c.BdyDefault();
        }

        private void LyingUp_922()
        {
            _c.pic = 638;
            _c.wait = 2f;
            _c.next = LyingUp_923;
            _c.BdyDefault();
        }

        private void LyingUp_923()
        {
            _c.pic = 639;
            _c.wait = 1f;
            _c.next = LyingUp_924;
            _c.BdyDefault();
        }

        private void LyingUp_924()
        {
            _c.pic = 639;
            _c.wait = 1f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}