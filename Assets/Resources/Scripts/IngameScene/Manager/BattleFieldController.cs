using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFieldController : MonoBehaviour
{
    DataConteiner dataConteiner;
    IngameUIController ingameUIController;

    event Action OnNextTurn;
    event Action OnGameOver;

    int turnCount;


    private void Awake()
    {
        dataConteiner = GameDirector.Instance.dataConteiner;
    }

    private void Start()
    {

        turnCount = dataConteiner.TurnCount;
    }

    public void GetIngameUIController(IngameUIController ingameUIController)
    {
        this.ingameUIController = ingameUIController;
    }

    public void CallGameOver()
    {
        // 게임 종료시 필요한 기능이 있다면, 이곳에 호출하거나 작성.

        OnGameOver.Invoke();
    }

    public void CallNextTurn()
    {
        turnCount++;
        OnNextTurn.Invoke();
    }

    public void StageEnter()
    {
        SceneManager.LoadScene("OutGame");
    }

}
