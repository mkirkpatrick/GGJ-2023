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

    private void Start()
    {
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
        PlayerController.instance.player.currentClan = currentlySelectedClan;
        SceneManager.LoadScene("Root Map");
    }
}
