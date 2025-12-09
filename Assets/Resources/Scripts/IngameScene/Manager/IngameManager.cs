using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class IngameManager : MonoBehaviour
{
    BattleFieldController battleFieldController;
    public Button stageExitBtn;

    private void Awake()
    {
        battleFieldController = GetComponent<BattleFieldController>();
    }


    public void StageExitBtn()
    {
        battleFieldController.StageEnter();
    }
}
