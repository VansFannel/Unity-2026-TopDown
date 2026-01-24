using UnityEngine;

public class Sight2D : MonoBehaviour
{
    [SerializeField] float radius = 5.0f;
    [SerializeField] float checkFrequency = 5.0f;

    float lastCheckTime = 0;
    Collider2D[] colliders;

    Transform closestPlayer;
    float distanceToClosestPlayer;

    void Update()
    {
        if ((Time.time - lastCheckTime) > (1.0f  / checkFrequency))
        {
            lastCheckTime = Time.time;

            //Debug.Log("Checking sight");
            colliders = Physics2D.OverlapCircleAll(transform.position, radius);

            closestPlayer = null;
            distanceToClosestPlayer = Mathf.Infinity;

            for(int index = 0; index < colliders.Length; index++)
            {
                if (colliders[index].CompareTag("Player"))
                {
                    float distanceToPlayer = Vector3.Distance(transform.position, colliders[index].transform.position);
                    if (distanceToPlayer < distanceToClosestPlayer)
                    {
                        closestPlayer = colliders[index].transform;
                        distanceToClosestPlayer = distanceToPlayer;
                    }
                }
            }
        }
    }

    public Transform GetClosestTarget()
    {
        return closestPlayer;
    }

    public bool IsPlayerInSight()
    {
        bool isPlayerInSight = false;

        for (int index = 0; !isPlayerInSight && (index < colliders.Length); index++)
        {
            if (colliders[index].CompareTag("Player"))
            {
                isPlayerInSight = true;
            }
        }

        return isPlayerInSight;
    }
}
