using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl_Paramour : MonoBehaviour
{
    public Paramour para;
    public Player play;

    public Animator control;
    public SpriteRenderer drawn;

    [SerializeField]
    private int hair;
    private int lastHair;
    private bool hairChanged;

    void Start()
    {
        para = FindObjectOfType<Paramour>();
        play = FindObjectOfType<Player>();
        control = GetComponent<Animator>();
        drawn = GetComponent<SpriteRenderer>();

        // For changing hair
        Debug.Log("Paramour PRONOUN: " + ParamourSelectedAttributes.LoveSelectedPronounInt);
        switch (ParamourSelectedAttributes.LoveSelectedBodyType)
        {
            case 1: // BodyType: he/his
                Debug.Log("PARAMOUR HAIR: " + ParamourSelectedAttributes.LoveSelectedHairPos);
                if (ParamourSelectedAttributes.LoveSelectedHairPos == 0)
                { hair = 0; }
                else if (ParamourSelectedAttributes.LoveSelectedHairPos > 0 && ParamourSelectedAttributes.LoveSelectedHairPos <= 10)
                { hair = 1; }
                else if (ParamourSelectedAttributes.LoveSelectedHairPos > 10 && ParamourSelectedAttributes.LoveSelectedHairPos <= 15)
                { hair = 2; }
                else if (ParamourSelectedAttributes.LoveSelectedHairPos > 15 && ParamourSelectedAttributes.LoveSelectedHairPos <= 18)
                { hair = 3; }
                else
                { hair = 3; }
                break;
            case 2: // BodyType: she/hers
            case 3: // BodyType: they/theirs
                Debug.Log("PARAMOUR HAIR: " + ParamourSelectedAttributes.LoveSelectedHairPos);
                if (ParamourSelectedAttributes.LoveSelectedHairPos == 0)
                { hair = 0; }
                else if (ParamourSelectedAttributes.LoveSelectedHairPos > 0 && ParamourSelectedAttributes.LoveSelectedHairPos <= 8)
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

        ChangeHair();
        lastHair = hair;
    }

    void Update()
    {
        // for changing hair during runtime
        if (lastHair != hair)
        {
            ChangeHair();
            lastHair = hair;
        }

        // for pointing right or left
        if (para.facingRight)
        { drawn.flipX = false; }
        else if (!para.facingRight)
        { drawn.flipX = true; }

        // for walking animation
        if (para.isWalking)
        { control.SetBool("isWalking", true); }
        else if (!para.isWalking)
        { control.SetBool("isWalking", false); }

        // for jump animation
        if (para.paraGrounded == false)
        { control.SetBool("jumpStart", true); }
        else if (para.paraGrounded == true)
        {
            control.SetBool("jumpStart", false);
            control.SetBool("jumpEnd", true);
            StartCoroutine("EndJump");
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
        if (control.name == "ParamourHair")
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
