using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text costText;

    public void Initialize(Item item, float cost)
    {
        iconImage.sprite = item.icon;
        itemNameText.text = item.itemName;
        costText.text = $"$ {cost - 0.01f}";
    }
}
