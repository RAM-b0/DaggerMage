using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

	public float alphaLevel = 0.5f;
	public float fadeSpeed = 0.05f;

	void Start () {
		
	}
	
	void Update () {
		alphaLevel -= fadeSpeed;

		Color tmp = GetComponent<SpriteRenderer>().color;
		tmp.a = alphaLevel;
 		GetComponent<SpriteRenderer>().color = tmp;

		if(tmp.a == 1){
			Destroy();
		}
	}
	void Destroy() {
		Destroy(gameObject);
	}

}
