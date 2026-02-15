using System.Collections;
using UnityEngine;

public class FollowingShoot : MonoBehaviour
{
    [SerializeField] float damage = 0.3f;
    [SerializeField] float speed = 0.01f;
    [SerializeField] float lifeTime = 5f;

    Transform target;
    ParticleSystem explosion;

    private void Awake()
    {
        explosion = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (target != null) {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity).Play();

            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        explosion.Play();
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
