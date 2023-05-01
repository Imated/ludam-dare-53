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
    [SerializeField] private float animationDuration = 0.5f;

    private float _lastMoney = 100f;
    private float _lastItemsSold = 0f;
    private float _endDayUIOriginalY;

    private void Awake()
    {
        _endDayUIOriginalY = endDayUI.transform.GetComponent<RectTransform>().anchoredPosition.y;
    }

    public void OnBedClicked()
    {
        moneyMadeText.text = $"MONEY MADE: $ {GameManager.instance.Money - _lastMoney}";
        _lastMoney = GameManager.instance.Money;
        itemsSoldText.text = $"ITEMS SOLD: {GameManager.instance.ItemsSold - _lastItemsSold}";
        _lastItemsSold = GameManager.instance.ItemsSold;
        endDayUI.transform.GetComponent<RectTransform>().DOAnchorPosY(0f, animationDuration).SetEase(Ease.OutBounce);
    }

    public void NextDay()
    {
        endDayUI.transform.GetComponent<RectTransform>().DOAnchorPosY(_endDayUIOriginalY, animationDuration - 0.5f).SetEase(Ease.InBack);
    }
}
