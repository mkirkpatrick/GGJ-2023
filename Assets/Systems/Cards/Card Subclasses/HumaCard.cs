using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Huma Card Data", menuName = "ScriptableObjects/Card/ClanCard/HumaCard")]
public class HumaCard : Card
{
    public override CardType cardType{get{return CardType.Huma;}}
    public override void use(Player p, Enemy e){
        if(e.isEnemyAction){
            p.healthCurrent -= this.effectValue;
            p.healthCurrent = (int)Mathf.Clamp(p.healthCurrent, 0f, p.healthMax);
        }
        else {
            e.healthCurrent -= this.effectValue;
            e.healthCurrent = (int)Mathf.Clamp(e.healthCurrent, 0f, e.healthMax);
        }
    }
}
