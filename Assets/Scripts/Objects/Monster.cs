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


    public abstract void ChangeHealth(int damage);


    private static Waypoint[] Waypoints;
    private int currentWaypoint = 0;


    public void SetWayPoints(WayPointsHolder wayPointsHolder)
    {
        Waypoints = wayPointsHolder.GetWaypoints();
        Debug.Log(Waypoints.Length);
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
            if (currentWaypoint < Waypoints.Length - 2)
            {
                currentWaypoint++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
  

