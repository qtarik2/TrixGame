using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonFunctions : MonoBehaviour
{
  public bool GetWrongMoves(Card inHand, Card inTable, WrongMoveList wrongCards)
  {    
    // Check inhand cards against last card in table
    if (inTable.cardName == "Ace")
    {
      foreach (var card in wrongCards.ace)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "King")
    {
      foreach (var card in wrongCards.king)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "Queen")
    {
      foreach (var card in wrongCards.queen)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "Jack")
    {
      foreach (var card in wrongCards.jack)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "10")
    {
      foreach (var card in wrongCards.ten)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "9")
    {
      foreach (var card in wrongCards.nine)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "8")
    {
      foreach (var card in wrongCards.eight)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "7")
    {
      foreach (var card in wrongCards.seven)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "6")
    {
      foreach (var card in wrongCards.six)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "5")
    {
      foreach (var card in wrongCards.five)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "4")
    {
      foreach (var card in wrongCards.four)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "3")
    {
      foreach (var card in wrongCards.three)
      {
        if (inHand.cardName == card) return true;
      }
    }
    if (inTable.cardName == "2")
    {
      foreach (var card in wrongCards.two)
      {
        if (inHand.cardName == card) return true;
      }
    }
    return false;
  }
}