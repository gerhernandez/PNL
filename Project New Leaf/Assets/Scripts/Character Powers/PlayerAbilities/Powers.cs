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

    // dimensions and center of playerCollider
    public Vector2 playerOriginalScale;
    public Vector2 playerOriginalCenter;

    // boar variables
    private bool power_activated;       // To hold a bool value when a power is activated ******* can and probably should be changed to boarPowerActivated *****
    private bool character_movement;    // To hold a bool value to make movement active or inactive ********* This does not have to be in this script ******

    // Flying variables
    public static float flyingStamina = 0.5f;

    public static int jumpCountOnA = 0;
    private float flyingVelocity = 10f;

    private const float MIN_DECREASE_IN_STAMINA = 0.001f;
    private const float MAX_DECREASE_IN_STAMINA = 0.003f;
    private const float MIN_FLYING_STAMINA = 0.0f;
    private const float MAX_FLYING_STAMINA = 0.5f;
    
    private void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerOriginalScale = playerCollider.size;
        playerOriginalCenter = playerCollider.offset;

        playerRigidbody = GetComponent<Rigidbody2D>();
        character_movement = true;      // Set character movement to true, ********* This does not have to be in this script ******
        power_activated = false;        // Set power activated to false, no powers are active at the start of the game
    }

    /// <summary>
    /// PLAYERS MOVEMENT HAS TO BE IN FIXEDUPDATE!
    /// </summary>
    private void FixedUpdate()
    {
        SnakePower();
        // if a power is activated, stop player's movement through control pad
        if (!power_activated)
        {
            FlyingMovement();
        }

    }

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
            if (Input.GetButton("ButtonB") && !power_activated)
            {
                // Start animation of boar smash here (swtiching of sprites plus animation) 

                power_activated = true;         // Set power_activated to true
                character_movement = false;     // Set character_movement to false (stops player from moving)

                // ********* This is a temporary fix, requires another check (player's facing direction) ***********
                // Change Vector2.left if player is facing right,
                // Change Vector2.right if player is facing left.
                // ******** I'll look into a better approach as I progress with other stuff *********
                playerRigidbody.velocity = Vector2.left * 100 * Time.deltaTime;

                Destroy(collision.gameObject);          // Destroy object
                StartCoroutine(BoarPowerActivated());   // Start coroutine to hold player's movement by one second
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            hasflyingPower = false;
            jumpCountOnA = 0;
        }

    }


    // Start of the coroutine, delay of one second is placed per boar smash
    // This could also hold the animation and switching of sprites
    IEnumerator BoarPowerActivated()
    {
        yield return new WaitForSeconds(1);
        power_activated = false;
        character_movement = true;
    }

    //---------------------------------------------
    // Flying starts
    //---------------------------------------------

    void FlyingMovement()
    {
        if (!hasflyingPower)
        {
            flyingStamina += 0.003f;
        }

        if (Input.GetButtonDown("ButtonA") && jumpCountOnA <= 2)
        {
            jumpCountOnA++;

            if (jumpCountOnA == 2)
            {
                hasflyingPower = true;
            }

            playerRigidbody.velocity = Vector2.up * 250 * Time.deltaTime;
        }

        if (hasflyingPower && flyingStamina > 0)
        {
            flyingStamina -= 0.001f;

            if (Input.GetButton("ButtonA"))
            {
                playerRigidbody.gravityScale = 0.3f;
                playerRigidbody.drag = 0.7f;
                playerRigidbody.velocity = Vector2.up * flyingVelocity;
                flyingStamina -= 0.003f;
            }

        }
        flyingStamina = (flyingStamina < 0) ? 0 : flyingStamina;
        flyingStamina = (flyingStamina > .25f) ? .25f : flyingStamina;
    }
}
