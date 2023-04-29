using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [HideInInspector] public Item referenceItem;
    
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text costText;

    public void Initialize(Item item, float cost)
    {
        var rand = Random.Range(0, 2);
        var ext = rand == 0 ? ".00" : ".50";
        iconImage.sprite = item.icon;
        itemNameText.text = item.itemName;
        costText.text = $"$ {cost}{ext}";
        referenceItem = item;
    }
}
