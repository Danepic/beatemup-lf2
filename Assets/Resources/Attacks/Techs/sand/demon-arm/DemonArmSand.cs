using Enums;
using UnityEngine;

public class DemonArmSand : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/demon-arm/sprites");
        base.Awake();
        headerName = "Demon Arm Sand";
        totalHp = 500;
        frames = PopulateFrames(this);
        attackLevel1Frame = null;
        attackLevel2Frame = null;
        attackLevel3Frame = null;
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    #region Attack Front

    private void AttackFrontInvoke_0()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        wait = 0.5f;
        next = AttackFrontInvoke_1;
        ItrDisable();

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_1()
    {
        pic = 106;
        wait = 0.5f;
        next = AttackFrontInvoke_2;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_2()
    {
        pic = 105;
        wait = 1f;
        next = AttackFrontInvoke_3;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_3()
    {
        pic = 104;
        wait = 0.5f;
        next = AttackFrontInvoke_4;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_4()
    {
        pic = 103;
        wait = 0.5f;
        next = AttackFrontInvoke_5;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_5()
    {
        pic = 102;
        wait = 1f;
        next = AttackFrontInvoke_6;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
        
        itr.dvx = 350; itr.dvy = 150; itr.dvz = 0; itr.action = 860;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;

        itr.x = 0.9932f;
        itr.y = 0.0455f;
        itr.z = 0f;
        itr.w = 1.898169f;
        itr.h = 0.4315155f;
        itr.zwidth = 0.44f;
        Itr();
    }

    private void AttackFrontInvoke_6()
    {
        ItrDisable();
        pic = 101;
        wait = 5f;
        next = AttackFrontInvoke_7;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_7()
    {
        pic = 100;
        wait = 0.5f;
        next = AttackFrontInvoke_8;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }
    
    private void AttackFrontInvoke_8()
    {
        pic = 101;
        wait = 0.5f;
        next = AttackFrontInvoke_9;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_9()
    {
        pic = 102;
        wait = 1f;
        next = AttackFrontInvoke_10;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_10()
    {
        pic = 103;
        wait = 0.5f;
        next = AttackFrontInvoke_11;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_11()
    {
        pic = 104;
        wait = 0.5f;
        next = AttackFrontInvoke_12;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_12()
    {
        pic = 105;
        wait = 1f;
        next = AttackFrontInvoke_13;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void AttackFrontInvoke_13()
    {
        pic = 106;
        wait = 1f;
        next = Remove_300;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
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