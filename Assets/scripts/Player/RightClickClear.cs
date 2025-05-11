using UnityEngine;

public class RightClickClear : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right Click
        {
            CardSelectionManager.Instance.DeselectAllCards();
        }
    }
}
