using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSurfacePoint : MonoBehaviour {
    public int pointCount;
    public float dTime;
    public GameObject point;
    public GameObject ptPrefab;
    
    void Start() {
        ptPrefab = Resources.Load("Prefabs/SurfacePoint") as GameObject;
        dTime = 2;
        pointCount = 200;
    }
    
    void Update() {

    }

    void FixedUpdate() {
        if (gameObject.transform.childCount == 0) {
            SphereSurfaceFirePoint(pointCount);
            return;
        }
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject, dTime);
        }
    }

    void SphereSurfaceFirePoint(int pointCount) {
        float x;
        float y;
        float z;
        for (int i = 0; i < pointCount; i++) {
            point = Instantiate(ptPrefab, transform);
            x = Random.Range(0.0f, 180.0f);
            y = Random.Range(0.0f, 180.0f);
            z = Random.Range(0.0f, 180.0f);
            point.transform.localEulerAngles = new Vector3(x, y, z);
            point.transform.localPosition = Quaternion.Euler(x, y, z) * Vector3.forward * 0.5f;
        }
    }
}
