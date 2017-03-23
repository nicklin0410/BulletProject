using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    public float bulletSpeed;
    public float destroyTime;

    void Awake() {

    }

    void Start() {
        //bulletSpeed = 50.0f;
    }

    protected virtual void Update() {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    }

    protected virtual void OnEnable() {
        Invoke("Clear", destroyTime);
    }

    protected virtual void Clear() {
        gameObject.SetActive(false);
    }

    protected virtual void OnDisable() {
        CancelInvoke();
    }

}
