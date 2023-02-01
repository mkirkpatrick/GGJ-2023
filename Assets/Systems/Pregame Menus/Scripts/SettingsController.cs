using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
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
    }

    void GoToMainMenu()
    {
        Debug.Log("Go to Main Menu");
        SceneManager.LoadScene("Main Menu");
    }
}
