using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour {
    public GameObject m_target;
    public GameObject m_turretPrefab;
    public GameObject m_bulletPrefab;
    public List<GameObject> m_turretPoints = new List<GameObject>();
    public List<GameObject> m_bulletPool = new List<GameObject>();
    public enum FireMethod {
        Free,
        Lock,
        Rotate
    }
    public FireMethod fireMethod = FireMethod.Free;

    public float m_fireTime;
    public float m_bufferTime;

    public float m_rotateSpeed;

    protected virtual void Awake() {
    }

    protected virtual void Start() {
        //m_fireTime = 1.0f;
        //m_bufferTime = 0.5f;
        //m_target = GameObject.FindWithTag("target");
        //m_turretPrefab = Resources.Load("Prefabs/TurretDefault") as GameObject;
        //m_bulletPrefab = Resources.Load("Prefabs/BulletTest") as GameObject;
        InvokeRepeating("Fire", m_bufferTime, m_fireTime);
    }

    protected virtual void Fire() {
        GameObject obj = GeneralObjectPooling.current.GetPooledObject(m_bulletPool, m_bulletPrefab);

        if (obj == null)
            return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }

    void Update() {

    }

    public void ChangeState() {
        if (Input.GetMouseButtonDown(0)) {
            switch (fireMethod) {
                case FireMethod.Free:
                    fireMethod = FireMethod.Lock;
                    return;
                case FireMethod.Lock:
                    fireMethod = FireMethod.Free;
                    return;
            }
        }

        switch (fireMethod) {
            case FireMethod.Free:
                return;
            case FireMethod.Lock:
                transform.LookAt(m_target.transform);
                return;
            case FireMethod.Rotate:
                TurretRotate(m_rotateSpeed);
                return;
        }

    }

    protected void TurretSpawn(Vector3 pos, Quaternion angle) {
        var turretObj = Instantiate(m_turretPrefab, pos, angle, transform);
        m_turretPoints.Add(turretObj);
    }

    //foreach (GameObject tp in turretPoints) {
    //        tp.AddComponent<TurretBehaviour>();
    //    }

    protected void TurretRotate(float rSpeed) {
        transform.RotateAround(transform.position, Vector3.down, rSpeed * Time.deltaTime);
    }
}