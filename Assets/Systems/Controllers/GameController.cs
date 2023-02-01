using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

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
    }
    private void Start()
    {

        Screen.SetResolution(1280, 720, false);
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
