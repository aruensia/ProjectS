using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    List<CardData> defaultDeck = new List<CardData>();
    List<CardData> defaultcardList = new List<CardData>();
    private List<CardData> userHand;
    private List<CardData> discradDeck;

    public void Init(List<CardData> userhand, List<CardData> discradDeck)
    {
        this.userHand = userhand;
        this.discradDeck = discradDeck;
    }

    //게임 시작 시 유저가 사용하는 기본 덱을 설정하는 과정
    public List<CardData> DefaultDeckSetting()
    {
        foreach (CardData card in defaultcardList)
        {
            defaultDeck.Add(card);
        }

        return defaultDeck;
    }


    //유저의 덱을 기본 덱으로 초기화 하는 함수
    public List<CardData> RestCardDeck(List<CardData> deck)
    {
        deck = defaultDeck;

        return deck;
    }

    public void DrawCard(PlayerData playerDate)
    {
        var UserDeck = playerDate.userDeck;
        var drawcount = playerDate.CardDrawCount;
        var UserHandCount = playerDate.userhand.Count;
        var maxHandSize = playerDate.MaxHandSize;

        for (int i = 0; i < drawcount; i++)
        {
            if (UserHandCount >= maxHandSize)
            {
                break;
            }

            if (UserDeck.Count <= 0)
            {
                UserDeck = ShuffleDeck(UserDeck);
            }

            CardData drawcard = UserDeck[0];

            Draw(drawcard);
            UserHandCount++;
            UserDeck.RemoveAt(0);
        }
    }


    public void Draw(CardData card)
    {
        userHand.Add(card);
    }

    public void Discard(CardData card)
    {
        discradDeck.Remove(card);
    }


    //인자로 받은 Queue 덱을 리스트에 담은 후, 리스트를 Fisher-Yates Shuffle로 섞은 후
    //다시 임시 Queue에 담은 후 반환하는 함수
    public List<CardData> ShuffleDeck(List<CardData> tempdeck)
    {
        var deckcount = tempdeck.Count;

        System.Random random = new System.Random();

        for (int i = deckcount-1; i > 0; i--)
        {
            int k = random.Next(i + 1);
            CardData value = tempdeck[k];
            tempdeck[k] = tempdeck[i];
            tempdeck[i] = value;
        }

        return tempdeck;
    }
}
