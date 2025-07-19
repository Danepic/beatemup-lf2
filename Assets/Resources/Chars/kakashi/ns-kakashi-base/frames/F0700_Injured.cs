using Enums;
using UnityEngine;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0700_Injured 
    {
        private readonly NsKakashiBase _c;

        public F0700_Injured(NsKakashiBase c)
        {
            _c = c;
        }

        #region InjuredManager
        private void InjuredManager_700()
        {
            var optionInjured = Random.value;
            _c.state = StateFrameEnum.INJURED;
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 602;
            _c.wait = 2f;
            _c.next = optionInjured > 0.5f ? Injured1_702 : Injured2_710;
            _c.BdyDefault();
            _c.Defense(1500);
        }
        #endregion

        #region Injured1
        private void Injured1_702()
        {
            _c.ResetMovementFromStop();
            _c.pic = 602;
            _c.wait = 3f;
            _c.next = Injured1_703;
            _c.Defense(880);
            _c.BdyDefault();
            _c.ApplyExternPhysic();
            _c.Defense(1500);
        }

        private void Injured1_703()
        {
            _c.pic = 602;
            _c.wait = 15f;
            _c.next = _c.frames[0];
            _c.InAir(801);
            _c.BdyDefault();
            _c.StopMovement();
        }
        #endregion

        #region Injured2
        private void Injured2_710()
        {
            _c.ResetMovementFromStop();
            _c.pic = 605;
            _c.wait = 3f;
            _c.next = Injured2_711;
            _c.Defense(880);
            _c.BdyDefault();
            _c.ApplyExternPhysic();
            _c.Defense(1500);
        }

        private void Injured2_711()
        {
            _c.pic = 605;
            _c.wait = 15f;
            _c.next = _c.frames[0];
            _c.InAir(801);
            _c.BdyDefault();
            _c.StopMovement();
        }
        #endregion
    }
}