using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardRules : MonoBehaviour
{
    public static CardRules cardRulesInstance;
    public Dictionary<string, int> duplicateItems;

    private void Awake()
    {
        if (cardRulesInstance != null && cardRulesInstance != this)
        {
            Destroy(this);
        }
        else
        {
            cardRulesInstance = this;
        }
    }

    public void CardStatus(List<Card> inHand, List<Card> inTable)
    {
        int totalInHand = 0;
        int totalInTable = 0;

        if (inHand != null)
        {
            totalInHand = getTotalValue(inHand, totalInHand);
        }
        if (inTable != null)
        {
            totalInTable = Multiply(inTable, getTotalValue(inTable, totalInTable));
        }
        Debug.Log(totalInHand + ", " + totalInTable);
    }

    // Move to common functionality
    private int getTotalValue(List<Card> cards, int total)
    {
        foreach (var card in cards)
        {
            if (card != null)
                total += card.cardWeight;
        }

        return total;
    }

    public bool CheckOccurence(List<Card> cards)
    {
        duplicateItems =
          cards
          .GroupBy(x => x.cardName)
          .ToDictionary(x => x.Key, x => x.Count());

        foreach (var item in duplicateItems)
        {
            var lastItem = duplicateItems.Last();
            if (item.Equals(lastItem))
            {
                if (item.Value > 1) return true;
                return false;
            }
        }
        return false;
    }

    public int Multiply(List<Card> cards, int totalVal)
    {
        int total = 0;
        int repeatTimes = 0;
        Dictionary<int, List<int>> multiplierArray = new();
        multiplierArray.Add(1, new List<int>() { 20, 25, 30 });
        multiplierArray.Add(2, new List<int>() { 15, 20, 25 });
        multiplierArray.Add(3, new List<int>() { 13, 15, 20 });
        multiplierArray.Add(4, new List<int>() { 12, 14, 16 });
        multiplierArray.Add(5, new List<int>() { 10, 12, 14 });

        bool isDuplicate = CheckOccurence(cards);

        if (isDuplicate)
        {
            foreach (var repeat in duplicateItems) repeatTimes = repeat.Value;

            foreach (var card in cards)
            {
                foreach (var multiplier in multiplierArray)
                {
                    if (card.cardID == multiplier.Key)
                    {
                        if (repeatTimes == 2)
                        {
                            total = totalVal * multiplier.Value[0];
                        }
                        if (repeatTimes == 3)
                        {
                            total = totalVal * multiplier.Value[1];
                        }
                        if (repeatTimes == 4)
                        {
                            total = totalVal * multiplier.Value[2];
                        }
                    }
                }
            }
            return total;
        }
        else
        {
            total = totalVal * 1;
            return total;
        }
    }
}
