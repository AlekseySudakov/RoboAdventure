using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundChech : MonoBehaviour {

	// Use this for initialization
private playerMovement player;

void Start()
{
	player = gameObject.GetComponentInParent<playerMovement>();
}
void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "platform"){
			player.grounded = true;

		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "platform"){
			player.grounded = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "platform"){
			player.grounded = false;
		
		}
	}
}
