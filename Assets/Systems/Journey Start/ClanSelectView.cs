using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ClanSelectView : MonoBehaviour
{
    public List<Clan> clanSelectList;
    public Clan currentlySelectedClan = null;

    public Button humaButton;
    public Button maniButton;
    public Button niteeButton;

    public TMP_Text description;

    public Button beginJourneyButton;

    public Animator crossfadeAnim;

    public AudioSource clanSelectAudioSource;

    public Enemy[] enemyReferences = new Enemy[6];

    private void Start()
    {
        clanSelectAudioSource = GetComponent<AudioSource>();

        MusicController.instance.PlaySong(MusicController.SongTitles.Root_Map);

        humaButton.onClick.AddListener(() => SelectClan(0));
        maniButton.onClick.AddListener(() => SelectClan(1));
        niteeButton.onClick.AddListener(() => SelectClan(2));

        beginJourneyButton.onClick.AddListener(() => BeginJourney());

        description.text = "Choose your clan.";
    }

    private void SelectClan(int _index) {
        currentlySelectedClan = clanSelectList[_index];
        description.text = currentlySelectedClan.description;
    }

    private void BeginJourney() {

        if (currentlySelectedClan == null)
            return;

        StartCoroutine(BeginJourneyCoroutine());
    }

    IEnumerator BeginJourneyCoroutine()
    {
        crossfadeAnim.SetTrigger("FadeOut");
        clanSelectAudioSource.Play();
        yield return new WaitForSeconds(1f);
        PlayerController.instance.player.currentClan = currentlySelectedClan;
        PlayerController.instance.CreateEnemyList(enemyReferences);
        SceneManager.LoadScene("Root Map");
    }
}
