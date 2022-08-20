using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Empty Card")]
public class Card : ScriptableObject
{
    public int cardID;
    public string cardName;
    public string cardType;
    public int cardWeight;
    public Sprite cardImage;

}
