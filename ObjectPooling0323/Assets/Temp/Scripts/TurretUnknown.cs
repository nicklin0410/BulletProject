using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUnknown : TurretBehaviour {
    public float acl;
    public float vel;

    protected override void Start() {
        InvokeRepeating("Fire", m_bufferTime, m_fireTime);
    }

    void Update() {
        vel += acl * Time.deltaTime;
        if (transform.position.z >= 0.0f) {
            acl = -Mathf.Abs(acl);
        }
        else {
            acl = Mathf.Abs(acl);
        }
        transform.Translate(0, 0, vel * Time.deltaTime);
    }
}
