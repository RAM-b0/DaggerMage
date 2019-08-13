using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	private AudioSource audioSource ;

	public void Play () {
		SceneManager.LoadScene(1);
	}

}
