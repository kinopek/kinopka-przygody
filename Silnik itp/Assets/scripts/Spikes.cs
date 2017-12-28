using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private player Player;

	void Start(){
	
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<player> ();

	}

	void OnTriggerEnter2D(Collider2D col){
	
		if (col.CompareTag ("Player")) {
		
			Player.Damage (3);

		}
	
	}

}
