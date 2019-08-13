using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	private Vector2 player;
	private Vector2 BG;
	void Start () {
		
	}

	void Update () {
		player = GameObject.Find("Player").transform.position;
		BG = this.transform.position;

		player.x = Mathf.RoundToInt(player.x);
		player.y = Mathf.RoundToInt(player.y);
		BG.x = Mathf.RoundToInt(BG.x);
		BG.y = Mathf.RoundToInt(BG.y);

		if(player.x > BG.x){
			Vector2 pos = this.transform.position;
			pos = new Vector2(transform.position.x + 1, transform.position.y);
			transform.position = pos;
		}else if(player.x < BG.x){
			Vector2 pos = this.transform.position;
			pos = new Vector2(transform.position.x - 1, transform.position.y);
			transform.position = pos;
		}
		if(player.y > BG.y){
			Vector2 pos = this.transform.position;
			pos = new Vector2(transform.position.x, transform.position.y +1);
			transform.position = pos;
		}else if(player.y < BG.y){
			Vector2 pos = this.transform.position;
			pos = new Vector2(transform.position.x, transform.position.y -1);
			transform.position = pos;
		}


	}
}
