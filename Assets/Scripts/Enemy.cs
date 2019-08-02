using System.Collections;
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

	public Animator animator;
	public GameObject bloodStain;
	private Rigidbody2D rb;
	private Vector2 direction;


	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		Debug.Log(rb);
		player = GameObject.FindGameObjectWithTag("Player").transform;
		timeBtwShots = startTimeBtwShots;
	}
	
	void Update () {

		//Move
		if(Vector2.Distance(transform.position, player.position) > stoppingDistance){
			transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

		}else if( Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance ){
			transform.position = this.transform.position;

		}else if( Vector2.Distance(transform.position, player.position) < retreatDistance ){
			transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
		}

		//animation
		direction = (player.transform.position - transform.position).normalized;
		animator.SetFloat("Horizontal", direction.x );
		animator.SetFloat("Vertical", direction.y );

		if(health <= 0){
			DestroyEnemy();
		}

		//Shot
		if(timeBtwShots <= 0){
				Instantiate(projectile, transform.position, Quaternion.identity);
				FindObjectOfType<AudioManager>().Play("SlimeShot");
				timeBtwShots = startTimeBtwShots;
		}else{
			timeBtwShots -= Time.deltaTime;
		}

	}
	
	public void TakeDamage(int damage){
		FindObjectOfType<AudioManager>().Play("SlimeHit");
		health -= damage;
		Debug.Log("Enemy took damage");
	}

	void DestroyEnemy() {
		FindObjectOfType<AudioManager>().Play("SlimeDeath");
		Instantiate(bloodStain, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}