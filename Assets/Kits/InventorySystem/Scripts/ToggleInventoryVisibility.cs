using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleInventoryVisibility : MonoBehaviour
{
    [SerializeField] InputActionReference inventoryAction;
    [SerializeField] GameObject inventory;

    private void OnEnable()
    {
        inventoryAction.action.Enable();
        inventoryAction.action.performed += OnInventoryAction;
    }

    private void OnDisable()
    {
        inventoryAction.action.Disable();
        inventoryAction.action.performed -= OnInventoryAction;
    }

    private void OnInventoryAction(InputAction.CallbackContext context)
    {
        inventory.SetActive(!inventory.activeInHierarchy);
    }
}
