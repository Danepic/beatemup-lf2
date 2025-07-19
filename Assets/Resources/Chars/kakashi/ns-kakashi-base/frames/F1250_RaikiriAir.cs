using Enums;
using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F1250_RaikiriAir
    {
        private readonly NsKakashiBase _c;

        public F1250_RaikiriAir(NsKakashiBase c)
        {
            _c = c;
        }

        private void RaikiriAir_1250()
        {
            _c.EnableManaPoints();
            _c.mp = 350;
            _c.state = StateFrameEnum.CANCEL_OPOINTS_IF_CHANGE_CONTEXT_FRAMES;
            _c.ResetMovementFromStop();
            _c.pic = 756;
            _c.wait = 1f;
            _c.next = _c.CheckIfHaveMana(_c.mp) ? RaikiriAir_1251 : 
                _c.frames[690];
            _c.BdyDefault();
            _c.ItrDisable();
        }

        private void RaikiriAir_1251()
        {
            _c.UsageManaPoints(_c.mp);
            _c.pic = 757;
            _c.wait = 5f;
            _c.next = RaikiriAir_1252;
            _c.StopMovement();
            _c.BdyDefault();
            _c.SpawnOpoint(RAIKIRI_OPOINT,
                _c.Opoint(x: -0.1f, y: 0.268f, z: -0.058f, oid: 100, facingFront: true, quantity: 1,
                    cancellable: true));
        }

        private void RaikiriAir_1252()
        {
            _c.EnableManaPoints();
            _c.pic = 758;
            _c.wait = 1f;
            _c.next = RaikiriAir_1253;
            _c.BdyDefault();
        }

        private void RaikiriAir_1253()
        {
            _c.pic = 759;
            _c.wait = 5f;
            _c.next = RaikiriAirDash_1254;
            _c.BdyDefault();
        }

        private void RaikiriAirDash_1254()
        {
            _c.CancelOpoints();
            _c.pic = 760;
            _c.wait = 1f;
            _c.next = RaikiriAirDash_1255;
            _c.ResetMovementFromStop();
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(_c.dvx = 250, _c.dvy = -50, _c.dvz = 0f, _c.facingRight);
        }

        private void RaikiriAirDash_1255()
        {
            _c.SpawnOpoint(RAIKIRI_OPOINT,
                _c.Opoint(x: 0.497f, y: 0.01019996f, z: -0.115f, oid: 200, facingFront: true, quantity: 1,
                    cancellable: true, attachToOwner: true));
            _c.pic = 761;
            _c.wait = 1f;
            _c.next = RaikiriAirAttack_1256;
            _c.BdyDefault();
        }

        private void RaikiriAirAttack_1256()
        {
            _c.pic = 762;
            _c.wait = 1f;
            _c.next = RaikiriAirAttack_1257;
            _c.BdyDefault();
            _c.itr.contact = ItrContactEnum.LYING;
            _c.itr.x = 0.3283f;
            _c.itr.y = 0.067f;
            _c.itr.z = 0;
            _c.itr.w = 0.3895265f;
            _c.itr.h = 1.197269f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 75;
            _c.itr.dvy = 200;
            _c.itr.dvz = 0;
            _c.itr.action = 800;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 90;
            _c.itr.effect = ItrEffectEnum.BLOOD;
            _c.itr.rest = 20;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.Itr();
        }

        private void RaikiriAirAttack_1257()
        {
            _c.pic = 763;
            _c.wait = 1f;
            _c.next = RaikiriAirAttack_1257;
            _c.BdyDefault();
            _c.OnGround(RaikiriAirGround_1258);
            _c.itr.contact = ItrContactEnum.LYING;
            _c.itr.x = 0.3283f;
            _c.itr.y = 0.067f;
            _c.itr.z = 0;
            _c.itr.w = 0.3895265f;
            _c.itr.h = 1.197269f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 75;
            _c.itr.dvy = 200;
            _c.itr.dvz = 0;
            _c.itr.action = 800;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 90;
            _c.itr.effect = ItrEffectEnum.BLOOD;
            _c.itr.rest = 20;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.Itr();
        }

        private void RaikiriAirGround_1258()
        {
            _c.ItrDisable();
            _c.pic = 763;
            _c.wait = 0.5f;
            _c.next = RaikiriAirGround_1259;
            _c.BdyDefault();
        }

        private void RaikiriAirGround_1259()
        {
            _c.pic = 763;
            _c.wait = 1f;
            _c.next = _c.frames[130];
            _c.BdyDefault();
            _c.SpawnGroundNormal(
                _c.Opoint(x: 0, y: 0, z: 0, oid: 0, facingFront: true, quantity: 1, cancellable: false));
            _c.CancelOpoints();
        }
    }
}