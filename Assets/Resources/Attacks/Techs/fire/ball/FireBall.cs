using Enums;
using UnityEngine;

public class FireBall : AttackController
{
    public static string FIRE_EXPLOSION_OPOINT = "fire_explosion";
    public static string FIRE_GROUND_OPOINT = "fire_ground";

    void Awake()
    {
        palettes.Add("Attacks/Techs/fire/ball/sprites");
        base.Awake();
        headerName = "Fire Prepare";
        totalHp = -1;
        frames = PopulateFrames(this);
        opoints.Add(FIRE_EXPLOSION_OPOINT, EnrichOpoint(2, "Attacks/Techs/fire/explosion/fire-explosion"));
        opoints.Add(FIRE_GROUND_OPOINT, EnrichOpoint(20, "Attacks/Techs/fire/ground/fire-ground"));
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    public void Update()
    {
        base.Update();
    }

    #region Idle

    private void Invoke_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        pic = 100;
        wait = 1f;
        next = Invoke_1;
        BdyDefault();
        ItrDisable();
        repeatCount = 250;
    }

    private void Invoke_1()
    {
        RepeatCountToFrame(Remove_300);
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = 101;
        wait = 1;
        next = Invoke_2;
        bdy.x = -0.1127f;
        bdy.y = 0.5392f;
        bdy.z = 0;
        bdy.w = 1.288947f;
        bdy.h = 1.312492f;
        bdy.zwidth = 0.75f;
        Bdy();
        ApplyDefaultPhysic(dvx = 20, dvy = 0, dvz = 0, facingRight);
        itr.x = -0.1127f;
        itr.y = 0.5392f;
        itr.z = 0;
        itr.w = 1.288947f;
        itr.h = 1.312492f;
        itr.zwidth = 0.75f;
        itr.dvx = 50;
        itr.dvy = 150;
        itr.dvz = 0;
        itr.action = 800;
        itr.applyInSingleEnemy = false;
        itr.defensable = false;
        itr.level = 3;
        itr.injury = 100;
        itr.effect = ItrEffectEnum.NORMAL;
        itr.rest = 12;
        itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
        OnWall(ExplosionInvoke_20);
        SpawnOpoint(FIRE_GROUND_OPOINT,
            Opoint(x: 0, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: false,
                attachToOwner: false));
    }

    private void Invoke_2()
    {
        RepeatCountToFrame(Remove_300);
        pic = 102;
        wait = 1f;
        next = Invoke_3;
        bdy.x = -0.1127f;
        bdy.y = 0.5392f;
        bdy.z = 0;
        bdy.w = 1.288947f;
        bdy.h = 1.312492f;
        bdy.zwidth = 0.75f;
        Bdy();
        ApplyDefaultPhysic(dvx = 20, dvy = 0, dvz = 0, facingRight);
        itr.x = -0.1127f;
        itr.y = 0.5392f;
        itr.z = 0;
        itr.w = 1.288947f;
        itr.h = 1.312492f;
        itr.zwidth = 0.75f;
        itr.dvx = 50;
        itr.dvy = 150;
        itr.dvz = 0;
        itr.action = 800;
        itr.applyInSingleEnemy = false;
        itr.defensable = false;
        itr.level = 3;
        itr.injury = 100;
        itr.effect = ItrEffectEnum.NORMAL;
        itr.rest = 12;
        itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
        OnWall(ExplosionInvoke_20);
    }

