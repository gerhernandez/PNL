using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    public static bool grounded;

    public float h, hX, speed;
    public float distanceToGround;

    public Rigidbody2D rb;
    public Collider2D playerCollider;

	// Use this for initialization
	void Start () {
        grounded = false;

        speed = 8f;
        distanceToGround = GetComponent<Collider2D>().bounds.extents.y;

        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            h = Input.GetAxis("Horizontal");
            //transform.Translate(transform.right * h * speed);
            rb.velocity = new Vector2(h * speed, rb.velocity.y);
        }

        if (Input.GetAxis("HorizontalX") > 0 || Input.GetAxis("HorizontalX") < 0)
        {
            hX = Input.GetAxis("HorizontalX");
            //transform.Translate(transform.right * hX * speed);
            rb.velocity = new Vector2(hX * speed, rb.velocity.y);
        }
	}

    void FixedUpdate()
    {
        RaycastHit2D groundRayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 3f), Vector2.down, 0.4f);

        //Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 3f), Vector2.down, Color.red);

        if (groundRayHit.collider != null)
        {
            //Debug.Log("collider name: " + groundRayHit.collider.name);
        }

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
    
    /*
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter: " + collision.gameObject.tag);

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("CollisionExit: " + collision.gameObject.tag);

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }*/
}
