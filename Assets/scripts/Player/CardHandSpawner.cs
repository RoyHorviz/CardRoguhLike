using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardHandSpawner : MonoBehaviour
{
    [Header("Card Prefabs")]
    [SerializeField] private GameObject waterCardPrefab;
    [SerializeField] private GameObject fireCardPrefab;
    [SerializeField] private GameObject earthCardPrefab;
    [SerializeField] private GameObject airCardPrefab;
    [SerializeField] private GameObject metalCardPrefab;

    [Header("Hand Area")]
    [SerializeField] private Transform handArea;
    [SerializeField] private Button playButton;
    [SerializeField] private Button spawnButton;
    [SerializeField] private Button discardButton;

    [Header("Deck Settings")]
    [SerializeField] private int deckSize = 20;
    public int DeckSize
    {
        get => deckSize;
        set => deckSize = value;
    }

    [SerializeField] private int maxCardsInHand = 5;
    public int MaxCardsInHand
    {
        get => maxCardsInHand;
        set => maxCardsInHand = value;
    }

    public Dictionary<ElementType, GameObject> PrefabMapping { get; private set; }
    public List<ElementType> DeckToDrawFrom { get; private set; }
    public List<GameObject> SpawnedCards { get; private set; } = new List<GameObject>();
    public List<GameObject> DiscardPile { get; private set; } = new List<GameObject>();

    public static CardHandSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // Bind play button to generate a random deck
        if (playButton != null)
            playButton.onClick.AddListener(GenerateRandomDeck);
        else
            Debug.LogError("Play button not assigned!");

        // Bind spawn button to draw a card
        if (spawnButton != null)
            spawnButton.onClick.AddListener(SpawnRandomCardFromDeck);
        else
            Debug.LogError("Spawn button not assigned!");

        // Bind discard button to discard selected cards via CardSelectionManager
        if (discardButton != null)
            discardButton.onClick.AddListener(() =>
            {
                CardSelectionManager.Instance.DiscardSelectedCards();
            });
        else
            Debug.LogError("Discard button not assigned!");

        InitializePrefabMapping();
    }

    private void InitializePrefabMapping()
    {
        PrefabMapping = new Dictionary<ElementType, GameObject>
        {
            { ElementType.Water, waterCardPrefab },
            { ElementType.Fire, fireCardPrefab },
            { ElementType.Earth, earthCardPrefab },
            { ElementType.Air, airCardPrefab },
            { ElementType.Metal, metalCardPrefab }
        };
    }

    private void GenerateRandomDeck()
    {
        DeckToDrawFrom = new List<ElementType>();
        List<ElementType> availableTypes = new List<ElementType>(PrefabMapping.Keys);

        for (int i = 0; i < deckSize; i++)
        {
            ElementType randomElement = availableTypes[Random.Range(0, availableTypes.Count)];
            DeckToDrawFrom.Add(randomElement);
        }

        Debug.Log($"Generated random deck with {deckSize} cards!");
    }

    private void SpawnRandomCardFromDeck()
    {
        if (DeckToDrawFrom == null || DeckToDrawFrom.Count == 0)
        {
            Debug.LogWarning("Deck is empty or not generated yet!");
            return;
        }

        if (SpawnedCards.Count >= maxCardsInHand)
        {
            Debug.LogWarning("Hand is full! Cannot draw more cards.");
            return;
        }

        ElementType selectedElement = DeckToDrawFrom[0];

        if (PrefabMapping.ContainsKey(selectedElement))
        {
            GameObject selectedPrefab = PrefabMapping[selectedElement];
            GameObject newCard = Instantiate(selectedPrefab, handArea);
            newCard.transform.localScale = Vector3.one;

            newCard.AddComponent<CardSelectionHandler>(); // Ensure the card can be selected

            SpawnedCards.Add(newCard);
        }
        else
        {
            Debug.LogWarning($"No prefab found for element type: {selectedElement}");
        }

        DeckToDrawFrom.RemoveAt(0);

        Debug.Log($"Spawned {selectedElement} card! {DeckToDrawFrom.Count} cards left in deck.");
    }

    // Deselect all cards in hand (visual + logic reset)
    public void DeselectAllCardsInHand()
    {
        foreach (GameObject card in SpawnedCards)
        {
            CardSelectionHandler selection = card.GetComponent<CardSelectionHandler>();
            if (selection != null)
            {
                selection.Deselect();
                selection.ShakeOnDeselect();
            }
        }
    }


    public void RemoveFromHand(GameObject card)
    {
        if (SpawnedCards.Contains(card))
        {
            SpawnedCards.Remove(card);
            Debug.Log("Removed card from SpawnedCards.");
        }
    }
}
