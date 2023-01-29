using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreenController : MonoBehaviour
{
    public float ScreenWaitTime = 2f;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(LoadDashboard(ScreenWaitTime));
    }

    IEnumerator LoadDashboard(float _time)
    {
        yield return new WaitForSeconds(_time);

        SceneManager.LoadScene("Main Menu");
    }
}
