using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    [SerializeField] float startingLife = 1.0f;
    [SerializeField] float currentLife;
    [SerializeField] public UnityEvent<float> onLifeChange;
    [SerializeField] public UnityEvent onDeath;

    [Header("Debug")]
    [SerializeField] float debugHitDamage = .1f;
    [SerializeField] bool debugReceiveHit;

    private void OnValidate()
    {
        if (debugReceiveHit)
        {
            debugReceiveHit = false;
            OnHitReceived(debugHitDamage);
        }
    }

    private void Awake()
    {
        currentLife = startingLife;
    }

    public void OnHitReceived(float damage)
    {
        if (currentLife > .0f)
        {
            currentLife -= damage;
            onLifeChange.Invoke(currentLife);

            if (currentLife <= .0f)
            {
                onDeath.Invoke();
                SceneManager.LoadScene("GameOverMenu");
            }
        }
    }

    internal void RecoverHealth(float healthRecovery)
    {
        if (currentLife > .0f)
        {
            currentLife += healthRecovery;
            currentLife = Mathf.Clamp01(currentLife);
            onLifeChange.Invoke(currentLife);
        }
    }
}
