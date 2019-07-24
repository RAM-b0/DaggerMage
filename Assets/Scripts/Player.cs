using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health;
	private bool facingDown;
	private bool facingRight =true;
	private float moveInputH;
	private float moveInputV;

	void Start () {

	}

	void Update () {
		if(health <= 0){
			DestroyPlayer();
		}

	}
	void FixedUpdate(){
		moveInputH = Input.GetAxis("Horizontal");
		moveInputV = Input.GetAxis("Vertical");

		if(facingRight == false && moveInputH > 0 ){
			flipHorizontaly();
		}else if(facingRight == true && moveInputH < 0){
			flipHorizontaly();
		}

		if(facingDown == false && moveInputV > 0 ){
			flipVerticaly();
		}else if(facingDown == true && moveInputV < 0){
			flipVerticaly();
		}

	}

	void flipHorizontaly(){
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;

		Scaler = transform.GetChild(0).localScale;
		Scaler.x *= -1;
		transform.GetChild(0).localScale = Scaler;
	}
	void flipVerticaly(){
		facingDown = !facingDown;
		Vector3 Scaler = transform.localScale;
		Scaler.y *= -1;
		transform.localScale = Scaler;

		Scaler = transform.GetChild(0).localScale;
		Scaler.y *= -1;
		transform.GetChild(0).localScale = Scaler;
	}

	public void TakeDamage(int damage){
		health -= damage;
		Debug.Log("Player took damage");
	}

	void DestroyPlayer() {
		Destroy(gameObject);
		Debug.Log("Game Over");
	}

}
