﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {
    //public Player p;
    /* TODO: used for testing animations of the powers */
    public Test_PowersActivated tp;

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
        //p = FindObjectOfType<Player>();

        /* TODO: test "player" for playing animations*/
        tp = FindObjectOfType<Test_PowersActivated>();

        //m = p.GetComponent<Move>();
        /* move gets from tp instead of p */
        m = tp.GetComponent<Move>();

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

        // for power animations
        if (tp.boarEnabled)
        {
            if (Input.GetButton("ButtonX"))
            {
                control.SetBool("boarActivated", true);
            }
            else
            {
                control.SetBool("boarActivated", false);
            }
        }
        if (tp.hawkEnabled)
        {
            if (Input.GetButton("ButtonA"))
            {
                control.SetBool("hawkActivated", true);
            }
            else
            {
                control.SetBool("hawkActivated", false);
            }
        }
        if (tp.viperEnabled)
        {
            if (Input.GetButton("ButtonB"))
            {
                control.SetBool("viperActivated", true);
            }
            else
            {
                control.SetBool("viperActivated", false);
            }
        }
        if (tp.wolfEnabled)
        {
            if (Input.GetButton("ButtonY"))
            {
                control.SetBool("wolfActivated", true);
            }
            else
            {
                control.SetBool("wolfActivated", false);
            }
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
