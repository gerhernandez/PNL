using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTrigger : MonoBehaviour {
    public LoadScene load;

	// Use this for initialization
	void Start () {
        load = GetComponent<LoadScene>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player detected!");
            load.loadScene = true;
        }
    }
}
