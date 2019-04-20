using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Damage : MonoBehaviour {
    public static bool isDamaged;
    public float dmgTime;

	// Use this for initialization
	void Start () {
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
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            isDamaged = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            isDamaged = false;
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
