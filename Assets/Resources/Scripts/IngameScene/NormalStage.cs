using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStage : MonoBehaviour
{
    public GameObject normalStagePrefab;
    Stage stage;

    void Start()
    {
        
    }

    public void InitStage(Stage _stage)
    {
        this.stage = _stage;
    }
}
