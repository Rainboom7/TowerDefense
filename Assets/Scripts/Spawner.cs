using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Delay;
    public float SpawnTime = 2f;
    private Monster[] _monsters;
    private WayPointsHolder _wayPoint;
    private float _timer;
   

    public void SetMonstersAndWaypoints(WayPointsHolder wayPoints,Monster[] monsters)
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
                Monster monster = GetRandomMonster();
                Instantiate(monster, transform.position, transform.rotation);
                yield return new WaitForSeconds(SpawnTime);
            }
        }
    }
    private Monster GetRandomMonster() {
        int index = Random.Range(0, _monsters.Length);
        Monster newMonster = _monsters[index];
        newMonster.SetWayPoints(_wayPoint);
        return newMonster;
    }
}
