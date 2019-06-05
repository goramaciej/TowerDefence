using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static Vector3 ResetPosition(this Transform trans) {
        //trans.position = Vector3.Distance(Vector3.zero)
        return Vector3.zero;
    }

    public static float GetDistance(this GameObject viuk) {
        // use only 
        // gameObject.GetDistance()
        // to return distance of monobehaviour gameObject from point zero
        float dist = 0;
        dist = Vector3.Distance(Vector3.zero, viuk.transform.position);
        return dist;
    }

    public static void SetPositionZero(this Transform trans) {
        Debug.Log("SetPositionZero");
        trans.position = Vector3.zero;
        //usage: gameObject.transform.SetPositionZero();
    }

    public static void SetZero(this GameObject go) {
        Debug.Log("SetPositionZero");
        go.transform.position = Vector3.zero;
    }

    public static IEnumerator LerpToPosition(this GameObject go, Vector3 endPosition, float time) {
        Debug.Log("Start coroutine");
        float curTime = 0f;
        Vector3 startPosition = go.transform.position;

        while (curTime < time) {
            go.transform.position = Vector3.Lerp(startPosition, endPosition, (curTime / time));
            curTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
