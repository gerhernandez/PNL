using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTrigger : MonoBehaviour {
    public LoadScene load;

    private bool loadZoneEntered = false;

	// Use this for initialization
	void Start () {
        load = GetComponent<LoadScene>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !loadZoneEntered)
        {
            Debug.Log("Player detected!");
            StartCoroutine(load.LoadAsyncScene());
            loadZoneEntered = true;
        }
    }
}
