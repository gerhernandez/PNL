using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

	public float speed = -2.0f;
	GameObject mountains;
	Vector2 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		mountains = GameObject.Find("Nighttime_Bg_Mountains");
	}
	
	// Update is called once per frame
	void Update () {
		float newPos = Mathf.Repeat(Time.time * speed, 100);
		transform.position = startPos + Vector2.right * newPos;
		// Vector2 offset = new Vector2(Time.time * speed, 0);
		
		// GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
