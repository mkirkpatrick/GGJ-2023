using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsView : MonoBehaviour
{
    public Button backButton;

    void Start()
    {
        backButton.onClick.AddListener(() => GoToMainMenu());
    }

    public void GoToMainMenu()
    {
        SoundEffectsController.instance.PlaySound("Confirm Selection");
        SceneManager.LoadScene("Main Menu");
    }
}
