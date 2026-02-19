using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseVampire : CharacterBase
{
    protected Sight2D sight;

    Life life;

    protected override void Awake()
    {
        base.Awake();

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
            SceneManager.LoadScene("WinMenu");
        }
    }
}
