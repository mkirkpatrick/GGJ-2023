using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject textManager;
    public TextManager textManagerScript;
    public DialogueText dialogueText;
    public AudioSource audioSource;

    void Start()
    {
        textManagerScript = textManager.GetComponent<TextManager>();
        audioSource = GetComponent<AudioSource>();
        dialogueText = GetComponent<DialogueText>();
        StartCoroutine(PauseThenRun());
    }

    IEnumerator PauseThenRun()
    {
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        textManagerScript.StartDialogue(dialogueText);
    }
}
