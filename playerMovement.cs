using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerMovement : MonoBehaviour {
	Rigidbody2D rb2d;
	public float speed;
	float move;
	bool facingRight = true;
	public GameObject[] lasers;
	Animator playerAnim;
	public float laserDirection;
	public Transform shotPosition;
	public bool grounded;
	public float jumpPower;
	public float vertical;
	public string color;
	public static playerMovement instance {get;set;}
	public GameObject ShootingAmmo;
	public Sprite [] laserColor;
	public Image laserImg;
	public Image healthImg;
	public float healthValue;
	public float tempHealth;
	// Use this for initialization
	void Start () {
		healthValue = 100;
		tempHealth = 100;
		color = "red";
		ShootingAmmo = lasers[0];
		grounded = false;
		instance = this;
		playerAnim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		laserDirection = 1;	
	}
	void FixedUpdate()
	{
		move = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		playerAnim.SetFloat("move", Mathf.Abs(move));
		playerAnim.SetFloat("vertical", Mathf.Abs(vertical));
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(DecreaseHealth());
		rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
		Collect(healthValue);
		playerAnim.SetBool("grounded", grounded);
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		if (Input.GetKeyDown(KeyCode.Space)){
			StartCoroutine(Shoot(ShootingAmmo));
		}
		if (Input.GetKeyDown(KeyCode.R)){
			if (color == "red"){
				ChangeColor("blue", laserColor[1], lasers[1]);
			}
			else if (color == "blue"){
				ChangeColor("yellow", laserColor[2], lasers[2]);
			}
			else if (color == "yellow"){
				ChangeColor("red", laserColor[0], lasers[0]);
			}
		}
		if (grounded && Input.GetKeyDown(KeyCode.UpArrow)){
			rb2d.AddForce(Vector2.up * jumpPower);
			playerAnim.SetFloat("vertical", 1);
		}
	}
	void ChangeColor(string laser, Sprite laserColorImg, GameObject ammo){
		color = laser;
		laserImg.sprite = laserColorImg;
		ShootingAmmo = ammo;
	}

	IEnumerator Shoot(GameObject ammo)
	{	
		Instantiate(ammo, shotPosition.position, Quaternion.identity);
		yield return null;
	}

	void Flip(){
		laserDirection =-laserDirection;
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}	

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "redLaser"){
			tempHealth = healthValue - 10;
		}
	}

	IEnumerator DecreaseHealth()
	{
		if (healthValue > tempHealth){
			healthValue -= (Time.deltaTime * 15);
		}
		yield return null;
	}

		public void Collect(float health){
		float amounth = (health/100.0f);
		if (healthImg != null)
		healthImg.fillAmount = amounth;
	}



}
