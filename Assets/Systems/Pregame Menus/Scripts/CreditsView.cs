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
        Debug.Log("Clicked");
        SceneManager.LoadScene("Main Menu");
    }

    void Update()
    {
        
    }
}
