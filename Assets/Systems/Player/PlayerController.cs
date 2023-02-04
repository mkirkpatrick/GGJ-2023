using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Player player;

    private void Awake()
    {
        instance = this;
        player = new Player();
    }
}
