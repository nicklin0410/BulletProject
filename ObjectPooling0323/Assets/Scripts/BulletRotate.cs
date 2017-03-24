using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotate : BulletBehavior {

    public float rotateSpeed;
    Vector3 centerPoint;
    Vector3 axis;

	void Start () {
        centerPoint = transform.localPosition;
        axis = Vector3.up;
	}

    protected override void Update () {
        base.Update();
        transform.RotateAround(centerPoint, axis, rotateSpeed * Time.deltaTime);
	}
}
