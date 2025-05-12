using System;
using UnityEngine;

// Base Card class
public class Card : MonoBehaviour
{
    public string Name { get; private set; }
    public int DamageRank { get; private set; } // Rank 1-5
    public string CardDescription { get; set; } // Card Description
    public ElementType Element { get; private set; } // Enum

    // Initialize the card properties
    public void Init(string name, int damageRank, ElementType element, string cardDescription)
    {
        Name = name;
        DamageRank = damageRank;
        Element = element;
        CardDescription = cardDescription;
    }

    // Return the damage rank
    public int GetDamage()
    {
        return DamageRank;
    }


    public ElementType GetElement()
    {
        return Element;
    }

}

// Enum for Element Types
public enum ElementType
{
    Water,
    Fire,
    Metal,
    Earth,
    Air
}


// Specific elemental cards, each sets its own properties





