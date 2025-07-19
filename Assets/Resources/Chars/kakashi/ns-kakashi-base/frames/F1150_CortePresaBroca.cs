using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F1150_CortePresaBroca 
    {
        private readonly NsKakashiBase _c;

        public F1150_CortePresaBroca(NsKakashiBase c)
        {
            _c = c;
        }

        private void CortePresaBroca_1150()
        {
            _c.EnableManaPoints();
            _c.mp = 150;
            _c.pic = 201;
            _c.wait = 1f;
            _c.next = _c.CheckIfHaveMana(_c.mp) ? CortePresaBroca_1151 : 
                _c.frames[690];
            _c.BdyDefault();
        }

        private void CortePresaBroca_1151()
        {
            _c.UsageManaPoints(_c.mp);
            _c.pic = 202;
            _c.wait = 1f;
            _c.next = CortePresaBroca_1152;
            _c.BdyDefault();
        }

        private void CortePresaBroca_1152()
        {
            _c.EnableManaPoints();
            _c.pic = 203;
            _c.wait = 1f;
            _c.next = CortePresaBroca_1153;
            _c.BdyDefault();
        }

        private void CortePresaBroca_1153()
        {
            _c.pic = 204;
            _c.wait = 1f;
            _c.next = CortePresaBroca_1154;
            _c.BdyDefault();
        }

        private void CortePresaBroca_1154()
        {
            _c.pic = 425;
            _c.wait = 1f;
            _c.next = CortePresaBroca_1155;
            _c.BdyDefault();
        }

        private void CortePresaBroca_1155()
        {
            _c.pic = 426;
            _c.wait = 1f;
            _c.next = CortePresaBroca_1156;
            _c.BdyDefault();
        }

        private void CortePresaBroca_1156()
        {
            _c.SpawnGroundSmall(_c.Opoint(x: 0, y: 0, z: 0f, oid: 0, facingFront: false, quantity: 1, cancellable: false,
                attachToOwner: false));
            _c.pic = 427;
            _c.wait = 1f;
            _c.next = CortePresaBroca_1157;
            _c.BdyDefault();
        }

        private void CortePresaBroca_1157()
        {
            _c.SpawnGroundExtraSmall(_c.Opoint(x: 0, y: 0, z: -0.03716838f, oid: 0, facingFront: false, quantity: 1,
                cancellable: false, attachToOwner: false));
            _c.pic = 702;
            _c.wait = 1f;
            _c.next = CortePresaBrocaWalinkg_1160;
            _c.BdyDefault();
        }

        private void CortePresaBrocaWalinkg_1160()
        {
            _c.pic = -9999;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 1f;
            _c.dvx = 5f;
            _c.dvz = 3f;
            _c.next = CortePresaBrocaWalinkg_1160;
            _c.mp = -25;
            _c.bdy.kind = BdyKindEnum.INVULNERABLE;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
            _c.CanFlip();
            _c.Jump(CortePresaBrocaAttack_1165);
            _c.Taunt(CortePresaBrocaAttack_1165);
            _c.Defense(CortePresaBrocaAttack_1165);
            _c.Attack(CortePresaBrocaAttack_1165);
            _c.InAir(CortePresaBrocaAttack_1165);
            _c.ApplyPhysicRunning();
            _c.ManageWalking();
            _c.SpawnGroundSmall(_c.Opoint(x: 0, y: 0, z: 0f, oid: 0, facingFront: false, quantity: 1, cancellable: false,
                attachToOwner: false));
        }

        private void CortePresaBrocaAttack_1165()
        {
            _c.SpawnGroundSmall(_c.Opoint(x: 0, y: 0, z: 0f, oid: 0, facingFront: false, quantity: 1, cancellable: false,
                attachToOwner: false));
            _c.pic = 723;
            _c.wait = 0.5f;
            _c.next = CortePresaBrocaAttack_1166;
            _c.BdyDefault();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.StopMovement();
        }

        private void CortePresaBrocaAttack_1166()
        {
            _c.SpawnGroundExtraSmall(_c.Opoint(x: 0, y: 0, z: -0.03716838f, oid: 0, facingFront: false, quantity: 1,
                cancellable: false, attachToOwner: false));
            _c.ResetMovementFromStop();
            _c.pic = 724;
            _c.wait = 0.5f;
            _c.next = CortePresaBrocaAttack_1167;
            _c.BdyDefault();
            _c.ItrDisable();
            _c.ApplyDefaultPhysic(_c.dvx = 40, _c.dvy = 350, _c.dvz = 0, _c.facingRight);
        }

        private void CortePresaBrocaAttack_1167()
        {
            _c.pic = 725;
            _c.wait = 1f;
            _c.next = CortePresaBrocaAttack_1168;
            _c.BdyDefault();
            _c.itr.dvx = 40;
            _c.itr.dvy = 350;
            _c.itr.dvz = 0;
            _c.itr.action = 840;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 45;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 14;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.ItrDefault(zwidth: 0.22f);
        }

        private void CortePresaBrocaAttack_1168()
        {
            _c.pic = 726;
            _c.wait = 10f;
            _c.next = CortePresaBroca_1169;
            _c.BdyDefault();
            _c.itr.dvx = 20;
            _c.itr.dvy = 200;
            _c.itr.dvz = 0;
            _c.itr.action = 840;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 45;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 12;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.ItrDefault(zwidth: 0.22f);
            _c.OnGround(290);
        }

        private void CortePresaBroca_1169()
        {
            _c.ItrDisable();
            _c.pic = 727;
            _c.wait = 0.5f;
            _c.next = CortePresaBroca_1170;
            _c.BdyDefault();
            _c.OnGround(290);
        }

        private void CortePresaBroca_1170()
        {
            _c.ItrDisable();
            _c.pic = 727;
            _c.wait = 2f;
            _c.next = CortePresaBroca_1171;
            _c.state = StateFrameEnum.JUMP_COMBO_ATTACK;
            _c.BdyDefault();
            _c.OnGround(290);
            _c.DoubleTapJump(670);
            _c.Attack(590);
        }

        private void CortePresaBroca_1171()
        {
            _c.ItrDisable();
            _c.pic = 727;
            _c.wait = 0.5f;
            _c.next = CortePresaBroca_1172;
            _c.state = StateFrameEnum.JUMP_COMBO_ATTACK;
            _c.BdyDefault();
            _c.OnGround(290);
            _c.DoubleTapJump(670);
            _c.Attack(590);
        }

        private void CortePresaBroca_1172()
        {
            _c.ItrDisable();
            _c.pic = 727;
            _c.wait = 2f;
            _c.next = CortePresaBroca_1172;
            _c.state = StateFrameEnum.JUMP_COMBO_ATTACK;
            _c.BdyDefault();
            _c.OnGround(290);
            _c.DoubleTapJump(670);
            _c.Attack(590);
        }
    }
}