using UnityEngine;

public class DiscardButtonHandler : MonoBehaviour
{
    public void OnDiscardButtonPressed()
    {
        Debug.Log("==== Before Discard ====");
        foreach (var card in CardSelectionManager.Instance.GetSelectedCards())
        {
            Debug.Log("Selected card: " + card.gameObject.name);
        }

        if (CardSelectionManager.Instance.GetSelectedCount() != 0)
        {
            CardSelectionManager.Instance.DiscardSelectedCards();
            Debug.Log("Cards discarded successfully!");
        }
        else
        {
            Debug.LogWarning("No cards selected to discard!");
        }

        Debug.Log("==== After Discard ====");
        foreach (var card in CardSelectionManager.Instance.GetSelectedCards())
        {
            Debug.Log("Selected card: " + card.gameObject.name);
        }
    }
}
