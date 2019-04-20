using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TempCheckPointScript : MonoBehaviour {

    private Transform playerPosition;
    private Vector2 currentCheckPoint;
    private const string FADE_SCREEN = "Fade";

	// Use this for initialization
	void Start () {
        playerPosition = transform;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CheckPoint")
        {
            Debug.Log("Triggered with " + collision.gameObject.name);
            currentCheckPoint = new Vector2(playerPosition.position.x, playerPosition.position.y);
        }
    }

    public void FadeScreen()
    {
        Flowchart.BroadcastFungusMessage(FADE_SCREEN);
    }

    public void MovePlayerToCurrentCheckPoint()
    {
        playerPosition.position = currentCheckPoint;
    }
    
}
