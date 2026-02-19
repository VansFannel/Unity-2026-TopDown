using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseVampire : CharacterBase
{
    protected Sight2DVampire sight;

    Life life;

    protected override void Awake()
    {
        base.Awake();

        sight = GetComponent<Sight2DVampire>();
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
