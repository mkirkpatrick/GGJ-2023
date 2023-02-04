using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Random Card Data", menuName = "ScriptableObjects/Card/UtilityCard/RandomCard")]
public class RandomCard : Card
{
    public override CardType cardType{get{return CardType.Utility;}}
    public override void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged){
        //essentially a "last resort"
        int rand = Random.Range(-5, 5);
        if(rand>0){
            //if it's positive, damage the target
            e.healthCurrent-=rand;
        } else if (rand<0){
            //if it's negative, damage the user
            p.healthCurrent-=rand;
        }
        //if its zero you're out of luck >.>
    }
}
