using Enums;
using UnityEngine;

public class AttackSand5 : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/attack-5/sprites");
        base.Awake();
        headerName = "Attack Sand 5";
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

    #region Attack Down
    private void AttackDownInvoke_0()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        wait = 0.5f;
        next = AttackDownInvoke_1;
        ItrDisable();
        BdyDefault(zwidth: 0.44f);
    }

    private void AttackDownInvoke_1()
    {
        pic = 100;
        wait = 0.5f;
        next = AttackDownInvoke_2;
        BdyDefault(zwidth: 0.44f);
    }

    private void AttackDownInvoke_2()
    {
        pic = 101;
        wait = 1f;
        next = AttackDownInvoke_3;
        BdyDefault(zwidth: 0.44f);
        
        itr.dvx = 50; itr.dvy = 0; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 80;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;

        itr.x = -0.542f;
        itr.y = 1.291f;
        itr.z = 0f;
        itr.w = 2.24775f;
        itr.h = 2.58265f;
        itr.zwidth = 0.44f;
        Itr();
    }

    private void AttackDownInvoke_3()
    {
        pic = 102;
        wait = 0.5f;
        next = AttackDownInvoke_4;
        
        BdyDefault(zwidth: 0.44f);
    }

    private void AttackDownInvoke_4()
    {
        pic = 103;
        wait = 0.5f;
        next = AttackDownInvoke_5;
        BdyDefault(zwidth: 0.44f);
    }

    private void AttackDownInvoke_5()
    {
        pic = 104;
        wait = 1f;
        next = AttackDownInvoke_6;
        BdyDefault(zwidth: 0.44f);
        OnGround(AttackDownGroundInvoke_10);
    }

    private void AttackDownInvoke_6()
    {
        pic = 105;
        wait = 0.5f;
        next = AttackDownInvoke_7;
        BdyDefault(zwidth: 0.44f);
    }

    private void AttackDownInvoke_7()
    {
        pic = 106;
        wait = 0.5f;
        next = Remove_300;
        BdyDefault(zwidth: 0.44f);
    }
    #endregion
    
    
    #region Attack Down Ground
    private void AttackDownGroundInvoke_10()
    {
        transform.localScale = new Vector3(0.2f,0.2f,1f);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 200;
        wait = 0.5f;
        next = AttackDownGroundInvoke_11;
        ItrDisable();
        BdyDefault(zwidth: 0.44f);
    }

    private void AttackDownGroundInvoke_11()
    {
        pic = 200;
        wait = 1f;
        next = AttackDownGroundInvoke_12;
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackDownGroundInvoke_12()
    {
        pic = 201;
        wait = 1f;
        next = AttackDownGroundInvoke_13;
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackDownGroundInvoke_13()
    {
        pic = 202;
        wait = 1f;
        next = AttackDownGroundInvoke_14;
        
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackDownGroundInvoke_14()
    {
        pic = 203;
        wait = 1f;
        next = AttackDownGroundInvoke_15;
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackDownGroundInvoke_15()
    {
        pic = 204;
        wait = 1f;
        next = AttackDownGroundInvoke_16;
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackDownGroundInvoke_16()
    {
        pic = 205;
        wait = 1f;
        next = AttackDownGroundInvoke_17;
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackDownGroundInvoke_17()
    {
        pic = 206;
        wait = 1f;
        next = AttackDownGroundInvoke_18;
        BdyDefault(zwidth: 0.22f);
    }

    private void AttackDownGroundInvoke_18()
    {
        pic = 207;
        wait = 1f;
        next = Remove_300;
        BdyDefault(zwidth: 0.22f);
    }
    #endregion
    
    #region Jump Super Attack
    private void JumpSuperAttackInvoke_30()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        wait = 0.5f;
        next = JumpSuperAttackInvoke_31;
        ItrDisable();
        BdyDefault(zwidth: 0.22f);
    }

    private void JumpSuperAttackInvoke_31()
    {
        pic = 100;
        wait = 0.5f;
        next = JumpSuperAttackInvoke_32;
        BdyDefault(zwidth: 0.22f);
    }

    private void JumpSuperAttackInvoke_32()
    {
        pic = 101;
        wait = 1f;
        next = JumpSuperAttackInvoke_33;
        BdyDefault(zwidth: 0.22f);
    }

    private void JumpSuperAttackInvoke_33()
    {
        pic = 102;
        wait = 0.5f;
        next = JumpSuperAttackInvoke_34;
        
        BdyDefault(zwidth: 0.22f);
        
        itr.x = -0.301f; itr.y = 1.211f; itr.z = 0;
        itr.w = 1.771828f; itr.h = 3.155782f; itr.zwidth = 0.44f;
        itr.dvx = 0; itr.dvy = -250; itr.dvz = 0; itr.action = 820;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 60;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
    }

    private void JumpSuperAttackInvoke_34()
    {
        pic = 103;
        wait = 0.5f;
        next = JumpSuperAttackInvoke_35;
        BdyDefault(zwidth: 0.22f);
    }

    private void JumpSuperAttackInvoke_35()
    {
        pic = 104;
        wait = 1f;
        next = JumpSuperAttackInvoke_36;
        BdyDefault(zwidth: 0.22f);
    }

    private void JumpSuperAttackInvoke_36()
    {
        pic = 105;
        wait = 0.5f;
        next = JumpSuperAttackInvoke_37;
        BdyDefault(zwidth: 0.22f);
    }

    private void JumpSuperAttackInvoke_37()
    {
        pic = 106;
        wait = 0.5f;
        next = Remove_300;
        BdyDefault(zwidth: 0.22f);
    }
    #endregion
    
    
    #region Run Attack
    private void RunAttackInvoke_60()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        transform.localScale = new Vector3(0.25f,0.25f,1f);
        pic = -9999;
        wait = 0.5f;
        next = RunAttackInvoke_61;
        ItrDisable();
        BdyDefault(zwidth: 0.44f);
    }

    private void RunAttackInvoke_61()
    {
        pic = 300;
        wait = 0.5f;
        next = RunAttackInvoke_62;
        BdyDefault(zwidth: 0.44f);
    }

    private void RunAttackInvoke_62()
    {
        pic = 301;
        wait = 1f;
        next = RunAttackInvoke_63;
        BdyDefault(zwidth: 0.44f);
        
        itr.dvx = 350; itr.dvy = 150; itr.dvz = 0; itr.action = 860;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 60;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;

        itr.x = -0.542f;
        itr.y = 1.291f;
        itr.z = 0f;
        itr.w = 2.24775f;
        itr.h = 2.58265f;
        itr.zwidth = 0.66f;
        Itr();
    }

    private void RunAttackInvoke_63()
    {
        pic = 302;
        wait = 0.5f;
        next = RunAttackInvoke_64;
        
        BdyDefault(zwidth: 0.44f);
    }

    private void RunAttackInvoke_64()
    {
        pic = 303;
        wait = 0.5f;
        next = RunAttackInvoke_65;
        BdyDefault(zwidth: 0.44f);
    }

    private void RunAttackInvoke_65()
    {
        pic = 304;
        wait = 1f;
        next = RunAttackInvoke_66;
        BdyDefault(zwidth: 0.44f);
    }

    private void RunAttackInvoke_66()
    {
        pic = 305;
        wait = 0.5f;
        next = RunAttackInvoke_67;
        BdyDefault(zwidth: 0.44f);
    }

    private void RunAttackInvoke_67()
    {
        pic = 306;
        wait = 0.5f;
        next = RunAttackInvoke_68;
        BdyDefault(zwidth: 0.44f);
    }

    private void RunAttackInvoke_68()
    {
        pic = 307;
        wait = 0.5f;
        next = Remove_300;
        BdyDefault(zwidth: 0.44f);
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