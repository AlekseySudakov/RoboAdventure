using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstNPCSecondScene : MonoBehaviour {
	public Animator animator;
	public bool isGreating;
	public GameObject words;
	public Animator wordAnim;
	bool talkToPlayer;
	Rigidbody2D rb2d;
	float direction, speed;
	bool facingRight;
	float nextWaypoint;
	float xMin, xMax;
	// Use this for initialization
	void Start () {
		xMax = Random.Range(13.9f, 16.2f);
		xMin = Random.Range(5.13f, 4f);
		facingRight = false;
		rb2d = GetComponent<Rigidbody2D>();
		isGreating = false;
		talkToPlayer = false;
	}
	void FixedUpdate()
	{
		animator.SetBool("isGreating", isGreating);
		wordAnim.SetBool("words", isGreating);
		animator.SetFloat("move", Mathf.Abs(direction));
	}
	
	// Update is called once per frame
	void Update () {
		if (talkToPlayer){
			StartCoroutine(StartWalk());
		}	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !talkToPlayer){
			isGreating = true;
			Invoke ("IsGreatingEnd", 4.5f);
		}
		
	}
	void IsGreatingEnd()
	{
		talkToPlayer = true;
		isGreating = false;
		nextWaypoint = xMax;
	}
	IEnumerator StartWalk()
	{
		
		if (transform.position.x < nextWaypoint && !facingRight){
			xMax = Random.Range(13.9f, 16.2f);
			nextWaypoint = xMax;
			Flip();
			direction = 1;
			speed = 2;
		
		
		}

		else if (transform.position.x > nextWaypoint && facingRight){
			xMin = Random.Range(5.13f, 4f);
			nextWaypoint = xMin;
			Flip();
			direction = -1;
			speed = 2;
		}

		rb2d.velocity = new Vector2 (direction * speed, rb2d.velocity.y);
		yield return null;
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
