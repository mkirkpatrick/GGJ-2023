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
    //public Animator crossfadeAnim;

    void Start()
    {
        playButton.onClick.AddListener(() => StartGame());
        settingsButton.onClick.AddListener(() => GoToSettings());
        creditsButton.onClick.AddListener(() => GoToCredits());
        exitButton.onClick.AddListener(() => ExitGame());

        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeIn");
        MusicController.instance.PlaySong(MusicController.SongTitles.Beginning);
    }

    void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }
    void GoToSettings() {
        SoundEffectsController.instance.PlaySound("Confirm Selection");
        SceneManager.LoadScene("Settings");
    }

    void GoToCredits() {
        SoundEffectsController.instance.PlaySound("Confirm Selection");
        SceneManager.LoadScene("Credits");
    }

    void ExitGame() {
        SoundEffectsController.instance.PlaySound("Confirm Selection");
        Application.Quit();
    }

    IEnumerator StartGameCoroutine()
    {
        ResetGameData();
        SoundEffectsController.instance.PlaySound("Confirm Selection");
        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Intro");
    }

    void ResetGameData()
    {

        //Reset enemies
    }
}
