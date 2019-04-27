using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public static bool grounded = false;

    private Transform playersTransform;
    private Rigidbody2D rb;
    private bool isPlayerMoving;
    private float playerWalkingSpeed;
    private float playerJumpingSpeed;
    private float joystickControllerX;
    private float playersDistanceToGround;
    private const string NPC_TAG = "NPC";
    
	void Start () {
        playersTransform = this.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
        isPlayerMoving = true;
        playerWalkingSpeed = 8f;
        playerJumpingSpeed = 4f;
        playersDistanceToGround = GetComponent<Collider2D>().bounds.extents.y;
	}
	
    void FixedUpdate()
    {
        if (isPlayerMoving)
        {
            PlayerMovement();
            CheckIfPlayerIsGrounded();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == NPC_TAG)
        {

        }
    }

    private void PlayerMovement()
    {
        if (Input.GetAxis("HorizontalX") > 0.3f || Input.GetAxis("HorizontalX") < -0.3f)
        {
            
            joystickControllerX = Input.GetAxis("HorizontalX");
            rb.velocity = new Vector2(joystickControllerX * playerWalkingSpeed, rb.velocity.y);
        }

        Debug.Log("Current translation: " + joystickControllerX);
        if (Input.GetButtonDown("ButtonA"))
        {
            rb.AddForce(transform.up * playerJumpingSpeed, ForceMode2D.Impulse);
        }
    }

    public void CheckIfPlayerIsGrounded()
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
    }
    
    public void ChangeMovementState()
    {
        isPlayerMoving = !isPlayerMoving;
    }

    public bool GetMovementState()
    {
        return isPlayerMoving;
    }
}
