using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BackgroundIntroScaler : MonoBehaviour, IPointerClickHandler
{
    public float targetScale = 2;
    public float timeToLerp = 50f;
    public float scaleModifier = 1;

    public Button skipButton;

    void Start()
    {
        MusicController.instance.StopMusic();
        skipButton.onClick.AddListener(() => SceneManager.LoadScene("Journey Start"));
        StartCoroutine(LerpFunction(targetScale, timeToLerp));
    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }

        //transform.localScale = startScale * endValue;
        scaleModifier = endValue;
        SceneManager.LoadScene("Journey Start");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        skipButton.gameObject.SetActive(true);
        StartCoroutine(SkipCountdown());
    }
    private IEnumerator SkipCountdown() {
        yield return new WaitForSeconds(5f);
        skipButton.gameObject.SetActive(false);
    }
}
