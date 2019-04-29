using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {
    public Player p;
    public Move m;
    public Animator control;
    public SpriteRenderer drawn;
    public Powers pow;
    public wolfPower wPow;

    public bool playBoar;
    public bool playHawk;
    public bool playViper;
    public bool playWolf;

    private int hair;
    void Start()
    {
        p = FindObjectOfType<Player>();
        m = p.GetComponent<Move>();

        pow = p.GetComponent<Powers>();

        control = GetComponent<Animator>();
        drawn = GetComponent<SpriteRenderer>();

        // For changing hair
        switch (PlayerSelectedAttributes.PlaySelectedPronounInt)
        {
            case 1: // pronoun: he/his
                if (PlayerSelectedAttributes.PlaySelectedHairPos == 0)
                { hair = 0; }
                else if ((PlayerSelectedAttributes.PlaySelectedHairPos > 0 && PlayerSelectedAttributes.PlaySelectedHairPos <= 10) && PlayerSelectedAttributes.PlaySelectedPronounInt == 1)
                { hair = 1; }
                else if (PlayerSelectedAttributes.PlaySelectedHairPos > 10 && PlayerSelectedAttributes.PlaySelectedHairPos <= 15)
                { hair = 2; }
                else if (PlayerSelectedAttributes.PlaySelectedHairPos > 15 && PlayerSelectedAttributes.PlaySelectedHairPos <= 18)
                { hair = 3; }
                else
                { hair = 3; }
                break;
            case 2: // pronoun: she/hers
            case 3: // pronoun: they/theirs
                if (PlayerSelectedAttributes.PlaySelectedHairPos == 0)
                { hair = 0; }
                else if ((PlayerSelectedAttributes.PlaySelectedHairPos > 0 && PlayerSelectedAttributes.PlaySelectedHairPos <= 8) && PlayerSelectedAttributes.PlaySelectedPronounInt == 1)
                { hair = 1; }
                else if (PlayerSelectedAttributes.PlaySelectedHairPos > 8 && PlayerSelectedAttributes.PlaySelectedHairPos <= 14)
                { hair = 2; }
                else if (PlayerSelectedAttributes.PlaySelectedHairPos > 14 && PlayerSelectedAttributes.PlaySelectedHairPos <= 17)
                { hair = 3; }
                else
                { hair = 3; }
                break;
            default:
                hair = 0;
                break;
        }

        // Overwrite base layer (bald) and set animated hairstyle
        // All other animations for player body should ignore this
        if (control.name == "PlayerHair")
        {
            if (hair == control.GetLayerIndex("ShortHair_Layer"))
            { control.SetLayerWeight(control.GetLayerIndex("ShortHair_Layer"), 1); }
            if (hair == control.GetLayerIndex("MediumHair_Layer"))
            { control.SetLayerWeight(control.GetLayerIndex("MediumHair_Layer"), 1); }
            else if (hair == control.GetLayerIndex("LongHair_Layer"))
            { control.SetLayerWeight(control.GetLayerIndex("LongHair_Layer"), 1); }
        }
    }

    void Update()
    {
        // for pointing right or left
        if (Input.GetAxis("HorizontalX") < -0.25)
        { drawn.flipX = true; }
        else if (Input.GetAxis("HorizontalX") > 0.25)
        { drawn.flipX = false; }

        switch (control.name)
        {
            // if walking with xbox controller, play walk animation w/ human state
            case "PlayerHair":
            case "PlayerLineart":
            case "PlayerSkin":
            case "PlayerShirt":
            case "PlayerPants":
                // for walking animation
                if (Mathf.Abs(Input.GetAxis("HorizontalX")) > 0.25)
                { control.SetBool("isWalking", true); }
                else if (Input.GetAxis("HorizontalX") > -0.25 && Input.GetAxis("HorizontalX") < 0.25)
                { control.SetBool("isWalking", false); }
                
                // for jump animation
                if (Move.grounded == false)
                { control.SetBool("jumpStart", true); }
                else if (Move.grounded == true)
                {
                    control.SetBool("jumpStart", false);
                    control.SetBool("jumpEnd", true);
                    StartCoroutine("Wait");
                }

                // set powers animation activated
                if (pow.IsCharging() || pow.IsPlayerFlying() || pow.IsViperCrawling())  // power is active
                {
                    Debug.Log("activate powers");
                    control.SetBool("powerActivated", true);
                }
                else
                {
                    control.SetBool("powerActivated", false);
                }
                break;
            // Powers animation playing
            case "Powers":
                // for power animations
                if (Powers.hasBoarPower)
                {
                    //if (Input.GetButtonDown("ButtonB"))
                    if (pow.IsCharging())
                    { control.SetBool("boarActivated", true); }
                    else
                    { control.SetBool("boarActivated", false); }
                }
                if (Powers.hasFlyingPower)
                {
                    if (pow.IsPlayerFlying() && !Move.grounded)
                    { control.SetBool("hawkActivated", true); }/*
                    else if (pow.) // player is not grounded and hawk is still activated
                    { control.SetBool("hawkGliding", true); }
                    else if ()
                    {
                        control.SetBool("hawkGliding", false);
                    }*/
                }
                if (Powers.hasSnakePower)
                {
                    if (Input.GetButton("ButtonY") && pow.IsViperCrawling())
                    { control.SetBool("viperActivated", true); }
                    else
                    { control.SetBool("viperActivated", false); }
                }
                if (Powers.hasWolfPower)
                {
                    if (Input.GetButtonDown("ButtonX"))
                    { control.SetBool("wolfActivated", true); }
                    else
                    { control.SetBool("wolfActivated", false); }
                }

                // set powers animation inactive
                if (!(pow.IsCharging() || pow.IsPlayerFlying() || pow.IsViperCrawling()))  // is active
                {
                    Debug.Log("deactivate powers");
                    control.SetBool("powerActivated", false);
                }
                else
                {
                    control.SetBool("powerActivated", true);
                }
                break;
        }
    }

    // wait for jump to finish
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        control.SetBool("jumpEnd", false);
    }

    // functions for animations
    /* TODO: cloud animation for transitioning? */ 
    IEnumerator WaitForBoar()
    {
        yield return new WaitForSeconds(3f);
    }

    IEnumerator WaitForHawk(bool grounded)
    {
        yield return new WaitForSeconds(2f);
    }

    IEnumerator WaitForViper()
    {
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator WaitForWolf()
    {
        yield return new WaitForSeconds(2f);
    }
}
