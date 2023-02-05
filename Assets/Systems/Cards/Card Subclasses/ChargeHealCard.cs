using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charge Heal Card Data", menuName = "ScriptableObjects/Card/UtilityCard/ChargeHealCard")]
public class ChargeHealCard : Card
{
    public override CardType cardType{get{return CardType.Utility;}}
    public override void use(Player p, Enemy e){
        p.healCharge++;
    }
}
