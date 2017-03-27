using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretChild : TurretBehaviour {

    public BulletParent bulletParent;//從哪個子彈生成這個Child

    protected override void Start() {
        //bulletPrefab = Resources.Load("Prefabs/BulletChild") as GameObject;
        m_bufferTime = 0.0f;
        m_fireTime = 0.2f;
        m_target = GameObject.FindWithTag("target");
    }

    protected override void Fire() {
        GameObject obj = GeneralObjectPooling.current.GetPooledObject(m_bulletPool, m_bulletPrefab);

        if (obj == null)
            return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }

    void OnEnable() {
        Invoke("Fire", bulletParent.m_destroyTime - Time.deltaTime);
    }



}
