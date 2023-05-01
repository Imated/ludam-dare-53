using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaptopUI : MonoBehaviour
{
    [SerializeField] private Sprite MarketSelected;
    [SerializeField] private Sprite OwnedSelected;
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
}
