using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour {
    public GameObject target;
    public GameObject turretPrefab;
    public GameObject bulletPrefab;
    public List<GameObject> bulletPool = new List<GameObject>();
    public enum FireMethod {
        Free,
        Lock,
        Rotate
    }
    public FireMethod fireMethod = FireMethod.Free;

    public float fireTime;
    public float bufferTime;

    protected virtual void Awake() {
        //bulletPrefab = Resources.Load("Prefabs/BulletParent") as GameObject;
        fireTime = 1.0f;
        bufferTime = 0.5f;
    }

    protected virtual void Start() {
        target = GameObject.FindWithTag("target");
        InvokeRepeating("Fire", bufferTime, fireTime);
    }
    
    protected virtual void Fire() {
        GameObject obj = GeneralObjectPooling.current.GetPooledObject(bulletPool, bulletPrefab);

        if (obj == null)
            return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
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
                transform.LookAt(target.transform);
                return;
        }

    }

    //protected void TurretSpawn(Vector3 pos, Quaternion angle) {
    //    var turretObj = Instantiate(turretPrefab, pos, angle);
    //    turretPoints.Add(turretObj);
    //    turretObj.transform.SetParent(transform);
    //}

    //foreach (GameObject tp in turretPoints) {
    //        tp.AddComponent<TurretBehaviour>();
    //    }

}