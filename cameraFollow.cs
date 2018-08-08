using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;
	public GameObject player;
	public float posVar;
	public bool bound;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
	{
		float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y-posVar, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);
		if(bound){
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
			Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
			Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	}
}
