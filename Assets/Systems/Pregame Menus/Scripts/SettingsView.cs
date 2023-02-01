using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsView : MonoBehaviour
{
    public Button fullscreenButton;
    public Button windowedButton;

    public Button res1Button;
    public Button res2Button;
    public Button res3Button;
    public Button res4Button;

    public Button backButton;

    void Start()
    {
        backButton.onClick.AddListener(() => GoToMainMenu());
        fullscreenButton.onClick.AddListener(() => SetFullscreen(true));
        windowedButton.onClick.AddListener(() => SetFullscreen(false));

        res1Button.onClick.AddListener(() => SetScreenResolution(1920, 1080));
        res2Button.onClick.AddListener(() => SetScreenResolution(1600, 900));
        res3Button.onClick.AddListener(() => SetScreenResolution(1366, 768));
        res4Button.onClick.AddListener(() => SetScreenResolution(800, 600));
    }

    void GoToMainMenu()
    {
        Debug.Log("Go to Main Menu");
        SceneManager.LoadScene("Main Menu");
    }
    void SetFullscreen(bool _value) { 
        Screen.fullScreen = _value;
    }
    void SetScreenResolution(int _width, int _height)
    {
        Screen.SetResolution(_width, _height, Screen.fullScreen);
    }
}
