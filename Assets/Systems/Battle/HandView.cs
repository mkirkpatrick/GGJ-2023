using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandView : MonoBehaviour
{
    public Button card1Button;
    public Button card2Button;
    public Button card3Button;
    public Button card4Button;
    public Button card5Button;

    private void Start()
    {
        card1Button.onClick.AddListener( () => SelectCard(1));
    }

    private void SelectCard(int _index) { 
    
    }
}
