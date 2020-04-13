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
    public int BaseHealth { get; private set; }
    public int Money { get; private set; }
    public int moneyPerSecond;
    public void OnMoneyChangeEvent(int value)
    {
        Money += value;
        Debug.Log(Money);
        AddMoneyEvent?.Invoke(Money);
    }
    public void NewGame()
    {
        Money = 200;
        BaseHealth = 100;
        AddMoneyEvent?.Invoke(Money);
        HealthChangeEvent?.Invoke(BaseHealth);

    }
    public void OnHealthChangeEvent(int damage)
    {
        BaseHealth -= damage;
        Debug.Log("healyth changed");
        Debug.Log(BaseHealth);
        HealthChangeEvent?.Invoke(BaseHealth);
    }
    


}
