using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData playerData;
    public int life;

    [SerializeField] int money;

    public int Money
    {
        get { return money; }
        set
        {
            if (value <= 0)
            {
                money = 0;
            }
            else
            {
                money = value;
            }
        }
    }

    public void Init(PlayerData _playerData)
    {
        this.playerData = _playerData;
    }

    public void InitStageData(Stage stage)
    {
        playerData.currentUserInStageList.Add(stage);
    }

    private void Start()
    {
        life = 10;
        money = 1000;
    }

    public void ResetPlayerData()
    {
        life = 10;
        money = 1000;
    }
}
