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

    public GameObject defenseHit;

    private Queue<ObjProcess> defenseHitQueue;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 45;

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Attack"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Object"), LayerMask.NameToLayer("Attack"));

        hitBloodQueue = this.PopulatePoolOfHitEffects(hitBlood, 50);
        defenseHitQueue = this.PopulatePoolOfHitEffects(defenseHit, 25);
    }

    private Queue<ObjProcess> PopulatePoolOfHitEffects(GameObject hit, int quantity)
    {
        var queue = new Queue<ObjProcess>();
        for (int i = 0; i < quantity; i++)
        {
            GameObject hitClone = GameObject.Instantiate<GameObject>(hit);
            ObjProcess hitCloneObjProcess = hitClone.GetComponent<ObjProcess>();
            queue.Enqueue(hitCloneObjProcess);
        }
        return queue;
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
            case ItrEffectEnum.DEFENSE:
                SpawnHit(defenseHitQueue, opointPosition);
                break;
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
