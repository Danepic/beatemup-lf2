using Enums;
using UnityEngine;

public class ShieldSand2 : AttackController
{
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/shield-2/sprites");
        base.Awake();
        headerName = "ShieldSand2";
        totalHp = 500;
        frames = PopulateFrames(this);
        opoints.Add(4, EnrichOpoint(10, "Etc/defense_hit/defense_hit"));
        opoints.Add(5, EnrichOpoint(10, "Etc/defense_hit/defense_hit"));
        opoints.Add(6, EnrichOpoint(10, "Etc/defense_hit/defense_hit"));
        attackLevel1Frame = null;
        attackLevel2Frame = null;
        attackLevel3Frame = null;
    }

    public void Start()
    {
        Physics.IgnoreCollision(selfBoxCollider, owner.GetComponent<BoxCollider>(), ignore: true);
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    #region Idle
    private void IdleInvoke_0()
    {
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 106;
        wait = 0.5f;
        next = IdleInvoke_1;
        ItrDisable();
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_1()
    {
        pic = 100; wait = 1; next = IdleInvoke_2;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_2()
    {
        pic = 101; wait = 1f; next = IdleInvoke_3;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_3()
    {
        pic = 103; wait = 1f; next = IdleInvoke_4;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_4()
    {
        pic = 104; wait = 1f; next = IdleInvoke_5;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_5()
    {
        repeatCount = 10;
        pic = 105; wait = 1f; next = MainDefense_6;
        BdyDefault(zwidth: 0.33f);
    }
    private void MainDefense_6()
    {
        RepeatCountToFrame(IdleInvoke_7);
        pic = 105; wait = 1f; next = MainDefense_6;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_7()
    {
        pic = 104; wait = 1f; next = IdleInvoke_8;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_8()
    {
        pic = 103; wait = 1f; next = IdleInvoke_9;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_9()
    {
        pic = 101; wait = 1f; next = IdleInvoke_10;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_10()
    {
        pic = 100; wait = 1f; next = IdleInvoke_11;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_11()
    {
        pic = 106; wait = 1f; next = Remove_300;
        BdyDefault(zwidth: 0.33f);
    }
    #endregion


    #region IdleAir
    private void IdleAirInvoke_20()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 106;
        wait = 0.5f;
        next = IdleAirInvoke_21;
        ItrDisable();
        BdyDefault(zwidth: 0.33f); OnGround(IdleAirInvoke_27);
    }
    private void IdleAirInvoke_21()
    {
        pic = 100; wait = 1; next = IdleAirInvoke_22;
        BdyDefault(zwidth: 0.33f); OnGround(IdleAirInvoke_27);
    }
    private void IdleAirInvoke_22()
    {
        pic = 101; wait = 1f; next = IdleAirInvoke_23;
        BdyDefault(zwidth: 0.33f); OnGround(IdleAirInvoke_27);
    }
    private void IdleAirInvoke_23()
    {
        pic = 103; wait = 1f; next = IdleAirInvoke_24;
        BdyDefault(zwidth: 0.33f); OnGround(IdleAirInvoke_27);
    }
    private void IdleAirInvoke_24()
    {
        pic = 104; wait = 1f; next = IdleAirInvoke_25;
        BdyDefault(zwidth: 0.33f); OnGround(IdleAirInvoke_27);
    }
    private void IdleAirInvoke_25()
    {
        repeatCount = 10;
        pic = 105; wait = 1f; next = MainDefense_26;
        BdyDefault(zwidth: 0.33f); OnGround(IdleAirInvoke_27);
    }
    private void MainDefense_26()
    {
        RepeatCountToFrame(IdleAirInvoke_27);
        pic = 105; wait = 1f; next = MainDefense_26;
        BdyDefault(zwidth: 0.33f); OnGround(IdleAirInvoke_27);
    }
    private void IdleAirInvoke_27()
    {
        pic = 104; wait = 0.5f; next = IdleAirInvoke_28;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleAirInvoke_28()
    {
        pic = 103; wait = 0.5f; next = IdleAirInvoke_29;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleAirInvoke_29()
    {
        pic = 101; wait = 0.5f; next = IdleAirInvoke_30;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleAirInvoke_30()
    {
        pic = 100; wait = 0.5f; next = IdleAirInvoke_31;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleAirInvoke_31()
    {
        pic = 106; wait = 0.5f; next = Remove_300;
        BdyDefault(zwidth: 0.33f);
    }
    #endregion


    #region Attack Up
    private void AttackUpInvoke_40()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 106;
        wait = 0.5f;
        next = AttackUpInvoke_41;
        ItrDisable();
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_41()
    {
        pic = 100; wait = 0.5f; next = AttackUpInvoke_42;
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_42()
    {
        pic = 101; wait = 0.5f; next = AttackUpInvoke_43;
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_43()
    {
        pic = 103; wait = 0.5f; next = AttackUpInvoke_44;
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_44()
    {
        pic = 104; wait = 1f; next = AttackUpInvoke_45;
        BdyDefault(zwidth: 0.33f);
                
        itr.dvx = -5f; itr.dvy = 350; itr.dvz = 0; itr.action = 840;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1; itr.injury = 20;
        itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15; itr.physic = ItrPhysicEnum.DEFAULT;

        itr.x = -0.0049f;
        itr.y = 0.392f;
        itr.z = 0f;
        itr.w = -0.4255021f;
        itr.h = 0.8759739f;
        itr.zwidth = 0.55f;
        Itr();
    }
    private void AttackUpInvoke_45()
    {
        pic = 105; wait = 1f; next = AttackUpInvoke_46;
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_46()
    {
        pic = 105; wait = 1f; next = AttackUpInvoke_47;
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_47()
    {
        pic = 104; wait = 1f; next = AttackUpInvoke_48;
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_48()
    {
        pic = 103; wait = 1f; next = AttackUpInvoke_49;
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_49()
    {
        pic = 101; wait = 1f; next = AttackUpInvoke_50;
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_50()
    {
        pic = 100; wait = 1f; next = AttackUpInvoke_51;
        BdyDefault(zwidth: 0.33f);
    }
    private void AttackUpInvoke_51()
    {
        pic = 106; wait = 1f; next = Remove_300;
        BdyDefault(zwidth: 0.33f);
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
