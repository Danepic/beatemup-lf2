using Enums;
using static CharController;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0450_Uppercut 
    {
        private readonly NsKakashiBase _c;

        public F0450_Uppercut(NsKakashiBase c)
        {
            _c = c;
        }

        private void Uppercut_450()
        {
            _c.pic = 412;
            _c.wait = 1f;
            _c.next = Uppercut_451;
            _c.state = StateFrameEnum.ATTACK;
            _c.BdyDefault();
        }

        private void Uppercut_451()
        {
            _c.pic = 414;
            _c.wait = 1f;
            _c.next = Uppercut_452;
            _c.BdyDefault();
        }

        private void Uppercut_452()
        {
            _c.pic = 415;
            _c.wait = 1f;
            _c.next = Uppercut_453;
            _c.BdyDefault();
            _c.ResetMovementFromStop();
        }

        private void Uppercut_453()
        {
            _c.pic = 415;
            _c.wait = 1f;
            _c.next = Uppercut_454;
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(dvx: 250f, dvy: 0, dvz: 0, _c.facingRight);
        }

        private void Uppercut_454()
        {
            _c.pic = 416;
            _c.wait = 0.5f;
            _c.next = Uppercut_455;
            _c.BdyDefault();
            _c.itr.x = 0.1614f;
            _c.itr.y = 0.5224f;
            _c.itr.z = 0;
            _c.itr.w = 0.1953547f;
            _c.itr.h = 0.7817728f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 25;
            _c.itr.dvy = 350;
            _c.itr.dvz = 0;
            _c.itr.action = 840;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 20;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 15;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.ItrDefault();
        }

        private void Uppercut_455()
        {
            _c.ItrDisable();
            _c.pic = 417;
            _c.wait = 5f;
            _c.next = Uppercut_456;
            _c.BdyDefault();
            _c.StopMovement();
        }

        private void Uppercut_456()
        {
            _c.pic = 418;
            _c.wait = 1f;
            _c.next = Uppercut_457;
            _c.BdyDefault();
        }

        private void Uppercut_457()
        {
            _c.pic = 418;
            _c.wait = 0.5f;
            _c.next = Uppercut_458;
            _c.BdyDefault();
        }

        private void Uppercut_458()
        {
            _c.pic = 419;
            _c.wait = 1f;
            _c.next = Uppercut_459;
            _c.BdyDefault();
        }

        private void Uppercut_459()
        {
            _c.pic = 419;
            _c.wait = 13f;
            _c.next = _c.frames[0];
            _c.Jump(650);
            _c.state = StateFrameEnum.UPPER_TO_JUMP_COMBO;
            _c.BdyDefault();
            _c.SpawnOpoint(JUMPING_COMBO_OPOINT, _c.Opoint(x: 0f, y: 0.40f, z: -0.08f, oid: 0, facingFront: true, quantity: 1));
        }
    }
}