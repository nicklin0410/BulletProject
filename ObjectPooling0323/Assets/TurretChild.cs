using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretChild : TurretBehaviour { 

    protected override void Start() {
        bulletPrefab = Resources.Load("Prefabs/BulletChild") as GameObject;
        bufferTime = 0.0f;
        fireTime = 0.2f;
        target = GameObject.FindWithTag("target");
        InvokeRepeating("Fire", bufferTime, fireTime);
    }


    void Update() {

    }

    protected override void Fire() {
        GameObject obj = GeneralObjectPooling.current.GetPooledObject(bulletPool, bulletPrefab);

        if (obj == null)
            return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }

}
