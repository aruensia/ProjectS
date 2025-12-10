using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConteiner : MonoBehaviour
{
    public Stage stageConteiner;
    public Player playerConteiner;
    public int stageCount = 0;

    public void DataInitForConteiner(Stage stage, Player player)
    {
        stageConteiner = stage;
        playerConteiner = player;
    }
}
