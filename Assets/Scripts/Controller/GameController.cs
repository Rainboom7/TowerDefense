using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Game Controller")]
public class GameController : ScriptableObject
{
    public event Action EndGameEvent;
    public event Action<int> AddMoneyEvent;
    public event Action<int> HealthChangeEvent;
    public event Action<int> TowersToBuyRecalculateEvent;
    [Range(0, 1000)]
    public int BeginHealth;
    [Range(0, 1000)]
    public int BeginMoney;
    private int _baseHealth;
    private int _money;
    public void OnMoneyChangeEvent(int value)
    {
        _money += value;
        AddMoneyEvent?.Invoke(_money);
        TowersToBuyRecalculateEvent?.Invoke(_money);
    }
    public void NewGame()
    {
        _baseHealth = BeginHealth;
        _money = BeginMoney;
        OnMoneyChangeEvent(0);
        OnHealthChangeEvent(0);
    }
    public void OnHealthChangeEvent(int damage)
    {
        _baseHealth -= damage;
        if (_baseHealth <= 0)
        {
            EndGameEvent?.Invoke();
        }
        HealthChangeEvent?.Invoke(_baseHealth);
    }
    


}
