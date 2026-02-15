using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerCharacter : CharacterBase
{
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference punch;

    private Vector2 rawMove;
    private bool mustPunch;
    private Vector2 punchDirection = Vector2.down;

    [Header("Punch data")]
    [SerializeField] float punchRadius = 0.3f;
    [SerializeField] float punchRange = 0.3f;

    Life life;

    protected override void Awake()
    {
        base.Awake();

        life = GetComponent<Life>();
    }

    private void OnEnable()
    {
        move.action.Enable();
        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        punch.action.Enable();
        punch.action.performed += OnPunch;
    }

    protected override void Update()
    {
        base.Update();

        Move(rawMove);

        if (mustPunch)
        {
            mustPunch = false;
            PerformPunch();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Drop drop = other.GetComponent<Drop>();
        if (drop != null)
        {
            life.RecoverHealth(drop.dropDefinition.healthRecovery);
            drop.NotifyPickedUp();
        }
        else
        {
            FollowingShoot shoot = other.GetComponent<FollowingShoot>();
            if (shoot != null)
            {
                life.OnHitReceived(shoot.GetDamage());
            }
        }
    }

    void PerformPunch()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, punchRadius, punchDirection * punchRange);

        foreach (RaycastHit2D hit in hits)
        {
            CharacterBase otherBaseCharacter = hit.collider.GetComponent<CharacterBase>();

            if (otherBaseCharacter != this)
            {
                otherBaseCharacter?.NotifyPunch();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, punchDirection * punchRange);
    }

    private void OnDisable()
    {
        move.action.Disable();
        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;

        punch.action.Disable();
        punch.action.performed -= OnPunch;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.action.ReadValue<Vector2>();

        if (rawMove.magnitude > .0f)
        {
            punchDirection = rawMove.normalized;
        }
    }

    private void OnPunch(InputAction.CallbackContext context)
    {
        mustPunch = true;
    }
}
