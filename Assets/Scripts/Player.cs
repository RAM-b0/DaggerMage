using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health;
	public Animator animator;
	public GameObject bloodStain;

	void Start () {

	}

	void Update () {
		if(health <= 0){
			DestroyPlayer();
		}
	}
	
	void FixedUpdate(){
		animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
		animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
	}

	public void TakeDamage(int damage){
		FindObjectOfType<AudioManager>().Play("PlayerHit");
		GameObject.Find("ControlCameraShake").GetComponent<SimpleCameraShakeInCinemachine>().Shake();
		health -= damage;
		Debug.Log("Player took damage");
	}

	void DestroyPlayer() {
		Instantiate(bloodStain, transform.position, Quaternion.identity);
		FindObjectOfType<AudioManager>().Play("PlayerDeath");
		Destroy(gameObject);
		Debug.Log("Game Over");
	}

}
