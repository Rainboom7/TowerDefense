using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSite : MonoBehaviour
{
    private Tower _selectedTower;
    private Tower _tower;
    private void Start()
    {
        _tower = null;
    }
    
    private void OnMouseDown()
    {
        Debug.Log('a');
        if (CanPlace())
        {
            _tower = Instantiate(_selectedTower, transform.position+new Vector3(0.0f,0.5f,0.0f), Quaternion.identity);
        }
    }


    public bool CanPlace()
    {
        return _tower == null;
    }

    public void SelectTower(Tower tower)
    {
        _selectedTower = tower;
    }

}
