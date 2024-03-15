using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private Transform player; // L'objet vers lequel l'objet actuel sera attiré
    [SerializeField] private float attractionForce = 10f; // La force d'attraction

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody non trouvé sur l'objet. Ajoutez un Rigidbody pour utiliser ce script.");
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            // Calcule la direction de l'objet cible
            Vector3 direction = player.position - transform.position;

            // Calcule la force d'attraction
            Vector3 attraction = direction.normalized * attractionForce * Time.fixedDeltaTime;

            // Applique la force à l'objet
            rb.AddForce(attraction, ForceMode.Acceleration);
        }
    }
}