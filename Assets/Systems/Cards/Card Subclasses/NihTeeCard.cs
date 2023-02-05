using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NihTee Card Data", menuName = "ScriptableObjects/Card/ClanCard/NihTeeCard")]
public class NihTeeCard : Card
{
    public override CardType cardType{get{return CardType.Nihtee;}}
    public override void use(Player p, Enemy e){
        //apply bleed to target
        if(e.isEnemyAction){
            p.bleedValue += this.effectValue;
        } else {
            e.bleedValue += this.effectValue;
        }
    }
}
