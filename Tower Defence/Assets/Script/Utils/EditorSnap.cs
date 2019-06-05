using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] float gridSize = 10f;
    Vector3 snapPos;

    void Update()
    {
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = snapPos;

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = (snapPos.x / gridSize).ToString() + "," + (snapPos.z / gridSize).ToString();
    }
}
