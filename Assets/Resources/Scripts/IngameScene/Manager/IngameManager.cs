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
    public GameObject ingameStageOjb;
    int turnCount;
    bool clearResult;

    public Player player;

    private void Awake()
    {
        battleFieldController = GetComponent<BattleFieldController>();
        dataConteiner = GameDirector.Instance.dataConteiner;
    }

    private void Start()
    {
        turnCount = dataConteiner.TurnCount;
        ingameStageOjb = dataConteiner.stageObj;
        StageOjbOff();
        LinesOff();
    }

    void StageOjbOff()
    {
        ingameStageOjb.SetActive(false);
    }

    void StageOjbOn()
    {
        ingameStageOjb.SetActive(true);
    }

    void LinesOn()
    {
        dataConteiner.lines.gameObject.SetActive(true);
    }

    void LinesOff()
    {
        dataConteiner.lines.gameObject.SetActive(false);
    }

    void StageClear()
    {
        clearResult = true;
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
        StageClear();
        dataConteiner.TrunCountPlus(clearResult); // 내부에서 턴 값을 1만큼 올려줌
        StageOjbOn();
        LinesOn();
        ExitStageData();
    }
}
