using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : TurretBehaviour {

    GameObject go;

    protected override void Start() {
        turretPrefab = Resources.Load("Prefabs/Turret") as GameObject;
        go = Instantiate(turretPrefab, transform);
        go.transform.SetParent(transform);
        go.transform.localPosition = Vector3.right;
        go.AddComponent<TurretBehaviour>();
    }

    void Update() {
        //go.transform.RotateAround(go.transform.parent.position, go.transform.parent.up, 30 * Time.deltaTime);
        //go.transform.RotateAround(transform.position, Vector3.down, 30 * Time.deltaTime);
    }
}