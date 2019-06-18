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

    private List<Waypoint> path = new List<Waypoint>();
    
    // Start is called before the first frame update
    void Start(){
        //FindPath();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            FindPath();
        }
    }

    private void FindPath() {
        Debug.Log("Finding Path from Pathfinder");
        LoadBlocks();
        ColorStartAndEndCube();
        Pathfind();
        ColorMyPathFromEnd();
        //ExploreNeighboors();
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
        //Debug.Log("Pathfind finished");
    }

    private void ColorMyPathFromEnd() {
        bool coloringPathState = true;
        Waypoint currentCheckingWaypoint = endWaypoint;
        /*for (var i = 0; i<10; i++) {
            
            if (currentCheckingWaypoint == startWaypoint) {
                break;
            }
        }*/
        while(currentCheckingWaypoint != startWaypoint) {
            path.Add(currentCheckingWaypoint);
            currentCheckingWaypoint.ColorPath();
            currentCheckingWaypoint = currentCheckingWaypoint.exploredFrom;
        }

        // REVERSE LIST
        List<Waypoint> tempList = new List<Waypoint>();
        for (int i = path.Count-1; i > -1; i--) {
            tempList.Add(path[i]);
        }

        EnemyMovement myEnemy = FindObjectOfType<EnemyMovement>();
        myEnemy.StartMove(tempList);
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
            try {
                QueueNewNeighbour(neighbourCoordinates);
            } catch {

            }
        }
    }
    private void QueueNewNeighbour(Vector2Int neighbourCoordinates) {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (!neighbour.beenExplored || !queue.Contains(neighbour)) {
            //neighbour.SetTopColor(Color.magenta);
            //neighbour.exploredFrom = searchCenter;
            neighbour.SetExplorationSource(searchCenter);
            queue.Enqueue(neighbour);
        }
    }
}
