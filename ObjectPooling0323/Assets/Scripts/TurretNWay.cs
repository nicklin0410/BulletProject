using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretNWay : TurretBehaviour {
    public int ways;
    public float distance;
    public float rotateAngle;
    public List<GameObject> turretPoints = new List<GameObject>();

    protected override void Start() {
        target = GameObject.FindWithTag("target");
        fireTime = 0.5f;
        bufferTime = 4.0f;
        turretPrefab = Resources.Load("Prefabs/Turret") as GameObject;
        SetTurrets(ways, distance, rotateAngle);
    }

    void Update() {
        ChangeState();
    }

    void SetTurrets(int ways, float d, float r) {
        int z;
        if (ways % 2 != 0) {
            z = (ways - 1) / 2;
            for (int i = 0; i < ways; i++) {
                var vx = new Vector3(0, d * (i - z), 0);
                for (int j = 0; j < ways; j++) {
                    var vy = new Vector3(d * (z - j), 0, 0);
                    var angle = Quaternion.Euler(r * (z - i), r * (z - j), 0);
                    TurretSpawn(vx + vy, angle);
                }
            }
        }
        else {
            z = ways / 2;
            for (int i = 0; i < ways; i++) {
                var vx = new Vector3(0, d / 2 * (2 * (i - z) - 1), 0);
                for (int j = 0; j < ways; j++) {
                    var vy = new Vector3(d / 2 * (2 * (z - j) - 1), 0, 0);
                    var angle = Quaternion.Euler(r / 2 * (2 * (z - i) - 1), r / 2 * (2 * (z - j) - 1), 0);
                    TurretSpawn(vx + vy, angle);
                }
            }

        }
        foreach (GameObject tp in turretPoints) {
            tp.AddComponent<TurretBehaviour>();
        }
    }
    
    protected void TurretSpawn(Vector3 pos, Quaternion angle) {
        var turretObj = Instantiate(turretPrefab, pos, angle);
        turretPoints.Add(turretObj);
        turretObj.transform.SetParent(transform);
    }


}
