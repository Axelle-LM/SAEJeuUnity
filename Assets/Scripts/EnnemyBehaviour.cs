using UnityEngine;
using UnityEngine.ProBuilder;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float checkInterval = 2f;
    [SerializeField] private float approachFactor = 0.1f;

    private Transform playerTransform;
    private Vector3 randomDirection;
    private float nextCheckTime = 0;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float shootInterval = 3f;
    [SerializeField] private float launchVelocity = 500;
    private float timeSinceLastShot = 0;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            OrientTowardsPlayer();

            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootInterval)
            {
                ShootTowardsPlayer();
                timeSinceLastShot = 0;
            }

            Move();
        }
    }

    void Move()
    {
        if (Time.time >= nextCheckTime)
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            randomDirection = Vector3.Lerp(randomDirection, directionToPlayer, approachFactor);
            nextCheckTime = Time.time + checkInterval;
        }

        transform.position += randomDirection * speed * Time.deltaTime;
    }

    void OrientTowardsPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0; // Empêche l'ennemi de regarder vers le haut ou vers le bas
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
    }

    void ShootTowardsPlayer()
    {
        GameObject enemyBullet = Instantiate(projectile, transform.position + transform.forward, Quaternion.LookRotation(playerTransform.position - transform.position)); // Correction de l'orientation de la balle
        enemyBullet.GetComponent<Rigidbody>().AddForce(enemyBullet.transform.forward * launchVelocity); // Utilisation de transform.forward de la balle tirée pour la direction
    }
}