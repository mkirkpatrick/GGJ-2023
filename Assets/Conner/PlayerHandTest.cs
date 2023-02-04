using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandTest : MonoBehaviour
{
    public GameObject[] cardObjs;
    public List<Color> cardColors = new List<Color>();
    GameObject[] inactiveCards;

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

        cardObjs = new GameObject[5];

        for(int i = 0; i < transform.childCount; i++)
        {
            cardObjs[i] = transform.GetChild(i).gameObject;
        }

        AdjustHand();
    }

    void AdjustHand()
    { 
        for(int i = 0; i < cardObjs.Length; i++)
        {
            cardObjs[i].SetActive(true);
            cardObjs[i].GetComponent<Image>().color = cardColors[i];
        }
    }

    public void SelectCard(GameObject cardButton)
    {
        int num = cardButton.GetComponent<CardButtonData>().cardNum;
        cardButton.SetActive(false);

        //Cycle color back to start of list
        Color usedColor = cardColors[num];
        cardColors.RemoveAt(num);
        cardColors.Insert(cardColors.Count, usedColor);

        Invoke("AdjustHand", 1f);
    }

    public void AddCard()
    {
        if(transform.childCount < 5)
        {
            

        }
    }
}
