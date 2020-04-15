using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField]
    private List<TowerSite> _towerSites;
    [SerializeField]
    private GameController _gameController;
    private void OnEnable()
    {
        foreach (TowerSite towerSite in _towerSites)
        {
            towerSite.ChangeMoneyAction += _gameController.OnMoneyChangeEvent;
            towerSite.DeselectTowerAction += deselectTower;
        }
    }
    public void SelectTower(Tower tower)
    {
        foreach (TowerSite towerSite in _towerSites)
        {
            towerSite.SelectTower(tower);
        }     
    }
    private void deselectTower()
    {
        SelectTower(null);
    }
    private void OnDisable()
    {
        foreach (TowerSite towerSite in _towerSites)
        {
            towerSite.ChangeMoneyAction -= _gameController.OnMoneyChangeEvent;
            towerSite.DeselectTowerAction -= deselectTower;
        }
    }
}
