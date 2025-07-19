using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0000_Standing 
    {
        private readonly NsKakashiBase _c;

        public F0000_Standing(NsKakashiBase c)
        {
            _c = c;
        }

        private void Standing_0()
        {
            _c.StopMovement();
            _c.CancelOpoints();
            _c.bdy.kind = BdyKindEnum.NORMAL;
            _c.ResetMovementFromStop();
            _c.pic = 108;
            _c.state = StateFrameEnum.STANDING;
            _c.wait = 2f;
            _c.next = Standing_1;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanWalking(20);
            _c.ApplyPhysicStanding();
            _c.CanSimpleDash(40);
            _c.CanSideDash(90);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(308);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ResetParams();
        }

        private void Standing_1()
        {
            _c.pic = 111;
            _c.state = StateFrameEnum.STANDING;
            _c.wait = 1f;
            _c.next = Standing_2;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanWalking(20);
            _c.ApplyPhysicStanding();
            _c.CanSimpleDash(40);
            _c.CanSideDash(90);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(308);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ResetParams();
        }

        private void Standing_2()
        {
            _c.pic = 110;
            _c.state = StateFrameEnum.STANDING;
            _c.wait = 3f;
            _c.next = Standing_3;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanWalking(20);
            _c.ApplyPhysicStanding();
            _c.CanSimpleDash(40);
            _c.CanSideDash(90);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(308);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ResetParams();
        }

        private void Standing_3()
        {
            _c.pic = 113;
            _c.state = StateFrameEnum.STANDING;
            _c.wait = 1f;
            _c.next = Standing_4;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanWalking(20);
            _c.ApplyPhysicStanding();
            _c.CanSimpleDash(40);
            _c.CanSideDash(90);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(308);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ResetParams();
        }

        private void Standing_4()
        {
            _c.pic = 112;
            _c.state = StateFrameEnum.STANDING;
            _c.wait = 3f;
            _c.next = Standing_5;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanWalking(20);
            _c.ApplyPhysicStanding();
            _c.CanSimpleDash(40);
            _c.CanSideDash(90);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(308);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ResetParams();
        }

        private void Standing_5()
        {
            _c.pic = 115;
            _c.state = StateFrameEnum.STANDING;
            _c.wait = 1f;
            _c.next = Standing_6;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanWalking(20);
            _c.ApplyPhysicStanding();
            _c.CanSimpleDash(40);
            _c.CanSideDash(90);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(308);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ResetParams();
        }

        private void Standing_6()
        {
            _c.pic = 114;
            _c.state = StateFrameEnum.STANDING;
            _c.wait = 3f;
            _c.next = Standing_7;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanWalking(20);
            _c.ApplyPhysicStanding();
            _c.CanSimpleDash(40);
            _c.CanSideDash(90);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(308);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ResetParams();
        }

        private void Standing_7()
        {
            _c.pic = 118;
            _c.state = StateFrameEnum.STANDING;
            _c.wait = 1f;
            _c.next = Standing_8;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanWalking(20);
            _c.ApplyPhysicStanding();
            _c.CanSimpleDash(40);
            _c.CanSideDash(90);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(308);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ResetParams();
        }

        private void Standing_8()
        {
            _c.pic = 117;
            _c.state = StateFrameEnum.STANDING;
            _c.wait = 3f;
            _c.next = Standing_0;
            _c.bdy.x = -0.0111f;
            _c.bdy.y = 0.2417f;
            _c.bdy.z = 0;
            _c.bdy.w = 0.4120263f;
            _c.bdy.h = 0.4834f;
            _c.bdy.zwidth = 0.44f;
            _c.Bdy();
            _c.CanWalking(20);
            _c.ApplyPhysicStanding();
            _c.CanSimpleDash(40);
            _c.CanSideDash(90);
            _c.Jump(210);
            _c.Taunt(195);
            _c.Defense(150);
            _c.Attack(350);
            _c.InAir(308);
            _c.PowerSide(1000);
            _c.Power(1100);
            _c.PowerDown(1150);
            _c.PowerUp(1200);
            _c.SuperPower(1300);
            _c.ResetParams();
        }
    }
}