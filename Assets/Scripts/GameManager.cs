using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
  CommonFunctions commonFunctions;
  CardList cardList;
  WrongMoveList wrongMoveList;

  // Card in hards
  public int aPlayerTotalCard = 5;
  public List<Card> aPlayerCardsInHands = new();
  public List<GameObject> cardObj;

  public int bPlayerCardsTotalCard = 5;
  public int cPlayerCardsTotalCard = 5;
  public int dPlayerCardsTotalCard = 5;

  ArrayList cardNames = new();
  public Dictionary<string, int> dublicateCards = new();

  public Button slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9, slot10, slot11;

  public List<Card> cardInTable = new();
  int total = 0;
  public int multiplier = 1;
  public bool isWrongMove = false;
  // Start is called before the first frame update
  void Start()
  {
    #region Button
    slot1.onClick.AddListener(() => DrawCard(0));
    slot2.onClick.AddListener(() => DrawCard(1));
    slot3.onClick.AddListener(() => DrawCard(2));
    slot4.onClick.AddListener(() => DrawCard(3));
    slot5.onClick.AddListener(() => DrawCard(4));
    slot6.onClick.AddListener(() => DrawCard(5));
    slot7.onClick.AddListener(() => DrawCard(6));
    slot8.onClick.AddListener(() => DrawCard(7));
    slot9.onClick.AddListener(() => DrawCard(8));
    slot10.onClick.AddListener(() => DrawCard(9));
    slot11.onClick.AddListener(() => DrawCard(10));
    #endregion

    commonFunctions = GetComponent<CommonFunctions>();
    wrongMoveList = GetComponent<WrongMoveList>();
    cardList = GetComponent<CardList>();
    DisplayCards();
  }

  public void DisplayCards()
  {
    // Distance from each cards -54
    for (int i = 0; i < aPlayerTotalCard; i++)
    {
      cardObj[i].SetActive(true);
      cardObj[i].GetComponent<Image>().sprite = cardList.clubs[i].cardImage;
      aPlayerCardsInHands.Add(cardList.clubs[i]);
    }
    CheckCards(total);
  }

  public void DrawCard(int buttonNo)
  {
    if (cardInTable.Count > 0)
    {
      isWrongMove = commonFunctions.GetWrongMoves(cardList.clubs[buttonNo], cardInTable[cardInTable.Count - 1], wrongMoveList);

      // Check wrong move
      if (isWrongMove != true)
      {
        // // Multiply final value
        aPlayerCardsInHands[buttonNo] = null;
        cardInTable.Add(cardList.clubs[buttonNo]);
      }
      else
      {
        Debug.Log("A wrong move!");
      }
    }
    if (cardInTable.Count == 0)
    {
      // Multiply final value
      aPlayerCardsInHands[buttonNo] = null;
      cardInTable.Add(cardList.clubs[buttonNo]);
    }


    #region Button
    // CardRules.cardRulesInstance.total = 0;
    if (isWrongMove == true) return;
    if (buttonNo == 0)
      slot1.gameObject.SetActive(false);
    if (buttonNo == 1)
      slot2.gameObject.SetActive(false);
    if (buttonNo == 2)
      slot3.gameObject.SetActive(false);
    if (buttonNo == 3)
      slot4.gameObject.SetActive(false);
    if (buttonNo == 4)
      slot5.gameObject.SetActive(false);
    if (buttonNo == 5)
      slot6.gameObject.SetActive(false);
    if (buttonNo == 6)
      slot7.gameObject.SetActive(false);
    if (buttonNo == 7)
      slot8.gameObject.SetActive(false);
    if (buttonNo == 8)
      slot9.gameObject.SetActive(false);
    if (buttonNo == 9)
      slot10.gameObject.SetActive(false);
    if (buttonNo == 10)
      slot11.gameObject.SetActive(false);
    #endregion

    CheckCards(total);
  }

  public void CheckCards(int total)
  {
    CardRules.cardRulesInstance.CardStatus(aPlayerCardsInHands, cardInTable, multiplier);
  }


  // public void CheckCards()
  // {
  //   foreach (var card in aPlayerCardsInHands)
  //   {
  //     CardRules.cardRulesInstance.CheckOccurence(card.cardWeight);
  //   }
  //   CardRules.cardRulesInstance.duplicates();
  // }

  // public void CheckCards()
  // {
  //   var count = 0;
  //   HashSet<string> hashset = new();
  //   HashSet<string> dublicate = new();

  //   var val = 0;
  //   foreach (var card in aPlayerCardsInHands)
  //   {
  //     cardNames.Add(card.cardName);
  //     val += card.cardWeight;
  //     Debug.Log(val);
  //   }

  //   foreach (string name in cardNames)
  //   {
  //     if (!hashset.Add(name))
  //     {
  //       count++;
  //       if (dublicate.Add(name))
  //         count++;
  //       // dublicateCards[name] = count;
  //       // break;
  //     }
  //   }

  //   if (dublicate.Count == 1)
  //   {
  //     // Call one pair
  //     CardRules.cardRulesInstance.OnePair();
  //   }
  //   if (dublicate.Count == 2)
  //   {
  //     // Call one pair
  //     CardRules.cardRulesInstance.TwoPair();
  //   }

  //   foreach (var kvp in dublicate)
  //   {
  //     // if (kvp.Value >= 1)
  //     // {
  //     Debug.Log(kvp);
  //     // }
  //   }
  // }
}
