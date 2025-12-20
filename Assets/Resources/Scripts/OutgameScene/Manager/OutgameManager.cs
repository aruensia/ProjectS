using System;
using System.Collections;
using System.Collections.Generic;
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

    public int turnCount; //ÅÏ Ä«¿îÆ®
    public int stageAddress;

    public bool stageSettingIsComplete = false;

    public List<Card> userDeck = new List<Card>();  // »ÌÀ» Ä«µåµ¦
    public List<Card> discradDeck = new List<Card>();  // ¹ö¸° Ä«µåµ¦

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
        CheckStageCount();
        OnStageSettingMethod();
        OnPlantSetting();
        
        cardController.Init(userDeck, discradDeck);
        startPos = new Vector3(-8.64f, 0.75f, 0.2f);
        player = GameDirector.Instance.player;
        
        SetupPlayerSihp();
        Debug.Log(player.playerData);
    }

    void OnStageSettingMethod()
    {
        stageController.InitTurnCount(turnCount);
        if(GameDirector.Instance.stageSettingIsComplete == false)
        {
            stageController.InstantiatePlent();
            stageController.InitStageSetting();
            stageController.OnMatariaisSetting();
            GameDirector.Instance.stageSettingIsComplete = true;
            GameDirector.Instance.dataConteiner.InitStageObj(stageController.stageOjbs);
            GameDirector.Instance.dataConteiner.InitLines(stageController.Lines);
            stageController.stageOjbs.transform.SetParent(GameDirector.Instance.transform);

        }
        stageController.EnterPlantSetting();
    }

    void OnPlantSetting()
    {
        if( turnCount == 1)
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
            if ( turnCount == 1)
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
        Debug.Log(player.transform.position);
    }

    public void StageEnter(Stage stage)
    {
        GameDirector.Instance.dataConteiner.DataInitForConteiner(player,turnCount, stage.stageAddressNumber);
        stageController.StageMove(stage);
    }

}
