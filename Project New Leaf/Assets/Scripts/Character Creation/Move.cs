﻿using System.Collections;
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
    private float playerJumpingSpeed;

    private Rigidbody2D rb;
    private Powers powers;
    private int jumpCount;
    private float playerWalkingSpeed;
    private float joystickControllerX;
    
    
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        powers = GetComponent<Powers>();
        isFacingRight = true;
        isPlayerMoving = true;
        isPlayerInteracting = false;
        jumpCount = 0;
        playerWalkingSpeed = 4f;
        playerJumpingSpeed = 5f;
	}
	
    void FixedUpdate()
    {
        if (isPlayerMoving)
        {
            PlayerMovement();
        }

        CheckIfPlayerIsGrounded();
    }

    private void PlayerMovement()
    {
        float deadzone = 0.25f;
        Vector2 stickInput = new Vector2(Input.GetAxis("HorizontalX"), Input.GetAxis("VerticalX"));

        if (stickInput.magnitude < deadzone && !isPlayerInteracting)
        {
            stickInput = Vector2.zero;
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
            } else
            {
                Debug.Log("Currently dashing");
            }
            
        }

        bool jumpAllowed = !powers.IsViperCrawling() && !powers.IsPlayerFlying() && jumpCount < 3 && isPlayerMoving;

        if (Input.GetButtonDown("ButtonA") && !isPlayerInteracting && jumpAllowed)
        {
            if(jumpCount < 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, transform.up.y * playerJumpingSpeed);
            }
            jumpCount++;
        }
    }

    public void CheckIfPlayerIsGrounded()
    {
        float yPos = 1f;

        RaycastHit2D groundRayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - yPos), Vector2.down, 0.25f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - yPos), Vector2.down, Color.red);

        if (groundRayHit.collider != null && groundRayHit.collider.tag == "Ground" && !powers.IsViperCrawling())
        {
            HealthManager.rechargeEnabled = true;
            jumpCount = 1;
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    #region Getters and Setters

    public void InInteractionZone()
    {
        isPlayerInteracting = !isPlayerInteracting;
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

    public int GetJumpCount()
    {
        return jumpCount;
    }

    public void SetJumpCount(int num)
    {
        jumpCount = num;
    }

    #endregion
}
