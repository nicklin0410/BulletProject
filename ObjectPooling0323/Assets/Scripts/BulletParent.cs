using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParent : BulletBehavior {
    [SerializeField]
    private List<GameObject> m_Children = new List<GameObject>();
    [SerializeField]
    private int m_Point;
    [SerializeField]
    private enum Axis { x, y, z }
    [SerializeField]
    private Axis axis;
    [SerializeField]
    private List<Axis> axises = new List<Axis>();
    [SerializeField]
    private GameObject go;

    void Awake() {
        bulletSpeed = 2.0f;
        destroyTime = 3.0f;
        go = Resources.Load("Prefabs/TurretChild") as GameObject;
        m_Point = 8;
        axises.Add(Axis.x);
        axises.Add(Axis.y);
        axises.Add(Axis.z);
    }

    void Start() {
    }

    protected override void OnEnable() {
        Invoke("SphericalVec3", destroyTime - Time.deltaTime);
        base.OnEnable();
    }

    protected override void OnDisable() {
        foreach (GameObject child in m_Children) {
            Destroy(child);
        }
        m_Children.Clear();
        base.OnDisable();
    }

    void SphericalVec3() {
        float degree = 360.0f / m_Point;
        Vector3 baseAxis;
        Quaternion rotate1 = Quaternion.identity;
        Quaternion rotate2 = Quaternion.identity;
        Quaternion rotate3 = Quaternion.identity;

        for (float f = 0.0f; f < 360.0f - 0.0001f; f += degree) {
            baseAxis = Vector3.zero;

            SwitchVar(f, axises[0], ref rotate1, ref baseAxis);
            m_Children.Add(Instantiate(go, transform.position, rotate1, transform));

            if (axises.Count >= 2 && Mathf.Abs(f % 180) > 0.0001f) {
                baseAxis = Vector3.zero;

                SwitchVar(f, axises[1], ref rotate2, ref baseAxis);

                m_Children.Add(Instantiate(go, transform.position, rotate2, transform));

                if (axises.Count == 3 && Mathf.Abs(f % 90) > 0.0001f) {
                    baseAxis = Vector3.zero;
                    SwitchVar(f, axises[2], ref rotate3, ref baseAxis);
                    m_Children.Add(Instantiate(go, transform.position, rotate3, transform));
                }
            }
        }
        //    foreach (GameObject go in m_Children)
        //        go.AddComponent<TurretBehaviour>();
    }

    void Swap<T>(ref T a, ref T b) {
        var tmp = a;
        a = b;
        b = tmp;
    }

    void SwitchVar(float f, Axis t, ref Quaternion r, ref Vector3 b) {
        switch (t) {
            case Axis.x:
                b.x = 1.0f;
                r = Quaternion.AngleAxis(f, b) * transform.rotation;
                break;
            case Axis.y:
                b.y = 1.0f;
                r = Quaternion.AngleAxis(f, b) * transform.rotation;
                break;
            case Axis.z:
                b.x = 1.0f;
                r = Quaternion.FromToRotation(Vector3.forward, Vector3.right) * Quaternion.AngleAxis(f, b) * transform.rotation;
                break;
        }
    }
}