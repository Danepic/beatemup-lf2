using Enums;
using UnityEngine;

public class SandBulletEffect : EffectController
{
    void Awake()
    {
        palettes.Add("Effects/sand/bullet-effect/sprites");
        base.Awake();
        headerName = "Sand Bullet Effect";
        frames = PopulateFrames(this);
    }

    public void Start()
    {
        ChangeFrame(frames[startFrame]);
        base.Start();
    }

    #region Attack Front

    private void AttackFrontInvoke_0()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        pic = -9999;
        wait = 0.5f;
        next = AttackFrontInvoke_1;
    }

    private void AttackFrontInvoke_1()
    {
        pic = 200;
        wait = 0.5f;
        next = AttackFrontInvoke_2;
    }

    private void AttackFrontInvoke_2()
    {
        pic = 201;
        wait = 1f;
        next = AttackFrontInvoke_3;
    }

    private void AttackFrontInvoke_3()
    {
        pic = 202;
        wait = 0.5f;
        next = AttackFrontInvoke_4;
    }

    private void AttackFrontInvoke_4()
    {
        pic = 203;
        wait = 0.5f;
        next = AttackFrontInvoke_5;
    }

    private void AttackFrontInvoke_5()
    {
        pic = 204;
        wait = 1f;
        next = AttackFrontInvoke_6;
    }

    private void AttackFrontInvoke_6()
    {
        pic = 205;
        wait = 0.5f;
        next = AttackFrontInvoke_7;
    }

    private void AttackFrontInvoke_7()
    {
        pic = 206;
        wait = 0.5f;
        next = AttackFrontInvoke_8;
    }

    private void AttackFrontInvoke_8()
    {
        pic = 207;
        wait = 0.5f;
        next = AttackFrontInvoke_1;
    }
    #endregion


    #region Remove

    private void Remove_300()
    {
        pic = -9999;
        Delete();
    }

    #endregion
}