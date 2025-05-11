using UnityEngine;

public class RightClickClear : MonoBehaviour
{
    void Update()
    {
        // Detect right mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            // Clear all selected cards
            CardSelectionManager.Instance.DeselectAllCards();
        }
    }
}
