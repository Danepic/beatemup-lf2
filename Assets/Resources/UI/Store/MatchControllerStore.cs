using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Model;
using Unity.VisualScripting;
using UnityEngine;

public class MatchControllerStore : MonoBehaviour
{
    public static MatchControllerStore Instance;
    public string player1CharacterResourcePath;
    public string player2CharacterResourcePath;
    public string stageResourcePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
