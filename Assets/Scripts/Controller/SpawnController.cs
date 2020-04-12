using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField]
    private Spawner _spawnpoint;
    private Coroutine _spawnRoutine;
    public WayPointsHolder WayPoints;
    public Monster[] Monsters;
    private void OnEnable()
    {
        _spawnpoint.SetMonstersAndWaypoints(WayPoints,Monsters);
        _spawnRoutine = StartCoroutine(_spawnpoint.SpawnRoutine);
    }

    private void OnDisable()
    {
        if (_spawnRoutine != null)
            StopCoroutine(_spawnRoutine);
        _spawnRoutine = null;
    }
}
