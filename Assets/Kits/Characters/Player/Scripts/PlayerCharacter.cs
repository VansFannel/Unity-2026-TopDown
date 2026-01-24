using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : CharacterBase
{
    [SerializeField] InputActionReference move;
    Animator animator;

    private Vector2 rawMove;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        move.action.Enable();
        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;
    }

    protected override void Update()
    {
        base.Update();

        Move(rawMove);

    }

    private void OnDisable()
    {
        move.action.Disable();
        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.action.ReadValue<Vector2>();
    }
}
