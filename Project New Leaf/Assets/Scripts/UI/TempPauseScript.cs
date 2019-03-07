using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPauseScript : MonoBehaviour {
    
    // This variable not needed in this script, supposed to be in player movement script
    public float speed = 10.0f;         // Speed of player movement

    public GameObject pauseCanvas;      // To hold the canvas game object for the pause menu

	// Update is called once per frame
	void Update () {
        Debug.Log(Time.timeScale);

        


        // as long as canvas is inactive, and player preses the pause button.
        if (Input.GetButtonDown("Pause") && !pauseCanvas.activeSelf)
        {
            // enable canvas
            pauseCanvas.SetActive(true);

            // pause game
            Time.timeScale = 0f;
        }
	}

    /// <summary>
    /// PLAYERS MOVEMENT HAS TO BE IN FIXEDUPDATE!
    /// </summary>
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    // PlayerMovement method: "HorizontalX" can be found under Edit -> Project Settings -> Input -> HorizontalX
    void PlayerMovement()
    {
        float translation = Input.GetAxis("HorizontalX") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        Debug.Log("Current Translation: " + translation);
    }
}
