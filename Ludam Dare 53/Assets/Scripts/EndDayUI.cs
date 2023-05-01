using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndDayUI : MonoBehaviour
{
    [SerializeField] private GameObject endDayUI;
    [SerializeField] private TMP_Text moneyMadeText;
    [SerializeField] private TMP_Text itemsSoldText;
    [SerializeField] private TMP_Text foodAndShippingText;
    [SerializeField] private float animationDuration = 0.5f;

    private float foodAndShippingCost;
    private float _lastMoney = 100f;
    private float _lastItemsSold = 0f;
    private float _endDayUIOriginalY;

    private void Awake()
    {
        _endDayUIOriginalY = endDayUI.transform.GetComponent<RectTransform>().anchoredPosition.y;
    }

    public void OnBedClicked()
    {
        if(GameManager.instance.Money - _lastMoney < 0)
            moneyMadeText.text = $"MONEY MADE: <color=#C30010>$ {GameManager.instance.Money - _lastMoney}</color>";
        else if(GameManager.instance.Money - _lastMoney == 0)
            moneyMadeText.text = $"MONEY MADE: $ {GameManager.instance.Money - _lastMoney}";
        else
            moneyMadeText.text = $"MONEY MADE: <color=#276221>$ {GameManager.instance.Money - _lastMoney}</color>";

        foodAndShippingCost = (GameManager.instance.ItemsSold - _lastItemsSold) * 0.5f + 1;
        GameManager.instance.RemoveMoney(foodAndShippingCost);
        foodAndShippingText.text = $"FOOD AND SHIPPING: <color=#C30010>$ {-foodAndShippingCost}</color>";
        _lastMoney = GameManager.instance.Money;
        itemsSoldText.text = $"ITEMS SOLD: {GameManager.instance.ItemsSold - _lastItemsSold}";
        _lastItemsSold = GameManager.instance.ItemsSold;
        endDayUI.transform.GetComponent<RectTransform>().DOAnchorPosY(0f, animationDuration).SetEase(Ease.OutExpo);
    }

    public void NextDay()
    {
        endDayUI.transform.GetComponent<RectTransform>().DOAnchorPosY(_endDayUIOriginalY, animationDuration - 0.5f).SetEase(Ease.InExpo);
    }
}
