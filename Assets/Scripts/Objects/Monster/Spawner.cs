using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Range(3, 10)]
    public float Delay;
    [Range(3,10)]
    public float SpawnTime;
    private Monster[] _monsters;
    private WayPointsHolder _wayPoint;
    public event Action<int> HealthChangeEvent;
    private float _timer;
   

    public void SetMonstersAndWaypoints(WayPointsHolder wayPoints,ref Monster[] monsters)
    { 
        _wayPoint = wayPoints;
        _monsters = monsters;       
     }

    public IEnumerator SpawnRoutine
    {
        get
        {
            
            yield return new WaitForSeconds(Delay);
            while (true)
            {
                SpawnTime *= 0.98f;
                int index = UnityEngine.Random.Range(0, _monsters.Length);
               Monster newMonster= Instantiate(_monsters[index], transform.position, transform.rotation);
                newMonster.SetWayPoints(_wayPoint);
                newMonster.HealthChangeEvent += HealthChangeEvent;
                yield return new WaitForSeconds(SpawnTime);
            }
        }
    }
    private Monster GetRandomMonster() {
        int index = UnityEngine.Random.Range(0, _monsters.Length);
        Monster newMonster = _monsters[index];
        newMonster.SetWayPoints(_wayPoint);
        return newMonster;
    }
}
