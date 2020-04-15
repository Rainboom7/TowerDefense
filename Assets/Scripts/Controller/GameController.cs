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
    public int BaseHealth { get; private set; }
    public int Money { get; private set; }
    public void OnMoneyChangeEvent(int value)
    {
        Money += value;
        Debug.Log(Money);
        AddMoneyEvent?.Invoke(Money);
        TowersToBuyRecalculateEvent?.Invoke(Money);
    }
    public void NewGame()
    {
        Money = 100;
        BaseHealth = 100;
        OnMoneyChangeEvent(0);
        OnHealthChangeEvent(0);
    }
    public void OnHealthChangeEvent(int damage)
    {
        BaseHealth -= damage;
        if (BaseHealth <= 0)
        {
            EndGameEvent?.Invoke();
        }
        HealthChangeEvent?.Invoke(BaseHealth);
    }
    


}
