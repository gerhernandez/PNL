using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerInteraction : MonoBehaviour {

    private Rigidbody playerRidigbody;
    private Move moveScript;
    private const string NPC_TAG = "NPC";
    private const string TrigDialogue_TAG = "TrigDialogue";
    
    void Start () {
        playerRidigbody = GetComponent<Rigidbody>();
        moveScript = GetComponent<Move>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == NPC_TAG)
        {
            moveScript.InInteractionZone(true);
        }
        if(collision.gameObject.tag == TrigDialogue_TAG)
        {
            string messageToBeBroadcasted = "" + collision.gameObject.name;
            Flowchart.BroadcastFungusMessage(messageToBeBroadcasted);
            moveScript.InInteractionZone(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == NPC_TAG)
        {
            string messageToBeBroadcasted = "" + collision.gameObject.name;

            if (Input.GetButtonDown("ButtonA") && moveScript.GetIsPlayerInteracting())
            {
                Flowchart.BroadcastFungusMessage(messageToBeBroadcasted);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == NPC_TAG)
        {
            moveScript.InInteractionZone(false);
        }
        if (collision.gameObject.tag == TrigDialogue_TAG)
        {
            moveScript.InInteractionZone(false);
            Destroy(collision.gameObject);
        }
    }
}
