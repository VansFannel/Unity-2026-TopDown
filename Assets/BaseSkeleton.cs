using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BaseSkeleton : CharacterBase
{
    [SerializeField] float delayAttack = 2.0f;
    protected Sight2D sight;
    [SerializeField] bool isAttacking = false;

    Life life;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();
        sight = GetComponent<Sight2D>();
        life = GetComponent<Life>();
    }

    protected override void Update()
    {
        base.Update();

        Transform closestTarget = sight.GetClosestTarget();

        if (closestTarget != null)
        {
            Move((closestTarget.position - transform.position).normalized);
        }
    }

    float damage = 0.5f;
    public void NotifyPunchLife(GameObject heartPrefab)
    {
        life.OnHitReceived(damage);

        if (life.GetLife() <= 0f)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                if (heartPrefab != null)
                {
                    Instantiate(heartPrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
            else if (gameObject.CompareTag("Vampire"))
            {
                SceneManager.LoadScene("WinMenu");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Vampire") && !isAttacking)
        {
            animator.SetTrigger("Attack");
            isAttacking = true;
            StartCoroutine(DelayAttack());
        }
    }

    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delayAttack);
        isAttacking = false;
    }

    public bool GetAttacking() { 
        return isAttacking;
    }
}
