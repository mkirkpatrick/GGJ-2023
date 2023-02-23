using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Random Card Data", menuName = "ScriptableObjects/Card/UtilityCard/RandomCard")]
public class RandomCard : Card
{
    public override CardType cardType{get{return CardType.Utility;}}
    public override void use(Player p, Enemy e){
        //essentially a "last resort"
        int rand = Random.Range(-5, 5);
        if(rand>0){
            //if it's positive, damage the target
            if(e.isEnemyAction){
                p.healthCurrent -= rand;
            } else {
                e.healthCurrent -= rand;
            }
        } else if (rand<0){
            //if it's negative, damage the user
            if(e.isEnemyAction){
                e.healthCurrent += rand;
            } else {
                p.healthCurrent += rand;
            }
        }
        //if its zero you're out of luck bc nothing happens >.>
        p.healthCurrent = (int)Mathf.Clamp(p.healthCurrent, 0f, p.healthMax);
        e.healthCurrent = (int)Mathf.Clamp(e.healthCurrent, 0f, e.healthMax);
    }
}
