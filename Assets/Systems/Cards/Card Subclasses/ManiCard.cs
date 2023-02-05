using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mani Card Data", menuName = "ScriptableObjects/Card/ClanCard/ManiCard")]
public class ManiCard : Card
{
    public override CardType cardType{get{return CardType.Mani;}}
    public override void use(Player p, Enemy e){
        //steal 5 hp from target
        if(e.isEnemyAction){
            p.healthCurrent -= 5;
            e.healthCurrent += 5;
        } else {
            e.healthCurrent -= 5;
            p.healthCurrent += 5;
        }

        p.healthCurrent = (int)Mathf.Clamp(p.healthCurrent, 0f, p.healthMax);
        e.healthCurrent = (int)Mathf.Clamp(e.healthCurrent, 0f, e.healthMax);
    }
}
