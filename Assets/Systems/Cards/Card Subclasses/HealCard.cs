using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Card Data", menuName = "ScriptableObjects/Card/HealCard")]
public class HealCard : Card
{
    public override CardType cardType{get{return CardType.Heal;}}
    public override void use(Player p, Enemy e){ 
        //increase user HP by effect value 
        if(e.isEnemyAction){
            e.healthCurrent += this.effectValue;
            e.healthCurrent = (int)Mathf.Clamp(e.healthCurrent, 0f, e.healthMax);
        } else {
            p.healthCurrent += (this.effectValue+p.healCharge);
            p.healthCurrent = (int)Mathf.Clamp(p.healthCurrent, 0f, p.healthMax);
        }
    }
}
