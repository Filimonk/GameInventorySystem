using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SlotClickHandler : MonoBehaviour
{
    public Button slotButton;
    
    private GameObject inventoryPanel;
    private InventoryManager inventoryManager;

    public void Start()
    {
        slotButton.onClick.AddListener(OnSlotButtonClick);
        
        inventoryPanel = GameObject.Find("InventoryPanel");
        inventoryManager = inventoryPanel.GetComponent<InventoryManager>();
    }

    public void OnSlotButtonClick()
    {
        inventoryManager.ApplyOneTime(transform.position);
    }
}
