using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // non used temporarily
    /*private BoxCollider boxCollider;
    private MeshRenderer myRenderer;
    private Bounds localBounds;*/

    [SerializeField] int hitPoints = 100;

    void Start()
    {
        //GetMyBounds();
        //AddCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other) {
        TakeDamage();
        if (hitPoints <= 0) {
            KillEnemy();
        }
    }

    private void TakeDamage() {
        hitPoints--;
    }
    private void KillEnemy() {
        Destroy(gameObject);
    }



    /*private void GetMyBounds() {
        Quaternion currentRotation = this.transform.rotation;
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        Bounds bounds = new Bounds(this.transform.position, Vector3.zero);

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>()) {
            bounds.Encapsulate(renderer.bounds);
        }

        Vector3 localCenter = bounds.center - this.transform.position;
        bounds.center = localCenter;
        localBounds = bounds;

        this.transform.rotation = currentRotation;
    }

    private void AddCollider() {
        boxCollider = gameObject.GetComponent<BoxCollider>();

        if (!boxCollider) {
            Debug.Log("No collider... add it");
            boxCollider = gameObject.AddComponent<BoxCollider>();
        }
        boxCollider.size = new Vector3(10f, 10f, 10f);

        boxCollider.isTrigger = false;
    }*/
}
