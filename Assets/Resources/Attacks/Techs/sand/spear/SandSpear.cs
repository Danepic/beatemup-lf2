using Enums;
using UnityEngine;

public class SandSpear : AttackController
{
    public static string SAND_ELEMENT_OPOINT = "sandElement";
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/spear/sprites");
        base.Awake();
        headerName = "Sand Spear";
        totalHp = 500;
        frames = PopulateFrames(this);
        attackLevel1Frame = null;
        attackLevel2Frame = null;
        attackLevel3Frame = null;
        
        opoints.Add(SAND_ELEMENT_OPOINT, EnrichOpoint(100, "Attacks/Elements/sand/sandElement"));

    }

    public void Start()
    {
        if (owner != null)
        {
            Physics.IgnoreCollision(selfBoxCollider, owner.GetComponent<BoxCollider>(), ignore: true);
        }
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    #region SpearSandAttack

    private void SpearSandAttack_0()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 100; wait = 1f; next = SpearSandAttack_1;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
        ItrDisable();
    }

    private void SpearSandAttack_1()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        pic = 101; wait = 1f; next = SpearSandAttack_2;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
        ApplyDefaultPhysic(dvx = 0, dvy = 50, dvz = 0, facingRight);
    }

    private void SpearSandAttack_2()
    {
        pic = 102; wait = 1f; next = SpearSandAttack_3;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void SpearSandAttack_3()
    {
        pic = 103; wait = 1f; next = SpearSandAttack_4;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void SpearSandAttack_4()
    {
        pic = 104; wait = 1f; next = SpearSandAttack_5;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void SpearSandAttack_5()
    {
        pic = 105; wait = 1f; next = SpearSandAttack_6;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void SpearSandAttack_6()
    {
        pic = 106; wait = 1f; next = SpearSandAttack_7;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void SpearSandAttack_7()
    {
        pic = 107; wait = 1f; next = SpearSandAttack_8;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void SpearSandAttack_8()
    {
        pic = 108; wait = 1f; next = SpearSandAttack_9;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void SpearSandAttack_9()
    {
        pic = 109; wait = 1f; next = SpearSandAttack_10;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void SpearSandAttack_10()
    {
        pic = 110; wait = 1f; next = SpearSandAttack_11;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void SpearSandAttack_11()
    {
        pic = 111; wait = 1f; next = SpearSandAttack_12;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
        repeatCount = 100;
    }

    private void SpearSandAttack_12()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        pic = 111; wait = 2f; next = SpearSandAttack_13;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
        
        itr.x = 0.0033f;
        itr.y = -0.0192f;
        itr.z = 0f;
        itr.w = 0.9048313f;
        itr.h = 0.3922809f;
        itr.zwidth = 0.55f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        ApplyDefaultPhysic(dvx = 400, dvy = 0, dvz = 0, facingRight);
        
        OnWall(FloatSpearSandGround_40); OnGround(FloatSpearSandGround_40);
    }

    private void SpearSandAttack_13()
    {
        RepeatCountToFrame(Remove_300);
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        pic = 111; wait = 5f; next = SpearSandAttack_14;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
        
        itr.x = 0.0033f;
        itr.y = -0.0192f;
        itr.z = 0f;
        itr.w = 0.9048313f;
        itr.h = 0.3922809f;
        itr.zwidth = 0.55f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        
        OnWall(FloatSpearSandGround_40); OnGround(FloatSpearSandGround_40);
    }

    private void SpearSandAttack_14()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        pic = 111; wait = 5f; next = SpearSandAttack_13;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
        
        itr.x = 0.0033f;
        itr.y = -0.0192f;
        itr.z = 0f;
        itr.w = 0.9048313f;
        itr.h = 0.3922809f;
        itr.zwidth = 0.55f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        
        OnWall(FloatSpearSandGround_40); OnGround(FloatSpearSandGround_40);
    }


    #endregion
    
    #region FloatSpearSandAttack
    private void FloatSpearSandAttack_20()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 100; wait = 1f; next = FloatSpearSandAttack_21;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
        ItrDisable();
    }

    private void FloatSpearSandAttack_21()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        pic = 101; wait = 1f; next = FloatSpearSandAttack_22;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
        ApplyDefaultPhysic(dvx = 0, dvy = 50, dvz = 0, facingRight);
    }

    private void FloatSpearSandAttack_22()
    {
        pic = 102; wait = 1f; next = FloatSpearSandAttack_23;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void FloatSpearSandAttack_23()
    {
        pic = 103; wait = 1f; next = FloatSpearSandAttack_24;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void FloatSpearSandAttack_24()
    {
        pic = 104; wait = 1f; next = FloatSpearSandAttack_25;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void FloatSpearSandAttack_25()
    {
        pic = 105; wait = 1f; next = FloatSpearSandAttack_26;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void FloatSpearSandAttack_26()
    {
        pic = 106; wait = 1f; next = FloatSpearSandAttack_27;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void FloatSpearSandAttack_27()
    {
        pic = 107; wait = 1f; next = FloatSpearSandAttack_28;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void FloatSpearSandAttack_28()
    {
        pic = 108; wait = 1f; next = FloatSpearSandAttack_29;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void FloatSpearSandAttack_29()
    {
        pic = 109; wait = 1f; next = FloatSpearSandAttack_30;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void FloatSpearSandAttack_30()
    {
        pic = 110; wait = 1f; next = FloatSpearSandAttack_31;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        BdyDefault();
    }

    private void FloatSpearSandAttack_31()
    {
        pic = 111; wait = 1f; next = FloatSpearSandAttack_32;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
        repeatCount = 100;
    }

    private void FloatSpearSandAttack_32()
    {
        pic = 111; wait = 2f; next = FloatSpearSandAttack_33;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
        
        itr.x = 0.0033f;
        itr.y = -0.0192f;
        itr.z = 0f;
        itr.w = 0.9048313f;
        itr.h = 0.3922809f;
        itr.zwidth = 0.55f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15;
        Itr();
        ApplyDefaultPhysic(dvx = 400, dvy = -250, dvz = 0, facingRight);
        
        OnWall(FloatSpearSandGround_40); OnGround(FloatSpearSandGround_40);
    }

    private void FloatSpearSandAttack_33()
    {
        RepeatCountToFrame(Remove_300);
        pic = 111; wait = 5f; next = FloatSpearSandAttack_34;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
        
        itr.x = 0.0033f;
        itr.y = -0.0192f;
        itr.z = 0f;
        itr.w = 0.9048313f;
        itr.h = 0.3922809f;
        itr.zwidth = 0.55f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15;
        Itr();
        
        OnWall(FloatSpearSandGround_40); OnGround(FloatSpearSandGround_40);
    }

    private void FloatSpearSandAttack_34()
    {
        pic = 111; wait = 5f; next = FloatSpearSandAttack_33;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
        
        itr.x = 0.0033f;
        itr.y = -0.0192f;
        itr.z = 0f;
        itr.w = 0.9048313f;
        itr.h = 0.3922809f;
        itr.zwidth = 0.55f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 15;
        Itr();
        
        OnWall(FloatSpearSandGround_40); OnGround(FloatSpearSandGround_40);
    }
    
    
    private void FloatSpearSandGround_40()
    {
        ItrDisable();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 110; wait = 1f; next = FloatSpearSandGround_41;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
    }
    
    private void FloatSpearSandGround_41()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 109; wait = 1f; next = FloatSpearSandGround_42;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
    }
    
    private void FloatSpearSandGround_42()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 108; wait = 1f; next = FloatSpearSandGround_43;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
        
        SpawnOpoint(SAND_ELEMENT_OPOINT, Opoint(x: 0f, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1, useParentOwner: true));
    }
    
    private void FloatSpearSandGround_43()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 107; wait = 1f; next = FloatSpearSandGround_44;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
    }
    
    private void FloatSpearSandGround_44()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 106; wait = 1f; next = FloatSpearSandGround_45;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
    }
    
    private void FloatSpearSandGround_45()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 105; wait = 1f; next = FloatSpearSandGround_46;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
    }
    
    private void FloatSpearSandGround_46()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 104; wait = 1f; next = FloatSpearSandGround_47;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
    }
    
    private void FloatSpearSandGround_47()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 103; wait = 1f; next = FloatSpearSandGround_48;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
    }
    
    private void FloatSpearSandGround_48()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 102; wait = 1f; next = FloatSpearSandGround_49;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
    }
    
    private void FloatSpearSandGround_49()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 101; wait = 1f; next = FloatSpearSandGround_50;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
        Bdy();
    }
    
    private void FloatSpearSandGround_50()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pic = 100; wait = 1f; next = Remove_300;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0033f; bdy.y = -0.0192f; bdy.z = 0;
        bdy.w = 0.9048313f; bdy.h = 0.3922809f; bdy.zwidth = 0.55f;
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
