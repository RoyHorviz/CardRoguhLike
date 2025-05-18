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

            // Match scale to player's card if available, fallback to Vector3.one
            if (CardHandSpawner.Instance != null && CardHandSpawner.Instance.SpawnedCards.Count > 0)
            {
                Vector3 referenceScale = CardHandSpawner.Instance.SpawnedCards[0].transform.localScale;
                cardGO.transform.localScale = referenceScale;
            }
            else
            {
                cardGO.transform.localScale = Vector3.one;
            }

            Card cardComponent = cardGO.GetComponent<Card>();
            cardComponent.Init(cardData.name, cardData.GetDamage(), cardData.GetElement(), cardData.CardDescription);
        }
    }
}
