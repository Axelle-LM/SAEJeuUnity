using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 5;
    [SerializeField] private Sprite heart;
    [SerializeField] private Canvas userInterface;
    private List<GameObject> heartObjects = new List<GameObject>();

    void Start()
    {
        UpdateHealthUI();
    }

    void Update()
    {
        // Suppose que Update est appelée pour chaque changement de santé du joueur
        UpdateHealthUI();
        GameOver();
    }

    void UpdateHealthUI()
    {
        // Efface tous les coeurs existants pour les reconstruire
        foreach (GameObject heartObject in heartObjects)
        {
            Destroy(heartObject);
        }
        heartObjects.Clear();

        // Affiche les coeurs en fonction de la santé du joueur
        for (int i = 0; i < playerHealth; i++)
        {
            GameObject imageObject = new GameObject("heart");
            RectTransform imageTransform = imageObject.AddComponent<RectTransform>();
            imageTransform.transform.SetParent(userInterface.transform);
            imageTransform.localScale = Vector3.one;
            imageTransform.anchoredPosition = new Vector2(-350f + (40 * i), 180f);
            imageTransform.sizeDelta = new Vector2(32, 32);

            Image image = imageObject.AddComponent<Image>();
            image.sprite = heart;
            heartObjects.Add(imageObject); // Ajoute l'objet coeur à la liste pour pouvoir le détruire plus tard
        }
    }
    void GameOver()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
