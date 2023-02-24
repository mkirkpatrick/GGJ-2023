using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatText : MonoBehaviour
{
    public TMP_Text combatText;
    private float timeDestroy;

    public void Initialize(string _text, Color _color, float _time)
    {
        combatText.text = _text;
        combatText.color = _color;
        timeDestroy = _time;
        StartCoroutine(FloatText());
    }

    private IEnumerator FloatText() {

        float timer = 0f;

        while (timer < 1)
        {
            timer += Time.deltaTime / timeDestroy;

            yield return null;
        }

        Destroy(gameObject);
    }
}
