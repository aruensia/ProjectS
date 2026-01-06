using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StageEvent<TStageEvent> : MonoBehaviour
{
    public abstract void StageEventInit(TStageEvent stageEvent);

}

public class NormalStage : StageEvent<Stage>
{
    Stage ingameStage;
    GameObject normalStagePrefab;

    public override void StageEventInit(Stage stageEvent)
    {
        ingameStage = stageEvent;
    }

    public void StartEvent()
    {
        Debug.Log("스테이지 시작함");
    }
}

public class ShopStage : StageEvent<Stage>
{
    Stage ingameStage;
    GameObject shopStagePrefab;

    public override void StageEventInit(Stage stageEvent)
    {
        
    }
}
