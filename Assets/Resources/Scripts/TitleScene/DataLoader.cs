using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataLoader
{
    public Dictionary<string, List<TableData>> tableDatas = new Dictionary<string, List<TableData>>()
    {
        {"ShipTable", new List<TableData>() },
        {"CardTable", new List<TableData>() },
    };

    public void DataLoad()
    {
        foreach (var item in tableDatas)
        {
            TextAsset csvFiles = Resources.Load<TextAsset>($"Tables/{item.Key}");

            if (csvFiles == null)
            {
                return;
            }

            string[] lines = csvFiles.text.Split('\n');
            switch (csvFiles.name)
            {
                case "ShipTable":
                    for (int i = 2; i < lines.Length - 1; i++)
                    {
                        string[] values = lines[i].Split(',');
                        ShipData tempShipData = new ShipData();
                        tempShipData.Index = int.Parse(values[0]);
                        tempShipData.shipClass = (ShipClass)int.Parse(values[1]);
                        tempShipData.name = values[2].ToString();
                        tempShipData.Armmor = int.Parse(values[3]);
                        tempShipData.Hull = int.Parse(values[4]);
                        tempShipData.Shild = int.Parse(values[4]);
                        tempShipData.Damage = int.Parse(values[5]);
                        tempShipData.AttackSpeed = float.Parse(values[6]);
                        tempShipData.AttackRange = float.Parse(values[7]);
                        tempShipData.MoveSpeed = float.Parse(values[8]);

                        item.Value.Add(tempShipData);
                        Debug.Log("로드 데이터 이름 : " + tempShipData.name);
                    }
                    break;



                case "CardTable":
                    for (int i = 2; i < lines.Length - 1; i++)
                    {
                        string[] values = lines[i].Split(',');
                        CardData tempcarddata = new CardData();
                        tempcarddata.Index = int.Parse(values[0]);
                        tempcarddata.cardtype = (CardType)int.Parse(values[1]);

                        item.Value.Add(tempcarddata);
                    }

                    break;

            }



        }
    }


}
