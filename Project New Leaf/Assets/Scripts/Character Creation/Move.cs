using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public static bool grounded = false;

    [SerializeField]
    private bool isPlayerMoving;
    [SerializeField]
    private bool isPlayerInteracting;
    [SerializeField]
    private bool isFacingRight;

    private Rigidbody2D rb;
    private Powers powers;
    private float playerWalkingSpeed;
    private float playerJumpingSpeed;
    private float joystickControllerX;
    
    
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        powers = GetComponent<Powers>();
        isFacingRight = true;
        isPlayerMoving = true;
        isPlayerInteracting = false;
        playerWalkingSpeed = 8f;
        playerJumpingSpeed = 2f;
	}
	
    void FixedUpdate()
    {
        if (isPlayerMoving)
        {
            PlayerMovement();
            CheckIfPlayerIsGrounded();
        }
    }

    private void PlayerMovement()
    {
        float deadzone = 0.25f;
        Vector2 stickInput = new Vector2(Input.GetAxis("HorizontalX"), Input.GetAxis("VerticalX"));

        if (stickInput.magnitude < deadzone && !isPlayerInteracting)
        {
            stickInput = Vector2.zero;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        else
        {
            if (Input.GetAxis("HorizontalX") > deadzone)
            {
                isFacingRight = true;
            }
            else if(Input.GetAxis("HorizontalX") < -deadzone)
            {
                isFacingRight = false;
            }
            rb.velocity = new Vector2(stickInput.x * playerWalkingSpeed, rb.velocity.y);
        }


        //Debug.Log("Current translation: " + joystickControllerX);
        if (Input.GetButtonDown("ButtonA") && !isPlayerInteracting && !powers.IsPlayerFlying())
        {
            rb.AddForce(transform.up * playerJumpingSpeed, ForceMode2D.Impulse);
        }
    }

    public void CheckIfPlayerIsGrounded()
    {
        RaycastHit2D groundRayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 3.75f), Vector2.down, 0.5f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 3.75f), Vector2.down);

        if (groundRayHit.collider != null && groundRayHit.collider.tag == "Ground")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }


    public void InInteractionZone(bool state)
    {
        isPlayerInteracting = state;
    }

    public bool GetIsPlayerInteracting()
    {
        return isPlayerInteracting;
    }

    public bool IsPlayerFacingRight()
    {
        return isFacingRight;
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
