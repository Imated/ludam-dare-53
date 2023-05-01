using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndDayUI : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private GameObject endDayUI;
    [SerializeField] private TMP_Text moneyMadeText;
    [SerializeField] private TMP_Text itemsSoldText;
    [SerializeField] private float fadeDuration = 0.5f;

    private float _lastMoney = 100f;
    private float _lastItemsSold = 0f;
    
    public void OnBedClicked()
    {
        fadeImage.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            endDayUI.SetActive(true);
            moneyMadeText.text = $"MONEY MADE: $ {GameManager.instance.Money - _lastMoney}";
            _lastMoney = GameManager.instance.Money;
            itemsSoldText.text = $"ITEMS SOLD: {GameManager.instance.ItemsSold - _lastItemsSold}";
            _lastItemsSold = GameManager.instance.ItemsSold;
            Invoke(nameof(NextDay), 1f);
        });
    }

    private void NextDay()
    {
        endDayUI.SetActive(false);
        fadeImage.DOFade(0f, fadeDuration);
    }
}
