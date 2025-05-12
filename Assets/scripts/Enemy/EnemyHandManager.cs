using System.Collections.Generic;
using UnityEngine;

public class EnemyHandManager : MonoBehaviour
{
    public Transform enemyCardArea;
    public GameObject cardPrefab;

    public void DisplayEnemyCards(List<Card> cards)
    {
        foreach (Transform child in enemyCardArea)
            Destroy(child.gameObject);

        foreach (var cardData in cards)
        {
            GameObject cardGO = GameObject.Instantiate(cardPrefab, enemyCardArea);
            Card cardComponent = cardGO.GetComponent<Card>();
            cardComponent.Init(cardData.name, cardData.GetDamage(), cardData.GetElement(), cardData.CardDescription);
        }
    }
}
