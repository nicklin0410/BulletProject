using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObjectPooling : MonoBehaviour {

    public static GeneralObjectPooling current;
    //[SerializeField]
    //private GameObject pooledObject1;
    //[SerializeField]
    //private GameObject pooledObject2;

    public int pooledAmount;
    public bool canGrow;

    //[SerializeField]
    //private List<GameObject> pooledList1 = new List<GameObject>();
    //[SerializeField]
    //private List<GameObject> pooledList2 = new List<GameObject>();

    void Awake() {
        //pooledAmount = 720;
        //canGrow = true;
        current = this;
    }


    void Start() {
        //poolCreater(pooledObject1, pooledList1);
        //poolCreater(pooledObject2, pooledList2);
    }

    public GameObject GetPooledObject(List<GameObject> pooledList, GameObject pooledObject) {
        for (int i = 0; i < pooledList.Count; i++) {
            if (!pooledList[i].activeInHierarchy) {
                return pooledList[i];
            }
        }

        if (canGrow) {
            GameObject obj = Instantiate(pooledObject);
            pooledList.Add(obj);
            return obj;
        }

        return null;
    }

    void poolCreater(GameObject pooledObject, List<GameObject> pooledList) {
        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledList.Add(obj);
        }
    }

}
