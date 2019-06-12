using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.left, Vector2Int.down };

    bool isRunning = true;
    
    // Start is called before the first frame update
    void Start(){
        LoadBlocks();
        ColorStartAndEndCube();
        //ExploreNeighboors();
        Pathfind();
    }

    private void Pathfind() {
        queue.Enqueue(startWaypoint);
        while(queue.Count > 0 && isRunning) {
            Waypoint searchCenter = queue.Dequeue();
            HoldWhenEndFound(searchCenter);
        }
        Debug.Log("Pathfind finished");
    }

    private void HoldWhenEndFound(Waypoint src) {
        if (src == endWaypoint) {
            isRunning = false;
        }
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

    private void ExploreNeighboors() {
        if (!isRunning) return;

        foreach(Vector2Int dir in directions) {
            Debug.Log(startWaypoint.GetPosition() + dir);
        }
    }
}
