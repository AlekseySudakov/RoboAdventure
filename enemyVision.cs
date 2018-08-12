using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyVision : MonoBehaviour {
	private enemyScript eScript;
	// Use this for initialization
	void Start () {
		eScript = gameObject.GetComponentInParent<enemyScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player"){
			eScript.enemyDetected = true;
			eScript.enemy = other.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player"){
			eScript.enemyDetected = false;
			eScript.enemy = null;
		}
		
	}
}
