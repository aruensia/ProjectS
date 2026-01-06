using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConteiner : MonoBehaviour
{
    public bool stageClearInfo = false;
    [SerializeField] int stageAddressNumber;
    public Player playerConteiner;
    [SerializeField] int turnCount = 0;
    public GameObject stageObj;
    public GameObject lines;
    public Stage currentSelectStage;

    public int StageAddresNumber { get => stageAddressNumber; }
    public int TurnCount {  get =>  turnCount; }


    public void DataInitForConteiner(Player player, int _turnCount, int _stageAddressNumber, Stage _stage)
    {
        playerConteiner = player;
        turnCount = _turnCount;
        stageAddressNumber = _stageAddressNumber;
        currentSelectStage = _stage;
    }

    public void TrunCountPlus(bool stageClearResult)
    {
        if(stageClearResult == true)
        {
            turnCount = turnCount + 1;
            Debug.Log("데이터 컨테이너의 턴 카운트가 증가함 : " + this.turnCount);
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


