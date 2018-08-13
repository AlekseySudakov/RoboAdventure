using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassEnemy: MonoBehaviour {
	public int health;
	public int damage;
	public float speed;
	public string color; 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "playerLaser"){
			if (PlayerLaserMove.instance.color == color){
				health--;
				Debug.Log("HIT!");
			}
		}
	}

	
	

}
