using UnityEngine;

public class PickableInventoryItem : MonoBehaviour
{
    [SerializeField] InventoryItemDefinition itemDefinition;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryUI.instance.NotifyItemPicked(itemDefinition);

            Destroy(gameObject);
        }
    }
}
