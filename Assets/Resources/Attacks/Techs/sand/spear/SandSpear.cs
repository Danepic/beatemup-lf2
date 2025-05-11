using Enums;
using UnityEngine;

public class SandSpear : AttackController
{
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
        bdy.x = 0.2087f; bdy.y = -0.0009f; bdy.z = 0;
        bdy.w = 0.4834476f; bdy.h = 0.4221749f; bdy.zwidth = 0.55f;
        Bdy();
        repeatCount = 100;
    }

    private void SpearSandAttack_12()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        pic = 111; wait = 2f; next = SpearSandAttack_13;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.55f;
        Bdy();
        
        itr.x = -0.0111f;
        itr.y = 0.2417f;
        itr.z = 0f;
        itr.w = 0.4120263f;
        itr.h = 0.4834f;
        itr.zwidth = 0.55f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        ApplyDefaultPhysic(dvx = 400, dvy = 0, dvz = 0, facingRight);
    }

    private void SpearSandAttack_13()
    {
        RepeatCountToFrame(Remove_300);
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        pic = 111; wait = 5f; next = SpearSandAttack_14;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.55f;
        Bdy();
        
        itr.x = -0.0111f;
        itr.y = 0.2417f;
        itr.z = 0f;
        itr.w = 0.4120263f;
        itr.h = 0.4834f;
        itr.zwidth = 0.55f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
    }

    private void SpearSandAttack_14()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        pic = 111; wait = 5f; next = SpearSandAttack_13;
        bdy.kind = BdyKindEnum.NORMAL;
        bdy.x = -0.0111f; bdy.y = 0.2417f; bdy.z = 0;
        bdy.w = 0.4120263f; bdy.h = 0.4834f; bdy.zwidth = 0.55f;
        Bdy();
        
        itr.x = -0.0111f;
        itr.y = 0.2417f;
        itr.z = 0f;
        itr.w = 0.4120263f;
        itr.h = 0.4834f;
        itr.zwidth = 0.55f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 800;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 150; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
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
