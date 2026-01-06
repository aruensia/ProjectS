using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutgameManager : MonoBehaviour
{
    public event Action OnNextTurn;
    public event Action OnEndTurn;
    public event Action OnGameOver;

    public GameObject gameController;
    public BuffController buffController;
    public CardController cardController;
    public StageController stageController;
    DataConteiner dataConteiner;
    public PlayerData playerdata;
    public Player player;
    public Vector3 startPos;
    public GameObject playerGameObj;
    public GameObject stageObj;

    public int turnCount; //턴 카운트
    public int stageAddress;

    public bool stageSettingIsComplete = false;

    public List<Card> userDeck = new List<Card>();  // 뽑을 카드덱
    public List<Card> discradDeck = new List<Card>();  // 버린 카드덱

    public List<Card> userHand = new List<Card>();

    private void Awake()
    {
        stageController = gameController.GetComponent<StageController>();
        buffController = gameController.GetComponent<BuffController>();
        cardController = gameController.GetComponent<CardController>();
        dataConteiner = GameDirector.Instance.dataConteiner.ConteinerToSend();
        GameDirector.Instance.InitOutgameManager(this);
    }

    private void Start()
    {
        GetTurnCountForDataConteiner();
        CheckStageCount();
        PlantAndStageSetting();
        OnPlantSetting();
        
        cardController.Init(userDeck, discradDeck);
        startPos = new Vector3(-8.64f, 0.75f, 0.2f);
        player = GameDirector.Instance.player;
        
        SetupPlayerSihp();
    }

    void PlantAndStageSetting()
    {
        stageController.InitTurnCount(turnCount);
        if(GameDirector.Instance.stageSettingIsComplete == false)
        {
            stageController.InstantiatePlent();
            stageController.InitStageSetting();
            GameDirector.Instance.stageSettingIsComplete = true;
            GameDirector.Instance.dataConteiner.InitStageObj(stageController.stageOjbs);
            GameDirector.Instance.dataConteiner.InitLines(stageController.Lines);
            stageController.stageOjbs.transform.SetParent(GameDirector.Instance.transform);
            stageController.EnterPlantSetting();

        }
        stageController.OnMatariaisSetting(stageAddress);
    }

    void GetTurnCountForDataConteiner()
    {
        turnCount = dataConteiner.TurnCount;
        Debug.Log("시작 턴 확인 : " + turnCount);
    }

    void OnPlantSetting()
    {
        if( turnCount == 0)
        {

        }
        else
        {
            stageController.EndPlantSetting(stageAddress);
            //stageController.StageMatarialsChange(dataConteiner.currentSelectStage);
        }
    }

    void CheckStageCount()
    {
        if (turnCount >= 10)
        {
            turnCount = 10;
        }
        else
        {
            if ( turnCount == 0)
            {

            }
            else
            {
                stageAddress = dataConteiner.StageAddresNumber;
            }
        }
    }

    public void CurrentStageDataSend(Stage stage)
    {
        player.InitStageData(stage);
    }


    public void CallGameEnd()
    {
        OnGameOver.Invoke();
    }

    public void CallNextTurn()
    {
        OnNextTurn.Invoke();
    }

    public void OnResetDrawCount()
    {
        playerdata.ResetDrawCount();
    }

    public void OnBuffApply()
    {
        buffController.ApplyBuff<DrawBuff, PlayerData>(player.playerData, 2);
    }

    public void SetupPlayerSihp()
    {
        player.transform.position = startPos;
    }

    public void StageEnter(Stage stage)
    {
        GameDirector.Instance.dataConteiner.DataInitForConteiner(player,turnCount, stage.stageAddressNumber, stage);
        stageController.StageMove(stage);
    }

}
