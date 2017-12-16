using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float speed = 50f;
	public float jump_power = 150f;
	public bool grounded;
	private Rigidbody2D rb2D;


	// Use this for initialization
	void Start () {
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");
		rb2D.AddForce ((Vector2.right * speed) * h);
	}

}
