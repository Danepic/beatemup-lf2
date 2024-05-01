using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleIA : MonoBehaviour
{
    public ObjProcess objProcess;
    void Update()
    {
        float option = Random.Range(1f, 9f);
        Debug.Log((int)option);
        switch ((int)option)
        {
            case 1:
                objProcess.HitUp(true, true, false);
                break;
            case 2:
                objProcess.HitUp(false, false, true);
                break;
            case 3:
                objProcess.HitDown(true, true, false);
                break;
            case 4:
                objProcess.HitDown(false, false, true);
                break;
            case 5:
                objProcess.HitLeft(true, true, false);
                break;
            case 6:
                objProcess.HitLeft(false, false, true);
                break;
            case 7:
                objProcess.HitRight(true, true, false);
                break;
            case 8:
                objProcess.HitRight(false, false, true);
                break;
        }
    }
}
