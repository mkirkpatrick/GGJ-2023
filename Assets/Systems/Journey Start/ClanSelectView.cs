using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClanSelectView : MonoBehaviour
{
    public List<Clan> clanSelectList;
    public Clan currentlySelectedClan = null;

    public Button humaButton;
    public Button maniButton;
    public Button niteeButton;

    public Button beginJourneyButton;

    private void Start()
    {
        humaButton.onClick.AddListener(() => SelectClan(0));
        maniButton.onClick.AddListener(() => SelectClan(1));
        niteeButton.onClick.AddListener(() => SelectClan(2));

        beginJourneyButton.onClick.AddListener(() => BeginJourney(currentlySelectedClan));
    }

    private void SelectClan(int _index) {
        currentlySelectedClan = clanSelectList[_index];
    }

    private void BeginJourney(Clan _clan) {
        PlayerController.instance.currentClan = _clan;
        SceneManager.LoadScene("Root Map");
    }
}
