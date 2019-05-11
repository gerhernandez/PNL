using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl_Paramour : MonoBehaviour
{
    public Paramour para;
    public Player play;

    public Animator control;
    public SpriteRenderer drawn;
    public LayerMask groundLayer;

    private Vector2 position;
    private Vector2 direction;
    
    private float distance;
    private int hair;
    private bool paraGrounded;

    void Start()
    {
        para = FindObjectOfType<Paramour>();
        play = FindObjectOfType<Player>();
        control = GetComponent<Animator>();
        drawn = GetComponent<SpriteRenderer>();

        Debug.Log("Paramour control name: " + control.name);

        // For changing hair
        switch (ParamourSelectedAttributes.LoveSelectedPronounInt)
        {
            case 1: // pronoun: he/his
                if (ParamourSelectedAttributes.LoveSelectedHairPos == 0)
                { hair = 0; }
                else if ((ParamourSelectedAttributes.LoveSelectedHairPos > 0 && ParamourSelectedAttributes.LoveSelectedHairPos <= 10) && ParamourSelectedAttributes.LoveSelectedPronounInt == 1)
                { hair = 1; }
                else if (ParamourSelectedAttributes.LoveSelectedHairPos > 10 && ParamourSelectedAttributes.LoveSelectedHairPos <= 15)
                { hair = 2; }
                else if (ParamourSelectedAttributes.LoveSelectedHairPos > 15 && ParamourSelectedAttributes.LoveSelectedHairPos <= 18)
                { hair = 3; }
                else
                { hair = 3; }
                break;
            case 2: // pronoun: she/hers
            case 3: // pronoun: they/theirs
                if (ParamourSelectedAttributes.LoveSelectedHairPos == 0)
                { hair = 0; }
                else if ((ParamourSelectedAttributes.LoveSelectedHairPos > 0 && ParamourSelectedAttributes.LoveSelectedHairPos <= 8) && ParamourSelectedAttributes.LoveSelectedPronounInt == 1)
                { hair = 1; }
                else if (ParamourSelectedAttributes.LoveSelectedHairPos > 8 && ParamourSelectedAttributes.LoveSelectedHairPos <= 14)
                { hair = 2; }
                else if (ParamourSelectedAttributes.LoveSelectedHairPos > 14 && ParamourSelectedAttributes.LoveSelectedHairPos <= 17)
                { hair = 3; }
                else
                { hair = 3; }
                break;
            default:
                hair = 1;
                break;
        }

        // Overwrite base layer (bald) and set animated hairstyle
        // All other animations for player body should ignore this
        if (control.name == "ParamourHair")
        {
            if (hair == control.GetLayerIndex("ShortHair_Layer"))
            { control.SetLayerWeight(control.GetLayerIndex("ShortHair_Layer"), 1); }
            else if (hair == control.GetLayerIndex("MediumHair_Layer"))
            { control.SetLayerWeight(control.GetLayerIndex("MediumHair_Layer"), 1); }
            else if (hair == control.GetLayerIndex("LongHair_Layer"))
            { control.SetLayerWeight(control.GetLayerIndex("LongHair_Layer"), 1); }
        }
    }

    void Update()
    {
        // if player in dialogue scene, set Player back to Idle and do nothing else
        if (!para.playerIsMoving)
        {
            // set any state back to Idle
            if (control.GetBool("isWalking")) control.SetBool("isWalking", false);
            if (control.GetBool("jumpEnd")) StartCoroutine("EndJump");
            if (control.GetBool("jumpStart"))
            {
                control.SetBool("jumpStart", false);
                control.SetBool("jumpEnd", true);
                StartCoroutine("EndJump");
            }

            return;
        }

        Debug.Log("play forward: " + play.transform.forward);

        // for pointing right or left
        /** TODO: change based on Player's movement */
        if (play.transform)
        { drawn.flipX = true; }
        else if (Input.GetAxis("HorizontalX") > 0.25)
        { drawn.flipX = false; }

        // for walking animation
        //if (Mathf.Abs(Input.GetAxis("HorizontalX")) > 0.25)
        //{ control.SetBool("isWalking", true); }
        //else if (Input.GetAxis("HorizontalX") > -0.25 && Input.GetAxis("HorizontalX") < 0.25)
        //{ control.SetBool("isWalking", false); }

        // for jump animation
        if (paraGrounded == false)
        { control.SetBool("jumpStart", true); }
        else if (paraGrounded == true)
        {
            control.SetBool("jumpStart", false);
            control.SetBool("jumpEnd", true);
            StartCoroutine("EndJump");
        }
    }

    void FixedUpdate()
    {
        CheckIfParamourIsGrounded();
    }

    // wait for jump to finish
    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(0.3f);
        control.SetBool("jumpEnd", false);
    }

    public void CheckIfParamourIsGrounded()
    {

        position = transform.position;
        direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        if (hit.collider != null)
        {
            paraGrounded = true;
        }
        else
        {
            paraGrounded = false;
        }
    }
}
