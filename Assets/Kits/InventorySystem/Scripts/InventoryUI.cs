using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    static public InventoryUI instance;

    [SerializeField] PlayerCharacter owner;

    [SerializeField] GameObject inventoryItemPrefab;
    GridLayoutGroup grid;

    private void Awake()
    {
        if (instance != null)
        {
            throw new System.Exception("There is already an InventoryUI in the scene.");
        }
        instance = this;
        grid = GetComponentInChildren<GridLayoutGroup>();
    }

    public void NotifyItemPicked(InventoryItemDefinition itemDefinition)
    {
        GameObject item = Instantiate(inventoryItemPrefab, grid.transform);
        item.GetComponent<InventoryItemUI>().Init(itemDefinition);
    }

    internal void NotifyInventoryItemUsed(InventoryItemDefinition inventoryItemDefinition)
    {
        owner.NotifyInventoryItemUsed(inventoryItemDefinition);
    }

    internal bool Contains(InventoryItemDefinition keyDefinition)
    {
        InventoryItemUI[] items = GetComponentsInChildren<InventoryItemUI>();

        return Array.Find(items, x => x.inventoryItemDefinition.uniqueItemName == keyDefinition.uniqueItemName) != null;
    }

    internal void Consume(InventoryItemDefinition keyDefinition)
    {
        InventoryItemUI[] items = GetComponentsInChildren<InventoryItemUI>();
        InventoryItemUI item = Array.Find(items, x => x.inventoryItemDefinition.uniqueItemName == keyDefinition.uniqueItemName);

        item.inventoryItemDefinition.numUses--;
        if (item.inventoryItemDefinition.numUses <= 0)
        {
            Destroy(item.gameObject);
        }
    }
}
