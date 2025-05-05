using UnityEngine;
using UnityEngine.EventSystems;

public class CardClickScaler : MonoBehaviour, IPointerClickHandler
{
    private RectTransform rectTransform;
    private bool isSelected = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
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
                SetSelected(false);
                CardSelectionManager.Instance.DeselectCard(this);
            }
        }
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
        rectTransform.localScale = selected ? Vector3.one * 1.2f : Vector3.one * 1.0f;

        if (!selected)
        {
            CardSelectionManager.Instance.DeselectCard(this); // לדווח למנהל להסיר אותי מהרשימה
        }
    }

    public void Discard()
    {
        gameObject.SetActive(false);
    }
}
