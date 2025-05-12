/// <summary>
/// Provides utility methods for calculating damage multipliers between elemental types.
/// </summary>
public static class ElementalLogic
{
    /// <summary>
    /// Gets the damage multiplier based on elemental advantage.
    /// </summary>
    /// <param name="attacker">The element of the attacking card.</param>
    /// <param name="defender">The element of the defending card.</param>
    /// <returns>Multiplier (1.5 for advantage, 0.5 for disadvantage, 1 for neutral).</returns>
    public static float GetElementMultiplier(ElementType attacker, ElementType defender)
    {
        if (IsStrongAgainst(attacker, defender)) return 1.5f;
        if (IsWeakAgainst(attacker, defender)) return 0.5f;
        return 1f;
    }

    private static bool IsStrongAgainst(ElementType a, ElementType b)
    {
        return (a == ElementType.Fire && b == ElementType.Metal) ||
               (a == ElementType.Metal && b == ElementType.Air) ||
               (a == ElementType.Air && b == ElementType.Earth) ||
               (a == ElementType.Earth && b == ElementType.Water) ||
               (a == ElementType.Water && b == ElementType.Fire);
    }

    private static bool IsWeakAgainst(ElementType a, ElementType b)
    {
        return IsStrongAgainst(b, a);
    }
}
