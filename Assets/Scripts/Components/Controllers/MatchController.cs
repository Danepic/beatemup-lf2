using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Unity.VisualScripting;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 45;

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Attack"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Character"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Object"), LayerMask.NameToLayer("Attack"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Attack"), LayerMask.NameToLayer("Attack"));
    }
}
