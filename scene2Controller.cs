using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene2Controller : MonoBehaviour {
	public static scene2Controller instance {get; set;}
	public bool liftGrounded;
	// Use this for initialization
	void Start () {
		liftGrounded = false;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
