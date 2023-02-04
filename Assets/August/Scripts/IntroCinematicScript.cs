using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCinematicScript : MonoBehaviour
{
    public GameObject textManager;
    public TextManager textManagerScript;
    public DialogueText dialogueText;


    void Start()
    {
        textManagerScript = textManager.GetComponent<TextManager>();
        dialogueText = GetComponent<DialogueText>();
        StartCoroutine(PauseThenRun());
    }

    IEnumerator PauseThenRun()
    {
        yield return new WaitForSeconds(2f);
        textManagerScript.StartDialogue(dialogueText);
    }
}