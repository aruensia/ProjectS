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
    int turnCount;

    public Player player;

    private void Awake()
    {
        battleFieldController = GetComponent<BattleFieldController>();
        dataConteiner = GameDirector.Instance.dataConteiner;
    }

    private void Start()
    {
        turnCount = dataConteiner.turnCount;
    }


    public void ExitStageData()
    {
        dataConteiner.stageClearInfo = true;
    }

    public void StageExitBtn()
    {
        battleFieldController.StageEnter();
    }

    private void OnDisable()
    {
        dataConteiner.turnCount++;
        Debug.Log("인게임 나갈때 턴값 : " + dataConteiner.turnCount);
        ExitStageData();
    }
}
