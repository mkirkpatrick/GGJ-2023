using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Reflect Card Data", menuName = "ScriptableObjects/Card/UtilityCard/ReflectCard")]
public class ReflectCard : Card
{
    public override CardType cardType{get{return CardType.Utility;}}
    public override void use(Player p, Enemy e, bool isEnemyAction, bool attackIsCharged, bool healIsCharged){
        //when used, make the enemy card switch the user and target 
        e.isEnemyAction = !isEnemyAction;
    }
}
