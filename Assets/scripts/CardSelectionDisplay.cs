using UnityEngine;
using UnityEngine.UI; // חשוב שזה יופיע!

public class CardSelectionDisplay : MonoBehaviour
{
    public Text selectedCountText; // לא TMP_Text

    private void Update()
    {
        if (CardSelectionManager.Instance != null && selectedCountText != null)
        {
            int count = CardSelectionManager.Instance.GetSelectedCount();
            selectedCountText.text = "Selected Cards: " + count.ToString();
        }
    }
}
