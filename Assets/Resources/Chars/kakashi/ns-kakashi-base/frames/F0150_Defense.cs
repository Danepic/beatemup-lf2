using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0150_Defense 
    {
        private readonly NsKakashiBase _c;

        public F0150_Defense(NsKakashiBase c)
        {
            _c = c;
        }

        private void StartDefense_150()
        {
            _c.pic = 139;
            _c.state = StateFrameEnum.DEFEND;
            _c.wait = 1f;
            _c.next = Defense_151;
            _c.Attack(310);
            _c.Power(170);
            _c.Jump(130);
            _c.BdyDefault();
        }

        private void Defense_151()
        {
            _c.pic = 140;
            _c.state = StateFrameEnum.DEFEND;
            _c.wait = 2f;
            _c.next = StopDefense_152;
            _c.CanHoldDefenseAfter(DefenseHold_155);
            _c.Attack(310);
            _c.Power(170);
            _c.Jump(130);
            _c.BdyDefault();
        }

        private void StopDefense_152()
        {
            _c.pic = 139;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = _c.frames[0];
            _c.Attack(310);
            _c.Power(170);
            _c.Jump(130);
            _c.BdyDefault();
        }

        private void DefenseHold_155()
        {
            _c.pic = 140;
            _c.state = StateFrameEnum.DEFEND;
            _c.wait = 1f;
            _c.next = Defense_151;
            _c.Attack(310);
            _c.Power(170);
            _c.Jump(130);
            _c.BdyDefault();
        }

        private void HitDefense_160()
        {
            _c.pic = 140;
            _c.state = StateFrameEnum.DEFEND;
            _c.wait = 1f;
            _c.next = HitDefense_161;
            _c.CanHoldDefenseAfter(Defense_151);
            _c.Attack(310);
            _c.Power(170);
            _c.Jump(130);
            _c.BdyDefault();
        }

        private void HitDefense_161()
        {
            _c.pic = 140;
            _c.state = StateFrameEnum.DEFEND;
            _c.wait = 2.5f;
            _c.next = StopDefense_152;
            _c.CanHoldDefenseAfter(Defense_151);
            _c.Attack(310);
            _c.Power(170);
            _c.Jump(130);
            _c.BdyDefault();
        }
    }
}