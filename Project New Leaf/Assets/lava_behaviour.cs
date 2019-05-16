using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava_behaviour : MonoBehaviour {

	public GameObject player;
    public AudioSource audio;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //This is used to calculate how loud our 
        //lava should be depending on how far away the player is
        var t = (transform.position - player.transform.position);
        float newT = Vector3.SqrMagnitude(t);
        newT = (newT - Mathf.Pow(audio.minDistance, 2) / Mathf.Pow(audio.maxDistance, 2));
        audio.spatialBlend = Mathf.Lerp(10f, 22000f, newT);
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
