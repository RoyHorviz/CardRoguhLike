// Changed namespace
namespace CardProjectTestAlgos.Enums
{
    // Represents the stages within a round-based game
    public enum GameState
    {
        BattleStart,
        RoundStart,
        Player1_Deal, // Human Player Deals
        Player1_Select, // Human Player Selects 5 cards
        Player2_Deal, // AI Player Deals
        Player2_Select, // AI Player Selects 5 cards
        RoundResolve,   // Calculate and apply damage difference
        GameOver
    }
}