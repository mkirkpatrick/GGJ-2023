using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandView : MonoBehaviour
{
    public GameObject[] cardSlots;

    private void Start()
    {
        cardSlots = new GameObject[5];

        for(int i = 0; i < transform.childCount; i++)
        {
            cardSlots[i] = transform.GetChild(i).gameObject;
        }
    }

    public void SelectCard(int _index) {
        cardSlots[_index].SetActive(false);

    }

    private void AdjustHand()
    {
        for(int i = 0; i < cardSlots.Length; i++)
        {

        }
    }
}
