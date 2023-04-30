using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    [SerializeField] private List<Item> availableItems;
    [SerializeField] private List<GameObject> roomItems;
    [SerializeField] private GameObject availableItemParent;
    [SerializeField] private GameObject sellUI;
    [SerializeField] private TMP_InputField sellUIPriceField;
    [SerializeField] private GameObject ownedItemParent;
    [SerializeField] private GameObject shippingItemsParent;
    [SerializeField] private GameObject shippingItemPrefab;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int itemsPerDay = 10;

    private List<Item> _items = new List<Item>();
    private List<Item> _ownedItems = new List<Item>();
    private List<Item> _shippingItems = new List<Item>();
    private Item _currentlySelectedItem;
    private GameObject _currentlySelectedUIItem;

    private void Awake()
    {
        instance = this;
        SpawnItems();
    }

    public void SpawnItems()
    {
        _items.Clear();
        foreach (var c in availableItemParent.transform)
            Destroy((c as Transform)?.gameObject);
        for (var i = 0; i < itemsPerDay; i++)
        {
            var rand = Random.Range(0, availableItems.Count);
            _items.Add(availableItems[rand]);
        }

        foreach (var item in _items)
        {
            var uiItem = Instantiate(itemPrefab, availableItemParent.transform);
            var percent = Random.Range(10, 16);
            var randomCost = item.cost * Random.Range(1f - percent / 100f, 1f + percent / 100f);
            var rand = Random.Range(0, 2);
            var ext = rand == 0f ? 0.00f : 0.50f;
            uiItem.GetComponent<UIItem>().Initialize(item, (int) randomCost + ext);
            uiItem.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                OnItemBuy(item, uiItem, (int) randomCost + ext);
            });
        }
    }
    
    public void OnItemBuy(Item item, GameObject uiItemObject, float cost)
    {
        if(!GameManager.instance.RemoveMoney(cost))
            return;
        if (!_ownedItems.Contains(item))
        {
            for (var i = 0; i < availableItems.Count; i++)
            {
                if(availableItems[i] == item)
                    roomItems[i].SetActive(true);
            }
        }
        _ownedItems.Add(item);
        var uiItem = Instantiate(itemPrefab, ownedItemParent.transform);
        ownedItemParent.transform.position = Vector3.zero;
        uiItem.GetComponent<UIItem>().InitializeOwned(item);
        uiItem.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            _currentlySelectedItem = item;
            _currentlySelectedUIItem = uiItem;
            sellUI.SetActive(true);
        });
    }

    public void SellCurrentItem()
    {
        var item = _currentlySelectedItem;
        _ownedItems.Remove(item);
        Destroy(_currentlySelectedUIItem);
        if(!_ownedItems.Contains(item))
        {
            for (var i = 0; i < availableItems.Count; i++)
            {
                if(availableItems[i] == item)
                    roomItems[i].SetActive(false);
            }
        }
        sellUI.SetActive(false);
        _shippingItems.Add(item);
        var uiItem = Instantiate(shippingItemPrefab, shippingItemsParent.transform);
        int.TryParse(sellUIPriceField.text, out var sellingPrice);
        uiItem.GetComponent<UIItem>().Initialize(item, sellingPrice);
        _currentlySelectedItem = null;
        _currentlySelectedUIItem = null;
    }
}
