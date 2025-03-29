using UnityEngine;
using UnityEngine.UI;

public class SlotClickHandler : MonoBehaviour
{
    public Button slotButton;
    
    private GameObject inventoryPanel;
    private InventoryManager inventoryManager;

    void Start()
    {
        slotButton.onClick.AddListener(OnSlotButtonClick);
        
        inventoryPanel = GameObject.Find("InventoryGridPanel");
        inventoryManager = inventoryPanel.GetComponent<InventoryManager>();
    }

    void OnSlotButtonClick()
    {
        inventoryManager.ApplyOneTime(transform.position);
    }
}
