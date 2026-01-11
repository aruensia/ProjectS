using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    Dictionary<int,ShipData> testdic = new Dictionary<int,ShipData>();

    public InputField costInit;
    public InputField keyInit;
    int idcount;

    public ShipData InitData(int cost)
    {
        ShipData userShip = new ShipData();
        userShip.cost = cost;
        idcount++;
        userShip.Index += idcount;

        return userShip;
    }

    public void AddDicUserShip(ShipData userShip)
    {
        testdic.Add(userShip.Index , userShip);
        Debug.Log("데이터 넣음");
    }
    
    public void Setbtn()
    {
        int cost = int.Parse(costInit.text);
        AddDicUserShip(InitData(cost));
    }

    public void ShowDic()
    {
        int key = int.Parse(keyInit.text);
        if(testdic.ContainsKey(key))
        {
            Debug.Log(testdic[key].cost);
        }
        else
        {
            Debug.Log("키가 없어요");
        }
    }
}
