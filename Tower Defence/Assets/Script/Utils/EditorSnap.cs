using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class EditorSnap : MonoBehaviour
{
    
     //waypoint;

    private void Awake() {
        Debug.Log("EditorSnapAwaken");
        //Debug.Log("EditorSnap: " + waypoint);
    }

    void Update()
    {        
        SnapToGrid();
        UpdateLabel();
    }

    void SnapToGrid() {
        Waypoint waypoint = GetComponent<Waypoint>();
        Vector2Int waypointPosition = waypoint.GetPosition();
        /*int gridSize = waypoint.GetGridSize();
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;*/
        Vector3 snapPos = new Vector3(waypointPosition.x, 0f, waypointPosition.y);
        transform.position = snapPos;
    }

    void UpdateLabel() {
        Waypoint waypoint = GetComponent<Waypoint>();
        Vector2Int waypointPosition = waypoint.GetPosition();
        int gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = (waypointPosition.x / gridSize).ToString() + "," + (waypointPosition.y  / gridSize).ToString();
        gameObject.name = "Cube (" + textMesh.text + ")";
    }
}
