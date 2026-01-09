using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerData
{
    public int money;
    public readonly int defaultDrawCount = 5; // 유저가 기본적으로 드로우하는 카드 개수;
    public int drawCount = 5;

    public List<CardData> userDeck;
    public List<CardData> userhand;
    public int MaxHandSize;
    public int CardDrawCount;
    public List<Stage> currentUserInStageList = new List<Stage>();
    public Stage currentUserInStage;

    public void ResetDrawCount()
    {
        drawCount = defaultDrawCount;
    }

    public void UserStageSellect(Stage sellectStage)
    {
        currentUserInStageList.Add(sellectStage);
    }

    public void MoveStage()
    {
        var lastnum = currentUserInStageList.Count - 1;
        currentUserInStage = currentUserInStageList[lastnum];
    }
}
