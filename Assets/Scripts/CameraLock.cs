using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    void Update()
    {
        // Obtenez l'entrée de l'axe horizontal et vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculer le vecteur de déplacement en fonction de l'entrée
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Normaliser le vecteur de déplacement pour éviter le déplacement diagonal plus rapide
        movement.Normalize();

        // Déplacer la caméra en fonction du vecteur de déplacement et de la vitesse de mouvement
        transform.Translate(movement * movementSpeed * Time.deltaTime);

        // Définir la position y de la caméra à 50
        Vector3 newPosition = transform.position;
        newPosition.y = 50f;
        transform.position = newPosition;
    }
}
