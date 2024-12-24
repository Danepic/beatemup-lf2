using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Model;
using Unity.VisualScripting;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public Transform p1Spawn;
    public Transform p2Spawn;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 45;

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Attack"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Character"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Object"), LayerMask.NameToLayer("Attack"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Attack"), LayerMask.NameToLayer("Attack"));

        var resourcePathP1 = ExtractObjectName(MatchControllerStore.Instance.player1CharacterResourcePath);
        Instantiate(Resources.Load<GameObject>(resourcePathP1), p1Spawn.position, Quaternion.identity);

        var resourcePathP2 = ExtractObjectName(MatchControllerStore.Instance.player2CharacterResourcePath);
        Instantiate(Resources.Load<GameObject>(resourcePathP2), p2Spawn.position, Quaternion.identity);
    }

    private string ExtractObjectName(string path)
    {
        int lastSlashIndex = path.LastIndexOf('/');

        string extracted = path.Substring(lastSlashIndex + 1);

        return path + "/" + extracted;
    }
}
