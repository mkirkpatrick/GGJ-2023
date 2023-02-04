using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Card Data", menuName = "ScriptableObjects/Card/HealCard")]
public class HealCard : Card
{
    public override CardType cardType{get{return CardType.Heal;}}
    public override void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged){ 
        //increase user HP by effect value 
        if(isEnemyAction){
            e.healthCurrent+=this.effectValue;
        } else if (healIsCharged){
            //if charged (has used the charge heal card) increase healing by 1
            p.healthCurrent+=(this.effectValue+1);
        } else {
            p.healthCurrent+=this.effectValue;
        }
    }
}