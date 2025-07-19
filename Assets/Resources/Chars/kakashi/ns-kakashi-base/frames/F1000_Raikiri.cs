using Enums;
using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F1000_Raikiri 
    {
        private readonly NsKakashiBase _c;

        public F1000_Raikiri(NsKakashiBase c)
        {
            _c = c;
        }

        private void Raikiri_1000()
        {
            _c.EnableManaPoints();
            _c.mp = 350;
            _c.state = StateFrameEnum.CANCEL_OPOINTS_IF_CHANGE_CONTEXT_FRAMES;
            _c.pic = 420;
            _c.wait = 1f;
            _c.next = _c.CheckIfHaveMana(_c.mp) ? Raikiri_1001 : 
                _c.frames[690];;
            _c.BdyDefault();
            _c.ItrDisable();
        }

        private void Raikiri_1001()
        {
            _c.UsageManaPoints(_c.mp);
            _c.pic = 421;
            _c.wait = 5f;
            _c.next = Raikiri_1002;
            _c.BdyDefault();
            _c.SpawnOpoint(RAIKIRI_OPOINT,
                _c.Opoint(x: 0, y: -0.085f, z: -0.058f, oid: 50, facingFront: true, quantity: 1, cancellable: true));
        }

        private void Raikiri_1002()
        {
            _c.EnableManaPoints();
            _c.pic = 703;
            _c.wait = 1f;
            _c.next = Raikiri_1003;
            _c.BdyDefault();
            _c.SpawnOpoint(RAIKIRI_OPOINT,
                _c.Opoint(x: 0.018f, y: 0.136f, z: -0.058f, oid: 100, facingFront: true, quantity: 1, cancellable: true));
        }

        private void Raikiri_1003()
        {
            _c.pic = 704;
            _c.wait = 10f;
            _c.next = Raikiri_1004;
            _c.BdyDefault();
        }

        private void Raikiri_1004()
        {
            _c.pic = 705;
            _c.wait = 0.5f;
            _c.next = Raikiri_1005;
            _c.BdyDefault();
        }

        private void Raikiri_1005()
        {
            _c.pic = 706;
            _c.wait = 1.5f;
            _c.next = Raikiri_1030;
            _c.BdyDefault();
        }

        private void Raikiri_1030()
        {
            _c.pic = 706;
            _c.wait = 0.5f;
            _c.next = RaikiriRunning_1006;
            _c.BdyDefault();
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.SpawnOpoint(RAIKIRI_OPOINT,
                _c.Opoint(x: -0.226f, y: 0.384f, z: -0.058f, oid: 150, facingFront: true, quantity: 1, cancellable: true,
                    attachToOwner: true));
        }

        private void RaikiriRunning_1006()
        {
            _c.pic = 707;
            _c.wait = 1.5f;
            _c.next = RaikiriRunning_1007;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1007()
        {
            _c.pic = 708;
            _c.wait = 0.5f;
            _c.next = RaikiriRunning_1008;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1008()
        {
            _c.pic = 709;
            _c.wait = 1.5f;
            _c.next = RaikiriRunning_1009;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1009()
        {
            _c.pic = 710;
            _c.wait = 0.5f;
            _c.next = RaikiriRunning_1010;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1010()
        {
            _c.pic = 711;
            _c.wait = 1.5f;
            _c.next = RaikiriRunning_1011;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1011()
        {
            _c.pic = 712;
            _c.wait = 0.5f;
            _c.next = RaikiriRunning_1012;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1012()
        {
            _c.pic = 713;
            _c.wait = 1.5f;
            _c.next = RaikiriRunning_1013;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1013()
        {
            _c.pic = 714;
            _c.wait = 0.5f;
            _c.next = RaikiriRunning_1014;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1014()
        {
            _c.pic = 715;
            _c.wait = 1.5f;
            _c.next = RaikiriRunning_1015;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1015()
        {
            _c.pic = 716;
            _c.wait = 0.5f;
            _c.next = RaikiriRunning_1016;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10f;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1016()
        {
            _c.pic = 717;
            _c.wait = 1.5f;
            _c.next = RaikiriRunning_1017;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 10f;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriRunning_1017()
        {
            _c.pic = 718;
            _c.wait = 0.5f;
            _c.next = RaikiriRunning_1006;
            _c.BdyDefault();
            _c.Attack(RaikiriAttack_1018);
            _c.dvx = 5f;
            _c.dvy = 0f;
            _c.dvz = 3f;
            _c.ApplyPhysicRunning();
        }

        private void RaikiriAttack_1018()
        {
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.pic = 719;
            _c.wait = 1f;
            _c.next = RaikiriAttack_1019;
            _c.BdyDefault();
        }

        private void RaikiriAttack_1019()
        {
            _c.pic = 720;
            _c.wait = 1.5f;
            _c.next = RaikiriAttack_1020;
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(350f, 0f, 0f, _c.facingRight);
            _c.ItrDisable();
            _c.SpawnOpoint(RAIKIRI_OPOINT,
                _c.Opoint(x: 0.65f, y: 0.384f, z: -0.058f, oid: 200, facingFront: true, quantity: 1, cancellable: true,
                    attachToOwner: true));
        }

        private void RaikiriAttack_1020()
        {
            _c.pic = 721;
            _c.wait = 1.5f;
            _c.next = RaikiriAttack_1021;
            _c.BdyDefault();
            _c.itr.x = 0.3905f;
            _c.itr.y = 0.3948f;
            _c.itr.z = 0;
            _c.itr.w = 0.3594886f;
            _c.itr.h = 0.994279f;
            _c.itr.zwidth = 0.66f;
            _c.itr.dvx = 300;
            _c.itr.dvy = 200;
            _c.itr.dvz = 0;
            _c.itr.action = 800;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 150;
            _c.itr.effect = ItrEffectEnum.BLOOD;
            _c.itr.rest = 20;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.Itr();
        }

        private void RaikiriAttack_1021()
        {
            _c.pic = 722;
            _c.wait = 8f;
            _c.next = RaikiriAttack_1022;
            _c.itr.x = 0.3905f;
            _c.itr.y = 0.3948f;
            _c.itr.z = 0;
            _c.itr.w = 0.3594886f;
            _c.itr.h = 0.994279f;
            _c.itr.zwidth = 0.66f;
            _c.itr.dvx = 300;
            _c.itr.dvy = 200;
            _c.itr.dvz = 0;
            _c.itr.action = 800;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 150;
            _c.itr.effect = ItrEffectEnum.BLOOD;
            _c.itr.rest = 20;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.Itr();
            _c.BdyDefault();
        }

        private void RaikiriAttack_1022()
        {
            _c.pic = 722;
            _c.wait = 2f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
            _c.ItrDisable();
            _c.StopMovement();
            _c.CancelOpoints();
        }
    }
}