    private void Invoke_3()
    {
        RepeatCountToFrame(Remove_300);
        pic = 103;
        wait = 1f;
        next = Invoke_4;
        bdy.x = -0.1127f;
        bdy.y = 0.5392f;
        bdy.z = 0;
        bdy.w = 1.288947f;
        bdy.h = 1.312492f;
        bdy.zwidth = 0.75f;
        Bdy();
        ApplyDefaultPhysic(dvx = 20, dvy = 0, dvz = 0, facingRight);
        itr.x = -0.1127f;
        itr.y = 0.5392f;
        itr.z = 0;
        itr.w = 1.288947f;
        itr.h = 1.312492f;
        itr.zwidth = 0.75f;
        itr.dvx = 50;
        itr.dvy = 150;
        itr.dvz = 0;
        itr.action = 800;
        itr.applyInSingleEnemy = false;
        itr.defensable = false;
        itr.level = 3;
        itr.injury = 100;
        itr.effect = ItrEffectEnum.NORMAL;
        itr.rest = 12;
        itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
        OnWall(ExplosionInvoke_20);
        SpawnOpoint(FIRE_GROUND_OPOINT,
            Opoint(x: 0, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: false,
                attachToOwner: false));
    }

    private void Invoke_4()
    {
        RepeatCountToFrame(Remove_300);
        pic = 104;
        wait = 1f;
        next = Invoke_5;
        bdy.x = -0.1127f;
        bdy.y = 0.5392f;
        bdy.z = 0;
        bdy.w = 1.288947f;
        bdy.h = 1.312492f;
        bdy.zwidth = 0.75f;
        Bdy();
        ApplyDefaultPhysic(dvx = 20, dvy = 0, dvz = 0, facingRight);
        itr.x = -0.1127f;
        itr.y = 0.5392f;
        itr.z = 0;
        itr.w = 1.288947f;
        itr.h = 1.312492f;
        itr.zwidth = 0.75f;
        itr.dvx = 50;
        itr.dvy = 150;
        itr.dvz = 0;
        itr.action = 800;
        itr.applyInSingleEnemy = false;
        itr.defensable = false;
        itr.level = 3;
        itr.injury = 100;
        itr.effect = ItrEffectEnum.NORMAL;
        itr.rest = 12;
        itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
        OnWall(ExplosionInvoke_20);
    }

    private void Invoke_5()
    {
        RepeatCountToFrame(Remove_300);
        pic = 100;
        wait = 1f;
        next = Invoke_1;
        bdy.x = -0.1127f;
        bdy.y = 0.5392f;
        bdy.z = 0;
        bdy.w = 1.288947f;
        bdy.h = 1.312492f;
        bdy.zwidth = 0.75f;
        Bdy();
        ApplyDefaultPhysic(dvx = 20, dvy = 0, dvz = 0, facingRight);
        itr.x = -0.1127f;
        itr.y = 0.5392f;
        itr.z = 0;
        itr.w = 1.288947f;
        itr.h = 1.312492f;
        itr.zwidth = 0.75f;
        itr.dvx = 50;
        itr.dvy = 150;
        itr.dvz = 0;
        itr.action = 800;
        itr.applyInSingleEnemy = false;
        itr.defensable = false;
        itr.level = 3;
        itr.injury = 100;
        itr.effect = ItrEffectEnum.NORMAL;
        itr.rest = 12;
        itr.physic = ItrPhysicEnum.DEFAULT;
        Itr();
        OnWall(ExplosionInvoke_20);
        SpawnOpoint(FIRE_GROUND_OPOINT,
            Opoint(x: 0, y: 0f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: false,
                attachToOwner: false));
    }

    #endregion

    #region Explosion

    private void ExplosionInvoke_20()
    {
        pic = -9999;
        wait = 1f;
        next = ExplosionInvoke_21; //Frame criado para dar um frame de diff entre o spawn ground no repeat do spawn do explosion no onwall
    }

    private void ExplosionInvoke_21()
    {
        pic = -9999;
        wait = 5f;
        next = Remove_300;
        SpawnOpoint(FIRE_EXPLOSION_OPOINT,
            Opoint(x: 0, y: 0.35f, z: 0f, oid: 0, facingFront: true, quantity: 1, cancellable: false,
                attachToOwner: false));
    }

    #endregion

    #region Remove

    private void Remove_300()
    {
        ItrDisable();
        Delete();
    }

    #endregion
}