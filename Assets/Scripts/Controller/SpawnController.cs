using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField]
    private Spawner _spawnpoint;
    private Coroutine _spawnRoutine;
    public WayPointsHolder WayPoints;
    public GameController Controller;
    public Monster[] Monsters;
    public void Begin()
    {
        _spawnpoint.HealthChangeEvent += Controller.OnHealthChangeEvent;
        _spawnpoint.SetMonstersAndWaypoints(WayPoints,ref Monsters);
        _spawnRoutine = StartCoroutine(_spawnpoint.SpawnRoutine);
    }

    public void Stop()
    {
        _spawnpoint.HealthChangeEvent -= Controller.OnHealthChangeEvent;

        if (_spawnRoutine != null)
            StopCoroutine(_spawnRoutine);
        _spawnRoutine = null;
    }
}
