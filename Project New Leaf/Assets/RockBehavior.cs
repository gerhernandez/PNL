using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour {

    public float unHitLifespan;
    public float lifeSpanAfterHit;
    public bool dying;


	// Use this for initialization
	void Start () {
        dying = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (dying)
        {
            lifeSpanAfterHit -= Time.deltaTime;
            if (lifeSpanAfterHit <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            unHitLifespan -= Time.deltaTime;
            if (unHitLifespan <= 0)
            {
                Destroy(gameObject);
            }
        }
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dying = true;
    }
}
