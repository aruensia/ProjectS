using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Button ingameSceneBtn;
    DataLoader dataloader = new DataLoader();

    private void Awake()
    {
        dataloader.DataLoad();
    }

    private void Start()
    {
        
    }

    public void IngameSceneBtn()
    {
        SceneManager.LoadScene("OutGame");
    }
}
