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
    private bool isCrawling;

    // boar variables
    private bool isCharging;
    private const float chargeRecoil = 5f;


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

        isCrawling = false;
        isFlying = false;
        isCharging = false;
    }

    /// <summary>
    /// PLAYERS MOVEMENT HAS TO BE IN FIXEDUPDATE!
    /// </summary>
    private void FixedUpdate()
    {
        if (hasflyingPower)
        {
            FlyingMovement();
        }
        if (hasSnakePower)
        {
            SnakePower();
        }
    }

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
            if (Input.GetButton("ButtonB") && !isCharging && hasBoarPower)
            {
                isCharging = true;
                MoveScript.ChangeMovementState();

                if (MoveScript.IsPlayerFacingRight())
                {
                    playerRigidbody.AddForce(transform.right * chargeRecoil, ForceMode2D.Impulse);
                }
                else if (!MoveScript.IsPlayerFacingRight())
                {
                    playerRigidbody.AddForce(-transform.right * chargeRecoil, ForceMode2D.Impulse);
                }

                Destroy(collision.gameObject);
                StartCoroutine(BoarPowerActivated());
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            isFlying = false;
            jumpCountOnA = 0;
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
            isCrawling = true;
            playerCollider.size = new Vector2(3f, .25f);
            playerCollider.offset = new Vector2(1.5f, .125f);

        }
        if (Input.GetButtonUp("ButtonY"))
        {
            isCrawling = false;
            playerCollider.size = playerOriginalScale;
            playerCollider.offset = playerOriginalCenter;
        }
    }

    public bool IsViperCrawling()
    {
        return isCrawling;
    }

    #endregion
    
    #region Boar Power

    // Start of the coroutine, delay of one second is placed per boar smash
    // This could also hold the animation and switching of sprites
    IEnumerator BoarPowerActivated()
    {
        yield return new WaitForSeconds(1);
        isFlying = false;
        MoveScript.ChangeMovementState();
    }

    public bool IsCharging()
    {
        return isCharging;
    }
    #endregion

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
