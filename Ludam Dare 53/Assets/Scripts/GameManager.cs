using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private int startingMoney = 100;
    
    private float _money;
    public float Money => _money;
    private int _day;
    public int Day => _day;

    private void Awake()
    {
        AddMoney(startingMoney);
        IncreaseDayCount();
        instance = this;
    }

    public void IncreaseDayCount()
    {
        _day++;
        UpdateUI();
    }

    public bool AddMoney(float amount)
    {
        _money += amount;
        UpdateUI();
        return true;
    }
    
    public bool RemoveMoney(float amount)
    {
        if (_money - amount >= 0)
        {
            _money -= amount;
            UpdateUI();
            return true;
        }

        return false;
    }

    private void UpdateUI()
    {
        moneyText.text = $"$ {_money}";
        dayText.text = $"Day {_day}";
    }
}
