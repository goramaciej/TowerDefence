using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();    
    
    // Start is called before the first frame update
    void Start(){
        LoadBlocks();
        ColorStartAndEndCube();
    }

    private void LoadBlocks() {
        var waypoints = FindObjectsOfType<Waypoint>();
        // check whether there already is a block on this position;

        foreach (Waypoint waypoint in waypoints) {
            Vector2Int pos = waypoint.GetPosition();
            if (grid.ContainsKey(pos)) {
                // there is already block on this position in dictionary
                Debug.LogWarning("Skip overlapping block: " + waypoint);
            } else {
                // no duplication, can add it at ease
                grid.Add(waypoint.GetPosition(), waypoint);
                waypoint.SetTopColor(Color.grey);
            }
        }
    }
    private void ColorStartAndEndCube() {
        startWaypoint.colorStart();
        endWaypoint.colorEnd();
    }
}
