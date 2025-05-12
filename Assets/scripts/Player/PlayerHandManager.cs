using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores and provides access to the player's currently selected cards.
/// </summary>
public class PlayerHandManager : MonoBehaviour
{
    [Tooltip("The list of currently selected cards by the player.")]
    public List<Card> selectedCards = new List<Card>();

    /// <summary>
    /// Returns a copy of the selected cards list.
    /// </summary>
    /// <returns>List of selected cards.</returns>
    public List<Card> GetSelectedCards()
    {
        return new List<Card>(selectedCards);
    }
}
