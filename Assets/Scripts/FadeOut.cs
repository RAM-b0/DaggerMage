using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

	public float alphaLevel = 1f;
	public float fadeSpeed = 0.05f;
	public float delay = 0f;

	void Start () {
		
	}
	
	void Update () {
		if(delay <= 0 ){

			alphaLevel -= fadeSpeed;

			Color tmp = GetComponent<SpriteRenderer>().color;
			tmp.a = alphaLevel;
 			GetComponent<SpriteRenderer>().color = tmp;

			if(tmp.a <= 0){
				Destroy();
			}

		}else {
			delay -= Time.deltaTime;
		}
		
	}
	void Destroy() {
		Destroy(gameObject);
	}

}
