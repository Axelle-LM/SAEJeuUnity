using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject laser; // Assurez-vous d'attacher le GameObject du laser dans l'inspecteur
    private bool laserActive = false; // Variable pour suivre l'état du laser

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Utiliser 1 pour le bouton droit de la souris
        {
            ToggleLaser(); // Appel de la méthode pour basculer l'état du laser
        }
    }

    void ToggleLaser()
    {
        laserActive = !laserActive; // Inverser l'état actuel du laser

        if (laser != null) // Vérifier si le GameObject du laser est attaché
        {
            laser.SetActive(laserActive); // Activer ou désactiver le laser en fonction de l'état
        }
        else
        {
            Debug.LogWarning("Laser GameObject is not assigned."); // Avertissement si le GameObject du laser n'est pas attaché
        }
    }
}
