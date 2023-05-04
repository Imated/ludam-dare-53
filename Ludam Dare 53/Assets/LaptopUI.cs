using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaptopUI : MonoBehaviour
{
    [SerializeField] private Sprite MarketSelected;
    [SerializeField] private Sprite OwnedSelected;
    [SerializeField] private GameObject marketContainer;
    [SerializeField] private GameObject ownedItemsContainer;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void MarketClicked()
    {
        image.sprite = MarketSelected;
    }

    public void OwnedClicked()
    {
        image.sprite = OwnedSelected;
    }

    public void OnBedClicked()
    {
        OwnedClicked();
        marketContainer.SetActive(true);
        ownedItemsContainer.SetActive(false);
    }
}
