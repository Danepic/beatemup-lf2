using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Model;
using Resources.Backgrounds;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MatchController : MonoBehaviour
{
    public Transform p1Spawn;
    public Transform p2Spawn;

    private string barsPath = "UI/Battle/Bars";

    public CameraController cameraController;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 45;

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Attack"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Character"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Object"), LayerMask.NameToLayer("Attack"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Attack"), LayerMask.NameToLayer("Attack"));

        if (MatchControllerStore.Instance != null)
        {
            var stageResourcePath = ExtractObjectName(MatchControllerStore.Instance.stageResourcePath);
            var stageGameObj = UnityEngine.Resources.Load<GameObject>(stageResourcePath);

            var stage = Instantiate(stageGameObj, stageGameObj.transform.position, Quaternion.identity);
            var stageSpriteRenderer = stage.transform.GetComponentsInChildren<SpriteRenderer>();

            var stageLimits = stage.GetComponentInChildren<StageLimitsComponent>();
            if (stageLimits != null)
            {
                cameraController.useLimits = stageLimits.useLimits;
                cameraController.minLimitX = stageLimits.minLimitX;
                cameraController.maxLimitX = stageLimits.maxLimitX;
                cameraController.minLimitY = stageLimits.minLimitY;
                cameraController.maxLimitY = stageLimits.maxLimitY;
                cameraController.minLimitZ = stageLimits.minLimitZ;
                cameraController.maxLimitZ = stageLimits.maxLimitZ;
            }

            var resourcePathP1 = ExtractObjectName(MatchControllerStore.Instance.player1CharacterResourcePath);
            var p1GameObj = Instantiate(UnityEngine.Resources.Load<GameObject>(resourcePathP1), p1Spawn.position,
                Quaternion.identity);
            p1GameObj.GetComponent<BaseEnemyAI>().enabled = false;

            var p1CharController = p1GameObj.GetComponent<CharController>();
            p1CharController.playerEnum = PlayerEnum.PLAYER_1;
            p1CharController.team = TeamEnum.TEAM_1;
            p1CharController.stageSpriteRenderer = stageSpriteRenderer;
            p1GameObj.GetComponent<PlayerInput>().SwitchCurrentControlScheme("P1", Keyboard.current);


            var resourcePathP2 = ExtractObjectName(MatchControllerStore.Instance.player2CharacterResourcePath);
            var p2GameObj = Instantiate(UnityEngine.Resources.Load<GameObject>(resourcePathP2), p2Spawn.position,
                Quaternion.identity);
            p2GameObj.GetComponent<BaseEnemyAI>().enabled = false; //mudar para true

            var p2CharController = p2GameObj.GetComponent<CharController>();
            p2CharController.playerEnum = PlayerEnum.PLAYER_2; //mudar para con
            p2CharController.team = TeamEnum.TEAM_2;
            p2CharController.stageSpriteRenderer = stageSpriteRenderer;
            p2GameObj.GetComponent<PlayerInput>().SwitchCurrentControlScheme("P2", Keyboard.current); // remover
        }
    }

    private string ExtractObjectName(string path)
    {
        int lastSlashIndex = path.LastIndexOf('/');

        string extracted = path.Substring(lastSlashIndex + 1);

        return path + "/" + extracted;
    }
}