using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public float maxSpeed = 3;
	public float speed = 50f;
	public float jump_power = 150f;
	public bool grounded;
	private Rigidbody2D rb2D;
    private Animator anim;

	// Use this for initialization
	void Start () {
		rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("grounded",grounded);
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2D.AddForce(Vector2.up * jump_power);
        }
    }

	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");
		rb2D.AddForce ((Vector2.right * speed) * h);
        if (rb2D.velocity.x > maxSpeed)
        {
            rb2D.velocity = new Vector2(maxSpeed, rb2D.velocity.y);
        }
        if(rb2D.velocity.x < -maxSpeed)
        {
            rb2D.velocity = new Vector2(-maxSpeed, rb2D.velocity.y);
        }
    }

}
