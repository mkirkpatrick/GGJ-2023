using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Huma Card Data", menuName = "ScriptableObjects/Card/ClanCard/HumaCard")]
public class HumaCard : Card
{
    public override CardType cardType{get{return CardType.Huma;}}
    public override void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged){
        if(isEnemyAction){
            p.healthCurrent-=this.effectValue;
        } else {
            e.healthCurrent-=this.effectValue;
        }
    }
}
