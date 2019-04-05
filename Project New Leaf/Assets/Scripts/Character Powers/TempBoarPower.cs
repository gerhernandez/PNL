using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBoarPower : MonoBehaviour
{

    // This variable not needed in this script, supposed to be in player movement script
    public float speed = 10.0f;         // Speed of player movement, ********* This does not have to be in this script ******

    private bool power_activated;       // To hold a bool value when a power is activated ******* can and probably should be changed to boarPowerActivated *****
    private bool character_movement;    // To hold a bool value to make movement active or inactive ********* This does not have to be in this script ******

    private void Start()
    {
        character_movement = true;      // Set character movement to true, ********* This does not have to be in this script ******
        power_activated = false;        // Set power activated to false, no powers are active at the start of the game
    }

    /// <summary>
    /// PLAYERS MOVEMENT HAS TO BE IN FIXEDUPDATE!
    /// </summary>
    private void FixedUpdate()
    {
        // if a power is activated, stop player's movement through control pad
        if (!power_activated)
            PlayerMovement();
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
                GetComponent<Rigidbody2D>().velocity = Vector2.left * 50 * Time.deltaTime;

                Destroy(collision.gameObject);          // Destroy object
                StartCoroutine(BoarPowerActivated());   // Start coroutine to hold player's movement by one second
            }
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

    // *************** Method not needed in this script *******************
    // PlayerMovement method: "HorizontalX" can be found under Edit -> Project Settings -> Input -> HorizontalX
    void PlayerMovement()
    {
        float translation = Input.GetAxis("HorizontalX") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetButtonDown("ButtonA"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 1000 * Time.deltaTime;
        }
    }
}
