using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConteiner : MonoBehaviour
{
    public bool stageClearInfo = false;
    public int stageAddressNumber;
    public Player playerConteiner;
    public int turnCount = 0;
    public GameObject stageObj;
    public Stage currentSelectStage;

    public void DataInitForConteiner(Player player, int _turnCount, int _stageAddressNumber)
    {
        playerConteiner = player;
        turnCount = _turnCount;
        stageAddressNumber = _stageAddressNumber;
    }

    public void InitStageObj(GameObject _stageobj)
    {
        stageObj = _stageobj;
    }
}
