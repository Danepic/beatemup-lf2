using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0020_Walking 
    {
        private readonly NsKakashiBase _c;

        public F0020_Walking(NsKakashiBase c)
        {
            _c = c;
        }

        private void Walking_20()
        {
            _c.pic = 119;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 2f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_21;
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_21()
        {
            _c.pic = 120;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 0.5f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_22;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_22()
        {
            _c.pic = 121;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 2f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_23;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.22f;
            _c.Bdy();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_23()
        {
            _c.pic = 122;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 0.5f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_24;
            _c.BdyDefault();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_24()
        {
            _c.pic = 123;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 2f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_25;
            _c.BdyDefault();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_25()
        {
            _c.pic = 124;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 0.5f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_26;
            _c.BdyDefault();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_26()
        {
            _c.pic = 125;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 2f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_27;
            _c.BdyDefault();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_27()
        {
            _c.pic = 126;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 0.5f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_28;
            _c.BdyDefault();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_28()
        {
            _c.pic = 127;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 2f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_29;
            _c.BdyDefault();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_29()
        {
            _c.pic = 128;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 0.5f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_30;
            _c.BdyDefault();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }

        private void Walking_30()
        {
            _c.pic = 130;
            _c.state = StateFrameEnum.WALKING;
            _c.wait = 2f;
            _c.dvx = 3f;
            _c.dvz = 3f;
            _c.next = Walking_20;
            _c.BdyDefault();
            _c.CanFlip();
            _c.CanStandingFromWalking(0);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(298);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ApplyPhysicWalking();
            _c.ManageWalking();
        }
    }
}