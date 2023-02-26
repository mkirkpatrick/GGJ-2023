using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCinematicScript : MonoBehaviour
{
    public GameObject textManager;
    public TextManager textManagerScript;
    public DialogueText dialogueText;
    //public ParticleSystem redParticles;
    //public ParticleSystem blueParticles;
    //public ParticleSystem yellowParticles;

    void Start()
    {
        CameraController.instance.Deactivate();
        MusicController.instance.PlaySong(MusicController.SongTitles.Beetle_Enlightenment);
        textManagerScript = textManager.GetComponent<TextManager>();
        dialogueText = GetComponent<DialogueText>();
        StartCoroutine(PauseThenRun());
    }

    IEnumerator PauseThenRun()
    {
        yield return new WaitForSeconds(2f);
        textManagerScript.StartDialogue(dialogueText);
        yield return new WaitForSeconds(65f);
        //redParticles.Play();
        //blueParticles.Play();
        //yellowParticles.Play();
        SceneManager.LoadScene("Main Menu");
    }
}
