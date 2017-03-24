using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {
    public float dTime;
        
    void OnEnable() {
        Invoke("Destroy", dTime);
    }

    void Destroy() {
        gameObject.SetActive(false);
    }

    void OnDisable() {
        CancelInvoke();
    }
}
