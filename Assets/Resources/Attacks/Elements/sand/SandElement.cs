using Enums;
using UnityEngine;

public class SandElement : AttackController
{
    private PhysicsObjController _ownerPhysicsObjController;

    void Awake()
    {
        palettes.Add("Attacks/Elements/sand/sprites");
        base.Awake();
        headerName = "Sand Element";
        totalHp = -1;
        frames = PopulateFrames(this);
        attackLevel1Frame = null;
        attackLevel2Frame = null;
        attackLevel3Frame = null;
        
        opoints.Add(50, EnrichOpoint(1, "Attacks/Techs/sand/attack-6/attackSand-6"));
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    #region Idle

    private void SandElement_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 100;
        wait = 1;
        next = SandElement_1;
        BdyDefault();
        OnGround(SandElement_2); repeatCount = 750;
    }

    private void SandElement_1()
    {
        RepeatCountToFrame(Remove_300);
        pic = 101;
        wait = 1;
        next = SandElement_1;
        BdyDefault();
        OnGround(SandElement_2);
    }

    private void SandElement_2()
    {
        pic = 102;
        wait = 1;
        BdyDefault(); InAir(SandElement_0);
        if (owner.currentFrameId is 1253 or 1703)
        {
            SpawnOpoint(50, Opoint(x: 0f, y: 0f, z: 0f, oid: 20, facingFront: true, quantity: 1));
            ChangeFrame(300);
        }
        else
        {
            next = SandElement_3;
        }
    }

    private void SandElement_3()
    {
        pic = 103;
        wait = 1;
        BdyDefault(); InAir(SandElement_0);
        if (owner.currentFrameId is 1253 or 1703)
        {
            SpawnOpoint(50, Opoint(x: 0f, y: 0f, z: 0f, oid: 20, facingFront: true, quantity: 1));
            ChangeFrame(300);
        }
        else
        {
            next = SandElement_4;
        }
    }

    private void SandElement_4()
    {
        pic = 104;
        wait = 1;
        if (owner.currentFrameId is 1253 or 1703)
        {
            SpawnOpoint(50, Opoint(x: 0f, y: 0f, z: 0f, oid: 20, facingFront: true, quantity: 1));
            ChangeFrame(300);
        }
        else
        {
            next = SandElement_5;
        }
        BdyDefault();
        repeatCount = 750; InAir(SandElement_0);
    }

    private void SandElement_5()
    {
        pic = 105;
        wait = 1;
        if (owner.currentFrameId is 1253 or 1703)
        {
            SpawnOpoint(50, Opoint(x: 0f, y: 0f, z: 0f, oid: 20, facingFront: true, quantity: 1));
            ChangeFrame(300);
        }
        else
        {
            next = SandElement_5;
        }
        BdyDefault();
        RepeatCountToFrame(Remove_300); InAir(SandElement_0);
    }

    #endregion


    #region Remove

    private void Remove_300()
    {
        pic = 108;
        wait = 2;
        next = Remove_301;
        ItrDisable();
        bdy.kind = BdyKindEnum.INVULNERABLE;
    }
    private void Remove_301()
    {
        pic = 109;
        wait = 2;
        next = Remove_302;
    }
    private void Remove_302()
    {
        pic = -9999;
        ItrDisable();
        Delete();
    }

    #endregion
}