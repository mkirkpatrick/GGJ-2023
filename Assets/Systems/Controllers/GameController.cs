using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public PlayerController playerController;
    public DeckController deckController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }

        playerController = transform.Find("Player Controller").GetComponent<PlayerController>();
        deckController = transform.Find("Deck Controller").GetComponent<DeckController>();
    }
    private void Start()
    {
        playerController.player.deckController = deckController;

        Screen.SetResolution(1366, 768, false);
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
