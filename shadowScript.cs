﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shadowScript : MonoBehaviour {
	public GameObject player;
	public Scene scene;
	public float yValue;
	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene();
		if (scene.name == "demoScene"){
			//transform.position = new Vector3(player.transform.position.x,-4.508f,0);
			yValue = -4.506f;
		}
		else if (scene.name == "city"){
			yValue = -3.87f;
		}
		player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
			transform.position = new Vector2(player.transform.position.x, yValue);//-4.506f);
		
	}
}
