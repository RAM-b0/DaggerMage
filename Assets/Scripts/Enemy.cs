﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	public float speed;
	public float stoppingDistance;
	public float retreatDistance;
	public float startTimeBtwShots;
	private float timeBtwShots;
	public GameObject projectile;
	public Transform player;

	private Animator anim;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		
		timeBtwShots = startTimeBtwShots;
	}
	
	void Update () {

		if(Vector2.Distance(transform.position, player.position) > stoppingDistance){
			transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

		}else if( Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance ){
			transform.position = this.transform.position;

		}else if( Vector2.Distance(transform.position, player.position) < retreatDistance ){
			transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
		}

		if(health <= 0){
			Destroy(gameObject);
		}

		if(timeBtwShots <= 0){
				Instantiate(projectile, transform.position, Quaternion.identity);
				timeBtwShots = startTimeBtwShots;
		}else{
			timeBtwShots -= Time.deltaTime;
		}


	}

	
	public void TakeDamage(int damage){
		health -= damage;
		Debug.Log("damage TAKEN");
	}

}
