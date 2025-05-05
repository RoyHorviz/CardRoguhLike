using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CardSelectionHandler : MonoBehaviour, IPointerClickHandler
{
    public bool IsSelected { get; private set; } = false;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Coroutine shakeCoroutine;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ToggleSelection();
        }
    }

    private void ToggleSelection()
    {
        IsSelected = !IsSelected;
        UpdateVisual();
    }

    public void Deselect()
    {
        IsSelected = false;
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = IsSelected ? 0.6f : 1f;
        }
    }

    // Add shake animation when deselecting
    public void ShakeOnDeselect()
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
        }
        shakeCoroutine = StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        Vector3 originalPosition = rectTransform.localPosition;
        float duration = 0.2f;
        float strength = 5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-strength, strength);
            float offsetY = Random.Range(-strength, strength);

            rectTransform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.localPosition = originalPosition;
    }
}
