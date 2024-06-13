using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private CollectibleData m_collectibleData;
    [SerializeField] private InventoryManager m_inventoryManager;
    private void Start()
    {
        m_inventoryManager = FindObjectOfType<InventoryManager>();
    }
    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.collider.CompareTag("Player"))
        {
            m_inventoryManager?.Add(m_collectibleData); //m_inventoryManager?.Example(); <=> if (m_inventoryManager != null) { Example(); }
            Destroy(gameObject);

            if (m_collectibleData.name == "Coupable n�3")
            {
                SceneManager.LoadScene("GameEnd", LoadSceneMode.Single);
            }

        }
    }
}