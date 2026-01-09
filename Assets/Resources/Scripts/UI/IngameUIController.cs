using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIController : MonoBehaviour
{
    event Action OnDrow;
    event Action OnDiscoard;
    int tempDrowCount = 1;
    public GameObject CardPrefab;
    bool firstDrowOn = false;

    [SerializeField] Vector3 drowCardDefaultPos;
    [SerializeField] Vector3 drowCardXPosValue;
    public GameObject cardPosObj;
    public GameObject canvers;

    void Start()
    {
        drowCardDefaultPos = cardPosObj.transform.position;
        drowCardXPosValue = drowCardDefaultPos;
        OnDrow += SetDrowPos;
        OnDiscoard += DiscardPos;
        SetDrowPos();
    }

    void SetDrowPos()
    {
        if(firstDrowOn != false)
        {
            Vector3 tempvector3 = new Vector3();
            tempvector3 = canvers.transform.position;
            tempvector3.x = tempvector3.x - 50;
            canvers.transform.position = tempvector3;
            drowCardXPosValue.x = drowCardXPosValue.x + 50;
        }

    }

    void DiscardPos()
    {
        drowCardXPosValue.x = drowCardXPosValue.x - 50;

    }

    public void TestDrowBtn()
    {
        OnDrow.Invoke();
        var tempcard = Instantiate(CardPrefab, canvers.transform);
        tempcard.transform.position = drowCardXPosValue;

        firstDrowOn = true;
    }
}
