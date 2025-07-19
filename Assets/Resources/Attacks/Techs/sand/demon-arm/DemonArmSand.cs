using Enums;
using UnityEngine;

public class DemonArmSand : AttackController
{
    public static string SAND_ELEMENT_OPOINT = "sandElement";
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
        
        opoints.Add(SAND_ELEMENT_OPOINT, EnrichOpoint(100, "Attacks/Elements/sand/sandElement"));
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    void Update()
    {
        base.Update();
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
        
        SpawnOpoint(SAND_ELEMENT_OPOINT, Opoint(x: 0.5f, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1, useParentOwner: true));
        
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
        
        SpawnOpoint(SAND_ELEMENT_OPOINT, Opoint(x: 1f, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1, useParentOwner: true));

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
        
        SpawnOpoint(SAND_ELEMENT_OPOINT, Opoint(x: 1.5f, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1, useParentOwner: true));

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

    #region Float Attack

    private void FloatAttackFrontInvoke_20()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        wait = 0.5f;
        next = FloatAttackFrontInvoke_21;
        ItrDisable();

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void FloatAttackFrontInvoke_21()
    {
        pic = 106;
        wait = 0.5f;
        next = FloatAttackFrontInvoke_22;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void FloatAttackFrontInvoke_22()
    {
        pic = 105;
        wait = 1f;
        next = FloatAttackFrontInvoke_23;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void FloatAttackFrontInvoke_23()
    {
        pic = 104;
        wait = 0.5f;
        next = FloatAttackFrontInvoke_24;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void FloatAttackFrontInvoke_24()
    {
        pic = 103;
        wait = 0.5f;
        next = FloatAttackFrontInvoke_25;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void FloatAttackFrontInvoke_25()
    {
        pic = 102;
        wait = 1f;
        next = FloatAttackFrontInvoke_26;

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
        
        SpawnOpoint(SAND_ELEMENT_OPOINT, Opoint(x: 0.195f, y: -0.039f, z: 0f, oid: 0, facingFront: true, quantity: 1, useParentOwner: true));
        
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

    private void FloatAttackFrontInvoke_26()
    {
        ItrDisable();
        pic = 101;
        wait = 5f;
        next = FloatAttackFrontInvoke_27;
        
        SpawnOpoint(SAND_ELEMENT_OPOINT, Opoint(x: 0.858f, y: -1f, z: 0f, oid: 0, facingFront: true, quantity: 1, useParentOwner: true));

        bdy.x = 0.9932f;
        bdy.y = 0.0455f;
        bdy.z = 0f;
        bdy.w = 1.898169f;
        bdy.h = 0.4315155f;
        bdy.zwidth = 0.44f;
        Bdy();
    }

    private void FloatAttackFrontInvoke_27()
    {
        pic = 100;
        wait = 0.5f;
        next = AttackFrontInvoke_8;
        
        SpawnOpoint(SAND_ELEMENT_OPOINT, Opoint(x: 1.36f, y: -1.5f, z: 0f, oid: 0, facingFront: true, quantity: 1, useParentOwner: true));

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