using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint, searchCenter;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.left, Vector2Int.down };

    bool initialPathfindingIsRunning = true;

    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    
    // Start is called before the first frame update
    void Start(){
        //FindPath();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            GetPath();
        }
    }

    public List<Waypoint> GetPath() {
        LoadBlocks();
        ColorStartAndEndCube();
        Pathfind();
        CreatePath();
        return path;
    }

    /// <summary>
    /// Find all objects of type Waypoint and add them to grid dictionary, furthermore avoid duplicating elements.
    /// </summary>
    private void LoadBlocks() {
        var waypoints = FindObjectsOfType<Waypoint>();

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


    /// <summary>
    /// Just color start and finish block
    /// </summary>
    private void ColorStartAndEndCube() {
        startWaypoint.ColorStart();
        endWaypoint.ColorEnd();
    }

    
    private void Pathfind() {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && initialPathfindingIsRunning) {
            searchCenter = queue.Dequeue();
            //Debug.Log( "Start searching from: " + searchCenter );
            searchCenter.beenExplored = true;
            HoldWhenEndFound();
            ExploreNeighboors();
        }
    }

    private void CreatePath() {
        Waypoint currentCheckingWaypoint = endWaypoint;

        while(currentCheckingWaypoint != startWaypoint) {
            path.Add(currentCheckingWaypoint);
            currentCheckingWaypoint.ColorPath();
            currentCheckingWaypoint = currentCheckingWaypoint.exploredFrom;
        }
        path.Add(startWaypoint);

        
        path.Reverse();

        /* EnemyMovement myEnemy = FindObjectOfType<EnemyMovement>();
        myEnemy.StartMove(path); */
    }

    private void HoldWhenEndFound() {
        if (searchCenter == endWaypoint) {
            initialPathfindingIsRunning = false;
        }
    }

    private void ExploreNeighboors() {
        if (!initialPathfindingIsRunning) return;

        foreach(Vector2Int dir in directions) {
            //Debug.Log(startWaypoint.GetPosition() + dir);
            Vector2Int neighbourCoordinates = searchCenter.GetPosition() + dir;
            if (grid.ContainsKey(neighbourCoordinates)) {
                QueueNewNeighbour(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordinates) {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (!neighbour.beenExplored || !queue.Contains(neighbour)) {
            neighbour.SetExplorationSource(searchCenter);
            queue.Enqueue(neighbour);
        }
    }
}
