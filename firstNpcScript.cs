using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstNpcScript : MonoBehaviour {
	public Animator firstNpc;
	bool facingRight;
	GameObject player;
	Rigidbody2D rb2d;
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
		if (firstNpc.GetBool("isStand") == true) {
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

	IEnumerator Reverse(){
		
		if (player.transform.position.x < this.transform.position.x && facingRight){
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
