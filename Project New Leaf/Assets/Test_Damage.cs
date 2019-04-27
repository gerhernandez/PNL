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
        dmgTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDamaged)
        {
            DamageOverTime(dmgTime);
            dmgTime += Time.deltaTime;
        }
        else
        {
            dmgTime = 0;
        }

        sr.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1f));
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            isDamaged = true;
            p.isDamaged = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            isDamaged = false;
            p.isDamaged = false;
        }
    }

    void DamageOverTime(float dmgTime)
    {
        Debug.Log("time: " + (int)dmgTime % 2);
        if ((int) dmgTime % 2 == 0)
        {
            Debug.Log("Damage!! at " + (int) dmgTime % 2);
        }
    }
}
