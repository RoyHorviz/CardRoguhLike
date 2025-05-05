using UnityEngine;

public class DiscardButtonHandler : MonoBehaviour
{
    public void OnDiscardButtonPressed()
    {
        if (CardSelectionManager.Instance.GetSelectedCount() > 0)
        {
            CardSelectionManager.Instance.DiscardSelectedCards();
            Debug.Log("Cards discarded successfully!");
        }
        else
        {
            Debug.LogWarning("No cards selected to discard!");
        }
    }
}
