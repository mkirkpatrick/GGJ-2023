using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenView : MonoBehaviour
{
    public Image logo;
    public float ScreenWaitTime = 2f;
    public Animator crossfadeAnimator;

    void Start()
    {
        MusicController.instance.PlaySong(MusicController.SongTitles.Ending);
        StartCoroutine(LoadMainMenu(ScreenWaitTime));
    }
    
    IEnumerator LoadMainMenu(float _time)
    {
        yield return new WaitForSeconds(_time);
        crossfadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Menu");
    }
}
