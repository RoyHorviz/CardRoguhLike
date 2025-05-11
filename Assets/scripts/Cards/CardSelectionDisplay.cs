using UnityEngine;
using UnityEngine.UI; 

public class CardSelectionDisplay : MonoBehaviour
{
    public Text selectedCountText; 

    private void Update()
    {
        if (CardSelectionManager.Instance != null && selectedCountText != null)
        {
            int count = CardSelectionManager.Instance.GetSelectedCount();
            selectedCountText.text = "Selected Cards: " + count.ToString();
        }
    }
}
