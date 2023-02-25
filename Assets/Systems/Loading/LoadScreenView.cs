using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenView : MonoBehaviour
{
    public float loadTime = 5f;

    private void Start()
    {
        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeIn");
        StartCoroutine(LoadRoutine());
    }

    IEnumerator LoadRoutine()
    {
        SoundEffectsController.instance.PlaySound("Cave Ambiene Loop");
        yield return new WaitForSeconds(loadTime);

        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeOut");
        yield return new WaitForSeconds(1f);

        SoundEffectsController.instance.StopSounds();

        SceneManager.LoadScene("Battle");
    }
}
