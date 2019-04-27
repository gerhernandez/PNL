using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Damage : MonoBehaviour {
    Player p;
    SpriteRenderer sr;
    public bool isDamaged;
    public float dmgTime;

	// Use this for initialization
	void Start () {
        p = FindObjectOfType<Player>();
        sr = GetComponent<SpriteRenderer>();
        isDamaged = false;
	}
	
	// Update is called once per frame
	void Update () {
        sr.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1f));
	}
}
