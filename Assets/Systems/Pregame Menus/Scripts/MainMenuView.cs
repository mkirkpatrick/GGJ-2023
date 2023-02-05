using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    public Button playButton;
    public Button creditsButton;
    public Button settingsButton;
    public Button exitButton;

    void Start()
    {
        playButton.onClick.AddListener(() => StartGame());
        settingsButton.onClick.AddListener(() => GoToSettings());
        exitButton.onClick.AddListener(() => ExitGame());
    }

    void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }
    void GoToSettings() {
        SceneManager.LoadScene("Settings");
    }
    void ExitGame() { 
        Application.Quit();
    }
}
