using Enums;
using static CharController;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0750_Kawarimi 
    {
        private readonly NsKakashiBase _c;

        public F0750_Kawarimi(NsKakashiBase c)
        {
            _c = c;
        }

        private void Kawa_1500()
        {
            _c.pic = -9999;
            _c.wait = 1f;
            _c.next = Kawa_1501;
            _c.BdyDefault();
            _c.bdy.kind = BdyKindEnum.INVULNERABLE;
            _c.ItrDisable();
            _c.SpawnOpoint(KAWA_LOG_OPOINT, _c.Opoint(x: 0f, y: 0.5f, z: 0f, oid: 0, facingFront: true, quantity: 1));
        }

        private void Kawa_1501()
        {
            _c.pic = -9999;
            _c.wait = 2f;
            _c.next = Kawa_1502;
            _c.BdyDefault();
            _c.bdy.kind = BdyKindEnum.INVULNERABLE;
            _c.ItrDisable();
            if (_c.hitRight)
            {
                _c.dvx = 300f;
                _c.ApplyDefaultPhysic(_c.dvx, dvy: 0f, dvz: 0f, _c.facingRight, ItrPhysicEnum.DEFAULT, ignoreFacing: true);
            }
            else if (_c.hitLeft)
            {
                _c.dvx = -300f;
                _c.ApplyDefaultPhysic(_c.dvx, dvy: 0f, dvz: 0f, _c.facingRight, ItrPhysicEnum.DEFAULT, ignoreFacing: true);
            }
            else
            {
                _c.ApplyDefaultPhysic(dvx: -300f, dvy: 0f, dvz: 0f, _c.facingRight, ItrPhysicEnum.DEFAULT);
            }
        }

        private void Kawa_1502()
        {
            _c.pic = 702;
            _c.wait = 1f;
            _c.next = Kawa_1503;
            _c.BdyDefault();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.ItrDisable();
        }

        private void Kawa_1503()
        {
            _c.pic = 701;
            _c.wait = 1f;
            _c.next = Kawa_1504;
            _c.BdyDefault();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.ItrDisable();
        }

        private void Kawa_1504()
        {
            _c.StopMovement();
            _c.pic = 700;
            _c.wait = 1f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.ItrDisable();
        }
    }
}