using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public PlayerHandManager playerHand;
    public Enemy enemy;
    public EnemyHandManager enemyHand;
    public Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(ExecuteBattle);
    }

    private void ExecuteBattle()
    {
        List<Card> playerCards = playerHand.GetSelectedCards();
        List<Card> enemyCards = enemy.DrawRandomCards(playerCards.Count);
        enemyHand.DisplayEnemyCards(enemyCards);

        for (int i = 0; i < playerCards.Count; i++)
        {
            Card playerCard = playerCards[i];
            Card enemyCard = enemyCards[i];

            float multiplier = ElementalLogic.GetElementMultiplier(playerCard.GetElement(), enemyCard.GetElement());
            int finalDamage = Mathf.RoundToInt(playerCard.GetDamage() * multiplier);
            enemy.currentHP -= finalDamage;

            Debug.Log($"[{playerCard.name}] vs [{enemyCard.name}]: {finalDamage} damage (ª{multiplier})");
        }

        Debug.Log($"Enemy HP after attack: {enemy.currentHP}/{enemy.maxHP}");
    }
}
