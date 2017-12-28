using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;

	public Image HeartUI;

	private player Player;

	void Start (){
	
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<player> ();

	}

	void Update (){
	
		HeartUI.sprite = HeartSprites [Player.currentHP];
	
	}


}
