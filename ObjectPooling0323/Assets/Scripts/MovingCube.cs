using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour {
    public float acl;
    public float vel;
    // Use this for initialization
    void Start() {
        acl = 10;
        vel = 0;
    }
    // Update is called once per frame
    void Update() {
        vel += acl * Time.deltaTime;
        if (transform.position.x > 0.0f) {
            acl = -Mathf.Abs(acl);
        }
        else {
            acl = Mathf.Abs(acl);
        }
        transform.Translate(vel * Time.deltaTime, 0, 0);
    }
}
