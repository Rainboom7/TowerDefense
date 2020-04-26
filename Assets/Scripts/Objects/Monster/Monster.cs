using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private GameController _gameController;
    [SerializeField]
    [Range(0, 100)]
    protected int _health;
    [SerializeField]
    [Range(0, 100)]
    protected int _cost;
    [SerializeField]
    [Range(0, 25)]
    protected float _speed;
    [SerializeField]
    [Range(0, 15)]
    protected int _damage;
    public  event Action<int> HealthChangeEvent;

    private static Waypoint[] Waypoints;
    private int currentWaypoint = 0;

    public void ChangeHealth(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _gameController?.OnMoneyChangeEvent(_cost);
            Destroy(gameObject);
        }
    }

    public void SetWayPoints(WayPointsHolder wayPointsHolder)
    {
        if(wayPointsHolder!=null)
             Waypoints = wayPointsHolder.GetWaypoints();
    }

    

    public void DoDamage() {
        HealthChangeEvent?.Invoke(_damage);
    }

    private void Update()
    {
        if (Waypoints != null)
        {
            Vector3 destination = Waypoints[currentWaypoint].transform.position;
            Vector3 direction = (destination - transform.position).normalized;
            if (Vector3.Distance(transform.position, destination) > 0.1)
            {
                gameObject.transform.position += direction * _speed * Time.deltaTime;

            }
            else
            {
                if (currentWaypoint < Waypoints.Length - 1)
                {
                    currentWaypoint++;
                }
                else
                {
                    DoDamage();
                    Destroy(gameObject);
                }
            }
        }
    }
}
  

