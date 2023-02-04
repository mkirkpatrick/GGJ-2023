using UnityEngine;
using UnityEngine.UI;

public class PlayerHandTest : MonoBehaviour
{
    public RectTransform[] cardRects;
    public float[] cardRadii;
    int cardCount;
    public float initialOffset = 200f;
    public bool centered = false;

    private void Start()
    {
        AdjustHand();
    }

    void AdjustHand()
    {
        /*
        cardCount = transform.childCount;

        //Generate data
        cardRects = new RectTransform[cardCount];
        cardRadii = new float[cardCount];

        for(int i = 0; i < cardCount; i++)
        {
            RectTransform currentRect = transform.GetChild(i).GetComponent<RectTransform>();
            cardRects[i] = currentRect;
            cardRadii[i] = currentRect.rect.width / 2;
        }

        //Execute on data
        float totalOffset = initialOffset + cardRadii[0];
        float bwBuffer = 80f;

        for(int i = 0; i < cardCount; i++)
        {
            cardRects[i].anchoredPosition = new Vector2(totalOffset, 0f);
            totalOffset += cardRadii[i] + bwBuffer + cardRadii[(i + 1) % cardCount];
        }

        /*
        cardRects = GetComponentsInChildren<RectTransform>();

        float offset = 200f;
        float newX = 0f;

        for (int i = 0; i < cardRects.Length; i++)
        {
            cardRects[i].anchoredPosition = new Vector2(newX, 0f);
            newX = newX + offset;
        }
        */
    }

    public void SelectCard(GameObject card)
    {
        card.SetActive(false);
        AdjustHand();
    }
}
