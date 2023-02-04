using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "ScriptableObjects/Enemy")]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public int healthCurrent;
    public int healthMax;
    public Sprite sprite;

    public bool isBleeding;
    public bool isEnemyAction;
}
