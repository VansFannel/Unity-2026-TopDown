using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooter : BaseSkeleton
{
    [SerializeField] float delay = 1.5f;
    [SerializeField] GameObject firePoint;

    [SerializeField] GameObject bulletPrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        while (true)
        {
            if (sight != null && sight.GetClosestTarget() != null)
            {
                Transform target = sight.GetClosestTarget();

                if (target.CompareTag("Player") && target != null)
                {
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
                    bullet.GetComponent<FollowingShoot>().SetTarget(target);
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
