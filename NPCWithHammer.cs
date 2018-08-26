using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWithHammer : MonoBehaviour {
	public Animator animator;
	public bool isCrash;
	public float crashTime;
	public ParticleSystem sparks;
	public GameObject words;
	public int wordsSelect;
	public Sprite[] pharses;
	public bool playerNear;
	public Animator wordsAnimator;
	public bool saidWord;
	// Use this for initialization
	void Start () {
		saidWord = false;
		playerNear = false;
		crashTime = Random.Range(4f,5f);
		isCrash = false;
	}
	
	// Update is called once per frame
	void Update () {
		crashTime -= Time.deltaTime;
		if (crashTime <= 0){
			isCrash = true;
			Invoke("Crash", 1f);
			
		}
	}
	void FixedUpdate()
	{
		wordsAnimator.SetBool("isSaid", saidWord);
		animator.SetBool("isCrash", isCrash);
	}
	void Crash(){
		isCrash = false; 
		crashTime = Random.Range(4f,5f);
	}

	public void SparksPlay(){
		sparks.Play();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player"){
				Debug.Log("SUKA");
				saidWord = true;

				SaidWords();
				Invoke("EndWord", 0.2f);
			
		}
	}

	void SaidWords(){

		if (saidWord){
			wordsSelect = Random.Range(0,3);
			words.GetComponent<SpriteRenderer>().sprite = pharses[wordsSelect];
		}
	}
	public void EndWord(){
		saidWord = false;
	}
}
