using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    public static bool isGrounded;
    public float h, hX, speed;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        isGrounded = false;
        speed = 0.25f;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("M-isGrounded: " + isGrounded);
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            h = Input.GetAxis("Horizontal");
            transform.Translate(transform.right * h * speed);
        }

        if (Input.GetAxis("HorizontalX") > 0 || Input.GetAxis("HorizontalX") < 0)
        {
            hX = Input.GetAxis("HorizontalX");
            transform.Translate(transform.right * hX * speed);
        }
	}

    void FixedUpdate()
    {
        if ((Input.GetButtonDown("ButtonA") || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.AddForce(transform.up * 6, ForceMode2D.Impulse);
        }
    }
    
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
    }
}
