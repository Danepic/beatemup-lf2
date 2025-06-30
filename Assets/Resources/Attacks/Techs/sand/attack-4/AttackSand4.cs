using Enums;
using UnityEngine;

public class AttackSand4 : AttackController
{
    private int onwerAdditionalDamage = 0;
    private CharacterController ownerCharController;
    void Awake()
    {
        palettes.Add("Attacks/Techs/sand/attack-4/sprites");
        base.Awake();
        headerName = "Attack Sand 4";
        totalHp = 500;
        frames = PopulateFrames(this);
        attackLevel1Frame = null;
        attackLevel2Frame = null;
        attackLevel3Frame = null;
        if (owner != null)
        {
            onwerAdditionalDamage = owner.GetComponent<CharController>().additionalDamage;
        }
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    #region Idle

    private void IdleInvoke_0()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        wait = 1.5f;
        next = IdleInvoke_1;
        ItrDisable();
        BdyDefault(zwidth: 0.44f);
    }

    private void IdleInvoke_1()
    {
        pic = 100;
        wait = 1;
        next = IdleInvoke_2;
        BdyDefault(zwidth: 0.44f);
    }

    private void IdleInvoke_2()
    {
        pic = 101;
        wait = 1f;
        next = IdleInvoke_3;
        BdyDefault(zwidth: 0.44f);
        
        itr.dvx = 65;
        itr.dvy = -10f;
        itr.dvz = 0;
        itr.action = 700;
        itr.applyInSingleEnemy = false;
        itr.defensable = true;
        itr.level = 1;
        itr.injury = 50 + onwerAdditionalDamage;
        itr.effect = ItrEffectEnum.BLOOD;
        itr.rest = 4;
        itr.physic = ItrPhysicEnum.FIXED;

        itr.x = 1.1814f;
        itr.y = 0.3259f;
        itr.z = 0;
        itr.w = 2.282079f;
        itr.h = 1.216991f;
        itr.zwidth = 0.44f;
        Itr();
    }

    private void IdleInvoke_3()
    {
        pic = 102;
        wait = 1f;
        next = IdleInvoke_4;
        
        BdyDefault(zwidth: 0.44f);
    }

    private void IdleInvoke_4()
    {
        pic = 103;
        wait = 1f;
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