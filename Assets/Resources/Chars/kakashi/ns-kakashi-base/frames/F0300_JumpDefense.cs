using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0300_JumpDefense 
    {
        private readonly NsKakashiBase _c;

        public F0300_JumpDefense(NsKakashiBase c)
        {
            _c = c;
        }

        private void StartJumpDefense_300()
        {
            _c.pic = 141;
            _c.state = StateFrameEnum.JUMP_DEFEND;
            _c.wait = 1f;
            _c.next = JumpDefense_301;
            _c.OnGround(290);
            _c.Attack(570);
            _c.BdyDefault();
        }

        private void JumpDefense_301()
        {
            _c.pic = 142;
            _c.state = StateFrameEnum.JUMP_DEFEND;
            _c.wait = 5f;
            _c.CanHoldDefenseAfter(JumpDefenseHold_303);
            _c.next = StopJumpDefense_302;
            _c.OnGround(290);
            _c.Attack(570);
            _c.BdyDefault();
        }

        private void StopJumpDefense_302()
        {
            _c.pic = 141;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = _c.frames[308];
            _c.OnGround(290);
            _c.Attack(570);
            _c.BdyDefault();
        }

        private void JumpDefenseHold_303()
        {
            _c.pic = 142;
            _c.state = StateFrameEnum.JUMP_DEFEND;
            _c.wait = 1f;
            _c.CanHoldDefenseAfter(JumpDefenseHold_303);
            _c.next = StopJumpDefense_302;
            _c.OnGround(290);
            _c.Attack(570);
            _c.BdyDefault();
        }

        private void HitJumpDefense_305()
        {
            _c.pic = 142;
            _c.state = StateFrameEnum.JUMP_DEFEND;
            _c.wait = 1f;
            _c.next = HitJumpDefense_306;
            _c.OnGround(290);
            _c.Attack(570);
            _c.BdyDefault();
        }

        private void HitJumpDefense_306()
        {
            _c.pic = 142;
            _c.state = StateFrameEnum.JUMP_DEFEND;
            _c.wait = 2.5f;
            _c.CanHoldDefenseAfter(JumpDefenseHold_303);
            _c.next = StopJumpDefense_302;
            _c.OnGround(290);
            _c.Attack(570);
            _c.BdyDefault();
        }
    }
}