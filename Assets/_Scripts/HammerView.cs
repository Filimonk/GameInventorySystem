using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HammerView : MonoBehaviour
{
    private Item item;
    
    private Image backgroundImage;

    private void Awake()
    {
        backgroundImage = GetComponent<Image>();
    }

    public void Init(Item item)
    {
        this.item = item;

        item.OnDestroy += CellViewDestroy;
        item.OnValueDecrease += DecreaseColor;
    }
    
    private void CellViewDestroy()
    {
        Destroy(gameObject);
    }
    
    private void OnDestroy()
    {
        item.OnDestroy -= CellViewDestroy;
        item.OnValueDecrease -= DecreaseColor;
    }
    
    private void DecreaseColor()
    {
        Color currentColor = backgroundImage.color;
        currentColor.a /= 2;
        
        backgroundImage.color = currentColor;
    }

    private void UpdatePosition(Vector3 coordinates)
    {
        transform.position = coordinates;
    }
}
