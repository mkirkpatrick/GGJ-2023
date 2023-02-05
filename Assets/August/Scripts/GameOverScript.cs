using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject textManager;
    public TextManager textManagerScript;
    public DialogueText dialogueText;
    public AudioSource audioSource;
    public Animator crossfadeAnim;

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
        yield return new WaitForSeconds(8f);
        crossfadeAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Menu");
    }
}
