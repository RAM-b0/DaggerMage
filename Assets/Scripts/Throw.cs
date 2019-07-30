using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

	public float offset;
	private float timeBtwShots;
	public float startTimeBtwShots;
	public GameObject projectile;
	public Transform firePoint;

	void Update () {
		Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

		if(timeBtwShots <= 0){
			if(Input.GetMouseButtonDown(0)){
				Instantiate(projectile, firePoint.position, transform.rotation);
				FindObjectOfType<AudioManager>().Play("Throw");
				timeBtwShots = startTimeBtwShots;
			}
		}else{
			timeBtwShots -= Time.deltaTime;
		}

	}

}
