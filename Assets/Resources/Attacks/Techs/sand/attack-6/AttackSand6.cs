using Enums;
using UnityEngine;

public class AttackSand6 : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/attack-6/sprites");
        base.Awake();
        headerName = "Attack Sand 6";
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
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackFrontInvoke_1()
    {
        pic = 300;
        wait = 0.5f;
        next = AttackFrontInvoke_2;
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackFrontInvoke_2()
    {
        pic = 301;
        wait = 1f;
        next = AttackFrontInvoke_3;
        BdyDefault(zwidth: 0.22f);
        
        itr.dvx = 350; itr.dvy = 150; itr.dvz = 0; itr.action = 860;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 150;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;

        itr.x = 1.864f;
        itr.y = 0.786f;
        itr.z = 0f;
        itr.w = 3.239095f;
        itr.h = 2.13297f;
        itr.zwidth = 0.44f;
        Itr();
    }

    private void AttackFrontInvoke_3()
    {
        pic = 302;
        wait = 0.5f;
        next = AttackFrontInvoke_4;
        
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackFrontInvoke_4()
    {
        pic = 303;
        wait = 0.5f;
        next = AttackFrontInvoke_5;
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackFrontInvoke_5()
    {
        pic = 304;
        wait = 1f;
        next = AttackFrontInvoke_6;
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackFrontInvoke_6()
    {
        pic = 305;
        wait = 0.5f;
        next = Remove_300;
        BdyDefault(zwidth: 0.22f);
    }
    #endregion

    #region ErupcaoAttack

    private void ErupcaoAttack_20()
    {
        pic = 200;
        wait = 2;
        next = ErupcaoAttack_21;
        BdyDefault(zwidth: 0.22f);
    }

    private void ErupcaoAttack_21()
    {
        pic = 201;
        wait = 2;
        next = ErupcaoAttack_22;
        BdyDefault(zwidth: 0.22f);
    }

    private void ErupcaoAttack_22()
    {
        pic = 202;
        wait = 2;
        next = ErupcaoAttack_23;
        BdyDefault(zwidth: 0.22f);
    }

    private void ErupcaoAttack_23()
    {
        pic = 203;
        wait = 2;
        next = ErupcaoAttack_24;
        BdyDefault(zwidth: 0.22f);
    }

    private void ErupcaoAttack_24()
    {
        pic = 204;
        wait = 2;
        next = ErupcaoAttack_25;
        BdyDefault(zwidth: 0.22f);
    }

    private void ErupcaoAttack_25()
    {
        pic = 205;
        wait = 2;
        next = ErupcaoAttack_20; // loop opcional
        BdyDefault(zwidth: 0.22f);
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