using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserMove : MonoBehaviour {
	Rigidbody2D rb2d;
	public float speed;
	float direction;
	// Use this for initialization
	void Start () {
		direction = playerMovement.instance.laserDirection;
		rb2d = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
	}
}
