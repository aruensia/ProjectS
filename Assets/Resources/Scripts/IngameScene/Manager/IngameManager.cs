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
    [SerializeField] Stage stage;

    public List<GameObject> IngameEventPrefabsList;

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
        stage = dataConteiner.currentSelectStage;
        StageOjbOff();
        LinesOff();
        StageEvent();
    }

    void StageEvent()
    {
        switch(stage.stageType)
        {
            case StageType.normal :
                stage.stageType = StageType.normal;
                IngameEventPrefabsList[(int)StageType.normal].SetActive(true);
                Debug.Log("일반전");
                break;

            case StageType.elite:
                stage.stageType = StageType.elite;
                IngameEventPrefabsList[(int)StageType.elite].SetActive(true);
                Debug.Log("정예");
                break;

            case StageType.shop:
                stage.stageType = StageType.shop;
                IngameEventPrefabsList[(int)StageType.shop].SetActive(true);
                Debug.Log("상점");
                break;

            case StageType.talk:
                stage.stageType = StageType.talk;
                IngameEventPrefabsList[(int)StageType.talk].SetActive(true);
                Debug.Log("이벤트");
                break;

            case StageType.boss:
                stage.stageType = StageType.boss;
                IngameEventPrefabsList[(int)StageType.boss].SetActive(true);
                Debug.Log("보스");
                break;

        }
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

    void IngamePrefabsOff()
    {
        for (int i = 0; i < IngameEventPrefabsList.Count; i++)
        {
            IngameEventPrefabsList[i].SetActive(false);
        }
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
        //IngamePrefabsOff();
        ExitStageData();
    }
}
