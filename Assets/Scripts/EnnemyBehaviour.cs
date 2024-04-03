using UnityEngine;
using UnityEngine.ProBuilder;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float m_enemySpeed = 5f;
    [SerializeField] private float m_checkInterval = 2f;
    [SerializeField] private float m_approachFactor = 0.1f;

    private Transform m_playerTransform;
    private Vector3 m_randomDirection;
    private float m_nextCheckTime = 0;

    [SerializeField] private GameObject m_projectile;
    [SerializeField] private float m_shootInterval = 3f;
    [SerializeField] private float m_launchVelocity = 500;
    private float m_timeSinceLastShot = 0;

    void Start()
    {
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (m_playerTransform != null)
        {
            OrientTowardsPlayer();

            m_timeSinceLastShot += Time.deltaTime;
            if (m_timeSinceLastShot >= m_shootInterval)
            {
                ShootTowardsPlayer();
                m_timeSinceLastShot = 0;
            }

            Move();
        }
    }

    void Move()
    {
        if (Time.time >= m_nextCheckTime)
        {
            Vector3 directionToPlayer = (m_playerTransform.position - transform.position).normalized;
            m_randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            m_randomDirection = Vector3.Lerp(m_randomDirection, directionToPlayer, m_approachFactor);
            m_nextCheckTime = Time.time + m_checkInterval;
        }

        transform.position += m_randomDirection * m_enemySpeed * Time.deltaTime;
    }

    void OrientTowardsPlayer()
    {
        Vector3 direction = m_playerTransform.position - transform.position;
        direction.y = 0; // Empêche l'ennemi de regarder vers le haut ou vers le bas
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
    }

    void ShootTowardsPlayer()
    {
        GameObject enemyBullet = Instantiate(m_projectile, transform.position + transform.forward, Quaternion.LookRotation(m_playerTransform.position - transform.position)); // Correction de l'orientation de la balle
        enemyBullet.GetComponent<Rigidbody>().AddForce(enemyBullet.transform.forward * m_launchVelocity); // Utilisation de transform.forward de la balle tirée pour la direction
    }
}