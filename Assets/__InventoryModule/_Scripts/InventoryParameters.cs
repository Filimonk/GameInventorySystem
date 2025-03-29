using TMPro;
using UnityEngine;

public class InventoryParameters : MonoBehaviour
{
    [SerializeField] private int WIDTH = 5;
    [SerializeField] private int HEIGHT = 4;
    
    [SerializeField] private KeyCode inventoryMenuKey = KeyCode.I;
    private GameObject inventoryPanel;
    private bool inventoryPanelActivated;
    
    [SerializeField] private TMP_FontAsset descriptionFieldFont;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemDescription;

    [SerializeField] private bool descriptionBlock = true;

    public void Awake()
    {
        inventoryPanel = transform.Find("InventoryPanel").gameObject;


        GameObject inventoryGridPanel = inventoryPanel.transform.Find("InventoryGridPanel").gameObject;
        inventoryGridPanel.GetComponent<InventoryGrid>().SetWidthAndHeightOfInventoryGrid(WIDTH, HEIGHT);
        
        
        GameObject observationPanel = inventoryPanel.transform.Find("ObservationPanel").gameObject;
        GameObject descriptionPanel = observationPanel.transform.Find("DescriptionPanel").gameObject;
        Transform itemNameTransform = descriptionPanel.transform.Find("ItemName");
        Transform itemDescriptionTransform = descriptionPanel.transform.Find("ItemDescription");
        itemName = itemNameTransform.GetComponent<TextMeshProUGUI>();
        itemDescription = itemDescriptionTransform.GetComponent<TextMeshProUGUI>();

        itemName.font = descriptionFieldFont;
        itemDescription.font = descriptionFieldFont;
        
        
        inventoryPanel.GetComponent<InventoryManager>().Init(inventoryGridPanel, itemName, 
                                                             itemDescription, descriptionBlock);
        inventoryPanel.SetActive(false);
        inventoryPanelActivated = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(inventoryMenuKey) && !inventoryPanelActivated)
        {
            inventoryPanel.SetActive(true);
            inventoryPanelActivated = true;
        }
        else if (Input.GetKeyDown(inventoryMenuKey) && inventoryPanelActivated)
        {
            inventoryPanel.SetActive(false);
            inventoryPanelActivated = false;
        }
    }
}
