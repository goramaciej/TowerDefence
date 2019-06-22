using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeShot : MonoBehaviour
{
    private Collider boxCollider;
    void Start()
    {
        AddCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddCollider() {
        boxCollider = gameObject.GetComponent<BoxCollider>();

        if (!boxCollider) {
            Debug.Log("No collider... add it");
            boxCollider = gameObject.AddComponent<BoxCollider>();
        }
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("Damage");
    }

    private void TakeDamage() {
       
    }
}
