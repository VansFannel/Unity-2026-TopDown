using System;
using UnityEngine;
using static UnityEditor.PlayerSettings.SplashScreen;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] float linearSpeed = 0.0f;

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
}
