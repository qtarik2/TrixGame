using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName ="ScriptableObjects/Empty Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string cardType;
    public int cardWeight;
    public Sprite cardImage;
    
}
