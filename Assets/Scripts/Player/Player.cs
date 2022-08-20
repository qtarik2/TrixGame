using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public string playerName { get; set; }
    public int playerID { get; set; }
    public List<Card> playerCard { get; set; }
    public int playerLevel { get; set; }
    public int playerScore { get; set; }

    public Player(string name, int id, List<Card> cards, int level, int score)
    {
        this.playerName = name;
        this.playerID = id;
        this.playerCard = cards;
        this.playerLevel = level;
        this.playerScore = score;
    }

    public Player(List<Card> cards)
    {
        this.playerCard = cards;
    }

    public void DrawCard(int buttonNo, List<Card> inTable, Button slot, int total)
    {
        bool isWrongMove = false;
        // Wrong move Function
        if (inTable.Count > 0)
        {
            isWrongMove = WrongMove.wrongMoveInstance.GetWrongMoves(this.playerCard[buttonNo], inTable[inTable.Count - 1]);

            // Check wrong move
            if (isWrongMove != true)
            {
                // Multiply final value
                inTable.Add(this.playerCard[buttonNo]);
                this.playerCard[buttonNo] = null;
            }
            else
            {
                Debug.Log("A wrong move!");
            }
        }
        else
        {
            inTable.Add(this.playerCard[buttonNo]);
            this.playerCard[buttonNo] = null;
        }

        #region Button
        // CardRules.cardRulesInstance.total = 0;
        if (isWrongMove == true) return;
        if (buttonNo == 0)
            slot.gameObject.SetActive(false);
        if (buttonNo == 1)
            slot.gameObject.SetActive(false);
        if (buttonNo == 2)
            slot.gameObject.SetActive(false);
        if (buttonNo == 3)
            slot.gameObject.SetActive(false);
        if (buttonNo == 4)
            slot.gameObject.SetActive(false);
        if (buttonNo == 5)
            slot.gameObject.SetActive(false);
        if (buttonNo == 6)
            slot.gameObject.SetActive(false);
        if (buttonNo == 7)
            slot.gameObject.SetActive(false);
        if (buttonNo == 8)
            slot.gameObject.SetActive(false);
        if (buttonNo == 9)
            slot.gameObject.SetActive(false);
        if (buttonNo == 10)
            slot.gameObject.SetActive(false);
        #endregion

        CheckCards(total, inTable);

        // if (inTable != null)
        // {
        //     foreach (var card in inTable)
        //     {
        //         GameObject newCopy = Instantiate(makeCopy, parent);
        //     }
        // }
    }

    public void CheckCards(int total, List<Card> inTable)
    {
        CardRules.cardRulesInstance.CardStatus(this.playerCard, inTable);
    }

}
