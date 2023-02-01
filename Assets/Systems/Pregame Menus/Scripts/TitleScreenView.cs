using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreenView : MonoBehaviour
{
    public float ScreenWaitTime = 2f;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(LoadMainMenu(ScreenWaitTime));
    }

    IEnumerator LoadMainMenu(float _time)
    {
        yield return new WaitForSeconds(_time);

        SceneManager.LoadScene("Main Menu");
    }
}
