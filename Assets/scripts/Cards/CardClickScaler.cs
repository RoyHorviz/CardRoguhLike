using UnityEngine;
using UnityEngine.EventSystems;

public class CardClickScaler : MonoBehaviour, IPointerClickHandler
{
    private RectTransform rectTransform;
    private bool isSelected = false;
    private bool isDiscarded = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDiscarded) return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isSelected)
            {
                if (CardSelectionManager.Instance.TrySelectCard(this))
                {
                    SetSelected(true);
                }
            }
            else
            {
                SetSelected(false, true); // Manual deselection
            }
        }
    }

    public void SetSelected(bool selected, bool manual = false)
    {
        isSelected = selected;
        rectTransform.localScale = selected ? Vector3.one * 1.2f : Vector3.one;

        if (!selected && manual)
        {
            CardSelectionManager.Instance.DeselectCard(this);
        }
    }

    public void Discard()
    {
        isDiscarded = true;

        // Fully deselect from selection manager
        SetSelected(false, true); // 'true' makes sure it's removed from the list

        gameObject.SetActive(false); // Hide the card
    }

}
