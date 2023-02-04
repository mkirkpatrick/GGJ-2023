using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIntroScaler : MonoBehaviour
{
    float targetScale = 2;
    float timeToLerp = 50f;
    float scaleModifier = 1;

    void Start()
    {
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
    }
}
