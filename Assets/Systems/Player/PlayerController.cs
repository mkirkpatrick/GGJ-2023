using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Player player;
    public List<AnimationClip> idleAnimations;

    private void Awake()
    {
        instance = this;
        CreateNewPlayer();
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

    public void CreateNewPlayer()
    {
        player = new Player();
    }
}
