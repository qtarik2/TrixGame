using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardRules : MonoBehaviour
{
  public static CardRules cardRulesInstance;
  // public Dictionary<string, bool> duplicateItems;

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

  public void CardStatus(List<Card> inHand, List<Card> inTable, int multiplier)
  {
    int totalInHand = 0;
    int totalInTable = 0;

    if (inHand != null)
    {
      totalInHand = getTotalValue(inHand, totalInHand);
    }
    if (inTable != null)
    {
      totalInTable = Multiply(inTable, getTotalValue(inTable, totalInTable), multiplier);
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
    var duplicateItems =
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

  public int Multiply(List<Card> card, int total, int multiplier)
  {
    bool isDuplicate = CheckOccurence(card);

    if (isDuplicate)
    {
      return total * multiplier;
    }
    else
    {
      return total * 1;
    }
  }
}
