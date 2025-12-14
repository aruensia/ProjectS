using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData playerData;
    public int life;

    public void Init(PlayerData _playerData)
    {
        this.playerData = _playerData;
        Debug.Log("데이터받음");
    }

    public void InitStageData(Stage stage)
    {
        playerData.currentUserInStageList.Add(stage);
    }

    
}
