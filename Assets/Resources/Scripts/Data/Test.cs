using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    Dictionary<int,Ship> testdic = new Dictionary<int,Ship>();

    public InputField costInit;
    public InputField keyInit;
    int idcount;

    public Ship InitData(int cost)
    {
        Ship userShip = new Ship();
        userShip.cost = cost;
        idcount++;
        userShip.id += idcount;

        return userShip;
    }

    public void AddDicUserShip(Ship userShip)
    {
        testdic.Add(userShip.id , userShip);
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
