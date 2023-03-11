using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenView : MonoBehaviour
{
    [SerializeField]
    private float loadTime = 5f;
    [SerializeField]
    private GameObject hintParent;
    private int hintNum = 0;

    private void Start()
    {
        hintNum = PlayerController.instance.player.nodeLocation - 1;
        LoadHintScreen(hintNum);

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

    void LoadHintScreen(int hintNum)
    {
        Transform hintTransform = hintParent.transform;
        for (int i = 0; i < hintTransform.childCount; i++)
        {
            hintTransform.GetChild(i).gameObject.SetActive(false);
        }

        hintTransform.GetChild(hintNum).gameObject.SetActive(true);
    }
}
