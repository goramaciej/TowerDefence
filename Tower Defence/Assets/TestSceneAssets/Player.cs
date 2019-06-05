using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()    {
        //gameObject.transform.SetPositionZero();
        //gameObject.LerpToPosition(new Vector3(10f, 10f, 10f), 2f);
        //gameObject.LerpToPosition(new Vector3(10f, 10f, 10f), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //StartCoroutine(MyLerp(new Vector3(20f, 20f, 20f), 3f));
            //gameObject.LerpToPosition(new Vector3(20f, 20f, 20f), 3f);
            gameObject.SetZero();
        }
    }    
}
