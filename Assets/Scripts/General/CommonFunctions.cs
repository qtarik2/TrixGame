using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonFunctions : MonoBehaviour
{    
    public List<Card> GetSliced(List<Card> card, int start, int numOfCards)
    {
        List<Card> tempList = new();
        int end = start + numOfCards;

        if (card.Count > (end - 1))
        {
            for (int i = start; i < end; i++)
            {
                tempList.Add(card[i]);
            }
        }
        return tempList;
    }
}