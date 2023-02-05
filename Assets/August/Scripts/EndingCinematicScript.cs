using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCinematicScript : MonoBehaviour
{
    public GameObject textManager;
    public TextManager textManagerScript;
    public DialogueText dialogueText;
    public ParticleSystem redParticles;
    public ParticleSystem blueParticles;
    public ParticleSystem yellowParticles;

    void Start()
    {
        CameraController.instance.Deactivate();
        textManagerScript = textManager.GetComponent<TextManager>();
        dialogueText = GetComponent<DialogueText>();
        StartCoroutine(PauseThenRun());
    }

    IEnumerator PauseThenRun()
    {
        yield return new WaitForSeconds(2f);
        textManagerScript.StartDialogue(dialogueText);
        yield return new WaitForSeconds(22f);
        redParticles.Play();
        blueParticles.Play();
        yellowParticles.Play();
    }    
}
