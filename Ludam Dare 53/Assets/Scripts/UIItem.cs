using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text sellPriceText;
    [SerializeField] private TMP_Text costText;

    public void Initialize(Item item)
    {
        iconImage.sprite = item.icon;
        itemNameText.text = item.itemName;
        sellPriceText.text = $"Selling For $ {item.sellPrice}";
        costText.text = $"$ {item.cost}";
    }
}
