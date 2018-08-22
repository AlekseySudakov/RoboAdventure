using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftControll : MonoBehaviour {
	Rigidbody2D rb2d;
	public float direction;
	public float speed;
	public bool grounded;
	bool nextStage = false;
	public GameObject  up, down;
	// Use this for initialization
	void Start () {
		speed = -1;
		rb2d = GetComponentInParent<Rigidbody2D>();
		direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(rb2d.velocity.x, direction * speed);
		StartCoroutine(IndicatorColor());
	}

	IEnumerator StopLift()
	{	
		speed = 0;
		yield return null;
	}
	IEnumerator IndicatorColor()
	{
		if (speed == 1){
			up.GetComponent<SpriteRenderer>().color = new Color (255,255,255,255);
			down.GetComponent<SpriteRenderer>().color = new Color (255,255,255,0);
		}
		else if (speed == 0){
			up.GetComponent<SpriteRenderer>().color = new Color (255,255,255,0);
			down.GetComponent<SpriteRenderer>().color = new Color (255,255,255,0);
		}
		else{
			up.GetComponent<SpriteRenderer>().color = new Color (255,255,255,0);
			down.GetComponent<SpriteRenderer>().color = new Color (255,255,255,255);
		}
		yield return null;
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "platform"){
			grounded = true;
			if (!nextStage){
				StartCoroutine(StopLift());
			}
			nextStage = true;
			
		}
		if (other.tag == "Player"){
			if (Input.GetKeyDown(KeyCode.E) && grounded){
				if (grounded){
					speed = 1;
					Debug.Log("Pressed");
				}
			}
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "platform"){
			grounded = false;
		
		}
	}
}
