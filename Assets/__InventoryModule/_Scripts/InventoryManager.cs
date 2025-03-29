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

    public void Init(InventoryGrid inventoryGrid, TextMeshProUGUI itemName, 
                     TextMeshProUGUI itemDescription, bool DescriptionBlockFlag)
    {
        this.inventoryGrid = inventoryGrid;
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        ProcessTheDescriptionBlockDisplay(DescriptionBlockFlag);
    }
    
    private Vector3 lastClicked = new Vector3(-1, -1, -1);
    
    public void ApplyOneTime(Vector3 position)
    {
        Item? item = inventoryGrid.GetItem(position);

        if (item != null)
        {
            if (lastClicked != position)
            {
                itemName.text = item.Name; 
                itemDescription.text = item.Description;
                lastClicked = position;
            }
            else
            {
                item.ApplyOneTime();
                Debug.Log("Double-click - item execution");
                
                item = inventoryGrid.GetItem(position);

                if (item != null)
                {
                    itemName.text = item.Name;
                    itemDescription.text = item.Description;
                }
                else
                {
                    itemName.text = ""; 
                    itemDescription.text = "";
                }
                lastClicked = new Vector3(-1, -1, -1);
            }
        }
        else
        {
            itemName.text = ""; 
            itemDescription.text = "";
            lastClicked = new Vector3(-1, -1, -1);
        }
    }
}
