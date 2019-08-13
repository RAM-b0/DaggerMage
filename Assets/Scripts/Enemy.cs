using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	public float speed;
	public float range;
	public float stoppingDistance;
	public float retreatDistance;
	public float startTimeBtwShots;
	public bool canShot;
	private float timeBtwShots;
	public GameObject projectile;
	public Transform player;

	public Animator animator;
	public GameObject bloodStain;
	private Rigidbody2D rb;
	private Vector2 direction;
	public string hitSound;
	public string shotSound;
	public string deathSound;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		timeBtwShots = startTimeBtwShots;
	}
	
	void Update () {
		if(Vector2.Distance(transform.position, player.position) < range){
			if(speed > 0) {
				//Move
				if(Vector2.Distance(transform.position, player.position) > stoppingDistance){
					transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
				}else if( Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance ){
					transform.position = this.transform.position;
				}else if( Vector2.Distance(transform.position, player.position) < retreatDistance ){
					transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
				}
			}

			//animation
			direction = (player.transform.position - transform.position).normalized;
			animator.SetFloat("Horizontal", direction.x );
			animator.SetFloat("Vertical", direction.y );

			if(health <= 0){
				DestroyEnemy();
			}

			//Shot
			if(canShot){
				if(timeBtwShots <= 0){
					animator.SetBool("IsAttacking", true);
					Invoke("SpawnProjectile", 0.4f);
					FindObjectOfType<AudioManager>().Play(shotSound);
					timeBtwShots = startTimeBtwShots;
					Invoke("NotAttacking", 0.3f);
				}else{
					timeBtwShots -= Time.deltaTime;
				}
			}
		}
		
		
	}

	void OnTriggerEnter2D(Collider2D other){
	 	if(other.CompareTag("Player")){
	 		GameObject.Find("Player").GetComponent<Player>().TakeDamage(1);
	 	}
	}
	
	public void TakeDamage(int damage){
		FindObjectOfType<AudioManager>().Play(hitSound);
		health -= damage;
		Debug.Log("Enemy took damage");
	}

	void DestroyEnemy() {
		FindObjectOfType<AudioManager>().Play(deathSound);
		Instantiate(bloodStain, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
	void NotAttacking(){
		animator.SetBool("IsAttacking", false);
	}
	void SpawnProjectile(){
		Instantiate(projectile, transform.position, Quaternion.identity);
	}

}