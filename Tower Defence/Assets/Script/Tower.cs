using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] int attackRange = 30;

    ParticleSystem.EmissionModule gunShooting;

    private void Start() {
        ParticleSystem gun = GetComponentInChildren<ParticleSystem>();
        gunShooting = gun.emission;
    }

    void Update() {
        FaceToEnemyAndShot();
        
    }
    void FaceToEnemyAndShot() {
        float currentDistance = Vector3.Distance(objectToPan.position, targetEnemy.position);

        if ((currentDistance < attackRange) && targetEnemy) {
            objectToPan.LookAt(targetEnemy);
            if (!gunShooting.enabled) {
                //gunShooting.enabled = true;
            }
        } else {
            if (gunShooting.enabled) {
                //gunShooting.enabled = false;
            }
        }
    }
}