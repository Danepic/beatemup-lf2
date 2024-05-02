using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectProcess : ObjProcess
{
    // Update is called once per frame
    void Update()
    {
        this.Timers();
        this.SpawnOpoint();
    }
}
