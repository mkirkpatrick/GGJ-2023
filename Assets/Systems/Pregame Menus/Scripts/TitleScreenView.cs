using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenView : MonoBehaviour
{
    public Image logo;
    private float currentTime = 0f;
    public float ScreenWaitTime = 2f;

    // Update is called once per frame
    void Start()
    {
        MusicController.instance.PlaySong(MusicController.SongTitles.Ending);
        StartCoroutine(LoadMainMenu(ScreenWaitTime));
    }

    IEnumerator LoadMainMenu(float _time)
    {
        yield return new WaitForSeconds(_time);

        SceneManager.LoadScene("Main Menu");
    }
}
