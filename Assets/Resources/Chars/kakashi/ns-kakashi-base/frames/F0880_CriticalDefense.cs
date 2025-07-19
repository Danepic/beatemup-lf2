using static CharController;
using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0880_CriticalDefense 
    {
        private readonly NsKakashiBase _c;

        public F0880_CriticalDefense(NsKakashiBase c)
        {
            _c = c;
        }

        #region CriticalDefense

        private void CriticalDefense_880()
        {
            if (_c.canParry)
            {
                _c.spriteRenderer.color = _c.parryColor;
                _c.currentHp += _c.lastDamage > 0 ? _c.lastDamage : 0;
                _c.canParry = false;
            }

            _c.pic = 140;
            _c.wait = 1f;
            _c.next = CriticalDefense_881;
            _c.Attack(350);
            _c.BdyDefault();
        }

        private void CriticalDefense_881()
        {
            _c.pic = 140;
            _c.wait = 1f;
            _c.next = _c.frames[152];
            _c.Attack(350);
            _c.BdyDefault();
            _c.SpawnOpoint(JUMPING_COMBO_OPOINT, _c.Opoint(x: 0f, y: 0.3f, z: -0.13f, oid: 0, facingFront: true, quantity: 1));
        }

        #endregion

        #region JumpCriticalDefense

        private void JumpCriticalDefense_885()
        {
            if (_c.canParry)
            {
                _c.spriteRenderer.color = _c.parryColor;
                _c.currentHp += _c.lastDamage > 0 ? _c.lastDamage : 0;
                _c.canParry = false;
            }

            _c.pic = 142;
            _c.wait = 1f;
            _c.next = JumpCriticalDefense_886;
            _c.Attack(590);
            _c.BdyDefault();
        }

        private void JumpCriticalDefense_886()
        {
            _c.pic = 142;
            _c.wait = 1f;
            _c.next = _c.frames[302];
            _c.Attack(590);
            _c.BdyDefault();
            _c.SpawnOpoint(JUMPING_COMBO_OPOINT, _c.Opoint(x: 0.11f, y: 0.25f, z: -0.12f, oid: 0, facingFront: true, quantity: 1));
        }

        #endregion
    }
}