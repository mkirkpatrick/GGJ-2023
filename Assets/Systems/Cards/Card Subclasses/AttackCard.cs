using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Card Data", menuName = "ScriptableObjects/Card/AttackCard")]
public class AttackCard : Card
{
    public override CardType cardType{get{return CardType.Attack;}}
    public override void use(Player p, Enemy e){ 
        //decrease target hp by effect value
        if(e.isEnemyAction){
            p.healthCurrent -= this.effectValue;
            p.healthCurrent = (int)Mathf.Clamp(p.healthCurrent, 0f, p.healthMax);
        } else {
            e.healthCurrent -= (this.effectValue+p.attackCharge);
            e.healthCurrent = (int)Mathf.Clamp(e.healthCurrent, 0f, e.healthMax);
        }
    }
}
