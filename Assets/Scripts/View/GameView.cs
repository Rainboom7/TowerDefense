using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public Tower[] Towers;
    [SerializeField]
    private TowerSelectView _towerSelectView;
    public GameController Controller;
    public TowerController TowerController;
    public BeginGamePanelView BeginGamePanelView;
    public GameOverPanelView GameOverPanelView;
    public int moneyPerSecond;
    public SpawnController SpawnController;
    public HudView HudView;
    private const int SECOND = 1;
    private void OnEnable()
    {
        _towerSelectView.Towers = Towers;
        _towerSelectView.SelectTowerAction += TowerController.SelectTower;
        _towerSelectView.ShowButtons();
        BeginGamePanelView.ShowHudEvent += HudView.ShowHud;
        BeginGamePanelView.StartGameEvent += StartGame;
        Controller.HealthChangeEvent += HudView.SetHealth;
        Controller.AddMoneyEvent += HudView.SetMoney;
        Controller.TowersToBuyRecalculateEvent += _towerSelectView.Recalculate;
        Controller.EndGameEvent += StopGame;
    }
   
    private void StartGame()
    { 
        Controller.NewGame();
        SpawnController.Begin();
        StartCoroutine(AddMoneyRoutine);
    }
    private void StopGame() {
        GameOverPanelView.GameOver();
        HudView.HideHud();
        StopCoroutine(AddMoneyRoutine);
        _towerSelectView.SelectTowerAction -= TowerController.SelectTower;
        Controller.HealthChangeEvent -= HudView.SetHealth;
        Controller.AddMoneyEvent -= HudView.SetMoney;
        Controller.EndGameEvent -= StopGame;
        BeginGamePanelView.ShowHudEvent -= HudView.ShowHud;
        BeginGamePanelView.StartGameEvent -= StartGame;
        Controller.EndGameEvent -= StopGame;
        Controller.TowersToBuyRecalculateEvent -= _towerSelectView.Recalculate;
        SpawnController.Stop();
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
