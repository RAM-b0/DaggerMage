using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {

	public float lifeTime;


	void Start () {
		Invoke("Destroy", lifeTime);
	}

	void Destroy() {
		Destroy(gameObject);
	}
}
