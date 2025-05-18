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
        Debug.Log($"Couunt we got from player count function is : {count}");
        for (int i = 0; i < count; i++)
        {
            if (tempDeck.Count > 0)
            {
                int index = Random.Range(0, tempDeck.Count);
                drawn.Add(tempDeck[index]);
                tempDeck.RemoveAt(index);
            }
            else
            {
                drawn.Add(null); // Add null if not enough cards in deck
            }
        }

        return drawn;
    }

}
