using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Chars;
using Domains;
using Enums;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raikiri : AttackController
{
    void Awake()
    {
        base.Awake();
        headerName = "Raikiri";
        totalHp = -1;
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    #region Idle
    private void IdleInvoke_0()
    {
        pic = -9999; repeatCount = 100;
        wait = 0.5f;
        next = IdleInvoke_1;
        ItrDisable();
        hurtbox.gameObject.SetActive(false);
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void IdleInvoke_1()
    {
        RepeatCountToFrame(Remove_300);
        pic = 100; wait = 1; next = IdleInvoke_2;
    }
    private void IdleInvoke_2()
    {
        pic = 101; wait = 1f; next = IdleInvoke_3;
    }
    private void IdleInvoke_3()
    {
        pic = 102; wait = 1f; next = IdleInvoke_4;
    }
    private void IdleInvoke_4()
    {
        pic = 103; wait = 1f; next = IdleInvoke_5;
    }
    private void IdleInvoke_5()
    {
        pic = 104; wait = 1f; next = IdleInvoke_6;
    }
    private void IdleInvoke_6()
    {
        pic = 105; wait = 1f; next = IdleInvoke_7;
    }
    private void IdleInvoke_7()
    {
        pic = 106; wait = 1f; next = IdleInvoke_8;
    }
    private void IdleInvoke_8()
    {
        pic = 107; wait = 1f; next = IdleInvoke_9;
    }
    private void IdleInvoke_9()
    {
        pic = 108; wait = 1f; next = IdleInvoke_10;
    }
    private void IdleInvoke_10()
    {
        pic = 109; wait = 1f; next = IdleInvoke_1;
    }
    #endregion


    #region Ground
    private void GroundIdleInvoke_50()
    {
        repeatCount = 50;
        pic = 200;
        wait = 1f;
        next = GroundIdleInvoke_51;
        ItrDisable();
        hurtbox.gameObject.SetActive(false);
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void GroundIdleInvoke_51()
    {
        RepeatCountToFrame(Remove_300);
        pic = 202;
        wait = 1f;
        next = GroundIdleInvoke_52;
    }

    private void GroundIdleInvoke_52()
    {
        pic = 204;
        wait = 1f;
        next = GroundIdleInvoke_53;
    }

    private void GroundIdleInvoke_53()
    {
        pic = 205;
        wait = 1f;
        next = GroundIdleInvoke_51;
    }
    #endregion


    #region Idle 2
    private void IdleSecondInvoke_100()
    {
        pic = 300; repeatCount = 50;
        wait = 0.5f;
        next = IdleSecondInvoke_101;
        ItrDisable();
        hurtbox.gameObject.SetActive(false);
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void IdleSecondInvoke_101()
    {
        pic = 301; RepeatCountToFrame(Remove_300);
        wait = 0.5f;
        next = IdleSecondInvoke_102;
    }

    private void IdleSecondInvoke_102()
    {
        pic = 302;
        wait = 0.5f;
        next = IdleSecondInvoke_103;
    }

    private void IdleSecondInvoke_103()
    {
        pic = 303;
        wait = 0.5f;
        next = IdleSecondInvoke_104;
    }

    private void IdleSecondInvoke_104()
    {
        pic = 304;
        wait = 0.5f;
        next = IdleSecondInvoke_105;
    }

    private void IdleSecondInvoke_105()
    {
        pic = 305;
        wait = 0.5f;
        next = IdleSecondInvoke_106;
    }

    private void IdleSecondInvoke_106()
    {
        pic = 306;
        wait = 0.5f;
        next = IdleSecondInvoke_107;
    }

    private void IdleSecondInvoke_107()
    {
        pic = 307;
        wait = 0.5f;
        next = IdleSecondInvoke_108;
    }

    private void IdleSecondInvoke_108()
    {
        pic = 308;
        wait = 0.5f;
        next = IdleSecondInvoke_109;
    }

    private void IdleSecondInvoke_109()
    {
        pic = 309;
        wait = 0.5f;
        next = IdleSecondInvoke_110;
    }

    private void IdleSecondInvoke_110()
    {
        pic = 310;
        wait = 0.5f;
        next = IdleSecondInvoke_111;
    }

    private void IdleSecondInvoke_111()
    {
        pic = 311;
        wait = 0.5f;
        next = IdleSecondInvoke_112;
    }

    private void IdleSecondInvoke_112()
    {
        pic = 312;
        wait = 0.5f;
        next = IdleSecondInvoke_113;
    }

    private void IdleSecondInvoke_113()
    {
        pic = 313;
        wait = 0.5f;
        next = IdleSecondInvoke_114;
    }

    private void IdleSecondInvoke_114()
    {
        pic = 314;
        wait = 0.5f;
        next = IdleSecondInvoke_115;
    }

    private void IdleSecondInvoke_115()
    {
        pic = 315;
        wait = 0.5f;
        next = IdleSecondInvoke_116;
    }

    private void IdleSecondInvoke_116()
    {
        pic = 316;
        wait = 0.5f;
        next = IdleSecondInvoke_117;
    }

    private void IdleSecondInvoke_117()
    {
        pic = 317;
        wait = 0.5f;
        next = IdleSecondInvoke_118;
    }

    private void IdleSecondInvoke_118()
    {
        pic = 318;
        wait = 0.5f;
        next = IdleSecondInvoke_119;
    }

    private void IdleSecondInvoke_119()
    {
        pic = 319;
        wait = 0.5f;
        next = IdleSecondInvoke_120;
    }

    private void IdleSecondInvoke_120()
    {
        pic = 320;
        wait = 0.5f;
        next = IdleSecondInvoke_121;
    }

    private void IdleSecondInvoke_121()
    {
        pic = 321;
        wait = 0.5f;
        next = IdleSecondInvoke_101;
    }
    #endregion


    #region Running
    private void RunningInvoke_150()
    {
        pic = 400; repeatCount = 50;
        wait = 0.5f;
        next = RunningInvoke_151;
        ItrDisable();
        hurtbox.gameObject.SetActive(false);
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void RunningInvoke_151()
    {
        pic = 401; RepeatCountToFrame(Remove_300);
        wait = 0.5f;
        next = RunningInvoke_152;
    }

    private void RunningInvoke_152()
    {
        pic = 402;
        wait = 0.5f;
        next = RunningInvoke_153;
    }

    private void RunningInvoke_153()
    {
        pic = 403;
        wait = 0.5f;
        next = RunningInvoke_154;
    }

    private void RunningInvoke_154()
    {
        pic = 404;
        wait = 0.5f;
        next = RunningInvoke_155;
    }

    private void RunningInvoke_155()
    {
        pic = 405;
        wait = 0.5f;
        next = RunningInvoke_156;
    }

    private void RunningInvoke_156()
    {
        pic = 406;
        wait = 0.5f;
        next = RunningInvoke_157;
    }

    private void RunningInvoke_157()
    {
        pic = 407;
        wait = 0.5f;
        next = RunningInvoke_158;
    }

    private void RunningInvoke_158()
    {
        pic = 408;
        wait = 0.5f;
        next = RunningInvoke_159;
    }

    private void RunningInvoke_159()
    {
        pic = 409;
        wait = 0.5f;
        next = RunningInvoke_151;
    }
    #endregion


    #region Attack
    private void AttackInvoke_200()
    {
        pic = 500; repeatCount = 50;
        wait = 1f;
        next = AttackInvoke_201;
        ItrDisable();
        hurtbox.gameObject.SetActive(false);
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void AttackInvoke_201()
    {
        pic = 501; RepeatCountToFrame(Remove_300);
        wait = 1f;
        next = AttackInvoke_202;
    }

    private void AttackInvoke_202()
    {
        pic = 502;
        wait = 1f;
        next = AttackInvoke_203;
    }

    private void AttackInvoke_203()
    {
        pic = 503;
        wait = 1f;
        next = AttackInvoke_204;
    }

    private void AttackInvoke_204()
    {
        pic = 504;
        wait = 1f;
        next = AttackInvoke_205;
    }

    private void AttackInvoke_205()
    {
        pic = 505;
        wait = 1f;
        next = AttackInvoke_201;
    }
    #endregion

    #region Remove
    private void Remove_300()
    {
        pic = -9999;
        ItrDisable();
        Delete();
    }
    #endregion
}
