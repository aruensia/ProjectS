using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFieldController : MonoBehaviour
{
    Stage stage;

    public void StageEnter()
    {
        SceneManager.LoadScene("OutGame");
    }
}
