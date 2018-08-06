using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	Rigidbody2D rb2d;
	public float speed;
	float move;
	bool facingRight = true;
	public GameObject[] lasers;
	Animator playerAnim;
	public float laserDirection;
	public Transform shotPosition;
	public static playerMovement instance {get;set;}
	// Use this for initialization
	void Start () {
		instance = this;
		playerAnim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		laserDirection = 1;
		
	}
	void FixedUpdate()
	{
		move = Input.GetAxis("Horizontal");
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
		playerAnim.SetFloat("move", Mathf.Abs(move));
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		if (Input.GetKeyDown(KeyCode.Space)){
			StartCoroutine(Shoot());
		}
	}

	IEnumerator Shoot()
	{	
		Instantiate(lasers[0], shotPosition.position, shotPosition.rotation);
		yield return null;
	}

	void Flip(){
		laserDirection =-laserDirection;
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}	
}
