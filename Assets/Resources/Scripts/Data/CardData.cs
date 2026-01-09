using ISubInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    ship, skill, item, curse
}

public class CardData : IUseble
{
    public string name;
    public CardType type;
    public int cost;

    void IUseble.Use()
    {
        GameDirector.Instance.outgameManager.cardController.Discard(this);
    }
}
