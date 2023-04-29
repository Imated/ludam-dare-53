using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    [SerializeField] private List<Item> availableItems;
    [SerializeField] private GameObject availableItemParent;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int itemsPerDay = 10;

    private List<Item> _items = new List<Item>();

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
            var percent = Random.Range(25, 31);
            var randomCost = item.cost * Random.Range(1f - percent / 100f, 1f + percent / 100f);
            uiItem.GetComponent<UIItem>().Initialize(item, (int) randomCost);
        }
    }
}