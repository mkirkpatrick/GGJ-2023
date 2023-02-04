using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NihTee Card Data", menuName = "ScriptableObjects/Card/ClanCard/NihTeeCard")]
public class NihTeeCard : Card
{
    public override CardType cardType{get{return CardType.Nihtee;}}
    public override void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged){
        //apply bleed to target
        if(isEnemyAction){
            p.isBleeding = true;
        } else {
            e.isBleeding = true;
        }
    }
}
