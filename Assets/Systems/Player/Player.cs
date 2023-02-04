using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public Clan currentClan;
    public int health;

    public Player() {
        health = 30;
    }
}