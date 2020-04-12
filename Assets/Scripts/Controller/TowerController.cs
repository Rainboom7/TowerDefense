using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField]
    private List<TowerSite> _towerSites;
    public Tower tower;
    private void OnEnable()
    {
        SelectTower(tower);
    }
    private void SelectTower(Tower tower)
    {
        foreach (TowerSite towerSite in _towerSites)
        {
            towerSite.SelectTower(tower);
        }
    }
}
