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
    public SpawnController spawnController;
    public HudView HudView;
    private const int SECOND = 1;
    private void OnEnable()
    {
        StartGame();
    }
   
    private void StartGame()
    {
        _towerSelectView.Towers = Towers;
        _towerSelectView.SelectTowerAction += TowerController.SelectTower;
        _towerSelectView.ShowButtons();
        BeginGamePanelView.ShowHudEvent += HudView.ShowHud;
        Controller.HealthChangeEvent += HudView.SetHealth;
        Controller.AddMoneyEvent += HudView.SetMoney;
        Controller.TowersToBuyRecalculateEvent += _towerSelectView.Recalculate;
        Controller.EndGameEvent += StopGame;
        Controller.NewGame();
        spawnController.Begin();
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
        Controller.EndGameEvent -= StopGame;
        Controller.TowersToBuyRecalculateEvent -= _towerSelectView.Recalculate;
        spawnController.Stop();

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
