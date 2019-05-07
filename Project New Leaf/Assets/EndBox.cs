using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision entered!");

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player entering!");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("collision stay!");

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player staying!");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("collision exit!");

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exited!");
        }
    }
}
