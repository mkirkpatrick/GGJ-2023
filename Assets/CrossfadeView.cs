using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossfadeView : MonoBehaviour
{
    public Animator crossfadeAnim;

    private void Awake()
    {
        crossfadeAnim = GetComponentInChildren<Animator>();
    }

    public void FadeState(string fadeState)
    {
        crossfadeAnim.Play(fadeState);
    }
}
