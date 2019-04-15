using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    public bool isGrounded;
    public float h, hX, speed;
    public Rigidbody2D rb;
    public SpriteRenderer drawn;

	// Use this for initialization
	void Start () {
        speed = 0.25f;

        rb = GetComponent<Rigidbody2D>();
        drawn = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            h = Input.GetAxis("Horizontal");
        }

        if (Input.GetAxis("HorizontalX") > 0 || Input.GetAxis("HorizontalX") < 0)
        {
            hX = Input.GetAxis("HorizontalX");
        }
        

        transform.Translate(transform.right * h * speed);

        if (h < 0)
        {
            drawn.flipX = true;
        }
        else if (h > 0)
        {
            drawn.flipX = false;
        }
	}

    void FixedUpdate()
    {
        if ((Input.GetButtonDown("ButtonA") || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.AddForce(transform.up * 6, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
