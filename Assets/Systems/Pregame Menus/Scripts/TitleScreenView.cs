using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenView : MonoBehaviour
{
    public Image logo;
    public float ScreenWaitTime = 2f;
    //public Animator crossfadeAnimator;

    void Start()
    {
        StartCoroutine(LoadMainMenu(ScreenWaitTime));
    }
    
    IEnumerator LoadMainMenu(float _time)
    {
        MusicController.instance.PlaySong(MusicController.SongTitles.Beginning);
        yield return new WaitForSeconds(_time);
        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Menu");
    }
}
