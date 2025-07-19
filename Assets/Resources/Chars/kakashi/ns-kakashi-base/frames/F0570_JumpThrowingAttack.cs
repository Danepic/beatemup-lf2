using static NsKakashiBase;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0570_JumpThrowingAttack 
    {
        private readonly NsKakashiBase _c;

        public F0570_JumpThrowingAttack(NsKakashiBase c)
        {
            _c = c;
        }

        private void JumpThrowingAttack_570()
        {
            _c.pic = 512;
            _c.wait = 1.5f;
            _c.next = JumpThrowingAttack_571;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpThrowingAttack_571()
        {
            _c.pic = 513;
            _c.wait = 0.5f;
            _c.next = JumpThrowingAttack_572;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpThrowingAttack_572()
        {
            _c.pic = 514;
            _c.wait = 1.5f;
            _c.next = JumpThrowingAttack_573;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.SpawnOpoint(KUNAI_OPOINT, _c.Opoint(x: 0.065f, y: 0.25f, z: 0f, oid: 20, facingFront: true, quantity: 1));
        }

        private void JumpThrowingAttack_573()
        {
            _c.pic = 515;
            _c.wait = 0.5f;
            _c.next = JumpThrowingAttack_574;
            _c.OnGround(290);
            _c.BdyDefault();
            _c.SpawnOpoint(KUNAI_OPOINT, _c.Opoint(x: 0.065f, y: 0.25f, z: 0f, oid: 20, facingFront: true, quantity: 1));
        }

        private void JumpThrowingAttack_574()
        {
            _c.pic = 516;
            _c.wait = 0.5f;
            _c.next = JumpThrowingAttack_575;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpThrowingAttack_575()
        {
            _c.pic = 517;
            _c.wait = 0.5f;
            _c.next = JumpThrowingAttack_576;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpThrowingAttack_576()
        {
            _c.pic = 517;
            _c.wait = 0.5f;
            _c.next = JumpThrowingAttack_577;
            _c.OnGround(290);
            _c.BdyDefault();
        }

        private void JumpThrowingAttack_577()
        {
            _c.pic = 517;
            _c.wait = 1f;
            _c.next = JumpThrowingAttack_577;
            _c.OnGround(290);
            _c.BdyDefault();
        }
    }
}