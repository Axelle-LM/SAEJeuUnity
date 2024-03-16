using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public List<CollectibleData> inventory;
    [SerializeField] private Canvas userInterface;
    private Text itemNameText;
    private Text itemDescriptionText;
    private List<GameObject> inventoryImageObjects = new List<GameObject>();

    private void Awake()
    {
        inventory = new List<CollectibleData>();
    }

    void Start()
    {
        UpdateInventoryUI();
    }

    void Update()
    {
        // Suppose que Update est appelé pour chaque changement de santé du joueur
        UpdateInventoryUI();
    }

    public void Add(CollectibleData referenceData)
    {
        inventory.Add(referenceData);
        UpdateInventoryUI();
    }

    public void Remove(CollectibleData referenceData)
    {
        if (inventory.Contains(referenceData))
        {
            inventory.Remove(referenceData);
            UpdateInventoryUI();
        }
    }

    void UpdateInventoryUI()
    {
        foreach (GameObject imageObject in inventoryImageObjects)
        {
            Destroy(imageObject);
        }
        inventoryImageObjects.Clear();

        for (int i = 0; i < inventory.Count; i++)
        {
            GameObject imageObject = new GameObject(inventory[i].name);
            RectTransform imageTransform = imageObject.AddComponent<RectTransform>();
            imageTransform.transform.SetParent(userInterface.transform);
            imageTransform.localScale = Vector3.one;
            imageTransform.anchoredPosition = new Vector2(-150f + (40 * i), -225f);
            imageTransform.sizeDelta = new Vector2(64, 64);

            Image image = imageObject.AddComponent<Image>();
            image.sprite = inventory[i].icon;

            // Ajouter un EventTrigger pour gérer le survol de la souris
            EventTrigger eventTrigger = imageObject.AddComponent<EventTrigger>();
            AddHoverEvents(eventTrigger, inventory[i]);

            inventoryImageObjects.Add(imageObject);
        }
    }

    private void AddHoverEvents(EventTrigger eventTrigger, CollectibleData collectibleData)
    {
        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((data) => { DisplayItemInfo(collectibleData); });
        eventTrigger.triggers.Add(pointerEnter);

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((data) => { ClearItemInfo(); });
        eventTrigger.triggers.Add(pointerExit);
    }

    private void DisplayItemInfo(CollectibleData collectibleData)
    {
        if (collectibleData != null)
        {
            itemNameText.text = collectibleData.name;
            itemDescriptionText.text = collectibleData.description;
        }
    }


    private void ClearItemInfo()
    {
        itemNameText.text = "";
        itemDescriptionText.text = "";
    }
}
