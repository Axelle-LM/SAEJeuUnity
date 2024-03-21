using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private CollectibleData referenceItem;
    [SerializeField] private InventoryManager inventoryManager;
    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (inventoryManager != null) // Ensure inventoryManager is not null
        {
            if (collision.collider.CompareTag("Player"))
            {
                inventoryManager.Add(referenceItem);
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.LogError("InventoryManager reference is null!");
        }
    }
}