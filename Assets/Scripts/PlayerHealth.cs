using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int m_playerHealth = 5;
    [SerializeField] private Sprite m_heart;
    [SerializeField] private Canvas m_userInterface;
    private List<GameObject> m_heartObjects = new List<GameObject>();

    void Start()
    {
        UpdateHealthUI();
    }

    void Update()
    {
        UpdateHealthUI();
        GameOver();
    }

    void UpdateHealthUI()
    {
        foreach (GameObject heartObject in m_heartObjects)
        {
            Destroy(heartObject);
        }
        m_heartObjects.Clear();

        // Affiche les coeurs en fonction de la sant� du joueur
        for (int i = 0; i < m_playerHealth; i++)
        {
            GameObject imageObject = new GameObject("m_heart");
            RectTransform imageTransform = imageObject.AddComponent<RectTransform>();
            imageTransform.transform.SetParent(m_userInterface.transform);
            imageTransform.localScale = Vector3.one;
            imageTransform.anchoredPosition = new Vector2(-350f + (40 * i), 180f);
            imageTransform.sizeDelta = new Vector2(32, 32);

            Image image = imageObject.AddComponent<Image>();
            image.sprite = m_heart;
            m_heartObjects.Add(imageObject); // Ajoute 
        }
    }
    void GameOver()
    {
        if (m_playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
