using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType {Attack, Huma, Mani, Nihtee, Heal, Utility };

public abstract class Card : ScriptableObject 
{
   
    public string cardName;
    public string cardDescription;
    public Sprite cardImage;
    public abstract CardType cardType{get;}
    public int effectValue;
    public int id;

    public abstract void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged);

}
