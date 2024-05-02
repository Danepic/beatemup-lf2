using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Unity.VisualScripting;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public GameObject hitBlood;

    private Queue<ObjProcess> hitBloodQueue;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Attack"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Object"), LayerMask.NameToLayer("Attack"));

        hitBloodQueue = new Queue<ObjProcess>();
        this.PopulatePoolOfHitEffects(hitBlood, hitBloodQueue);
    }

    private void PopulatePoolOfHitEffects(GameObject hit, Queue<ObjProcess> hitQueue)
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject hitClone = GameObject.Instantiate<GameObject>(hit);
            ObjProcess hitCloneObjProcess = hitClone.GetComponent<ObjProcess>();
            hitQueue.Enqueue(hitCloneObjProcess);
        }
    }

    public void SpawnOpoint(Vector3 opointPosition, ItrEffectEnum effect)
    {
        switch (effect)
        {
            case ItrEffectEnum.BLOOD:
                SpawnHit(hitBloodQueue, opointPosition);
                break;
            case ItrEffectEnum.NORMAL:
            case ItrEffectEnum.SLOW:
            case ItrEffectEnum.STUN:
            case ItrEffectEnum.IGNITE:
            case ItrEffectEnum.POISON:
            case ItrEffectEnum.ROOT:
            case ItrEffectEnum.CHARM:
            case ItrEffectEnum.FEAR:
            case ItrEffectEnum.TAUNT:
            case ItrEffectEnum.BLIND:
            case ItrEffectEnum.PARALYSIS:
            case ItrEffectEnum.FREEZE:
            case ItrEffectEnum.CONFUSE:
            case ItrEffectEnum.SILENCE:
            case ItrEffectEnum.NO_EFFECT:
            default:
                break;
        }
    }

    private void SpawnHit(Queue<ObjProcess> hitBloodQueue, Vector3 opointPosition)
    {
        Debug.Log(hitBloodQueue == null);
        ObjProcess gameObj = hitBloodQueue.Dequeue();
        gameObj.transform.position = opointPosition;
        gameObj.gameObject.SetActive(true);
        for (int i = 0; i < gameObj.transform.childCount; i++)
        {
            gameObj.transform.GetChild(i).gameObject.SetActive(true);
        }
        gameObj.Start();
    }
}
