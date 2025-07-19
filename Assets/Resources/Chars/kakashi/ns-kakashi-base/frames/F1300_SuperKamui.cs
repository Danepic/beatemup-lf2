using Enums;
using static CharController;
using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F1300_SuperKamui
    {
        private readonly NsKakashiBase _c;

        public F1300_SuperKamui(NsKakashiBase c)
        {
            _c = c;
        }

        private void SuperKamui_1300()
        {
            _c.EnableManaPoints();
            _c.mp = 800;
            _c.state = StateFrameEnum.CANCEL_OPOINTS_IF_CHANGE_CONTEXT_FRAMES;
            _c.ResetMovementFromStop();
            _c.pic = 764;
            _c.wait = 2f;
            _c.next = _c.CheckIfHaveMana(_c.mp) ? SuperKamui_1301 : 
                _c.frames[690];
            _c.bdy.kind = BdyKindEnum.INVULNERABLE;
            _c.BdyDefault();
            _c.ItrDisable();
            _c.SpawnOpoint(ULTIMATE_OPOINT, _c.Opoint(x: 0f, y: 0.371f, z: -0.094f, oid: 0, facingFront: true, quantity: 1));
            _c.StageFadeOut(0.05f);
        }

        private void SuperKamui_1301()
        {
            _c.UsageManaPoints(_c.mp);
            _c.pic = 765;
            _c.wait = 1f;
            _c.next = SuperKamui_1302;
            _c.BdyDefault();
            _c.bdy.kind = BdyKindEnum.INVULNERABLE;
            _c.SpawnOpoint(ULTIMATE_MUGSHOT_OPOINT, _c.Opoint(x: 0f, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1));
            _c.StageFadeOut(0.05f);
        }

        private void SuperKamui_1302()
        {
            _c.EnableManaPoints();
            _c.BlackoutStage();
            _c.pic = 766;
            _c.wait = 2f;
            _c.next = SuperKamui_1303;
            _c.BdyDefault();
        }

        private void SuperKamui_1303()
        {
            _c.pic = 767;
            _c.wait = 1f;
            _c.next = SuperKamui_1304;
            _c.BdyDefault();
            _c.SpawnOpoint(KAMUI_EYE_OPOINT, _c.Opoint(x: 0.05f, y: 0.806f, z: 0f, oid: 0, facingFront: true, quantity: 1));
            _c.opointsControl = null;
        }

        private void SuperKamui_1304()
        {
            _c.pic = 768;
            _c.wait = 5f;
            _c.next = SuperKamui_1305;
            _c.BdyDefault();
            _c.StageFadeIn(0.1f);
            _c.opointsControl = _c.SpawnOpoint(KAMUI_TARGET_OPOINT,
                _c.Opoint(x: 0.03900003f, y: 0.3f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: true),
                _c.opointsControl);
        }

        private void SuperKamui_1305()
        {
            _c.pic = 769;
            _c.wait = 1f;
            _c.next = SuperKamui_1312;
            _c.BdyDefault();
            _c.StageFadeIn(0.1f);
            _c.repeatCount = 200;
        }

        private void SuperKamui_1312()
        {
            _c.RepeatCountToFrame(SuperKamui_1310_Attack);
            _c.ResetStageColor();
            _c.pic = 770;
            _c.wait = 1f;
            _c.next = SuperKamui_1306;
            _c.BdyDefault();
            _c.Attack(SuperKamui_1310_Attack);
        }

        private void SuperKamui_1306()
        {
            _c.RepeatCountToFrame(SuperKamui_1310_Attack);
            _c.pic = 770;
            _c.wait = 1f;
            _c.next = SuperKamui_1306;
            _c.BdyDefault();
            _c.Attack(SuperKamui_1310_Attack);
        }

        private void SuperKamui_1310_Attack()
        {
            _c.pic = 770;
            _c.wait = 4f;
            _c.next = SuperKamui_1311_Attack;
            _c.BdyDefault();
            _c.opointsControl[0].ChangeFrame(50);
        }

        private void SuperKamui_1311_Attack()
        {
            _c.pic = 602;
            _c.wait = 4f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}