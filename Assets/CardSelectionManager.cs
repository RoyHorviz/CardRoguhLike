using System.Collections.Generic;
using UnityEngine;

public class CardSelectionManager : MonoBehaviour
{
    public static CardSelectionManager Instance;

    public int maxSelectedCards = 5;
    private List<CardClickScaler> selectedCards = new List<CardClickScaler>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool TrySelectCard(CardClickScaler card)
    {
        if (selectedCards.Count >= maxSelectedCards)
            return false;

        if (!selectedCards.Contains(card))
            selectedCards.Add(card);

        Debug.Log("Card selected! Total selected: " + selectedCards.Count); // <-- лап

        return true;
    }

    public void DeselectCard(CardClickScaler card)
    {
        if (selectedCards.Contains(card))
        {
            selectedCards.Remove(card);
            Debug.Log("Card deselected! Total selected: " + selectedCards.Count); // <-- лап
        }
    }

    public void DeselectAllCards()
    {
        List<CardClickScaler> cardsToDeselect = new List<CardClickScaler>(selectedCards);

        foreach (var card in cardsToDeselect)
        {
            card.SetSelected(false);
        }

        Debug.Log("Deselect all called. Total selected after: " + selectedCards.Count); // <-- лап
    }

    public void DiscardSelectedCards()
    {
        foreach (var card in new List<CardClickScaler>(selectedCards))
        {
            card.Discard();
        }

        Debug.Log("Discarded all selected cards. Count: " + selectedCards.Count); // <-- лап
        selectedCards.Clear();
    }

    public int GetSelectedCount()
    {
        return selectedCards.Count;
    }
}
