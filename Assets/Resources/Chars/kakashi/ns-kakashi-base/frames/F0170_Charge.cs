using Enums;
using static CharController;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0170_Charge 
    {
        private readonly NsKakashiBase _c;

        public F0170_Charge(NsKakashiBase c)
        {
            _c = c;
        }

        private void ChargeStart_170()
        {
            _c.pic = 201;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = ChargeStart_171;
            _c.BdyDefault();
        }

        private void ChargeStart_171()
        {
            _c.pic = 202;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = ChargeStart_172;
            _c.BdyDefault();
        }

        private void ChargeStart_172()
        {
            _c.pic = 203;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = ChargeStart_173;
            _c.BdyDefault();
        }

        private void ChargeStart_173()
        {
            _c.pic = 204;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = Charge_175;
            _c.BdyDefault();
        }

        private void Charge_175()
        {
            _c.AddManaPoints(_c.manaTechniqueValue);
            _c.pic = 204;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 0.5f;
            _c.next = Charge_176;
            _c.Attack(ChargeStop_190);
            _c.Power(ChargeStop_190);
            _c.Defense(ChargeStop_190);
            _c.Jump(ChargeStop_190);
            _c.BdyDefault();
            _c.SpawnOpoint(CHAKRA_CHARGE_OPOINT, _c.Opoint(x: 0.173f, y: 0.497f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
        }

        private void Charge_176()
        {
            _c.EnableManaPoints();
            _c.pic = 204;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 0.5f;
            _c.next = Charge_177;
            _c.Attack(ChargeStop_190);
            _c.Power(ChargeStop_190);
            _c.Defense(ChargeStop_190);
            _c.Jump(ChargeStop_190);
            _c.BdyDefault();
            _c.SpawnOpoint(CHAKRA_CHARGE_AURA_OPOINT, _c.Opoint(x: 0f, y: 0.014f, z: 0f, oid: 0, facingFront: true, quantity: 1));
        }

        private void Charge_177()
        {
            _c.pic = 204;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 0.5f;
            _c.next = Charge_178;
            _c.Attack(ChargeStop_190);
            _c.Power(ChargeStop_190);
            _c.Defense(ChargeStop_190);
            _c.Jump(ChargeStop_190);
            _c.BdyDefault();
            _c.SpawnOpoint(CHAKRA_CHARGE_SMOKE_OPOINT, _c.Opoint(x: 0f, y: 0.109f, z: -0.102f, oid: 0, facingFront: true, quantity: 1));
        }

        private void Charge_178()
        {
            _c.pic = 204;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 3f;
            _c.next = Charge_179;
            _c.Attack(ChargeStop_190);
            _c.Power(ChargeStop_190);
            _c.Defense(ChargeStop_190);
            _c.Jump(ChargeStop_190);
            _c.BdyDefault();
        }

        private void Charge_179()
        {
            _c.pic = 204;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 2f;
            _c.next = Charge_180;
            _c.Attack(ChargeStop_190);
            _c.Power(ChargeStop_190);
            _c.Defense(ChargeStop_190);
            _c.Jump(ChargeStop_190);
            _c.BdyDefault();
        }

        private void Charge_180()
        {
            _c.pic = 204;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 2f;
            _c.next = Charge_181;
            _c.Attack(ChargeStop_190);
            _c.Power(ChargeStop_190);
            _c.Defense(ChargeStop_190);
            _c.Jump(ChargeStop_190);
            _c.BdyDefault();
        }

        private void Charge_181()
        {
            _c.pic = 204;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 2f;
            _c.next = Charge_182;
            _c.Attack(ChargeStop_190);
            _c.Power(ChargeStop_190);
            _c.Defense(ChargeStop_190);
            _c.Jump(ChargeStop_190);
            _c.BdyDefault();
        }

        private void Charge_182()
        {
            _c.pic = 204;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 2f;
            _c.next = Charge_175;
            _c.Attack(ChargeStop_190);
            _c.Power(ChargeStop_190);
            _c.Defense(ChargeStop_190);
            _c.Jump(ChargeStop_190);
            _c.BdyDefault();
        }

        private void ChargeStop_190()
        {
            _c.pic = 203;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = ChargeStop_191;
            _c.BdyDefault();
        }

        private void ChargeStop_191()
        {
            _c.pic = 203;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = ChargeStop_192;
            _c.BdyDefault();
        }

        private void ChargeStop_192()
        {
            _c.pic = 202;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 1f;
            _c.next = ChargeStop_193;
            _c.BdyDefault();
        }

        private void ChargeStop_193()
        {
            _c.pic = 201;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 0.5f;
            _c.next = ChargeStop_194;
            _c.BdyDefault();
        }

        private void ChargeStop_194()
        {
            _c.pic = 201;
            _c.state = StateFrameEnum.OTHER;
            _c.wait = 0.5f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}