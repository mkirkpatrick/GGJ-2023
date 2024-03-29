using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*for a specific enemy to use against player, not other way around
[CreateAssetMenu(fileName = "New Yoink Card Data", menuName = "ScriptableObjects/Card/UtilityCard/EnemyYoinkCard")]
public class YoinkCard : Card
{
    public override CardType cardType{get{return CardType.Utility;}}
    DeckController deckController;
    public override void use(Player p, Enemy e){
        //takes a random card from the players hand and confiscates it until the end of round 
        //(actual deck remains unchanged, only the cards in play)
        deckController = GameController.instance.deckController;
        int rand = Random.Range(0, 5);
        p.deck.hand.RemoveAt(rand);
        deckController.DrawUntilFull(p.deck);
    }
}
