using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the selection of cards by the player, with a limit on how many can be selected.
/// </summary>
public class CardSelectionManager : MonoBehaviour
{
    public static CardSelectionManager Instance;

    [Tooltip("Maximum number of cards that can be selected at once.")]
    public int maxSelectedCards = 5;

    // Changed from HashSet to List to preserve the order of selection
    private List<CardClickScaler> selectedCards = new List<CardClickScaler>();

    private void Awake()
    {
        // Singleton pattern to ensure a single instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Attempts to select a card. Returns false if the selection limit is reached or the card is already selected.
    /// </summary>
    public bool TrySelectCard(CardClickScaler card)
    {
        if (selectedCards.Count >= maxSelectedCards || selectedCards.Contains(card))
            return false;

        selectedCards.Add(card);
        Debug.Log($"Card selected! Total selected: {selectedCards.Count}");
        return true;
    }

    /// <summary>
    /// Deselects a specific card if it is currently selected.
    /// </summary>
    public void DeselectCard(CardClickScaler card)
    {
        if (selectedCards.Remove(card))
        {
            Debug.Log($"Card deselected! Total selected: {selectedCards.Count}");
        }
    }

    /// <summary>
    /// Deselects all selected cards and clears the selection list.
    /// </summary>
    public void DeselectAllCards()
    {
        foreach (var card in new List<CardClickScaler>(selectedCards))
        {
            var handler = card.GetComponent<CardSelectionHandler>();
            if (handler != null)
            {
                handler.Deselect(); // Reset visual state
            }

            card.SetSelected(false); // Reset logical state
        }

        selectedCards.Clear();
        Debug.Log("Deselect all called. Total selected after: " + selectedCards.Count);
    }

    /// <summary>
    /// Discards all selected cards and clears the selection list.
    /// </summary>
    public void DiscardSelectedCards()
    {
        foreach (var card in new List<CardClickScaler>(selectedCards))
        {
            card.Discard();
        }

        selectedCards.Clear();
        Debug.Log("Discarded all selected cards. Count: 0");
    }

    /// <summary>
    /// Returns the current number of selected cards.
    /// </summary>
    public int GetSelectedCount()
    {
        return selectedCards.Count;
    }

    /// <summary>
    /// Returns the list of currently selected cards in the order they were selected.
    /// </summary>
    public List<CardClickScaler> GetSelectedCards()
    {
        return selectedCards;
    }

    /// <summary>
    /// Moves the selected cards to a specified parent transform, preserving their selection order,
    /// and removes them from the hand. A maximum of 5 cards are allowed in the target area.
    /// </summary>
    /// <param name="destination">The transform to which the cards will be moved.</param>
    public void MoveSelectedCardsToArea(Transform destination)
    {
        int existingCardCount = destination.childCount;
        int availableSlots = 5 - existingCardCount;

        if (availableSlots <= 0)
        {
            Debug.LogWarning("Play area is already full. Max 5 cards allowed.");
            return;
        }

        // Only move as many cards as there are available slots
        int cardsToMove = Mathf.Min(selectedCards.Count, availableSlots);

        for (int i = 0; i < cardsToMove; i++)
        {
            var card = selectedCards[i];

            // Move card to play area
            card.transform.SetParent(destination, worldPositionStays: false);

            // Remove card from hand
            if (CardHandSpawner.Instance != null)
            {
                CardHandSpawner.Instance.RemoveFromHand(card.gameObject);
            }
            else
            {
                Debug.LogWarning("CardHandSpawner.Instance is null — could not remove card from hand.");
            }
        }

        // Remove only the cards that were actually moved from the selection list
        selectedCards.RemoveRange(0, cardsToMove);

        Debug.Log($"Moved {cardsToMove} card(s) to play area. Total now in area: {destination.childCount}.");
    }




}
