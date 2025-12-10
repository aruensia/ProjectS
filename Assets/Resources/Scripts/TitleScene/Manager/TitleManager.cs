using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Button ingameSceneBtn;

    public void IngameSceneBtn()
    {
        SceneManager.LoadScene("OutGame");
    }
}
