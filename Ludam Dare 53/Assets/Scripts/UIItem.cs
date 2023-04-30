using System;
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
        iconImage.sprite = item.icon;
        itemNameText.text = item.itemName;
        costText.text = $"$ {cost:F2}";
        referenceItem = item;
    }

    public void InitializeOwned(Item item)
    {
        iconImage.sprite = item.icon;
        itemNameText.text = item.itemName;
        GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = "Sell";
        costText.gameObject.SetActive(false);
        referenceItem = item;
    }
}
