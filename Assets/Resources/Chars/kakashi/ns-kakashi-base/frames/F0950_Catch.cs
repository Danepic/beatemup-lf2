using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0950_Catch 
    {
        private readonly NsKakashiBase _c;

        public F0950_Catch(NsKakashiBase c)
        {
            _c = c;
        }

        private void CatchInvisible_950()
        {
            _c.repeatCount = 250;
            _c.ResetMovementFromStop();
            _c.CancelOpoints();
            _c.pic = -9999;
            _c.wait = 2f;
            _c.next = CatchInvisible_951;
            _c.BdyDefault();
            _c.bdy.kind = BdyKindEnum.INVULNERABLE;
        }

        private void CatchInvisible_951()
        {
            _c.RepeatCountToFrame(801);
            _c.ResetMovementFromStop();
            _c.CancelOpoints();
            _c.pic = -9999;
            _c.wait = 2f;
            _c.next = CatchInvisible_951;
            _c.BdyDefault();
            _c.bdy.kind = BdyKindEnum.INVULNERABLE;
        }
    }
}