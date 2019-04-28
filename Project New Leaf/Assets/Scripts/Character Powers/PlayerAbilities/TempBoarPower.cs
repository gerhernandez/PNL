using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBoarPower : MonoBehaviour
{
    // variables of Player
    public Collider2D playerCollider;

    // boar variables
    private Rigidbody2D playerRigidBody;
    private bool power_activated;       // To hold a bool value when a power is activated ******* can and probably should be changed to boarPowerActivated *****
    private bool character_movement;    // To hold a bool value to make movement active or inactive ********* This does not have to be in this script ******

    // Flying variables
    public bool flying_activated;
    public int aButtonCount;
    public float flyingStamina;
    public float flyingVelocity;

    private TempCheckPointScript checkPoint;

    
    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        checkPoint = GetComponent<TempCheckPointScript>();
        character_movement = true;      // Set character movement to true, ********* This does not have to be in this script ******
        power_activated = false;        // Set power activated to false, no powers are active at the start of the game
        flying_activated = false;
        aButtonCount = 0;
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
            //transform.localScale = new Vector3(.75f, .75f, 1);

        }
        if (Input.GetButtonUp("ButtonY"))
        {
            //transform.localScale = new Vector3(.75f, 1.5f, 1);
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
                playerRigidBody.velocity = Vector2.left * 100 * Time.deltaTime;

                Destroy(collision.gameObject);          // Destroy object
                StartCoroutine(BoarPowerActivated());   // Start coroutine to hold player's movement by one second
            }
        }

        if(collision.gameObject.tag == "Ground")
        {
            flying_activated = false;
            aButtonCount = 0;
        }

        //************************** TAG NEEDS TO BE CHANGED ************************
        // ENEMY IS TEMP, CHANGE TO LAVA TAG OR SOMETHING ELSE
        // **************************************************************************
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player takes a point of damage");
            character_movement = false;
            StartCoroutine(PlayerDeathFadeScreen());
        }
    }

    IEnumerator PlayerDeathFadeScreen()
    {
        checkPoint.FadeScreen();
        yield return new WaitForSeconds(3);
        //checkPoint.MovePlayerToCurrentCheckPoint();
        character_movement = true;
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
        if (!flying_activated)
        {
            flyingStamina += 0.003f;
        }

        if (Input.GetButtonDown("ButtonA") && aButtonCount <= 2)
        {
            aButtonCount++;

            if (aButtonCount == 2)
            {
                flying_activated = true;
            }

            playerRigidBody.velocity = Vector2.up * 250 * Time.deltaTime;
        }

        if (flying_activated && flyingStamina > 0)
        {
            flyingStamina -= 0.001f;

            if (Input.GetButton("ButtonA"))
            {
                playerRigidBody.gravityScale = 0.3f;
                playerRigidBody.drag = 0.7f;
                playerRigidBody.velocity = Vector2.up * flyingVelocity;
                flyingStamina -= 0.003f;
            }
            
        }
        flyingStamina = (flyingStamina < 0) ? 0 : flyingStamina;
        flyingStamina = (flyingStamina > .25f) ? .25f : flyingStamina;
    }

    //******************************** REQUIREMENT FOR FLIGHT **************************************
    // When player is grounded, set flightActivated to false, this way the flight stamina increases
    // *********************************************************************************************
}
