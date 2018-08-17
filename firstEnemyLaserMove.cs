using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstEnemyLaserMove : MonoBehaviour {
	Rigidbody2D rb2b;
	public float speed;
	float direction;
	public ParticleSystem collisionParticle;
	// Use this for initialization
	void Start () {
		direction = enemyScript.instance.laserDirection;
		rb2b = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb2b.velocity = new Vector2 (direction * speed, rb2b.velocity.y);
		Invoke("SetLaserDisable", 0.3f);
		Destroy(1f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player"){
			this.GetComponent<SpriteRenderer>().color = new Color (255,255,255,0);
			collisionParticle.Play();
			speed = 0;
			Destroy(2f);
		}
	}

	void Destroy(float time){
		Destroy(gameObject, time);
	}
	void SetLaserDisable(){
		speed = 0;
		this.GetComponent<SpriteRenderer>().color = new Color (0,0,0,0);
		//colisionParicle.Play();
	}
}
