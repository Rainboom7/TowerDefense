using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectView : MonoBehaviour
{
    
    [HideInInspector]
    public Tower[] Towers;
    [SerializeField]
    private TowerButtonView[] Buttons;
    [HideInInspector]
    public Action<Tower> SelectTowerAction;

    public void ShowButtons()
    {
        for (int i = 0; i < Towers.Length; i++)
        {
            Buttons[i].Tower = Towers[i];
            Buttons[i].SelectTowerAction += SelectTowerAction;
            Buttons[i].Enable();
        }
    }
    public void Recalculate(int Money)
    {
        foreach (TowerButtonView buttonView in Buttons)
        {
            if (buttonView.Tower.Cost > Money)
            {
                buttonView.Button.interactable = false;
            }
            if (buttonView.Tower.Cost <= Money && (buttonView.Button.interactable==false))
            {
                buttonView.Button.interactable = true;
            }

        }
    }
  
}
