using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles click interactions on a card, allowing the player to select or deselect it.
/// </summary>
[RequireComponent(typeof(Card))]
public class CardClickHandler : MonoBehaviour, IPointerClickHandler
{
    [Tooltip("Optional: reference to the player's hand manager. If null, it will search for one in the scene.")]
    public PlayerHandManager playerHandManager;

    private Card card;
    private bool isSelected = false;
    private Vector3 originalScale;

    /// <summary>
    /// Initializes the card reference and stores original scale for visual feedback.
    /// </summary>
    private void Start()
    {
        card = GetComponent<Card>();
        originalScale = transform.localScale;

        if (playerHandManager == null)
        {
            playerHandManager = FindObjectOfType<PlayerHandManager>();
        }
    }

    /// <summary>
    /// Handles the click event to select or deselect a card.
    /// </summary>
    /// <param name="eventData">Click input data from Unity's event system.</param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (card == null || playerHandManager == null)
            return;

        if (!isSelected)
        {
            if (playerHandManager.selectedCards.Count < 5)
            {
                playerHandManager.selectedCards.Add(card);
                isSelected = true;
                ApplySelectedVisuals();
            }
        }
        else
        {
            playerHandManager.selectedCards.Remove(card);
            isSelected = false;
            ResetVisuals();
        }
    }

    /// <summary>
    /// Applies visual feedback to indicate the card is selected.
    /// </summary>
    private void ApplySelectedVisuals()
    {
        transform.localScale = originalScale * 1.1f; // Slightly enlarge
    }

    /// <summary>
    /// Resets visual feedback to indicate the card is no longer selected.
    /// </summary>
    private void ResetVisuals()
    {
        transform.localScale = originalScale;
    }
}
