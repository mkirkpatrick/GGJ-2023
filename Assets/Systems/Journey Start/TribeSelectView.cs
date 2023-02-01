using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TribeSelectView : MonoBehaviour
{
    public List<Tribe> tribeSelectList;
    public Tribe currentlySelectedTribe = null;

    public Button tribe1Button;
    public Button tribe2Button;
    public Button tribe3Button;

    private void Start()
    {
        tribe1Button.onClick.AddListener(() => SelectTribe(0));
        tribe2Button.onClick.AddListener(() => SelectTribe(1));
        tribe3Button.onClick.AddListener(() => SelectTribe(2));
    }

    private void SelectTribe(int _index) {
        currentlySelectedTribe = tribeSelectList[_index];
    }
}
