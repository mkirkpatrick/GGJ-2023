using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Card Data", menuName = "ScriptableObjects/Card/AttackCard")]
public class AttackCard : Card
{
    public override CardType cardType{get{return CardType.Attack;}}
    public override void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged){ 
        //decrease target hp by effect value
        if(isEnemyAction){
            p.healthCurrent-=this.effectValue;
            p.healthCurrent = (int)Mathf.Clamp(p.healthCurrent, 0f, p.healthMax);
        } else if (attackIsCharged){
            //if charge attack card has been played by the player, damage increased by 1
            e.healthCurrent-=(this.effectValue+1);
            e.healthCurrent = (int)Mathf.Clamp(e.healthCurrent, 0f, e.healthMax);
        } else {
            e.healthCurrent-=this.effectValue;
            e.healthCurrent = (int)Mathf.Clamp(e.healthCurrent, 0f, e.healthMax);
        }
    }
}
