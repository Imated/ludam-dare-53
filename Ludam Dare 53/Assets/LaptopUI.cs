using UnityEngine;
using UnityEngine.UI;

public class LaptopUI : MonoBehaviour
{
    [SerializeField] private Sprite marketSelected;
    [SerializeField] private Sprite marketHighlighted;
    [SerializeField] private Sprite ownedSelected;
    [SerializeField] private Sprite ownedHighlighted;
    [SerializeField] private GameObject marketContainer;
    [SerializeField] private GameObject ownedItemsContainer;
    
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void MarketClicked()
    {
        _image.sprite = marketSelected;
    }

    public void OwnedClicked()
    {
        _image.sprite = ownedSelected;
    }

    public void MarketHovered()
    {
        _image.sprite = marketHighlighted;
    }

    public void OwnedHovered()
    {
        _image.sprite = ownedHighlighted;
    }
    
    public void MarketStoppedHovering()
    {
        _image.sprite = ownedSelected;
    }

    public void OwnedStoppedHovering()
    {
        _image.sprite = marketSelected;
    }
    
    public void OnBedClicked()
    {
        MarketClicked();
        marketContainer.SetActive(true);
        ownedItemsContainer.SetActive(false);
    }
}
