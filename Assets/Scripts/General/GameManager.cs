using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Player aPlayer = new Player("Tarik", 1, null, 1, 0);
    Player bPlayer = new Player("Sultan", 2, null, 1, 0);
    CommonFunctions commonFunctions;
    CardList cardList;

    // Card in hards
    public int numOfCards = 11;
    public List<GameObject> cardObj;
    public List<Card> aPlayerCardsInHands = new();
    public List<Card> bPlayerCardsInHands = new();

    public List<Card> cardInTable = new();
    int total = 0;

    // UI Part
    public Transform aPlayerRoot;
    public Transform bPlayerRoot;
    public Transform tableSlotRoot;
    public GameObject makeCopy;

    public Button[] buttons;
    public GameObject getBtn;

    // Start is called before the first frame update
    void Start()
    {
        commonFunctions = GetComponent<CommonFunctions>();
        cardList = GetComponent<CardList>();

        StartCoroutine(DisplayCards());
    }

    void Update()
    {

    }

    public IEnumerator DisplayCards()
    {
        yield return new WaitForSeconds(0.5f);

        if (cardList.AllShuffledCard != null)
        {
            aPlayerCardsInHands.AddRange(commonFunctions.GetSliced(cardList.AllShuffledCard, 0, numOfCards));
            aPlayer = new Player(aPlayerCardsInHands);
            bPlayerCardsInHands.AddRange(commonFunctions.GetSliced(cardList.AllShuffledCard, 11, numOfCards));
            bPlayer = new Player(bPlayerCardsInHands);
            // player.GetCardName();

            // Distance from each cards -54
            SetCardInUI(aPlayerCardsInHands, aPlayerRoot, -300, -1000, 64, 0);
            SetCardInUI(bPlayerCardsInHands, bPlayerRoot, -300, 1000, 64, 0);

            // ADD Event Listener
            buttons = getBtn.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                int j = i;
                buttons[i].onClick.AddListener(() => aPlayer.DrawCard(j, cardInTable, buttons[j], total));
            }

            // Check Value
            CheckCards(total);
        }
    }

    public void SetCardInUI(List<Card> cards, Transform parent, int posX, int posY, int incX, int incY)
    {
        for (int i = 0; i < numOfCards; i++)
        {
            GameObject newCopy = Instantiate(makeCopy, parent);
            newCopy.name = "slot" + (i + 1);
            // newCopy.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(test));
            newCopy.GetComponent<RectTransform>().localPosition = new Vector2(posX, posY);
            newCopy.GetComponent<Image>().sprite = cards[i].cardImage;
            posX += incX;
            posY += incY;
        }
    }

    public void CheckCards(int total)
    {
        CardRules.cardRulesInstance.CardStatus(aPlayerCardsInHands, cardInTable);
    }
}
