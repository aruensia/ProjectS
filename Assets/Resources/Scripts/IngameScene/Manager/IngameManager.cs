using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public enum IngameStartStep
{
    Start, InitBuff, Drow, end
}

public class IngameManager : MonoBehaviour
{
    event Action OnFinishStep;


    DataConteiner dataConteiner;
    BattleFieldController battleFieldController;
    IngameUIController ingameUIController;
    public Button stageExitBtn;
    public GameObject ingameStageOjb;
    bool clearResult;
    [SerializeField] Stage stage;


    IngameStartStep startstep;
    LinkedList<IngameStartStep> ingameStartState = new LinkedList<IngameStartStep>();
    LinkedListNode<IngameStartStep> StateStep;

    bool startStepComplete = false;

    public List<GameObject> IngameEventPrefabsList;

    public Player player;

    private void Awake()
    {
        battleFieldController = GetComponent<BattleFieldController>();
        dataConteiner = GameDirector.Instance.dataConteiner;
        player = GameDirector.Instance.player;
    }

    private void Start()
    {
        ingameStageOjb = dataConteiner.stageObj;
        stage = dataConteiner.currentSelectStage;
        battleFieldController.GetIngameUIController(ingameUIController);

        OnFinishStep += NextStep;

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

    void InitLinkdListNode()
    {
        ingameStartState.AddFirst(IngameStartStep.Start);
        ingameStartState.AddLast(IngameStartStep.InitBuff);
        ingameStartState.AddLast(IngameStartStep.Drow);
        ingameStartState.AddLast(IngameStartStep.end);
    }

    void StartStep()
    {
        StartStepAction(StateStep.Value);
    }

    void RestStep()
    {
        StateStep = ingameStartState.First;
    }

    void NextStep()
    {
        StateStep = StateStep.Next;
        StartStepAction(StateStep.Value);
    }


    void StartStepAction(IngameStartStep step)
    {
        switch(step)
        {
            case IngameStartStep.Start:
                Debug.Log("스타트 스탭 실행됌");
                OnFinishStep.Invoke();
                break;

            case IngameStartStep.InitBuff:
                Debug.Log("버프 스탭 실행됌");
                OnFinishStep.Invoke();
                break;

            case IngameStartStep.Drow:
                Debug.Log("드로우 스탭 실행됌");
                OnFinishStep.Invoke();
                break;

            case IngameStartStep.end:
                Debug.Log("종료 스탭 실행됌");
                OnFinishStep.Invoke();
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
