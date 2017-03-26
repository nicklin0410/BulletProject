using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChasing : BulletBehavior {

    public GameObject target;

    void Start() {
        target = GameObject.FindWithTag("target");
    }

    protected override void Update() {
        base.Update();
        transform.LookAt(target.transform);
    }
}