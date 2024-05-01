using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Attack"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Object"), LayerMask.NameToLayer("Attack"));
    }
}
