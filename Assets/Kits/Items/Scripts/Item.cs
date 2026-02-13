using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, InteractableInterface
{
    [SerializeField] ItemSO itemSO;
    [SerializeField] Inventory inventory;

    public void Interact()
    {
        inventory.AddItem(itemSO);
        Destroy(gameObject);
    }
}
