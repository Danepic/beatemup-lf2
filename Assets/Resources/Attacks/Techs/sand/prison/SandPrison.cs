using Enums;
using UnityEngine;

public class SandPrison : AttackController
{
    private Transform enemyTarget;
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/prison/sprites");
        base.Awake();
        headerName = "Sand Prison";
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
        enemyTarget = FindNearestEnemy()?.transform;
    }
    
    public void Update()
    {
        base.Update();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, whatIsGround))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

    #region Sand Prison Ultimate
    private void SandPrisonUltimate_0()
    {
        transform.position = enemyTarget.position;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 100;
        wait = 1f;
        next = SandPrisonUltimate_1;
        ItrDisable();
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_1()
    {
        pic = 101;
        wait = 1f;
        next = SandPrisonUltimate_2;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_2()
    {
        pic = 102;
        wait = 1f;
        next = SandPrisonUltimate_3;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_3()
    {
        pic = 103;
        wait = 1f;
        next = SandPrisonUltimate_4;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_4()
    {
        pic = 104;
        wait = 1f;
        next = SandPrisonUltimate_5;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_5()
    {
        pic = 105;
        wait = 1f;
        next = SandPrisonUltimate_6;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_6()
    {
        pic = 106;
        wait = 1f;
        next = SandPrisonUltimate_7;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_7()
    {
        pic = 107;
        wait = 1f;
        next = SandPrisonUltimate_8;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_8()
    {
        pic = 108;
        wait = 1f;
        next = SandPrisonUltimate_9;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_9()
    {
        pic = 109;
        wait = 3f;
        next = SandPrisonUltimate_10;
        BdyDefault(zwidth: 0.22f);
        ItrDisable();
        hittableObjects.Clear();
    }

    private void SandPrisonUltimate_10()
    {
        pic = 110;
        wait = 1f;
        next = SandPrisonUltimate_11;
        BdyDefault(zwidth: 0.22f);
        
        itr.dvx = 0; itr.dvy = 0; itr.dvz = 0; itr.action = 950;
        itr.applyInSingleEnemy = false; itr.defensable = false; itr.level = 1; itr.injury = 0;
        itr.effect = ItrEffectEnum.NO_EFFECT; itr.rest = 20; itr.physic = ItrPhysicEnum.DEFAULT;

        itr.x = -0.014f;
        itr.y = 0.5291f;
        itr.z = 0f;
        itr.w = 1.93749f;
        itr.h = 1.056104f;
        itr.zwidth = 0.22f;
        Itr();
    }

    private void SandPrisonUltimate_11()
    {
        ItrDisable();
        pic = 111;
        wait = 1f;
        next = SandPrisonUltimate_12;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_12()
    {
        pic = 112;
        wait = 1f;
        next = SandPrisonUltimate_13;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_13()
    {
        pic = 113;
        wait = 1f;
        next = SandPrisonUltimate_14;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_14()
    {
        pic = 114;
        wait = 1f;
        next = SandPrisonUltimate_15;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_15()
    {
        pic = 115;
        wait = 1f;
        next = SandPrisonUltimate_16;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_16()
    {
        pic = 200;
        wait = 1f;
        next = SandPrisonUltimate_17;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_17()
    {
        pic = 201;
        wait = 1f;
        next = SandPrisonUltimate_18;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_18()
    {
        pic = 202;
        wait = 1f;
        next = SandPrisonUltimate_19;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_19()
    {
        pic = 203;
        wait = 1f;
        next = SandPrisonUltimate_20;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_20()
    {
        pic = 204;
        wait = 1f;
        next = SandPrisonUltimate_21;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_21()
    {
        pic = 205;
        wait = 1f;
        next = SandPrisonUltimate_22;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_22()
    {
        pic = 206;
        wait = 10f;
        next = SandPrisonUltimate_23;
        BdyDefault(zwidth: 0.22f);
    }
    
    private void SandPrisonUltimate_23()
    {
        foreach (var hittableCharacter in GetHittableCharacters())
        {
            hittableCharacter.ApplyInjured(400);
            hittableCharacter.ChangeFrame(800);
        }
        hittableObjects.Clear();
        pic = 200;
        wait = 1f;
        next = SandPrisonUltimate_24;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_24()
    {
        pic = 201;
        wait = 1f;
        next = SandPrisonUltimate_25;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_25()
    {
        pic = 202;
        wait = 1f;
        next = SandPrisonUltimate_26;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_26()
    {
        pic = 203;
        wait = 1f;
        next = SandPrisonUltimate_27;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_27()
    {
        pic = 204;
        wait = 1f;
        next = SandPrisonUltimate_28;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_28()
    {
        pic = 205;
        wait = 1f;
        next = SandPrisonUltimate_29;
        BdyDefault(zwidth: 0.22f);
    }

    private void SandPrisonUltimate_29()
    {
        pic = 206;
        wait = 1f;
        next = Remove_300;
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