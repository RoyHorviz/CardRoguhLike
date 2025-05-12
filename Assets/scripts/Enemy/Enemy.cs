using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an enemy in battle, including its HP, element type, and deck of cards.
/// </summary>
public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int maxHP = 100;
    public int currentHP;
    public ElementType element;

    [Tooltip("The enemy's card deck.")]
    public List<Card> deck = new List<Card>();

    /// <summary>
    /// Initializes enemy HP at the start of the battle.
    /// </summary>
    private void Start()
    {
        currentHP = maxHP;
    }

    /// <summary>
    /// Randomly draws a specified number of cards from the enemy's deck.
    /// </summary>
    /// <param name="count">The number of cards to draw.</param>
    /// <returns>A list of randomly selected cards.</returns>
    public List<Card> DrawRandomCards(int count)
    {
        List<Card> drawn = new List<Card>();
        List<Card> tempDeck = new List<Card>(deck);

        for (int i = 0; i < count && tempDeck.Count > 0; i++)
        {
            int index = Random.Range(0, tempDeck.Count);
            drawn.Add(tempDeck[index]);
            tempDeck.RemoveAt(index);
        }

        return drawn;
    }
}
