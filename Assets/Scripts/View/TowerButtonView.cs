using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerButtonView : MonoBehaviour
{
    [HideInInspector]
    public Button Button;
    [HideInInspector]
    public Tower Tower;
    [HideInInspector]
    public Text TowerName;
   [HideInInspector]
    public Text TowerCost;
    [SerializeField]
    private TowerController _towerController;
    public Action<Tower> SelectTowerAction;
    public void Enable()
    {
        Button = gameObject.GetComponent<Button>();
        TowerName.text = Tower.GetName();
        TowerCost.text = Tower.GetCost().ToString();
        Button.interactable = false;
    }
    public void SelectTower()
    {
        SelectTowerAction?.Invoke(Tower);
    }
}
