using Enums;
using UnityEngine;

public class ShieldSand1 : AttackController
{
    public static string DEFENSE_HIT1_OPOINT = "defense_hit";
    public static string DEFENSE_HIT2_OPOINT = "defense_hit2";
    public static string DEFENSE_HIT3_OPOINT = "defense_hit3";
    
    private CharController ownerChar;
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/shield-1/sprites");
        base.Awake();
        headerName = "ShieldSand1";
        totalHp = 500;
        frames = PopulateFrames(this);
        opoints.Add(DEFENSE_HIT1_OPOINT, EnrichOpoint(10, "Etc/defense_hit/defense_hit"));
        opoints.Add(DEFENSE_HIT2_OPOINT, EnrichOpoint(10, "Etc/defense_hit/defense_hit"));
        opoints.Add(DEFENSE_HIT3_OPOINT, EnrichOpoint(10, "Etc/defense_hit/defense_hit"));
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
        ownerChar = owner.GetComponent<CharController>();
        base.Start();
    }

    #region Idle
    private void IdleInvoke_0()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 100;
        wait = 0.5f;
        next = IdleInvoke_1;
        ItrDisable();
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_1()
    {
        pic = 101; wait = 1; next = IdleInvoke_2;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_2()
    {
        pic = 102; wait = 1f; next = IdleInvoke_3;
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
        pic = 105; wait = 1f; next = MainDefense_6;
        BdyDefault(zwidth: 0.33f);
    }
    private void MainDefense_6()
    {
        pic = 106; wait = 0.5f; next = IdleInvoke_7;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_7()
    {
        pic = 107; wait = 75f; next = IdleInvoke_8;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_8()
    {
        if (owner != null)
        {
            if (ownerChar.onGround)
            {
                owner.ChangeFrame(1122);
            }
            else
            {
                owner.ChangeFrame(1622);
            }
        }

        pic = 106; wait = 0.5f; next = IdleInvoke_9;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_9()
    {
        pic = 105; wait = 1f; next = IdleInvoke_10;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_10()
    {
        pic = 104; wait = 1f; next = IdleInvoke_11;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_11()
    {
        pic = 103; wait = 1f; next = IdleInvoke_12;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_12()
    {
        pic = 102; wait = 0.5f; next = IdleInvoke_13;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_13()
    {
        pic = 101; wait = 0.5f; next = IdleInvoke_14;
        BdyDefault(zwidth: 0.33f);
    }
    private void IdleInvoke_14()
    {
        pic = 100; wait = 0.5f; next = Remove_300;
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
