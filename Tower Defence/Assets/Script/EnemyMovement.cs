using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> blockList;
    [SerializeField] float duration = 1f;
    [SerializeField] AnimationCurve curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

    private int currentStep = 0;
    private Vector3 currentStartPosition;
    private Vector3 currentTargetPosition;
    private float time = 0f;
    private bool isAnimating = false;

    // Start is called before the first frame update
    void Start() {        
        transform.position = blockList[0].transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(FollowPath());
        }

        if (isAnimating) {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(currentStartPosition, currentTargetPosition, curve.Evaluate(time / duration));
        }
    }

    IEnumerator FollowPath() {
        isAnimating = true;
        int count = blockList.Count;
        for (int i=0; i< count; i++) {

            currentStartPosition = blockList[i].transform.position;

            if (i+1 == count) {
                isAnimating = false;
            } else {
                currentTargetPosition = blockList[i + 1].transform.position;
            }            
            time = 0;
            yield return new WaitForSeconds(duration);
        }
        //Debug.Log("coroutine end");
    }

   
    
}
