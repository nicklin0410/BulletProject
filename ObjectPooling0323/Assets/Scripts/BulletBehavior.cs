using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    public float m_bulletSpeed;
    public float m_destroyTime;

    void Awake() {

    }

    void Start() {
        //bulletSpeed = 50.0f;
    }

    protected virtual void Update() {
        transform.Translate(0, 0, m_bulletSpeed * Time.deltaTime);
    }

    protected virtual void OnEnable() {
        Invoke("Clear", m_destroyTime);
    }

    protected virtual void Clear() {
        gameObject.SetActive(false);
    }

    protected virtual void OnDisable() {
        CancelInvoke();
    }

}
