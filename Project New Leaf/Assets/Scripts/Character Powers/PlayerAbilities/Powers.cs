using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour {

    // booleans for power activation
    public static bool hasflyingPower = false;
    public static bool hasBoarPower = false;
    public static bool hasSnakePower = false;
    public static bool hasWolfPower = false;

    // variables of Player
    public BoxCollider2D playerCollider;
    private Rigidbody2D playerRigidbody;
    private Move MoveScript;

    // dimensions and center of playerCollider
    public Vector2 playerOriginalScale;
    public Vector2 playerOriginalCenter;

    // boar variables
    private bool isCharging;


    // Flying variables
    private bool isFlying;
    private int jumpCountOnA = 0;
    private float flyingVelocity = 10f;
    private float flyingStamina = 0.5f;
    private const float MIN_DECREASE_IN_STAMINA = 0.001f;
    private const float MAX_DECREASE_IN_STAMINA = 0.003f;
    private const float MIN_FLYING_STAMINA = 0.0f;
    private const float MAX_FLYING_STAMINA = 0.5f;
    
    private void Start()
    {
        MoveScript = GetComponent<Move>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerOriginalScale = playerCollider.size;
        playerOriginalCenter = playerCollider.offset;

        
        isFlying = false;
        isCharging = false;
    }

    /// <summary>
    /// PLAYERS MOVEMENT HAS TO BE IN FIXEDUPDATE!
    /// </summary>
    private void FixedUpdate()
    {
        
        // if a power is activated, stop player's movement through control pad
        if (hasflyingPower)
        {
            FlyingMovement();
        }
        if (hasSnakePower)
        {
            SnakePower();
        }

    }

    #region Snake Power
    /// <summary>
    /// Snake Power shrinks player to fit under small crawl spaces
    /// </summary>
    public void SnakePower()
    {
        if (Input.GetButton("ButtonY"))
        {
            playerCollider.size = new Vector2(3f, .25f);
            playerCollider.offset = new Vector2(1.5f, .125f);

        }
        if (Input.GetButtonUp("ButtonY"))
        {
            playerCollider.size = playerOriginalScale;
            playerCollider.offset = playerOriginalCenter;
        }
    }
    #endregion

    /// <summary>
    /// OnCollisionStay2D method: Used when player is attempting to use boar power on a crate
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        // check if collision is of tag breakable
        if (collision.gameObject.tag == "Breakable")
        {
            // when player presses the B button on the xbox controller, and a power has not been activated yet
            if (Input.GetButton("ButtonB") && !isCharging)
            {
                isCharging = true;
                MoveScript.ChangeMovementState();

                if (MoveScript.face)
                {
                    playerRigidbody.velocity = Vector2.left * 100 * Time.deltaTime;
                }
                

                Destroy(collision.gameObject);          // Destroy object
                StartCoroutine(BoarPowerActivated());   // Start coroutine to hold player's movement by one second
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            isFlying = false;
            jumpCountOnA = 0;
        }

    }


    // Start of the coroutine, delay of one second is placed per boar smash
    // This could also hold the animation and switching of sprites
    IEnumerator BoarPowerActivated()
    {
        yield return new WaitForSeconds(1);
        isFlying = false;
        MoveScript.ChangeMovementState();
    }

    #region Flying Power

    //---------------------------------------------
    // Flying starts
    //---------------------------------------------

    void FlyingMovement()
    {
        if (!isFlying)
        {
            flyingStamina += 0.003f;
        }

        if (Input.GetButtonDown("ButtonA") && jumpCountOnA <= 2)
        {
            jumpCountOnA++;

            if (jumpCountOnA == 2)
            {
                isFlying = true;
            }
        }

        if (isFlying && flyingStamina > 0)
        {
            flyingStamina -= MIN_DECREASE_IN_STAMINA;

            if (Input.GetButton("ButtonA"))
            {
                playerRigidbody.gravityScale = 0.3f;
                playerRigidbody.drag = 0.7f;
                playerRigidbody.AddForce(transform.up * flyingVelocity, ForceMode2D.Impulse);
                flyingStamina -= MAX_DECREASE_IN_STAMINA;
            }

        }
        flyingStamina = (flyingStamina < MIN_FLYING_STAMINA) ? MIN_FLYING_STAMINA : flyingStamina;
        flyingStamina = (flyingStamina > MAX_FLYING_STAMINA) ? MAX_FLYING_STAMINA : flyingStamina;
    }

    public bool IsPlayerFlying()
    {
        return isFlying;
    }
    #endregion
}
