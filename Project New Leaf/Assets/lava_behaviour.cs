using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava_behaviour : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			other.GetComponent<Rigidbody2D>().mass = 5;
			other.GetComponent<Rigidbody2D>().gravityScale = 0.30f;
			other.GetComponent<Rigidbody2D>().drag = 5.0f;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			other.GetComponent<Rigidbody2D>().mass = 1;
			other.GetComponent<Rigidbody2D>().gravityScale = 1;
			other.GetComponent<Rigidbody2D>().drag = 0;
		}
	}
}
