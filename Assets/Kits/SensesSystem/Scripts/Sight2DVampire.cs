using UnityEngine;

public class Sight2DVampire : MonoBehaviour
{
    [SerializeField] float radius = 5.0f;
    [SerializeField] float checkFrequency = 5.0f;
    [Space]
    [SerializeField] IVisible2D.Side[] sides;


    float lastCheckTime = 0;
    Collider2D[] colliders;

    Transform closestTarget;
    float distanceToClosestTarget;
    int priorityOfClosestTarget;

    void Update()
    {
        if ((Time.time - lastCheckTime) > (1.0f  / checkFrequency))
        {
            lastCheckTime = Time.time;

            colliders = Physics2D.OverlapCircleAll(transform.position, radius);

            closestTarget = null;
            distanceToClosestTarget = Mathf.Infinity;
            priorityOfClosestTarget = -1;

            for (int index = 0; index < colliders.Length; index++)
            {
                IVisible2D visible = colliders[index].GetComponent<IVisible2D>();
                if ((visible != null) && (CanSee(visible)))
                {
                    float distanceToPlayer = Vector3.Distance(transform.position, colliders[index].transform.position);
                    if ((visible.GetPriority() > priorityOfClosestTarget) ||
                        ((visible.GetPriority() == priorityOfClosestTarget) && (distanceToPlayer < distanceToClosestTarget)))
                    {
                        closestTarget = colliders[index].transform;
                        distanceToClosestTarget = distanceToPlayer;
                        priorityOfClosestTarget = visible.GetPriority();
                    }
                }
            }
        }
    }

    private bool CanSee(IVisible2D visible)
    {
        bool canSee = false;
        for (int index = 0; ((!canSee) && (index < sides.Length)); index++)
        {
            canSee = (visible.GetSide() == sides[index]);
        }

        return canSee;
    }

    public Transform GetClosestTarget()
    {
        return closestTarget;
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
