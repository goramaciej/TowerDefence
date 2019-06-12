using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
        
    public int GetGridSize() {
        return gridSize;
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

        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
    public void colorStart() {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = Color.green;
    }
    public void colorEnd() {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = Color.red;
    }
}