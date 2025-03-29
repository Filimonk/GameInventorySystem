#nullable enable

using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private InventoryGrid inventoryGrid;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemDescription;
    
    private void ProcessTheDescriptionBlockDisplay(bool DescriptionBlockFlag)
    {
        if (DescriptionBlockFlag == false)
        {
            
        }
    }

    public void Init(GameObject inventoryGridPanel, TextMeshProUGUI itemName, 
                     TextMeshProUGUI itemDescription, bool DescriptionBlockFlag)
    {
        inventoryGrid = inventoryGridPanel.GetComponent<InventoryGrid>();
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        ProcessTheDescriptionBlockDisplay(DescriptionBlockFlag);
    }
    
    public void ApplyOneTime(Vector3 position)
    {
        Item? item = inventoryGrid.GetItem(position);
    }
}
