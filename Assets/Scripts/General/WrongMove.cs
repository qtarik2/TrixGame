using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongMove : MonoBehaviour
{
    public static WrongMove wrongMoveInstance;

    void Awake()
    {
        if (wrongMoveInstance != null && wrongMoveInstance != this)
        {
            Destroy(this);
        }
        else
        {
            wrongMoveInstance = this;
        }
    }

    public bool GetWrongMoves(Card inHand, Card inTable)
    {
        Dictionary<int, int[,]> clubsIgnoredList = new();
        Dictionary<int, int[,]> diamondsIgnoredList = new();
        Dictionary<int, int[,]> heartsIgnoredList = new();
        Dictionary<int, int[,]> spadesIgnoredList = new();

        #region Clubs  
        clubsIgnoredList.Add(1, new int[,] { { 2 }, { 3 }, { 6 } });
        clubsIgnoredList.Add(2, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(3, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(4, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(5, new int[,] { { 1 }, { 6 }, { 5 } });
        clubsIgnoredList.Add(6, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(7, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(8, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(9, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(10, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(11, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(12, new int[,] { { 2 }, { 3 }, { 5 } });
        clubsIgnoredList.Add(13, new int[,] { { 2 }, { 3 }, { 5 } });
        #endregion

        #region Diamonds  
        diamondsIgnoredList.Add(1, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(2, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(3, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(4, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(5, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(6, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(7, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(8, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(9, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(10, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(11, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(12, new int[,] { { 2 }, { 3 }, { 5 } });
        diamondsIgnoredList.Add(13, new int[,] { { 2 }, { 3 }, { 5 } });
        #endregion

        #region Hearts  
        heartsIgnoredList.Add(1, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(2, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(3, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(4, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(5, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(6, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(7, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(8, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(9, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(10, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(11, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(12, new int[,] { { 2 }, { 3 }, { 5 } });
        heartsIgnoredList.Add(13, new int[,] { { 2 }, { 3 }, { 5 } });
        #endregion

        #region Spades  
        spadesIgnoredList.Add(1, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(2, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(3, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(4, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(5, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(6, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(7, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(8, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(9, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(10, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(11, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(12, new int[,] { { 2 }, { 3 }, { 5 } });
        spadesIgnoredList.Add(13, new int[,] { { 2 }, { 3 }, { 5 } });
        #endregion


        foreach (var card in clubsIgnoredList)
        {
            if (card.Key == inTable.cardID)
            {
                foreach (var ignore in card.Value)
                {
                    if (inHand.cardID == ignore) return true;
                }
            }
        }
        return false;
    }
}
