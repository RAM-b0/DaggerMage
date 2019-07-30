using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public float lifeTime;


	void Start () {
		Invoke("DestroyCloud", lifeTime);
	}

	void DestroyCloud() {
		Destroy(gameObject);
	}
}
