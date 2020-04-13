using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    [SerializeField]
    protected int _health;
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected int _damage;
    public  event Action<int> HealthChangeEvent;

    private static Waypoint[] Waypoints;
    private int currentWaypoint = 0;

    public void ChangeHealth(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Destroy(gameObject);
    }

    public void SetWayPoints(WayPointsHolder wayPointsHolder)
    {
        Waypoints = wayPointsHolder.GetWaypoints();
        Debug.Log(Waypoints.Length);
    }
    public void DoDamage() {
        HealthChangeEvent?.Invoke(_damage);
    }
  
    private void Update()
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
  

