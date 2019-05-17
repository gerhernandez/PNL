using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAcceleratingPlatform : MonoBehaviour {

    private Vector2 speed;
    public Vector2 acceleration;

    public int halfInterval;
    int clock;
    Rigidbody2D rb;

    Vector3 startingPosition;
    bool returning;
    bool decreasing;
    // Use this for initialization
    void Start()
    {
        clock = halfInterval;
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        speed.Set(0, 0);
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if (halfInterval > 0)
        {

            speed += acceleration;
            rb.velocity = speed;
            
            clock--;

            if (clock == 0)
            {
                clock = halfInterval;

                if (decreasing == true)
                {
                    if (returning == true)
                    {
                        transform.SetPositionAndRotation(startingPosition, Quaternion.identity);
                    }
                    returning = !returning;
                    
                }
                else
                {
                    acceleration.Set(-acceleration.x, -acceleration.y);

                }
                decreasing = !decreasing;
                
            }

        }
    }
}
