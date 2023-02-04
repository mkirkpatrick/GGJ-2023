using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Image dialoguePanel;
    public Queue<string> sentences;
    public string currentText;
    public AudioSource typingAudio;


    void Start()
    {
        typingAudio = GetComponent<AudioSource>();
        sentences = new Queue<string>();
    }

    //To use this in a script:
    //1. Create a "public DialogueText dialogueText" at the beginning of your script.
    //2. In the inspector of the object with the script attached, choose the number of sentences and fill in the text boxes with your desired text.
    //3. Link it to this script/the TextManager with GetComponenet or whatever.
    //4. Run "StartDialogue(dialogueText)" function.
    //It should take care of the rest!

    public void StartDialogue(DialogueText dialogue)
    {
        dialogueText.gameObject.SetActive(true);
        dialoguePanel.gameObject.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
  
        StartCoroutine(DisplayNextSentenceCoroutine());

    }

    public void DisplayNextSentence()
    {
        StartCoroutine(DisplayNextSentenceCoroutine());
    }

    IEnumerator DisplayNextSentenceCoroutine()
    {
        string sentence = sentences.Dequeue();

        for (int i = 0; i < sentence.Length; i++)
        {
            if (typingAudio.isPlaying == false)
            {
            typingAudio.Play();
            }
            currentText = sentence.Substring(0, i + 1);
            dialogueText.text = currentText;
            yield return new WaitForSeconds(.03f);
        }

        yield return new WaitForSeconds(3f);
        if (sentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            DisplayNextSentence();
        }
    }


    public void EndDialogue()
    {
        dialogueText.text = " ";
        sentences.Clear();
        dialoguePanel.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
    }

}
