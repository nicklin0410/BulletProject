using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpherical : TurretBehaviour {
    public float m_radius;
    public int m_pointCount;

    protected override void Start() {
        InvokeRepeating("Fire", m_bufferTime, m_fireTime);
    }

    protected override void Fire() {
        for (int i = 0; i < m_pointCount; i++) {
            GameObject obj = GeneralObjectPooling.current.GetPooledObject(m_bulletPool, m_bulletPrefab);
            if (obj == null)
                return;

            var v = RandomSphericalVec3();

            obj.transform.localEulerAngles = v;
            obj.transform.localPosition = transform.position + Quaternion.Euler(v) * Vector3.forward * m_radius;
            obj.SetActive(true);
        }
    }

    Vector3 RandomSphericalVec3() {
        Vector3 v = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        return v;
    }
}