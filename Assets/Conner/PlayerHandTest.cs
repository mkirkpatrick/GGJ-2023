using UnityEngine;
using UnityEngine.UI;

public class PlayerHandTest : MonoBehaviour
{
    public RectTransform[] cardRects;
    int cardCount;

    private void Start()
    {
        AdjustHand();
    }

    void AdjustHand()
    {
        cardRects = GetComponentsInChildren<RectTransform>();

        float offset = 200f;
        float newX = 0f;

        for (int i = 0; i < cardRects.Length; i++)
        {
            cardRects[i].anchoredPosition = new Vector2(newX, 0f);
            newX = newX + offset;
        }
    }

    public void SelectCard(GameObject card)
    {
        card.SetActive(false);
        AdjustHand();
    }

    private void OnDrawGizmos()
    {

    }
}
