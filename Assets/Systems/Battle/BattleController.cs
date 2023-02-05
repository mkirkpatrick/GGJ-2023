using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    private DeckController deckController;
    private PlayerController playerController;
    public BattleView battleView;
    public HandView handView;

    private void Start()
    {
        deckController = GameController.instance.deckController;

        
       

        // Load Player - health
        // Load Enemy

        //
    }
}
