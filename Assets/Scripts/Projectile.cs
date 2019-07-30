using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public float distance;
	public int damage;
	public LayerMask whatIsSolid;

	public GameObject cloud;

	private Transform target;
	public string targetsTag;
	private Vector2 destination;
	
	void Start () {
		Invoke("DestroyProjectile", lifeTime);
		target = GameObject.FindGameObjectWithTag(targetsTag).transform; 
		destination = new Vector2(target.position.x, target.position.y);
	}

	void Update () {

		if(targetsTag == "Enemy"){
			RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
			transform.Translate(Vector2.up * speed * Time.deltaTime);

			if(hitInfo.collider != null){
			if(hitInfo.collider.CompareTag(targetsTag)){
				hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
			}
			speed = 0;
			DestroyProjectile();
		}
		}else{
			RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, destination, distance, whatIsSolid);
			transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

			if(hitInfo.collider != null){
			if(hitInfo.collider.CompareTag(targetsTag)){
				Debug.Log("Player was hit");
				hitInfo.collider.GetComponent<Player>().TakeDamage(damage);
			}
			speed = 0;
			DestroyProjectile();
		}
		}
		
		

		
		if(transform.position.x == destination.x && transform.position.y == destination.y){
			DestroyProjectile();
		}
	}
	
	// void OnTriggerEnter2D(Collider2D other){
	// 	if(other.CompareTag("Player")){
	// 		DestroyProjectile();
	// 	}
	// }

	void DestroyProjectile() {
		Instantiate(cloud, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
