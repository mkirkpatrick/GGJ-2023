using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public PlayerController playerController;
    public DeckController deckController;
    public GameObject crossFade;

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

        deckController = transform.Find("Deck Controller").GetComponent<DeckController>();
        playerController = transform.Find("Player Controller").GetComponent<PlayerController>();

        //crossFade = transform.Find("Crossfade").gameObject;
        DontDestroyOnLoad(crossFade);
    }
    private void Start()
    {
        playerController.player.deckController = this.deckController;

        Screen.SetResolution(1920, 1080, true);
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }
}
