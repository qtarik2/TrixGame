using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public List<Card> clubs = new();
    public List<Card> diamonds = new();
    public List<Card> hearts = new();
    public List<Card> spades = new();
    public List<Card> AllShuffledCard = new();

    void Start()
    {
        AllShuffledCard.AddRange(clubs);
        AllShuffledCard.AddRange(diamonds);
        AllShuffledCard.AddRange(hearts);
        AllShuffledCard.AddRange(spades);
        Shuffle(AllShuffledCard);
    }


    void Shuffle<T>(IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
