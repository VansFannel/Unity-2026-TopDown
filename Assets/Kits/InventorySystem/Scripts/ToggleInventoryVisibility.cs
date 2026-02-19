using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleInventoryVisibility : MonoBehaviour
{
    [SerializeField] InputActionReference inventoryAction;

    [SerializeField] Canvas inventoryPanel;
    [SerializeField] GameObject items;

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
        inventoryPanel.enabled = !inventoryPanel.enabled;
        //items.SetActive(!items.activeInHierarchy);
    }
}
