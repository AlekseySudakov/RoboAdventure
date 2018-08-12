using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {
	public bool enemyDetected = false;
	public GameObject detectIndicator;
	bool facingLeft;
	public GameObject enemy;
	
	// Use this for initialization
	void Start () {
		facingLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyDetected){
			StartCoroutine(EnemyDetect());
		}
		else{
			StartCoroutine(EnemyHide());
		}
	}

	void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator EnemyDetect()
	{
		detectIndicator.GetComponent<SpriteRenderer>().color = new Color32 (255,255,255,125);
		if (enemy.transform.position.x < transform.position.x && !facingLeft){
			Flip();
		}
		else if (enemy.transform.position.x > transform.position.x && facingLeft){
			Flip();
		}
		yield return null;
	}
	IEnumerator EnemyHide()
	{
		detectIndicator.GetComponent<SpriteRenderer>().color = new Color (255,255,255,0);
		yield return null;
	}
	
}
