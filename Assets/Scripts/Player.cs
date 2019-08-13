using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public int health;
	public Animator animator;
	public GameObject bloodStain;
	private bool isImmortal;

	void Start () {

	}

	void Update () {
		if(health <= 0){
			DestroyPlayer();
		}
		
		if (Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene(1);
		}
	}
	
	void FixedUpdate(){
		animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
		animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
	}

	public void TakeDamage(int damage){
		if(!isImmortal){
			isImmortal = true;
			FindObjectOfType<AudioManager>().Play("PlayerHit");
			GameObject.Find("ControlCameraShake").GetComponent<SimpleCameraShakeInCinemachine>().Shake();
			health -= damage;
			Debug.Log("Player took damage");
			this.GetComponent<SpriteRenderer>().color = new Color (0, 255, 0, 255);
			Invoke("Mortality", 1f);
		}
		
	}

	void DestroyPlayer() {
		Instantiate(bloodStain, transform.position, Quaternion.identity);
		FindObjectOfType<AudioManager>().Play("PlayerDeath");
		Destroy(gameObject);
	}

	void Mortality(){
		isImmortal = false;
		this.GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255);
	}

}
