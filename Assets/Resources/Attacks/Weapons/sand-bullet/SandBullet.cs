using Enums;
using UnityEngine;

public class SandBullet : AttackController
{
    private ObjController invokedEffect;
    
    void Awake()
    {
        palettes.Add("Attacks/Weapons/sand-bullet/sprites");
        base.Awake();
        opoints.Add(50, EnrichOpoint(2, "Effects/sand/bullet-effect/sand-bullet-effect"));
        headerName = "Sand Bullet";
        totalHp = 175;
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        ChangeFrame(InvokeFront_0);
        base.Start();
    }

    public void Update() {
        base.Update();
    }

    #region Front
    private void InvokeFront_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 0.5f;
        next = InvokeImpulse_1;
        BdyDefault(zwidth: 0.22f);
        ItrDisable();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        repeatCount = 100;
        SpawnOpoint(50, Opoint(x: 0f, y: 0f, z: -0.03f, oid: 0, facingFront: true, quantity: 1, attachToOwner: true, cancellable: true));
    }
    private void InvokeImpulse_1()
    {
        pic = 100; dvx = 425; dvy = 125; dvz = 0;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeImpulse_2;
        BdyDefault(zwidth: 0.22f);
        OnGround(Remove_300);
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
    private void InvokeImpulse_2()
    {
        pic = 101;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 10f;
        next = InvokeImpulse_3;
        BdyDefault(zwidth: 0.22f);
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Remove_300); OnWall(Remove_300);
    }
    private void InvokeImpulse_3()
    {
        RepeatCountToFrame(Remove_300);
        pic = 102;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeImpulse_4;
        BdyDefault(zwidth: 0.22f);

        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Remove_300); OnWall(Remove_300);
    }
    private void InvokeImpulse_4()
    {
        RepeatCountToFrame(Remove_300);
        pic = 103;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeImpulse_5;
        BdyDefault(zwidth: 0.22f);
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Remove_300); OnWall(Remove_300);
    }
    private void InvokeImpulse_5()
    {
        RepeatCountToFrame(Remove_300);
        pic = 104;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeImpulse_6;
        BdyDefault(zwidth: 0.22f);
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Remove_300); OnWall(Remove_300);
    }
    private void InvokeImpulse_6()
    {
        RepeatCountToFrame(Remove_300);
        pic = 105;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeImpulse_7;
        BdyDefault(zwidth: 0.22f);
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Remove_300); OnWall(Remove_300);
    }
    private void InvokeImpulse_7()
    {
        RepeatCountToFrame(Remove_300);
        pic = 106;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeImpulse_8;
        BdyDefault(zwidth: 0.22f);
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Remove_300); OnWall(Remove_300);
    }
    private void InvokeImpulse_8()
    {
        RepeatCountToFrame(Remove_300);
        pic = 107;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeImpulse_3;
        BdyDefault(zwidth: 0.22f);
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        Itr();
        OnGround(Remove_300); OnWall(Remove_300);
    }
    #endregion
    
    
    #region Down
    private void InvokeDown_20()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 0.5f;
        next = InvokeDown_21;
        BdyDefault();
        ItrDisable();
        repeatCount = 100;
        var childOpoints = SpawnOpoint(50, Opoint(x: 0f, y: 0f, z: -0.03f, oid: 0, facingFront: true, quantity: 1, attachToOwner: true, cancellable: true));
        foreach (var opoint in childOpoints)
        {
            opoint.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void InvokeDown_21()
    {
        pic = 100; dvx = 300; dvy = -25; dvz = 0;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 1f;
        next = InvokeDown_22;
        BdyDefault(zwidth: 0.22f);
        OnGround(Ground_160); OnWall(Wall_150);
        ApplyDefaultPhysic(dvx, dvy, dvz, facingRight);
    }
    private void InvokeDown_22()
    {
        pic = 101;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 10f;
        next = InvokeDown_23;
        BdyDefault(zwidth: 0.22f);
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Ground_160); OnWall(Wall_150);
    }
    private void InvokeDown_23()
    {
        RepeatCountToFrame(Remove_300);
        pic = 102;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeDown_24;
        BdyDefault(zwidth: 0.22f);

        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Ground_160); OnWall(Wall_150);
    }
    private void InvokeDown_24()
    {
        RepeatCountToFrame(Remove_300);
        pic = 103;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeDown_25;
        BdyDefault(zwidth: 0.22f);
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Ground_160); OnWall(Wall_150);
    }
    private void InvokeDown_25()
    {
        RepeatCountToFrame(Remove_300);
        pic = 104;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeDown_26;
        BdyDefault(zwidth: 0.22f);
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Ground_160); OnWall(Wall_150);
    }
    private void InvokeDown_26()
    {
        RepeatCountToFrame(Remove_300);
        pic = 105;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeDown_27;
        BdyDefault(zwidth: 0.22f);
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Ground_160); OnWall(Wall_150);
    }
    private void InvokeDown_27()
    {
        RepeatCountToFrame(Remove_300);
        pic = 106;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeDown_28;
        BdyDefault(zwidth: 0.22f);
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        Itr();
        OnGround(Ground_160); OnWall(Wall_150);
    }
    private void InvokeDown_28()
    {
        RepeatCountToFrame(Remove_300);
        pic = 107;
        state = StateFrameEnum.ATTACK_IDLE;
        wait = 5f;
        next = InvokeDown_23;
        BdyDefault(zwidth: 0.22f);
        itr.dvx = 150; itr.dvy = 100; itr.dvz = 0; itr.action = 700;
        itr.applyInSingleEnemy = false; itr.defensable = true; itr.level = 1;
        itr.injury = 20; itr.effect = ItrEffectEnum.BLOOD; itr.rest = 7;
        
        itr.x = 0f;
        itr.y = 0.2f;
        itr.z = 0f;
        itr.w = 2.75f;
        itr.h = 2.91f;
        itr.zwidth = 0.44f;
        Itr();
        OnGround(Ground_160); OnWall(Wall_150);
    }
    #endregion
    

    private void Wall_150()
    {
        CancelOpoints();
        pic = 109;
        wait = 1f;
        next = Wall_151;
        ItrDisable();
    }

    private void Wall_151()
    {
        pic = 110;
        wait = 1f;
        next = Wall_152;
        ItrDisable();
    }

    private void Wall_152()
    {
        pic = 111;
        wait = 1f;
        ItrDisable();
        next = Remove_300;
    }
    

    private void Ground_160()
    {
        CancelOpoints();
        pic = 200;
        wait = 1f;
        next = Ground_161;
        ItrDisable();
    }

    private void Ground_161()
    {
        pic = 201;
        wait = 1f;
        next = Ground_162;
        ItrDisable();
    }

    private void Ground_162()
    {
        pic = 202;
        wait = 1f;
        ItrDisable();
        next = Remove_300;
    }

    private void Remove_300()
    {
        pic = -9999;
        ItrDisable();
        Delete();
    }
}
