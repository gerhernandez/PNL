using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {
    public Player p;
    public Move m;
    public HealthManager h;

    public Animator control;
    public SpriteRenderer drawn;
    public Powers pow;

    public bool playBoar;
    public bool playHawk;
    public bool playViper;
    public bool playWolf;

    public bool wasFlying;

    [SerializeField]
    private int hair;
    private int lastHair;
    private bool hairChanged;

    void Start()
    {
        p = FindObjectOfType<Player>();
        m = p.GetComponent<Move>();

        h = GameObject.Find("Manager").GetComponentInChildren<HealthManager>();

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
                { hair = 1; }
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
                hair = 1;
                break;
        }

        ChangeHair();
        lastHair = hair;
    }

    void Update()
    {
        Debug.Log("Boar charging: " + pow.IsCharging());
        // for changing hair during runtime
        if (lastHair != hair)
        {
            ChangeHair();
            lastHair = hair;
        }

        // if player in dialogue scene, set Player back to Idle and do nothing else
        if (m.GetIsPlayerInteracting())
        {
            Debug.Log("entered is interacting");
            // set any state back to Idle
            if (control.GetBool("isWalking")) control.SetBool("isWalking", false);
            if (control.GetBool("jumpEnd"))   StartCoroutine("EndJump");
            if (control.GetBool("jumpStart"))
            {
                control.SetBool("jumpStart", false);
                control.SetBool("jumpEnd", true);
                StartCoroutine("EndJump");
            }

            if (control.name == "Powers")
            {
                if (control.GetBool("boarActivated") || control.GetBool("hawkActivated") || control.GetBool("viperActivated") || control.GetBool("wolfActivated"))
                { foreach (AnimatorControllerParameter param in control.parameters) { control.SetBool(param.name, false); } }
            }
            if (control.GetBool("powerActivated")) control.SetBool("powerActivated", false);

            return;
        }

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
                    StartCoroutine("EndJump");
                }

                // set powers animation activated
                if (pow.IsCharging() || pow.IsPlayerFlying() || pow.IsViperCrawling() || pow.IsWolfDashing())  // power is active
                { control.SetBool("powerActivated", true); }
                else
                { control.SetBool("powerActivated", false); }
                break;
            // Powers animation playing
            case "Powers":
                
                // for boar animation
                if (Powers.hasBoarPower && pow.IsCharging())
                {
                    control.SetBool("boarActivated", true);
                    //StartCoroutine("PlayBoarCharge");
                } else { control.SetBool("boarActivated", false); }

                // for hawk animation
                if (Powers.hasFlyingPower && pow.IsPlayerFlying())
                { control.SetBool("hawkActivated", true); }
                else { control.SetBool("hawkActivated", false); }

                // for viper animation
                if (Powers.hasSnakePower && pow.IsViperCrawling())
                { control.SetBool("viperActivated", true); }
                else { control.SetBool("viperActivated", false); }
                
                // for wolf animation
                if (Powers.hasWolfPower && pow.IsWolfDashing())
                { control.SetBool("wolfActivated", true); }
                else  { control.SetBool("wolfActivated", false); }

                // set powers animation inactive
                if (!(pow.IsCharging() || pow.IsPlayerFlying() || pow.IsViperCrawling() || pow.IsWolfDashing()))  // is active
                { control.SetBool("powerActivated", false); }
                else
                { control.SetBool("powerActivated", true); }
                break;
        }
    }

    // wait for jump to finish
    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(0.3f);
        control.SetBool("jumpEnd", false);
    }

    // change hair
    void ChangeHair()
    {
        // Overwrite base layer (bald) and set animated hairstyle
        // All other animations for player body should ignore this
        if (control.name == "PlayerHair")
        {
            if (hair == 0)
            {   // if bald, set all other layers to 0
                for (int i = 1; i < control.layerCount; i++)
                { control.SetLayerWeight(i, 0); }
            }
            else if (hair == control.GetLayerIndex("ShortHair_Layer"))
            {   // set short hair visible
                control.SetLayerWeight(control.GetLayerIndex("ShortHair_Layer"), 1);
                // set others transparent
                control.SetLayerWeight(control.GetLayerIndex("MediumHair_Layer"), 0);
                control.SetLayerWeight(control.GetLayerIndex("LongHair_Layer"), 0);
            }
            else if (hair == control.GetLayerIndex("MediumHair_Layer"))
            {   // set medium hair visible
                control.SetLayerWeight(control.GetLayerIndex("MediumHair_Layer"), 1);
                // set others transparent
                control.SetLayerWeight(control.GetLayerIndex("ShortHair_Layer"), 0);
                control.SetLayerWeight(control.GetLayerIndex("LongHair_Layer"), 0);
            }
            else if (hair == control.GetLayerIndex("LongHair_Layer"))
            {   // set long hair visible
                control.SetLayerWeight(control.GetLayerIndex("LongHair_Layer"), 1);
                // set others transparent
                control.SetLayerWeight(control.GetLayerIndex("ShortHair_Layer"), 0);
                control.SetLayerWeight(control.GetLayerIndex("MediumHair_Layer"), 0);
            }
        }
    }
}
