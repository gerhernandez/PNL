using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {
    public Player p;
    public Move m;
    public Animator control;
    public SpriteRenderer drawn;

    public static int hair;

    public bool playBoar;
    public bool playHawk;
    public bool playViper;
    public bool playWolf;

    void Start()
    {
        p = FindObjectOfType<Player>();
        m = p.GetComponent<Move>();
        control = GetComponent<Animator>();
        drawn = GetComponent<SpriteRenderer>();

        // hair choice: 0 -> short, 1 -> medium, 2 -> long
        hair = 0;

        // For changing hair
        // All other animations for player body should ignore this
        if (hair == control.GetLayerIndex("MediumHair_Layer"))
        {   // overwrite base layer (short hair) and set MediumHair as main layer
            control.SetLayerWeight(1, 1);
        }
        else if (hair == control.GetLayerIndex("LongHair_Layer"))
        {   // overwrite base layer (short hair) and set LongHair as main layer
            control.SetLayerWeight(2, 1);
        }
    }

    void Update()
    {
        // if walking with xbox controller, play walk animation
        if (Mathf.Abs(Input.GetAxis("HorizontalX")) > 0.25)
        {
            control.SetBool("isWalking", true);
        }
        else if (Input.GetAxis("HorizontalX") > -0.25 && Input.GetAxis("HorizontalX") < 0.25)
        {
            control.SetBool("isWalking", false);
        }

        if (Input.GetAxis("HorizontalX") < -0.25)
        {
            drawn.flipX = true;
        }
        else if (Input.GetAxis("HorizontalX") > 0.25)
        {
            drawn.flipX = false;
        }

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

    // functions for animations
    // TODO: cloud animation for transitioning?

}
