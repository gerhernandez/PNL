using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovingPlatform : MonoBehaviour {

    public Vector2 speed;

    public int interval;
    public int clock;
    Rigidbody2D rb;

    public Vector3 startingPosition;
    bool returning;
    // Use this for initialization
    void Start () {
        clock = interval;
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    
	
	// Update is called once per frame
	void FixedUpdate () {

        if (interval >= 0)
        {
            rb.velocity = speed;

            

            if (clock > 0)
            {
                clock--;
            }
            else
            {
                clock = interval;
                speed.Set(-speed.x, -speed.y);
                if (returning == true)
                {
                    transform.SetPositionAndRotation(startingPosition, Quaternion.identity);
                }
                returning = !returning;
            }

        }
    }
}
