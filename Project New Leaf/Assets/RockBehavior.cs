using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour {

    public int unHitLifespan;
    public int lifeSpanAfterHit;
    public bool dying;


	// Use this for initialization
	void Start () {
        dying = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (dying)
        {
            lifeSpanAfterHit--;
            if (lifeSpanAfterHit < 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            unHitLifespan--;
            if (unHitLifespan < 0)
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
