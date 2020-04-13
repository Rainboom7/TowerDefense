using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    
    public GameController Controller;
    public int moneyPerSecond;
    public SpawnController spawnController;
    [SerializeField]
    private HudView _hudView;
    private const int SECOND = 1;
    private void OnEnable()
    {
        StartGame();
    }
    private void OnDisable()
    {
        StopGame();
    }
    private void StartGame()
    {
        Controller.HealthChangeEvent += _hudView.SetHealth;
        Controller.AddMoneyEvent += _hudView.SetMoney;
        Controller.NewGame();
        spawnController.Begin();
        StartCoroutine(AddMoneyRoutine);
    }
    private void StopGame() {
        StopCoroutine(AddMoneyRoutine);
        Controller.HealthChangeEvent -= _hudView.SetHealth;
        Controller.AddMoneyEvent -= _hudView.SetMoney;
    }
    
    public IEnumerator AddMoneyRoutine
    {
        get
        {
            yield return new WaitForSeconds(SECOND);
            while (true)
            {
                Controller?.OnMoneyChangeEvent(moneyPerSecond);
                yield return new WaitForSeconds(SECOND);
            }
        }
    }
}
