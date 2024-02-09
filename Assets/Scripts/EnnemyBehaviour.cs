using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public float checkInterval = 2f;
    public float approachFactor = 0.1f;

    private Transform playerTransform;
    private Vector3 randomDirection;
    private float nextCheckTime = 0;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform != null)
        {

            float distanceX = Mathf.Abs(transform.position.x - playerTransform.position.x);
            float distanceZ = Mathf.Abs(transform.position.z - playerTransform.position.z);


            if (distanceX <= 5f && distanceZ <= 5f)
            {
                MoveTowardsPlayer();
            }
            else
            {
                MoveRandomlyApproachPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void MoveRandomlyApproachPlayer()
    {
        if (Time.time >= nextCheckTime)
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            randomDirection = Vector3.Lerp(randomDirection, directionToPlayer, approachFactor).normalized;
            nextCheckTime = Time.time + checkInterval;
        }

        transform.position += randomDirection * speed * Time.deltaTime;
    }


}