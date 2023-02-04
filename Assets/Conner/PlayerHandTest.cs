using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandTest : MonoBehaviour
{
    public List<Color> cardColors = new List<Color>();
    GameObject[] inactiveCards;

    public GameObject[] cardSlots;

    private void Start()
    {
        cardColors.Add(Color.white);
        cardColors.Add(Color.red);
        cardColors.Add(Color.blue);
        cardColors.Add(Color.yellow);
        cardColors.Add(Color.green);
        cardColors.Add(Color.cyan);
        cardColors.Add(Color.magenta);
        cardColors.Add(Color.black);

        cardSlots = new GameObject[5];

        for(int i = 0; i < transform.childCount; i++)
        {
            cardSlots[i] = transform.GetChild(i).gameObject;
        }

        AdjustHand();
    }

    void AdjustHand()
    { 
        for(int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].SetActive(true);
            cardSlots[i].GetComponent<Image>().color = cardColors[i];
        }
    }

    public void SelectCard(int slotNum)
    {
        cardSlots[slotNum].SetActive(false);

        //Cycle color back to start of list
        Color usedColor = cardColors[slotNum];
        cardColors.RemoveAt(slotNum);
        cardColors.Insert(cardColors.Count, usedColor);

        Invoke("AdjustHand", 1f);
    }
}
