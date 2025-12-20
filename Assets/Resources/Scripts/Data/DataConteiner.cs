using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConteiner : MonoBehaviour
{
    public bool stageClearInfo = false;
    int stageAddressNumber;
    public Player playerConteiner;
    int turnCount = 0;
    public GameObject stageObj;
    public GameObject lines;
    public Stage currentSelectStage;

    public int StageAddresNumber { get; }
    public int TurnCount { get; }



    public void DataInitForConteiner(Player player, int _turnCount, int _stageAddressNumber)
    {
        playerConteiner = player;
        turnCount = _turnCount;
        stageAddressNumber = _stageAddressNumber;
    }

    public void TrunCountPlus(bool stageClearResult)
    {
        if(stageClearResult == true)
        {
            turnCount = turnCount + 1;
        }
    }

    public void InitStageObj(GameObject _stageobj)
    {
        stageObj = _stageobj;
    }

    public void InitLines(GameObject _lines)
    {
        lines = _lines;
    }

    public DataConteiner ConteinerToSend()
    {
        return this;
    }
}


