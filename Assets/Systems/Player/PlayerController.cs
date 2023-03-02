using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Player player;
    public List<AnimationClip> idleAnimations;
    public DeckController deckController;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        deckController = DeckController.instance;
    }

    public void CreateEnemyList(Enemy[] enemyReferences){
        player.enemyStages[0] = enemyReferences[3];
        if(player.currentClan.clanName.Equals("Huma")){
            player.enemyStages[1] = enemyReferences[1];
            player.enemyStages[3] = enemyReferences[2];
        } else if (player.currentClan.clanName.Equals("Mani")){
            player.enemyStages[1] = enemyReferences[0];
            player.enemyStages[3] = enemyReferences[2];
        } else if (player.currentClan.clanName.Equals("Nih-Tee")){
            player.enemyStages[1] = enemyReferences[0];
            player.enemyStages[3] = enemyReferences[1];
        }
        player.enemyStages[2] = enemyReferences[5];
        player.enemyStages[4] = enemyReferences[4];
    }

    public void CheckClanVictory (int node, DeckController dc){
        Debug.Log("checking clan victory");
        Debug.Log("node is : " + node);
        if(node == 1){
            Debug.Log("adding card");
            if(player.currentClan.clanName.Equals("Huma")){
                //add index 1 in clan cards
                dc.addClanCard(1, player.deck);
            } else if (player.currentClan.clanName.Equals("Mani")){
                //add index 0 in clan cards
                dc.addClanCard(0, player.deck);
            } else if (player.currentClan.clanName.Equals("Nih-Tee")){
                // add index 0 in clan cards
                dc.addClanCard(0, player.deck);
            } 
        } else if (node == 3){
            Debug.Log("adding card");
            if(player.currentClan.clanName.Equals("Huma")){
                //add index 2 in clan cards
                dc.addClanCard(2, player.deck);
            } else if (player.currentClan.clanName.Equals("Mani")){
                //add index 2 in clan cards
                dc.addClanCard(2, player.deck);
            } else if (player.currentClan.clanName.Equals("Nih-Tee")){
                // add index 1 in clan cards
                dc.addClanCard(1, player.deck);
            }
        }
    }

    public void CreateNewPlayer(Clan _clan)
    {
        player = new Player(_clan);
        player.deck = deckController.GetNewDeck(player);
    }
}