using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserMove : MonoBehaviour {
	Rigidbody2D rb2d;
	public float speed;
	float direction;
	public ParticleSystem colisionParicle;
	// Use this for initialization
	void Start () {
		direction = playerMovement.instance.laserDirection;
		rb2d = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "barell"){
			this.GetComponent<SpriteRenderer>().color = new Color (255,255,255,0);
			colisionParicle.Play();
			speed = 0;
			Destroy();
		}
		
	}

	void Destroy(){
		Destroy(gameObject, 2f);
	}
}
