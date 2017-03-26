using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIData {

    //自己
    public GameObject go;

    //目標
    public GameObject target;
    //	public float fDistance;
    public Vector3 vTargetPosition = Vector3.zero;


    //運動
    // 最大操控力
    public float fMaxForce = 0.7f;
    // 最大速度
    public float fMaxSpeed = 10.0f;

    // Steering Force
    public Vector3 vSteering = Vector3.zero;

    // 運動的合力 (方向 + 速度)
    public Vector3 vVelocity = Vector3.zero;


    // Debug
    public Vector3 vTemp1 = Vector3.zero;
    public Vector3 vTemp2 = Vector3.zero;
    
}

public class AIBehavior : MonoBehaviour {

    #region ========== Main

    public static void Steering(ref AIData data) {
        data.vSteering = Vector3.ClampMagnitude(data.vSteering, data.fMaxForce);

        Vector3 vVelocity;
        vVelocity = Vector3.ClampMagnitude(data.vVelocity + data.vSteering, data.fMaxSpeed);
        
        //	data.vTemp1 = data.vSteering * 3.0f;
        
        // Get Velocity
        data.vVelocity = Vector3.ClampMagnitude(data.vVelocity + data.vSteering, data.fMaxSpeed);
        
        //轉向
        data.go.transform.forward = Vector3.Normalize(data.vVelocity);

        //位移
        data.go.transform.position += data.vVelocity * Time.deltaTime;

        //Reset
        data.vSteering = Vector3.zero;
        
    }
    
    #endregion ==========
    
    #region ========== Behaviors (public function)

    public static void Seek(ref AIData data) {

        Vector3 vSeek = DoSeek(ref data);
        data.vSteering += vSeek;

    }
    
    #endregion ==========
    
    #region ========== Do (private function)

    private static Vector3 DoSeek(ref AIData data) {

        Vector3 vForce = Vector3.zero;
        
        Vector3 vToTarget = data.vTargetPosition - data.go.transform.position;
        Vector3 vDesired = Vector3.Normalize(vToTarget) * data.fMaxSpeed;

        /*
		float fDistance = vToTarget.magnitude;

		if (fDistance < 1.0f) {
			
			//開始減速
			vDesired = Vector3.Normalize (vDesired) * data.fMaxSpeed * (fDistance / 1.0f);

		}*/

        vForce = vDesired - data.vVelocity;
        
        return vForce;
    }
    #endregion ==========
}