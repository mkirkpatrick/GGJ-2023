using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shuffle Card Data", menuName = "ScriptableObjects/Card/UtilityCard/ShuffleCard")]
public class ShuffleCard : Card
{
    public override CardType cardType{get{return CardType.Utility;}}
    public override void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged){
        //call the deck method to shuffle, send boolean of true (include hand)
    }
}
