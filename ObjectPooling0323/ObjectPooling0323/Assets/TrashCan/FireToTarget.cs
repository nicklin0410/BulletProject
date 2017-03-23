using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireToTarget : MonoBehaviour {
    public GameObject target;
    public float bufferTime;
    public float fireTime;

    // Use this for initialization
    void Start() {
        InvokeRepeating("Fire", bufferTime, fireTime);
    }

    // Update is called once per frame
    void Update() {
        transform.LookAt(target.transform);

    }

    void Fire() {
        //GameObject obj = GeneralObjectPooling.current.GetPooledObject(bulletPool, bulletPrefab);

        //if (obj == null)
        //    return;

        //obj.transform.position = transform.position;
        //obj.transform.rotation = transform.rotation;
        //obj.SetActive(true);


    }
}
