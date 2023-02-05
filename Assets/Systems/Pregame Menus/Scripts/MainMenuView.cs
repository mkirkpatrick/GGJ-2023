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
    public AudioSource menuAudioSource;
    public Animator crossfadeAnim;

    void Start()
    {
        playButton.onClick.AddListener(() => StartGame());
        settingsButton.onClick.AddListener(() => GoToSettings());
        exitButton.onClick.AddListener(() => ExitGame());
        menuAudioSource = GetComponent<AudioSource>();
    }

    void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }
    void GoToSettings() {
        menuAudioSource.Play();
        SceneManager.LoadScene("Settings");
    }
    void ExitGame() { 
        Application.Quit();
    }

    IEnumerator StartGameCoroutine()
    {
        menuAudioSource.Play();
        crossfadeAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Intro");
    }
}
