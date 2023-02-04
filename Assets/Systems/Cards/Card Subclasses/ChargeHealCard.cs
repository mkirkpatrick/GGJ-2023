using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charge Heal Card Data", menuName = "ScriptableObjects/Card/UtilityCard/ChargeHealCard")]
public class ChargeHealCard : Card
{
    public override CardType cardType{get{return CardType.Utility;}}
    public override void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged){
        //increase any healing done for the rest of the encounter by 1
        p.healIsCharged = true;
    }
}
