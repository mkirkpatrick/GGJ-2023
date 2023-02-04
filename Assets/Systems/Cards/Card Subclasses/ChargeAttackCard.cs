using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charge Attack Card Data", menuName = "ScriptableObjects/Card/UtilityCard/ChargeAttackCard")]
public class ChargeAttackCard : Card
{
    public override CardType cardType{get{return CardType.Utility;}}
    public override void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged){
        //increases damage done by attack cards by 1 until end of encounter
        p.attackIsCharged = true;
    }
}
