using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public static bool grounded = false;
    
    private Rigidbody2D rb;
    private bool isPlayerMoving;
    private float playerWalkingSpeed;
    private float playerJumpingSpeed;
    private float joystickControllerX;
    private const string NPC_TAG = "NPC";
    
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        isPlayerMoving = true;
        playerWalkingSpeed = 8f;
        playerJumpingSpeed = 4f;
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
        float deadzone = 0.25f;
        Vector2 stickInput = new Vector2(Input.GetAxis("HorizontalX"), Input.GetAxis("VerticalX"));

        if (stickInput.magnitude < deadzone)
        {
            stickInput = Vector2.zero;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
            
        else
            rb.velocity = new Vector2(stickInput.x * playerWalkingSpeed, rb.velocity.y);
        

        //Debug.Log("Current translation: " + joystickControllerX);
        //if (Input.GetButtonDown("ButtonA"))
        //{
        //    rb.AddForce(transform.up * playerJumpingSpeed, ForceMode2D.Impulse);
        //}
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
