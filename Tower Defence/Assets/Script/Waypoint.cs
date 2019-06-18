using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] public Waypoint exploredFrom;
    [SerializeField] private Color exploredColor;
    [SerializeField] private Color pathColor;

    public bool beenExplored = false;


    Vector2Int gridPos;
    const int gridSize = 10;

    private MeshRenderer topMeshRenderer;

    public void Awake() {
        topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
    }

    public int GetGridSize() {
        return gridSize;
    }

    public void SetExplorationSource(Waypoint explorationSource) {
        if (!exploredFrom) {
            exploredFrom = explorationSource;
        }

    }

    public Vector2Int GetPosition() {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize));
    }
    public void SetTopColor(Color color) {
        /*foreach (Transform wall in GetComponentsInChildren<Transform>()) {
            MeshRenderer myMesh = wall.GetComponent<MeshRenderer>();
            myMesh.material.color = Color.white;
        }*/
        MeshRenderer[] childTransforms = GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer T in childTransforms) {
            GameObject go = T.gameObject;
            MeshRenderer myMesh = T.gameObject.GetComponent<MeshRenderer>();
            myMesh.material.color = Color.white;
        }

        topMeshRenderer.material.color = color;
    }
    public void ColorOnExploration() {
        topMeshRenderer.material.color = exploredColor;
    }
    public void ColorPath() {
        topMeshRenderer.material.color = pathColor;
    }

    public void ColorStart() {
        topMeshRenderer.material.color = Color.green;
    }
    public void ColorEnd() {
        topMeshRenderer.material.color = Color.red;
    }
}