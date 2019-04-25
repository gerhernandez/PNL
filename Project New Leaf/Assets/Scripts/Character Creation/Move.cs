using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    public static bool grounded;

    public float h, hX, speed;
    public float distanceToGround;

    public Rigidbody2D rb;
    public Collider2D playerCollider;
    
	void Start () {
        grounded = false;

        speed = 8f;
        distanceToGround = GetComponent<Collider2D>().bounds.extents.y;

        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
	}
	
	void Update () {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            h = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(h * speed, rb.velocity.y);
        }

        if (Input.GetAxis("HorizontalX") > 0 || Input.GetAxis("HorizontalX") < 0)
        {
            hX = Input.GetAxis("HorizontalX");
            rb.velocity = new Vector2(hX * speed, rb.velocity.y);
        }
	}

    void FixedUpdate()
    {
        RaycastHit2D groundRayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 3f), Vector2.down, 0.4f);
        
        if (groundRayHit.collider != null && groundRayHit.collider.tag == "Ground")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if ((Input.GetButtonDown("ButtonA") || Input.GetKeyDown(KeyCode.Space)) && grounded)
        {
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
    }
}
