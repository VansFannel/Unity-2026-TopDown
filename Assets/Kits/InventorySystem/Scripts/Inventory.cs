using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] Button[] items;

    private void Awake()
    {
        inventory.SetActive(false);
    }

    private void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            int index = i;
            items[i].onClick.AddListener(() => { OnClickEvent(index); });
        }
    }

    private void Update()
    {
        if (inventory != null)
        {
            if (Keyboard.current.iKey.wasPressedThisFrame)
            {
                inventory.SetActive(!inventory.activeSelf);
            }

        }
    }

    private void OnClickEvent(int index)
    {
        Debug.Log("Soy " + index + " y me has pulsao");
    }

    private int actualItemIndex = 0;
    public void AddItem(ItemSO itemSO)
    {
        items[actualItemIndex].gameObject.SetActive(true);

        items[actualItemIndex].GetComponent<Image>().sprite = itemSO.itemIcon;

        actualItemIndex++;
    }
}
