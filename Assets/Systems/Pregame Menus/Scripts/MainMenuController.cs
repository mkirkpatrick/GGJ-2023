using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button playButton;
    public Button viewIntroButton;
    public Button creditsButton;
    public Button settingsButton;

    void Start()
    {
        settingsButton.onClick.AddListener(() => GoToSettings());
    }

    void GoToSettings() {
        SceneManager.LoadScene("Settings");
    }
}
