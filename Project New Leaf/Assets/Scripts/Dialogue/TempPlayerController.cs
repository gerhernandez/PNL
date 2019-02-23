using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerController : MonoBehaviour {

    Rigidbody rb;

    public float jump;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (class.!InDialogue())
        //{
        //    PlayerMovement();
        //}
        
	}
    
    void PlayerMovement()
    {
        // basic player movement
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
        }

        // basic jump movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.GetComponent<Rigidbody>().velocity = Vector2.up * jump * Time.deltaTime;
        }
    }
}
