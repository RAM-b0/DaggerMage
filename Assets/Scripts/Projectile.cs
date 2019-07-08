using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float lifeTime;

	private Transform enemy;
	private Vector2 target;
	
	void Start () {
		Invoke("DestroyProjectile", lifeTime);
		enemy = GameObject.FindGameObjectWithTag("Enemy").transform; 
		target = new Vector2(enemy.position.x, enemy.position.y);
	}

	void Update () {
		transform.Translate(Vector2.up * speed * Time.deltaTime);

		if(transform.position.x == target.x && transform.position.y == target.y){
			Destroy(gameObject);
		}
	}
	void DestroyProjectile() {
		//Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
