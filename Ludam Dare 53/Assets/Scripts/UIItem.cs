using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [HideInInspector] public Item referenceItem;
    
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject editUI;

    private bool _isTransaction;
    private float _chanceOfBeingSold;
    private float _sellingPrice;
    
    public void Initialize(Item item, float cost)
    {
        iconImage.sprite = item.icon;
        itemNameText.text = item.itemName;
        costText.text = $"$ {cost:F2}";
        referenceItem = item;
    }

    public void InitializeOwned(Item item, float cost)
    {
        iconImage.sprite = item.icon;
        itemNameText.text = item.itemName;
        GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = "Sell";
        costText.text = $"$ {cost:F2}";
        referenceItem = item;
    }

    public void InitializeTransaction(Item item, float price)
    {
        iconImage.sprite = item.icon;
        itemNameText.text = item.itemName;
        costText.text = $"$ {price:F2}";
        referenceItem = item;
        _sellingPrice = price;
        _isTransaction = true;
        _chanceOfBeingSold = Mathf.Pow(82, item.cost / price) / 100;
        print(price);
        print(_chanceOfBeingSold * 100 + "%");
    }

    public bool TrySell()
    {
        if(!_isTransaction)
            return false;
        if (Random.value < _chanceOfBeingSold)
        {
            GameManager.instance.AddMoney(_sellingPrice);
            GameManager.instance.IncreaseItemsSold();
            Destroy(gameObject);
            return true;
        }

        return false;
    }

    public void OnBuy()
    {
        if(GameManager.instance.Money >  referenceItem.cost && buyButton.GetComponentInChildren<TMP_Text>().text == "BUY")
        {
            buyButton.GetComponentInChildren<TMP_Text>().text = "SOLD";
            buyButton.image.color = Color.gray;
            buyButton.interactable = false;
            buyButton.GetComponent<Interactable>().enabled = false;
        }
    }

    public void ChangePrice(Item item, float price)
    {
        costText.text = $"$ {price:F2}";
        _sellingPrice = price;
        _chanceOfBeingSold = Mathf.Pow(82, item.cost / price) / 100;
    }
}
