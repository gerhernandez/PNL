using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_AnimationControl : MonoBehaviour {
    public Animator control;
    public SpriteRenderer drawn;

    public static int hair;

	void Start () {
        control = GetComponent<Animator>();
        drawn = GetComponent<SpriteRenderer>();

        /* TODO: Debug hair choice: 0 -> short, 1 -> medium, 2 -> long*/
        hair = 2;

        // For chainging hair
        // All other animations for player body should ignore this
        if (hair == control.GetLayerIndex("MediumHair_Layer"))
        {
            // overwrite base layer (short hair) and set MediumHair as main layer
            control.SetLayerWeight(1, 1);
        }
        else if (hair == control.GetLayerIndex("LongHair_Layer"))
        {
            // overwrite base layer (short hair) and set LongHair as main layer
            control.SetLayerWeight(2, 1);
        }
	}
    
    void Update()
    {
        ///* TODO: Controls with keyboard
        // if walking with keyboard
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            control.SetBool("isWalking", true);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            control.SetBool("isWalking", false);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            drawn.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            drawn.flipX = false;
        }
        //*/

        /*
        // if walking with xbox controller, play walk animation
        if (Mathf.Abs(Input.GetAxis("HorizontalX")) > 0)
        {
            control.SetBool("isWalking", true);
        }
        else if (Input.GetAxis("HorizontalX") == 0)
        {
            control.SetBool("isWalking", false);
        }

        if (Input.GetAxis("HorizontalX") < 0)
        {
            drawn.flipX = true;
        }
        else if (Input.GetAxis("HorizontalX") > 0)
        {
            drawn.flipX = false;
        }
        */

        // for jump animation
        if (Move.grounded == false)
        {
            control.SetBool("jumpStart", true);
        }
        else if (Move.grounded == true)
        {
            control.SetBool("jumpStart", false);
            control.SetBool("jumpEnd", true);
            StartCoroutine("Wait");
        }
    }

    // wait for jump to finish
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        control.SetBool("jumpEnd", false);
    }
}
