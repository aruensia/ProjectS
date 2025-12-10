using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class IngameManager : MonoBehaviour
{
    DataConteiner dataConteiner;
    BattleFieldController battleFieldController;
    public Button stageExitBtn;

    public Stage stage;
    public Player player;

    private void Awake()
    {
        battleFieldController = GetComponent<BattleFieldController>();
        dataConteiner = GameDirector.Instance.dataConteiner;
    }

    private void Start()
    {
        stage = dataConteiner.stageConteiner;
    }

    public void ExitStageData()
    {
        dataConteiner.stageConteiner = stage;
        dataConteiner.playerConteiner = player;
    }

    public void StageExitBtn()
    {
        stage.stageClearInfo = true;
        battleFieldController.StageEnter();
    }

    private void OnDisable()
    {
        ExitStageData();
    }
}
