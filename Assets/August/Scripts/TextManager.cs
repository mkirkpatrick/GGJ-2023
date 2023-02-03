using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Image dialoguePanel;
    public Button nextButton;
    public Queue<string> sentences;
    public string currentText;


    void Start()
    {
        sentences = new Queue<string>();
    }


    void Update()
    {
        if (sentences.Count > 0)
        {
            nextButton.gameObject.SetActive(true);
        }
        else
        {
            nextButton.gameObject.SetActive(false);
        }
    }

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

            currentText = sentence.Substring(0, i + 1);
            dialogueText.text = currentText;

            yield return new WaitForSeconds(.01f);
        }
    }


    public void EndDialogue()
    {
        dialogueText.text = " ";
        dialoguePanel.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }

}
