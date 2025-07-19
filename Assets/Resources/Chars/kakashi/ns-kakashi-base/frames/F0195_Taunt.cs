namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0195_Taunt 
    {
        private readonly NsKakashiBase _c;

        public F0195_Taunt(NsKakashiBase c)
        {
            _c = c;
        }

        private void Taunt_195()
        {
            _c.pic = 100;
            _c.wait = 2f;
            _c.next = Taunt_196;
            _c.BdyDefault();
        }

        private void Taunt_196()
        {
            _c.pic = 101;
            _c.wait = 0.5f;
            _c.next = Taunt_197;
            _c.BdyDefault();
        }

        private void Taunt_197()
        {
            _c.pic = 102;
            _c.wait = 2f;
            _c.next = Taunt_198;
            _c.BdyDefault();
        }

        private void Taunt_198()
        {
            _c.pic = 103;
            _c.wait = 0.5f;
            _c.next = Taunt_199;
            _c.BdyDefault();
        }

        private void Taunt_199()
        {
            _c.pic = 104;
            _c.wait = 2f;
            _c.next = Taunt_200;
            _c.BdyDefault();
        }

        private void Taunt_200()
        {
            _c.pic = 105;
            _c.wait = 0.5f;
            _c.next = Taunt_201;
            _c.BdyDefault();
        }

        private void Taunt_201()
        {
            _c.pic = 106;
            _c.wait = 2f;
            _c.next = Taunt_202;
            _c.BdyDefault();
        }

        private void Taunt_202()
        {
            _c.pic = 106;
            _c.wait = 2f;
            _c.next = Taunt_203;
            _c.BdyDefault();
        }

        private void Taunt_203()
        {
            _c.pic = 106;
            _c.wait = 2f;
            _c.next = Taunt_204;
            _c.BdyDefault();
        }

        private void Taunt_204()
        {
            _c.pic = 106;
            _c.wait = 2f;
            _c.next = Taunt_205;
            _c.BdyDefault();
        }

        private void Taunt_205()
        {
            _c.pic = 106;
            _c.wait = 2f;
            _c.next = Taunt_206;
            _c.BdyDefault();
        }

        private void Taunt_206()
        {
            _c.pic = 107;
            _c.wait = 2f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}