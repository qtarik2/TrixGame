using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public List<Card> card;
    int numOfCards = 11;
    public Transform root;
    public GameObject makeCopy;

    void Start()
    {
        int setPosition = 0; // 0, 54, 108
        for (int i = 0; i < numOfCards; i++)
        {
            GameObject newCopy = Instantiate(makeCopy, root);
            newCopy.GetComponent<RectTransform>().localPosition = new Vector2(setPosition, 0);
            newCopy.GetComponent<Image>().sprite = card[0].cardImage;
            setPosition += 54;
        }

    }

}
