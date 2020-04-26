using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class TowerSite : MonoBehaviour
    {
        private Tower _selectedTower;
        [HideInInspector]
        public event Action<int> ChangeMoneyAction;
        [HideInInspector]
        public event Action DeselectTowerAction;




        public void Onclick()
        {
            if (_selectedTower != null)
            {
                Instantiate(_selectedTower, transform.position + new Vector3(0.0f, 0.5f, -90.0f), Quaternion.identity);
                ChangeMoneyAction?.Invoke(-_selectedTower.Cost);
                DeselectTowerAction?.Invoke();
                gameObject.SetActive(false);
            }
        }



        public void SelectTower(Tower tower)
        {
            _selectedTower = tower;
        }

    }
