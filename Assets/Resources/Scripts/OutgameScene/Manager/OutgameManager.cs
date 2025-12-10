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
    public PlayerData playerdata;
    public Player player;
    public Vector3 startPos;
    public GameObject playerGameObj;


    public int turnCount; //ÅÏ Ä«¿îÆ®

    public List<Card> userDeck = new List<Card>();  // »ÌÀ» Ä«µåµ¦
    public List<Card> discradDeck = new List<Card>();  // ¹ö¸° Ä«µåµ¦

    public List<Card> userHand = new List<Card>();

    private void Awake()
    {
        stageController = gameController.GetComponent<StageController>();
        buffController = gameController.GetComponent<BuffController>();
        cardController = gameController.GetComponent<CardController>();
        GameDirector.Instance.InitIngameManager(this);
    }

    private void Start()
    {
        cardController.Init(userDeck, discradDeck);
        startPos = new Vector3(-8.64f, 0.75f, 0.2f);
        player = GameDirector.Instance.player;

        SetupPlayerSihp();
        Debug.Log(player.playerData);
    }

    void CheckStageCount()
    {
        if(GameDirector.Instance.dataConteiner.stageCount != 0)
        {
            GameDirector.Instance.dataConteiner.stageCount++;
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

    public void OnNextStage()
    {

    }

    public void OnBuffApply()
    {
        buffController.ApplyBuff<DrawBuff, PlayerData>(GameDirector.Instance.playerData, 2);
    }

    public void SetupPlayerSihp()
    {
        player.transform.position = startPos;
        Debug.Log(player.transform.position);
    }

    public void StageEnter(Stage stage)
    {
        stageController.StageMove(stage);
    }
}
