using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : TurretBehaviour {

    GameObject go;

    protected override void Start() {
        //m_turretPrefab = Resources.Load("Prefabs/TurretDefault") as GameObject;
        //m_bulletPrefab = Resources.Load("Prefabs/BulletTest") as GameObject;
        go = Instantiate(m_turretPrefab, transform);
        go.transform.localPosition = Vector3.right;
        InvokeRepeating("Fire", m_bufferTime, m_fireTime);
    }

    void Update() {
        TurretRotate(m_rotateSpeed);
    }
}