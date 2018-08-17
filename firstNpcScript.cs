using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstNpcScript : MonoBehaviour {
	public Animator firstNpc;
	bool facingRight;
	GameObject player;
	Rigidbody2D rb2d;
	public float speed;
	float move = 1;
	public GameObject words;
	public Animator wordsAnim;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		facingRight = true;
		player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
	{
		if (firstSceneController.getInstance.enemyDestroy){
			firstNpc.SetBool("isStand", true);
		}
		if (firstNpc.GetBool("isStand") == true && wordsAnim.GetBool("words") == false) {
			StartCoroutine(Reverse());
		}
		
		
	}

	public void Words(){
		wordsAnim.SetBool("words", true);
		words.GetComponent<SpriteRenderer>().color = new Color (255,255,255,255);
		if (!facingRight){
			words.GetComponent<SpriteRenderer>().flipX = true;
		}
	}

	public void GoNextInvoke(){
		if (facingRight){
			words.GetComponent<SpriteRenderer>().flipX = false;
		}
		Invoke("GoNext", 1f);
	}
	public void GoNext(){
		if (!facingRight){
			Flip();
		}
		firstNpc.SetFloat("move", Mathf.Abs(move));
		rb2d.velocity = new Vector2 (move * speed, rb2d.velocity.y);
	}

	IEnumerator Reverse(){
		
		if (player.transform.position.x < this.transform.position.x && facingRight){
			Flip();
		}
		else if (player.transform.position.x > this.transform.position.x && !facingRight){
			Flip();
		}
		yield return null;
	}
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
