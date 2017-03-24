using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpherical : TurretBehaviour {
    public float radius;
    public int pointCount;
    //Transform RandomSphericalTrans;

    protected override void Start() {
        InvokeRepeating("Fire", fireTime, fireTime);
    }

    protected override void Fire() {
        for (int i = 0; i < pointCount; i++) {
            GameObject obj = GeneralObjectPooling.current.GetPooledObject(bulletPool, bulletPrefab);
            if (obj == null)
                return;

            var v = RandomSphericalVec3();

            obj.transform.localEulerAngles = v;
            obj.transform.localPosition = transform.position + Quaternion.Euler(v) * Vector3.forward * radius;
            obj.SetActive(true);
        }
    }

    Vector3 RandomSphericalVec3() {
        Vector3 v = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        return v;
    }
}