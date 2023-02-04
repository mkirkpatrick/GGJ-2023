using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public Clan currentClan;
    public int healthCurrent;
    public int healthMax;

    public int nodeLocation = 0;

    public bool attackIsCharged;
    public bool healIsCharged;
    public bool isBleeding;

    public Player() {
        healthCurrent = 30;
        healthMax = 30;
    }
}
