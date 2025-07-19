using Enums;
using UnityEngine;

public class SandFloat : AttackController
{
    public static string SAND_ELEMENT_OPOINT = "sandElement";
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/float/sprites");
        base.Awake();
        headerName = "SandFloat";
        totalHp = 500;
        frames = PopulateFrames(this);
        attackLevel1Frame = null;
        attackLevel2Frame = null;
        attackLevel3Frame = null;
        
        opoints.Add(SAND_ELEMENT_OPOINT, EnrichOpoint(50, "Attacks/Elements/sand/sandElement"));
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

    #region Idle

    private void FloatSand_0()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 107; wait = 0.5f;
        next = FloatSand_1;
        bdy.kind = BdyKindEnum.INVULNERABLE;
        ItrDisable();
    }

    private void FloatSand_1()
    {
        pic = 106; wait = 0.5f;
        next = FloatSand_2;
    }

    private void FloatSand_2()
    {
        pic = 105; wait = 0.5f;
        next = FloatSand_3;
    }

    private void FloatSand_3()
    {
        pic = 104; wait = 0.5f;
        next = FloatSand_4;
    }

    private void FloatSand_4()
    {
        pic = 103; wait = 0.5f;
        next = FloatSand_5;
    }

    private void FloatSand_5()
    {
        pic = 102; wait = 0.5f;
        next = FloatSand_6;
    }

    private void FloatSand_6()
    {
        pic = 101; wait = 0.5f;
        next = FloatSand_7;
    }

    private void FloatSand_7()
    {
        pic = 100; wait = 15f;
        next = FloatSand_7;
        SpawnOpoint(SAND_ELEMENT_OPOINT, Opoint(x: 0f, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1, useParentOwner: true));
    }

    private void FloatSand_8()
    {
        pic = 100; wait = 0.5f;
        next = FloatSand_9;
    }

    private void FloatSand_9()
    {
        pic = 101; wait = 0.5f;
        next = FloatSand_10;
    }

    private void FloatSand_10()
    {
        pic = 102; wait = 0.5f;
        next = FloatSand_11;
    }

    private void FloatSand_11()
    {
        pic = 103; wait = 0.5f;
        next = FloatSand_12;
    }

    private void FloatSand_12()
    {
        pic = 104; wait = 0.5f;
        next = FloatSand_13;
    }

    private void FloatSand_13()
    {
        pic = 105; wait = 0.5f;
        next = FloatSand_14;
    }

    private void FloatSand_14()
    {
        pic = 106; wait = 0.5f;
        next = FloatSand_15;
    }

    private void FloatSand_15()
    {
        pic = 107; wait = 0.5f;
        next = Remove_300;
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
