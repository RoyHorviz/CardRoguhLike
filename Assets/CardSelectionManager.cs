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

    private HashSet<CardClickScaler> selectedCards = new HashSet<CardClickScaler>();

    private void Awake()
    {
        // Implement singleton pattern to ensure only one instance exists.
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
    /// Attempts to select a card. Returns false if selection limit is reached or card is already selected.
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
    /// Deselects all selected cards and clears the internal list.
    /// </summary>
    public void DeselectAllCards()
    {
        foreach (var card in new List<CardClickScaler>(selectedCards))
        {
            card.SetSelected(false); // Only visual and flag update
        }

        selectedCards.Clear(); // Clear logical selection
        Debug.Log("Deselect all called. Total selected after: " + selectedCards.Count);
    }

    public IEnumerable<CardClickScaler> GetSelectedCards()
    {
        return selectedCards;
    }



    /// <summary>
    /// Discards all selected cards and clears the list.
    /// </summary>
    public void DiscardSelectedCards()
    {
        // Create a copy of the collection to avoid modification during iteration.
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
        return   this.selectedCards.Count;
    }

   
}
