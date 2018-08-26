using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserMove : MonoBehaviour {
	Rigidbody2D rb2d;
	public float speed;
	float direction;
	public ParticleSystem colisionParicle;
	
	public static PlayerLaserMove instance {get;set;}
	public string color;
	// Use this for initialization
	void Start () {

		instance = this;
		color = playerMovement.instance.color;
		direction = playerMovement.instance.laserDirection;
		rb2d = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
		Invoke("SetLaserDisable", 0.3f);
		Destroy(1f);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "barell" || coll.tag == "Wall"){
			this.GetComponent<SpriteRenderer>().color = new Color (255,255,255,0);
			colisionParicle.Play();
			speed = 0;
			Destroy(2f);
		}
		
	}
	
	void SetLaserDisable(){
		speed = 0;
		this.GetComponent<SpriteRenderer>().color = new Color (0,0,0,0);
		//colisionParicle.Play();
	}
	
	void Destroy(float time){
		Destroy(gameObject, time);
	}
}
