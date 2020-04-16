using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsHolder : MonoBehaviour
{
    [SerializeField]
    private Waypoint[] _waypoints;
    public Waypoint[] GetWaypoints()
    {
        return _waypoints;
    }
}
