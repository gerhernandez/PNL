using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {
    public static bool grounded = false;
    public float betweenJumpTime;

    private bool isPlayerMoving;
    private bool isPlayerInteracting;
    private bool isFacingRight;
    private bool playerNeedsToStop;

    private Rigidbody2D playerRb;

    private Vector2 position;
    private Vector2 direction;
    private float distance;
    private float jumpTimer;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Powers powers;
    private int jumpCount;
    private float playerWalkingSpeed;
    private float joystickControllerX;
    private bool jumpTimerSet;

    public float playerJumpingSpeed;

    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        distance = 1.3f;
        powers = GetComponent<Powers>();
        playerRb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        isPlayerMoving = true;
        isPlayerInteracting = false;
        playerNeedsToStop = false;
        jumpCount = 1;
        jumpTimerSet = false;
        jumpTimer = 0f;
        playerWalkingSpeed = 4f;
	}

    void FixedUpdate()
    {
        if (isPlayerMoving)
        {
            PlayerMovement();
        }
        else
        {
            if (playerNeedsToStop)
            {
                playerRb.velocity = new Vector2(0, playerRb.velocity.y);
                playerNeedsToStop = false;
            }
        }
        if (jumpTimerSet)
        {
            jumpTimer += Time.deltaTime;
            if(jumpTimer >= betweenJumpTime)
            {
                jumpTimerSet = false;
            }
        }

        CheckIfPlayerIsGrounded();
    }

    private void PlayerMovement()
    {
        float deadzone = 0.25f;
        Vector2 stickInput = new Vector2(Input.GetAxis("HorizontalX"), Input.GetAxis("VerticalX"));

        if (stickInput.magnitude < deadzone && !isPlayerInteracting && !powers.IsWolfDashing())
        {
            stickInput = Vector2.zero;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        else
        {
            if (Input.GetAxis("HorizontalX") > deadzone && isPlayerMoving)
            {
                isFacingRight = true;
            }
            else if(Input.GetAxis("HorizontalX") < -deadzone && isPlayerMoving)
            {
                isFacingRight = false;
            }
            if (!powers.IsWolfDashing()) {
                rb.velocity = new Vector2(stickInput.x * playerWalkingSpeed, rb.velocity.y);
            }
        }

        bool jumpAllowed = !powers.IsViperCrawling() && !powers.IsPlayerFlying() && jumpCount < 2 && isPlayerMoving;

        if (Input.GetButtonDown("ButtonA") && !isPlayerInteracting && jumpAllowed && !jumpTimerSet)
        {
            jumpTimerSet = true;
            rb.velocity = new Vector2(rb.velocity.x, transform.up.y * playerJumpingSpeed);
            jumpCount++;
        } else if(Input.GetButtonDown("ButtonA") && jumpCount >= 2 && !grounded && !jumpTimerSet)
        {
            jumpCount++;
        }
        
    }

    public void CheckIfPlayerIsGrounded()
    {

        position = transform.position;
        direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        if (hit.collider != null)
        {
            grounded = true;
            jumpCount = 1;
        }
        else
        {
            grounded = false;
        }
    }

    #region Getters and Setters

    public void InInteractionZone()
    {
        
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
        playerNeedsToStop = true;
        isPlayerInteracting = !isPlayerInteracting;
        isPlayerMoving = !isPlayerMoving;
    }

    public void SetMovementState(bool newState)
    {
        isPlayerMoving = newState;
    }

    public bool GetMovementState()
    {
        return isPlayerMoving;
    }

    public int GetJumpCount()
    {
        return jumpCount;
    }

    

    #endregion
}
