using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryParameters : MonoBehaviour
{
    [SerializeField] private int WIDTH = 5;
    [SerializeField] private int HEIGHT = 4;
    
    [SerializeField] private KeyCode inventoryMenuKey = KeyCode.I;
    private GameObject inventoryPanel;
    private bool inventoryPanelActivated;

    private InventoryGrid inventoryGrid;
    
    [SerializeField] private TMP_FontAsset descriptionFieldFont;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemDescription;

    [SerializeField] private bool descriptionBlock = true;

    public void Awake()
    {
        inventoryPanel = transform.Find("InventoryPanel").gameObject;


        GameObject inventoryGridPanel = inventoryPanel.transform.Find("InventoryGridPanel").gameObject;
        inventoryGrid = inventoryGridPanel.GetComponent<InventoryGrid>();
        inventoryGrid.SetWidthAndHeightOfInventoryGrid(WIDTH, HEIGHT);
        
        
        GameObject observationPanel = inventoryPanel.transform.Find("ObservationPanel").gameObject;
        GameObject descriptionPanel = observationPanel.transform.Find("DescriptionPanel").gameObject;
        Transform itemNameTransform = descriptionPanel.transform.Find("ItemName");
        Transform itemDescriptionTransform = descriptionPanel.transform.Find("ItemDescription");
        itemName = itemNameTransform.GetComponent<TextMeshProUGUI>();
        itemDescription = itemDescriptionTransform.GetComponent<TextMeshProUGUI>();

        itemName.font = descriptionFieldFont;
        itemDescription.font = descriptionFieldFont;
        
        
        inventoryPanel.GetComponent<InventoryManager>().Init(inventoryGrid, itemName, 
                                                             itemDescription, descriptionBlock);
        inventoryPanel.SetActive(false);
        inventoryPanelActivated = false;
    }

    private List<Tuple<Item, GameObject>> requestQueue = new List<Tuple<Item, GameObject>>();
    public void AddItem(Item item, GameObject itemPrefab)
    {
        if (inventoryPanelActivated)
        {
            inventoryGrid.AddItem(item, itemPrefab);
        }
        else
        {
            requestQueue.Add(new Tuple<Item, GameObject>(item, itemPrefab));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(inventoryMenuKey) && !inventoryPanelActivated)
        {
            inventoryPanel.SetActive(true);
            inventoryPanelActivated = true;

            foreach (var request in requestQueue)
            {
                if (!inventoryGrid.AddItem(request.Item1, request.Item2))
                {
                    Debug.Log("Объект не добавлен - инвентарь переполнен");
                }
            }
        }
        else if (Input.GetKeyDown(inventoryMenuKey) && inventoryPanelActivated)
        {
            inventoryPanel.SetActive(false);
            inventoryPanelActivated = false;
        }
    }
}
