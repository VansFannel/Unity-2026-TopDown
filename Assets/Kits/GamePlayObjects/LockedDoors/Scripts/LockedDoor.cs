using TMPro;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] InventoryItemDefinition keyDefinition;
    [SerializeField] TextMeshProUGUI text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (InventoryUI.instance.Contains(keyDefinition))
            {
                InventoryUI.instance.Consume(keyDefinition);

                text.SetText("Opening Door");

                gameObject.SetActive(false);
            }
        }
        else
        {
            text.SetText("Need a key");
        }
    }
}
