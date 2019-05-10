using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Move moveScript;
    private const string NPC_TAG = "NPC";
    private const string TrigDialogue_TAG = "TrigDialogue";
    private List<string> npcsTalkedTo;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        moveScript = GetComponent<Move>();
        npcsTalkedTo = new List<string>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == NPC_TAG)
        {
            moveScript.InInteractionZone(true);
        }
        if (collision.gameObject.tag == TrigDialogue_TAG)
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
                Debug.Log("Button Pressed!");
                Flowchart.BroadcastFungusMessage(messageToBeBroadcasted);

                if (!npcsTalkedTo.Contains(messageToBeBroadcasted))
                {
                    npcsTalkedTo.Add(messageToBeBroadcasted);
                }

                if(npcsTalkedTo.Count >= 3)
                {
                    Destroy(GameObject.Find("BlockPath"));
                }
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

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if(collision.gameObject.name == "BlockPath")
        {
            Flowchart.BroadcastFungusMessage("BlockPath");
        }
    }
}
