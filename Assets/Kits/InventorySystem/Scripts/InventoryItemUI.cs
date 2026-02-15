using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] public InventoryItemDefinition inventoryItemDefinition;

    Image image;
    TextMeshProUGUI text;
    Button[] buttons;

    InventoryUI inventoryUI;

    enum ButtonAction
    {
        Discard,
        Use,
        Give,
        Sell
    }

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        inventoryUI = GetComponentInParent<InventoryUI>();
    }

    private void OnEnable()
    {
        buttons[(int)ButtonAction.Discard].onClick.AddListener(OnDiscard);
        buttons[(int)ButtonAction.Use].onClick.AddListener(OnUse);
        buttons[(int)ButtonAction.Give].onClick.AddListener(OnGive);
        buttons[(int)ButtonAction.Sell].onClick.AddListener(OnSell);
    }

    private void OnDisable()
    {
        buttons[(int)ButtonAction.Discard].onClick.RemoveListener(OnDiscard);
        buttons[(int)ButtonAction.Use].onClick.RemoveListener(OnUse);
        buttons[(int)ButtonAction.Give].onClick.RemoveListener(OnGive);
        buttons[(int)ButtonAction.Sell].onClick.RemoveListener(OnSell);
    }

    private void Start()
    {
        Init(inventoryItemDefinition);
    }

    public void Init(InventoryItemDefinition definition)
    {
        inventoryItemDefinition = Instantiate(definition);

        text.text = inventoryItemDefinition.uniqueItemName;
        image.sprite = inventoryItemDefinition.sprite;
    }

    void OnDiscard()
    {
        Debug.Log("OnDiscard", this);
    }

    void OnUse()
    {
        inventoryUI.NotifyInventoryItemUsed(inventoryItemDefinition);
        inventoryItemDefinition.numUses--;
        if (inventoryItemDefinition.numUses <= 0)
        {
            Destroy(gameObject);
        }

    }

    void OnSell()
    {
        Debug.Log("OnSell", this);
    }

    void OnGive()
    {
        Debug.Log("OnGive", this);
    }
}
