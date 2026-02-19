using System;
using UnityEngine;
using static UnityEditor.PlayerSettings.SplashScreen;

public class CharacterBase : MonoBehaviour, IVisible2D
{
    [SerializeField] float linearSpeed = 0.0f;

    [SerializeField] int priority = 0;
    [SerializeField] IVisible2D.Side side;

    Rigidbody2D rb2D;

    Animator animator;
    Vector2 lastMoveDirection;

    protected virtual void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

        animator.SetFloat("HorizontalVelocity", lastMoveDirection.x);
        animator.SetFloat("VerticalVelocity", lastMoveDirection.y);
    }

    protected void Move(Vector2 direction)
    {
        lastMoveDirection = direction;
        rb2D.position += direction * linearSpeed * Time.deltaTime;
    }

    internal void NotifyPunch()
    {
        Destroy(gameObject);
    }

    internal void NotifyPunchLife(GameObject heartPrefab)
    {
        if (heartPrefab != null)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    int IVisible2D.GetPriority()
    {
        return priority;
    }

    IVisible2D.Side IVisible2D.GetSide()
    {
        return side;    
    }
}
