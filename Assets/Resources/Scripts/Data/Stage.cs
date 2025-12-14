using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageType
{
    normal, shop, talk, elite, boss, end
    // normal:일반 전투, Shop: 상점, talk: 대화, elite: 정예, boss: 보스, end: 종료
}


public class Stage : MonoBehaviour
{
    public StageType stageType;
    public List<Stage> nextStage;
    public Stage previousStage;
    public bool stageClearInfo = false;
    public int stageAddressNumber;

    public Ship enemyship;

}
