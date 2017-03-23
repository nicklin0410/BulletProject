using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolingTest : MonoBehaviour
{

	public float fireTime = 0.25f;
	public GameObject bullet;

	public int pooledAmount = 20;
	List<GameObject> bulletList;

	// Use this for initialization
	void Start ()
	{
		bulletList = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (bullet);
			obj.SetActive (false);
			bulletList.Add (obj);
		}
		InvokeRepeating ("Fire", fireTime, fireTime);
	}

	// Update is called once per frame
	void Fire ()
	{
		for (int i = 0; i < bulletList.Count; i++) {
			if (!bulletList [i].activeInHierarchy) {
				bulletList [i].transform.position = transform.position;
				bulletList [i].transform.rotation = transform.rotation;
				bulletList [i].SetActive (true);
				break;
			}
		}
	}
}
