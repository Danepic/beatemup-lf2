using Enums;

namespace Resources.Chars.kakashi.ns_kakashi_base.frames
{
    public class F0330_RunningAttack 
    {
        private readonly NsKakashiBase _c;

        public F0330_RunningAttack(NsKakashiBase c)
        {
            _c = c;
        }

        private void RunningAttack_330()
        {
            _c.pic = 211;
            _c.wait = 1f;
            _c.state = StateFrameEnum.ATTACK;
            _c.next = RunningAttack_331;
            _c.BdyDefault();
            _c.ItrDisable();
        }

        private void RunningAttack_331()
        {
            _c.StopMovement();
            _c.pic = 211;
            _c.wait = 0.5f;
            _c.next = RunningAttack_332;
            _c.BdyDefault();
        }

        private void RunningAttack_332()
        {
            _c.ResetMovementFromStop();
            _c.pic = 212;
            _c.wait = 1f;
            _c.dvx = 350;
            _c.next = RunningAttack_333;
            _c.BdyDefault();
            _c.ApplyDefaultPhysic(_c.dvx, null, null, _c.facingRight);
        }

        private void RunningAttack_333()
        {
            _c.pic = 213;
            _c.wait = 0.5f;
            _c.next = RunningAttack_334;
            _c.BdyDefault();
        }

        private void RunningAttack_334()
        {
            _c.pic = 214;
            _c.wait = 1f;
            _c.next = RunningAttack_335;
            _c.BdyDefault();
        }

        private void RunningAttack_335()
        {
            _c.pic = 215;
            _c.wait = 0.5f;
            _c.next = RunningAttack_336;
            _c.BdyDefault();
        }

        private void RunningAttack_336()
        {
            _c.pic = 216;
            _c.wait = 1f;
            _c.next = RunningAttack_337;
            _c.BdyDefault();
            _c.itr.x = 0.2098f;
            _c.itr.y = 0.2994f;
            _c.itr.z = 0;
            _c.itr.w = 0.4802928f;
            _c.itr.h = 0.3247183f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 250;
            _c.itr.dvy = 200;
            _c.itr.dvz = 0;
            _c.itr.action = 860;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 60;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 7;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.Itr();
        }

        private void RunningAttack_337()
        {
            _c.ItrDisable();
            _c.pic = 217;
            _c.wait = 1f;
            _c.next = RunningAttack_338;
            _c.BdyDefault();
            _c.itr.x = 0.2098f;
            _c.itr.y = 0.2994f;
            _c.itr.z = 0;
            _c.itr.w = 0.4802928f;
            _c.itr.h = 0.3247183f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 250;
            _c.itr.dvy = 200;
            _c.itr.dvz = 0;
            _c.itr.action = 860;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 60;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 7;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.Itr();
        }

        private void RunningAttack_338()
        {
            _c.pic = 218;
            _c.wait = 1f;
            _c.next = RunningAttack_339;
            _c.BdyDefault();
            _c.itr.x = 0.2098f;
            _c.itr.y = 0.2994f;
            _c.itr.z = 0;
            _c.itr.w = 0.4802928f;
            _c.itr.h = 0.3247183f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 250;
            _c.itr.dvy = 200;
            _c.itr.dvz = 0;
            _c.itr.action = 860;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 60;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 7;
            _c.itr.physic = ItrPhysicEnum.DEFAULT;
            _c.Itr();
        }

        private void RunningAttack_339()
        {
            _c.pic = 219;
            _c.wait = 1f;
            _c.next = RunningAttack_340;
            _c.BdyDefault();
            _c.itr.x = 0.2098f;
            _c.itr.y = 0.2994f;
            _c.itr.z = 0;
            _c.itr.w = 0.4802928f;
            _c.itr.h = 0.3247183f;
            _c.itr.zwidth = 0.44f;
            _c.itr.dvx = 250;
            _c.itr.dvy = 200;
            _c.itr.dvz = 0;
            _c.itr.action = 860;
            _c.itr.applyInSingleEnemy = false;
            _c.itr.defensable = true;
            _c.itr.level = 1;
            _c.itr.injury = 60;
            _c.itr.effect = ItrEffectEnum.NORMAL;
            _c.itr.rest = 7;
            _c.Itr();
        }

        private void RunningAttack_340()
        {
            _c.StopMovement();
            _c.pic = 220;
            _c.wait = 0.5f;
            _c.next = RunningAttack_341;
            _c.BdyDefault();
        }

        private void RunningAttack_341()
        {
            _c.pic = 221;
            _c.wait = 1f;
            _c.next = RunningAttack_342;
            _c.BdyDefault();
        }

        private void RunningAttack_342()
        {
            _c.pic = 222;
            _c.wait = 0.5f;
            _c.next = RunningAttack_343;
            _c.BdyDefault();
        }

        private void RunningAttack_343()
        {
            _c.pic = 224;
            _c.wait = 1f;
            _c.next = RunningAttack_344;
            _c.BdyDefault();
        }

        private void RunningAttack_344()
        {
            _c.pic = 225;
            _c.wait = 0.5f;
            _c.next = RunningAttack_345;
            _c.BdyDefault();
        }

        private void RunningAttack_345()
        {
            _c.pic = 226;
            _c.wait = 1f;
            _c.next = _c.frames[0];
            _c.BdyDefault();
        }
    }
}