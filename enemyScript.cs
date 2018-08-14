using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript: ClassEnemy {
	
	public bool enemyDetected = false;
	public GameObject detectIndicator;
	bool facingLeft;
	public GameObject laser;
	public Transform laserPossition;
	public GameObject enemy;
	public float laserDirection;
	static public enemyScript instance {get;set;}
	public float shotTime = 1f;
	public Animator enemyAnim;
	public ParticleSystem deathSmoke;

	
	// Use this for initialization
	void Awake()
	{
		
	}
	void Start () {
		color = "red";
		health = 1;
		damage = 1;
		speed = 100;
		laserDirection = -1;
		instance = this;
		facingLeft = true;
	}
	// Update is called once per frame
	void Update () {
		if (enemyDetected && health > 0){
			StartCoroutine(EnemyDetect());
			StartCoroutine(ShotIE(2.0f));
		}
		else{
			StartCoroutine(EnemyHide());
		}
		if (health <= 0){
			firstSceneController.getInstance.enemyDestroy = true;
			Debug.Log(firstSceneController.getInstance.enemyDestroy.ToString());
		}
	}
	void FixedUpdate()
	{
		enemyAnim.SetInteger ("health", health);
	}

	void Flip(){
		laserDirection =- laserDirection;
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
	IEnumerator ShotIE(float waitTime)
	{		
			shotTime-=Time.deltaTime;
			if (shotTime <= 0){
				Shot();
				shotTime = 1f;
			}
			yield return null;
	}
	void Shot(){
		Instantiate (laser, laserPossition.position, Quaternion.identity);
	}


	void Death()
	{
		deathSmoke.Play();
	}
	
	
		

		

	

	
}
