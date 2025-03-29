#nullable enable

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    private int WIDTH;
    private int HEIGHT;
    
    [SerializeField] private Transform slotsPanelTransform = null!;
    [SerializeField] private GridLayoutGroup slotsGridLayoutGroup = null!;
    [SerializeField] private Transform itemsPanelTransform = null!;
    
    [SerializeField] private GameObject slotForItemPrefab = null!;
    
    private List<List<GameObject>> slotsForItems = new List<List<GameObject>>();
    private List<List<Item?>> field = new List<List<Item?>>();
    
    private Vector2Int fieldPosition;
    
    public void SetWidthAndHeightOfInventoryGrid(int WIDTH, int HEIGHT)
    {
        this.WIDTH = WIDTH;
        this.HEIGHT = HEIGHT;
    }
    
    public void Start()
    {
        for (int i = 0; i < HEIGHT; ++i)
        {
            slotsForItems.Add(new List<GameObject>());
            field.Add(new List<Item?>());
            for (int j = 0; j < WIDTH; ++j)
            {
                GameObject newSlotForItem = Instantiate(slotForItemPrefab, slotsPanelTransform);
                slotsForItems[i].Add(newSlotForItem);

                field[i].Add(null);
            }
        }
        
        slotsGridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        slotsGridLayoutGroup.constraintCount = WIDTH;
    }

    public bool AddItem(Item item, GameObject itemPrefab)
    {
        int x = -1;
        int y = -1;

        for (int i = 0; i < HEIGHT; ++i)
        {
            for (int j = 0; j < WIDTH; ++j)
            {
                if (field[i][j] == null)
                {
                    x = i;
                    y = j;
                    break;
                }
            }
        }

        if (x == -1)
        {
            return false;
        }

        HammerView view = Instantiate(itemPrefab, itemsPanelTransform).GetComponent<HammerView>();
        view.transform.position = slotsForItems[x][y].transform.position;
        view.Init(item);
        
        field[x][y] = item;
        fieldPosition = new Vector2Int(x, y);
        item.OnDestroy += SlotRelease;

        return true;
    }

    private Vector2Int GetCoordinates(Vector3 position)
    {
        Debug.Log(position.x + " " + position.y);
        
        for (int i = 0; i < HEIGHT; ++i)
        {
            for (int j = 0; j < WIDTH; ++j)
            {
                if (position.Equals(slotsForItems[i][j].transform.position))
                {
                    return new Vector2Int(i, j);
                }
            }
        }
        
        return new Vector2Int(0, 0);
    }

    public Item? GetItem(Vector3 position)
    {
        Vector2Int coordinates = GetCoordinates(position);
        
        Debug.Log(coordinates.x + " " + coordinates.y);

        return field[coordinates.x][coordinates.y];
    }

    private void SlotRelease()
    {
        field[fieldPosition.x][fieldPosition.y] = null;
    }
}
