using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class player : MonoBehaviour {
    public float maxSpeed = 3;
	public float speed = 50f;
	public float jump_power = 150f;
	public bool grounded;
	private Rigidbody2D rb2D;
    private Animator anim;

	//Stats
	public int currentHP;
	public int maxHP = 5;


	// Use this for initialization
	void Start () {
		rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

		currentHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("grounded",grounded);
        anim.SetFloat("speed", Mathf.Abs(rb2D.velocity.x));

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
		if (currentHP > maxHP) {
			currentHP = maxHP;
		}
		if (currentHP <= 0) {
			Die ();
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

	void Die () {
		//restart
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

	}
		

	public void Damage(int dmg){
		
		if (dmg > currentHP) {

			currentHP = 0;
			
		}
		else {

			currentHP -= dmg;
		}	
	}

}
	


public IEnumerator Knockback(float knockDuration, float knockBackPwr, Vector3 knockBackDir){

	float timer = 0;

	while (knockDur > timer){

		timer+=Time.deltaTime;

		rb2D.AddForce(new Vector3 (knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

	}

}