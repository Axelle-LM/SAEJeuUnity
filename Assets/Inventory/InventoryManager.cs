//InventoryManager.cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public List<CollectibleData> inventory;
    [SerializeField] private Canvas userInterface;
    private List<GameObject> inventoryImageObjects = new List<GameObject>();
    private TextMeshProUGUI itemInfoText;
    private bool isMouseOverItem;

    private void Awake()
    {
        inventory = new List<CollectibleData>();
    }

    void Start()
    {
        CreateItemInfoText();
        UpdateInventoryUI();
    }

    void Update()
    {
        if (isMouseOverItem)
        {
            UpdateItemInfoTextPosition();
        }
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
            imageTransform.anchoredPosition = new Vector2(-150f + (100 * i), -225f);
            imageTransform.sizeDelta = new Vector2(64, 64);

            Image image = imageObject.AddComponent<Image>();
            image.sprite = inventory[i].icon;

            EventTrigger eventTrigger = imageObject.AddComponent<EventTrigger>();
            AddEventTrigger(eventTrigger, OnPointerEnter, EventTriggerType.PointerEnter);
            AddEventTrigger(eventTrigger, OnPointerExit, EventTriggerType.PointerExit);

            inventoryImageObjects.Add(imageObject);
        }
    }

    private void AddEventTrigger(EventTrigger trigger, UnityEngine.Events.UnityAction<BaseEventData> callback, EventTriggerType triggerType)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = triggerType;
        entry.callback.AddListener(callback);
        trigger.triggers.Add(entry);
    }

    public void OnPointerEnter(BaseEventData eventData)
    {
        isMouseOverItem = true;
        UpdateItemInfoTextPosition();
    }

    public void OnPointerExit(BaseEventData eventData)
    {
        isMouseOverItem = false;
        itemInfoText.text = "";
    }

    private void CreateItemInfoText()
    {
        GameObject textObject = new GameObject("ItemInfoText");
        RectTransform textTransform = textObject.AddComponent<RectTransform>();
        textTransform.SetParent(userInterface.transform);
        textTransform.localScale = Vector3.one;
        textTransform.sizeDelta = new Vector2(300, 50); // Taille arbitraire

        itemInfoText = textObject.AddComponent<TextMeshProUGUI>();
        itemInfoText.alignment = TextAlignmentOptions.Center;
        itemInfoText.fontSize = 16;
    }

    private void UpdateItemInfoTextPosition()
    {
        if (inventory.Count > 0)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);
            foreach (RaycastResult result in results)
            {
                if (inventoryImageObjects.Contains(result.gameObject))
                {
                    int index = inventoryImageObjects.IndexOf(result.gameObject);
                    RectTransform itemTransform = result.gameObject.GetComponent<RectTransform>();
                    itemInfoText.rectTransform.anchoredPosition = itemTransform.anchoredPosition + new Vector2(0, 50); // Ajuster la position au-dessus de l'item
                    itemInfoText.text = $"{inventory[index].name}\n{inventory[index].description}";
                    return;
                }
            }
        }
        itemInfoText.text = "";
    }
}