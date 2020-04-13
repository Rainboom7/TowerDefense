using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Delay;
    public float SpawnTime = 2f;
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
