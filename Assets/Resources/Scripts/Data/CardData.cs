using SubInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    ship, skill, item, curse
}

public class CardData : TableData, IUseble
{
    public string name;
    public CardType cardtype;
    public int cost;

    void IUseble.Use()
    {
        GameDirector.Instance.outgameManager.cardController.Discard(this);
    }
}
