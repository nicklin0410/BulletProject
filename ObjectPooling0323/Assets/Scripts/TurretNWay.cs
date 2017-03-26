using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretNWay : TurretBehaviour {
    public int m_ways;
    public float m_distance;
    public float m_rotateAngle;

    protected override void Start() {
        //base.Start();
        //m_target = GameObject.FindWithTag("target");
        //m_fireTime = 0.6f;
        //m_bufferTime = 1.5f;
        //m_turretPrefab = Resources.Load("Prefabs/TurretDefault") as GameObject;
        //SetFirePoints(m_ways, m_distance, m_rotateAngle);
        InvokeRepeating("Fire", m_bufferTime, m_fireTime);
    }

    void Update() {
        ChangeState();
    }

    protected override void Fire() {
        int z;
        if (m_ways % 2 != 0) {

            z = (m_ways - 1) / 2;
            for (int i = 0; i < m_ways; i++) {
                var vx = new Vector3(0, m_distance * (i - z), 0);
                for (int j = 0; j < m_ways; j++) {
                    var vy = new Vector3(m_distance * (z - j), 0, 0);
                    var angle = Quaternion.Euler(m_rotateAngle * (z - i), m_rotateAngle * (z - j), 0);
                    GameObject obj = GeneralObjectPooling.current.GetPooledObject(m_bulletPool, m_bulletPrefab);

                    if (obj == null)
                        return;

                    obj.transform.position = transform.position + vx + vy;
                    obj.transform.rotation = transform.rotation * angle;
                    obj.SetActive(true);
                    //TurretSpawn(vx + vy, angle);
                }
            }
        }
        else {
            z = m_ways / 2;
            for (int i = 0; i < m_ways; i++) {
                var vx = new Vector3(0, m_distance / 2 * (2 * (i - z) - 1), 0);
                for (int j = 0; j < m_ways; j++) {
                    var vy = new Vector3(m_distance / 2 * (2 * (z - j) - 1), 0, 0);
                    var angle = Quaternion.Euler(m_rotateAngle / 2 * (2 * (z - i) - 1), m_rotateAngle / 2 * (2 * (z - j) - 1), 0);
                    GameObject obj = GeneralObjectPooling.current.GetPooledObject(m_bulletPool, m_bulletPrefab);

                    if (obj == null)
                        return;

                    obj.transform.position = transform.position + vx + vy;
                    obj.transform.rotation = transform.rotation * angle;
                    obj.SetActive(true);
                }
            }

        }
    }

}