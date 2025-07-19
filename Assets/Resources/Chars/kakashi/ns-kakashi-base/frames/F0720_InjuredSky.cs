using Enums;
using UnityEngine;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0720_InjuredSky 
    {
        private readonly NsKakashiBase _c;

        public F0720_InjuredSky(NsKakashiBase c)
        {
            _c = c;
        }

        #region InjuredSkyManager

        private void InjuredSkyManager_720()
        {
            var optionInjured = Random.value;
            _c.state = StateFrameEnum.INJURED;
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 602;
            _c.wait = 2f;
            _c.next = optionInjured > 0.5f ? InjuredSky1_722 : InjuredSky2_730;
            _c.BdyDefault();
            _c.Defense(1500);
        }

        #endregion

        #region InjuredSky1

        private void InjuredSky1_722()
        {
            _c.ResetMovementFromStop();
            _c.pic = 602;
            _c.wait = 3f;
            _c.next = InjuredSky1_723;
            _c.Defense(885);
            _c.BdyDefault();
            _c.ApplyExternPhysic();
            _c.Defense(1500);
        }

        private void InjuredSky1_723()
        {
            _c.pic = 602;
            _c.wait = 1f;
            _c.next = InjuredSky1_724;
            _c.BdyDefault();
            _c.StopMovement();
        }

        private void InjuredSky1_724()
        {
            _c.pic = 602;
            _c.wait = 10f;
            _c.next = _c.frames[801];
            _c.BdyDefault();
        }

        #endregion

        #region InjuredSky2

        private void InjuredSky2_730()
        {
            _c.ResetMovementFromStop();
            _c.pic = 605;
            _c.wait = 3f;
            _c.next = InjuredSky2_731;
            _c.Defense(885);
            _c.BdyDefault();
            _c.ApplyExternPhysic();
            _c.Defense(1500);
        }

        private void InjuredSky2_731()
        {
            _c.pic = 605;
            _c.wait = 1f;
            _c.next = InjuredSky2_733;
            _c.BdyDefault();
            _c.StopMovement();
        }

        private void InjuredSky2_733()
        {
            _c.pic = 605;
            _c.wait = 10f;
            _c.next = _c.frames[801];
            _c.BdyDefault();
        }

        #endregion
    }
}