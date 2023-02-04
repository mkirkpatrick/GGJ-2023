using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType {Attack, Huma, Mani, Nihtee, Heal, Utility };

[CreateAssetMenu(fileName = "New Card Data", menuName = "ScriptableObjects/Card")]
public class Card : ScriptableObject 
{
   
    public string cardName;
    public string cardDescription;
    public Sprite cardImage;
    public CardType cardType;
    public int effectValue;
    public int id;


}
