using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TempPlayerController : MonoBehaviour {

    private Rigidbody2D rb;             // To hold the player's rigid body
    private const string NPC = "NPC";   // To hold a constant for the tag of the NPCs
    private const string TrigDialogue = "TrigDialogue"; //// To hold a constant for the tag of the Dialogue Triggers
    private bool movement_state;        // To hold a boolean value for player's movement

    public float jump;                  // To hold the value in which will be multiplied for jumping physics, used with Rigidbody2D

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();   // Set the objects Rigidbody2D component and initialize it to rb
        movement_state = true;              // Set the movement value to start at true
    }
	
	// Update is called once per frame
	void Update () {
        // if movement_state is true, allow movement, otherwise, no movement is allowed
        if (GetMovementState())
        {
            PlayerMovement();   // Function that allows player to move in game
        }
        
	}

    /// <summary>
    /// OnTriggerStay2D method, Used to detect when player is close to something
    /// 1. If collision has tag of NPC, do the following:
    ///   - Declare and initialize a string variable called "message" by the objects name.
    ///   - If the spacebar is pressed, and movement_state currently equals to true, do the following:
    ///     ---> Call the function "ChangeMovementState()," which changes it from true to false.
    ///     ---> Broadcast the message to all flowcharts. The flowchart that has the same message is able to receive it and start up
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 1.
        if(collision.gameObject.tag == NPC)
        {
            string message = "NPC_" + collision.gameObject.name;

            if (Input.GetKeyDown(KeyCode.Space) && movement_state)
            {
                ChangeMovementState();
                Flowchart.BroadcastFungusMessage(message);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Found a trigger zone " + collision.gameObject.tag);
        // 1.
        if(collision.gameObject.tag == TrigDialogue)
        {
            string message = collision.gameObject.name;

            ChangeMovementState();
            Flowchart.BroadcastFungusMessage(message);
            Destroy(collision.gameObject);
        }
    }

    void PlayerMovement()
    {
        // basic player movement
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - .1f, transform.position.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + .1f, transform.position.y);
        }

        // basic jump movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.velocity = Vector2.up * jump;
        }
    }

    /// <summary>
    /// ChangeMovementState method: Inverses the boolean value of movement_state
    /// </summary>
    void ChangeMovementState()
    {
        movement_state = !movement_state;
    }

    /// <summary>
    /// GetMovementState method: Retrieves the boolean value movement_state
    /// </summary>
    /// <returns></returns>
    bool GetMovementState()
    {
        return movement_state;
    }

}
