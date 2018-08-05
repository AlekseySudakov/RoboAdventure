using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	Rigidbody2D rb2d;
	public float speed;
	float move;
	bool facingRight = true;
	Animator playerAnim;
	// Use this for initialization
	void Start () {
		playerAnim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
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
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}	
}
