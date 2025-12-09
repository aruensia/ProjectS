using Radishmouse;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageController : MonoBehaviour
{
    public GameObject stagePoint;
    public LineRenderer lineRenderer;

    public List<GameObject> stageObjList;

    public List<List<Stage>> battleList = new List<List<Stage>>();
    public Stage currentStage;
    public GameObject plent;
    public GameObject stageOjbs;
    public Material ClearMataral;
    public Material DafaultMataral;


    List<StageType> stageCounter = new List<StageType> {StageType.normal, StageType.normal, StageType.normal, StageType.elite, StageType.normal,StageType.normal,StageType.normal, StageType.shop,StageType.normal,StageType.boss};
    int battleInStageCount = 3;
    int totalStageCount = 10;
    int count = 0;

    public InputField inpufield;

    public int selectnum;

    private void Start()
    {
        lineRenderer.gameObject.SetActive(true);

        InstantiatePlent();
        InitStageSetting();
    }

    public void InstantiatePlent()
    {
        float initX = -5.19f;
        float initY = 2f;

        for ( int i = 0; i < 10;  i++ )
        {
            float tempX = (initX -(i * -2f));

            for (int j  = 0; j < 3;  j++ )
            {
                var tempPlent = Instantiate(plent, stageOjbs.transform.GetChild(i));

                float tempY = (initY - j);

                tempPlent.transform.position = new Vector3(tempX, tempY, 0);

            }
        }
    }


    public void InitStageSetting()
    {
        //totalStageCount = 10; 총 플레이어가 싸워야 하는 전투 횟수
        for (int i = 0; i < totalStageCount; i++)
        {
            var stageList = new List<Stage>();

            //battleInStageCount 한 전투에서 유저가 선택해야하는 스테이지 횟수
            for (int j = 0; j < battleInStageCount; j++)
            {
                var tempstage = CreateStage(i,j);
                StageSetting(tempstage, i);
                stageList.Add(tempstage);
            }

            battleList.Add(stageList);

            if( i > 0)
            {
                FindNextBattlePoint(battleList[i - 1], battleList[i], i);
            }
        }
    }

    public Stage CreateStage(int batllelist, int stagecount)
    {
        var tempstage = stageOjbs.transform.GetChild(batllelist).transform.GetChild(stagecount).GetComponent<Stage>();

        return tempstage;
    }

    public Stage StageSetting(Stage stage, int stagecount)
    {
        int tempRand = UnityEngine.Random.Range((int)StageType.normal, (int)StageType.end-1);

        if(stagecount != (int)stageCounter[count])
        {
            switch (tempRand)
            {
                case (int)StageType.normal:
                    stage.stageType = StageType.normal;
                    break;

                case (int)StageType.shop:
                    stage.stageType = StageType.shop;
                    break;

                case (int)StageType.talk:
                    stage.stageType = StageType.talk;
                    break;

                case (int)StageType.elite:
                    stage.stageType = StageType.elite;
                    break;

                case (int)StageType.end:
                    stage.stageType = StageType.end;
                    break;
            }
        }
        else
        {
            switch(stagecount)
            {
                case (int)StageType.shop:
                    stage.stageType = StageType.shop;
                    break;

                case (int)StageType.talk:
                    stage.stageType = StageType.talk;
                    break;

                case (int)StageType.elite:
                    stage.stageType = StageType.elite;
                    break;

                case (int)StageType.boss:
                    stage.stageType = StageType.boss;
                    break;
            }
        }
        return stage;
    }

    public void TestDebug()
    {
        var tempint = inpufield.text;
        Debug.Log(battleList[int.Parse(tempint)]);

        selectnum = int.Parse(tempint);
    }

    public void CechkStage()
    {
        var tempint = inpufield.text;
        foreach(Stage stages in battleList[int.Parse(tempint)] )
        {
            Debug.Log(stages.stageType);
        }
    }

    //
    public void FindNextBattlePoint(List<Stage> previousStageList, List<Stage> currentStageList, int layerCount)
    {
        for(int i = 0; i < currentStageList.Count; i++)
        {
            previousStageList[i].nextStage.Add(currentStageList[i]);

            var mainline = Instantiate(lineRenderer);
            mainline.startWidth = 0.1f;
            mainline.endWidth = 0.1f;

            mainline.SetPosition(0, previousStageList[i].transform.position);
            mainline.SetPosition(1, currentStageList[i].transform.position);

            if (layerCount > 1)
            {
                switch (i)
                {
                    case 0:
                        var templist1 = new List<Stage> { null, currentStageList[i+1] };
                        int tempRand1 = UnityEngine.Random.Range(0, 2);
                        for (int j = 0; j <= tempRand1; j++)
                        {
                            if( j == 0)
                            {

                            }
                            else
                            {
                                var templine = Instantiate(lineRenderer);
                                templine.startWidth = 0.1f;
                                templine.endWidth = 0.1f;

                                previousStageList[i].nextStage.Add(templist1[j]);
                                templine.SetPosition(0, previousStageList[i].transform.position);
                                templine.SetPosition(1, templist1[j].transform.position);
                            }
                        }
                        break;

                    case 1: 
                        var templist2 = new List<Stage> { null, currentStageList[i-1], currentStageList[i+1] };
                        int tempRand2 = UnityEngine.Random.Range(0, 3);
                        for (int j = 0; j <= tempRand2; j++)
                        {
                            if (j == 0)
                            {

                            }
                            else
                            {
                                var templine = Instantiate(lineRenderer);
                                templine.startWidth = 0.1f;
                                templine.endWidth = 0.1f;

                                previousStageList[i].nextStage.Add(templist2[j]);
                                templine.SetPosition(0, previousStageList[i].transform.position);
                                templine.SetPosition(1, templist2[j].transform.position);
                            }
                        }
                        break;

                    case 2:
                        var templist3 = new List<Stage> { null, currentStageList[i-1] };
                        int tempRand3 = UnityEngine.Random.Range(0, 2);
                        for (int j = 0; j <= tempRand3; j++)
                        {
                            if (j == 0)
                            {

                            }
                            else
                            {
                                var templine = Instantiate(lineRenderer);
                                templine.startWidth = 0.1f;
                                templine.endWidth = 0.1f;

                                previousStageList[i].nextStage.Add(templist3[j]);
                                templine.SetPosition(0, previousStageList[i].transform.position);
                                templine.SetPosition(1, templist3[j].transform.position);
                            }
                        }
                        break;
                }
            }
        }
    }

    public void StageMove(Stage stage)
    {
        if(stage.stageClearInfo == false)
        {
            stage.stageClearInfo = true;
            SceneManager.LoadScene("InGame");

        }
        else
        {
            Debug.Log("이미 클리어 한 스테이지 입니다.");
        }

    }

    public void StageExit()
    {
        SceneManager.LoadScene("OutGame");
    }
}
