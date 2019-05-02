using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColors_Paramour : MonoBehaviour
{
    // reference to the Paramour and the Paramour script
    public Paramour pa;
    public GameObject paramourSprite;

    // the GameObjects attached to the Paramour
    public GameObject hair;
    public GameObject skin;
    public GameObject shirt;
    public GameObject pants;

    // sprite renderers of above GameObjects
    public SpriteRenderer hairSR;
    public SpriteRenderer skinSR;
    public SpriteRenderer shirtSR;
    public SpriteRenderer pantsSR;

    /* TODO: can be used with Dialogue/Fungus for setting lighting color; on backburner for now
    public bool isTwilight;
    public bool isNight;
    public bool isDay;
    */

    // Use this for initialization
    void Start()
    {
        pa = FindObjectOfType<Paramour>();

        // Find the name GameObject
        //paramourSprite = GameObject.Find("Player(Clone)");
        paramourSprite = GameObject.FindWithTag("Paramour");

        // Find the GameObjects and SpriteRenderers under the Player
        // using this method of finding GameObjects b/c GameObject.Find was returning Preview Scene objects (bug)
        hair = paramourSprite.transform.Find("ParamourHair").gameObject;
        skin = paramourSprite.transform.Find("ParamourSkin").gameObject;
        shirt = paramourSprite.transform.Find("ParamourShirt").gameObject;
        pants = paramourSprite.transform.Find("ParamourPants").gameObject;

        hairSR = hair.GetComponent<SpriteRenderer>();
        skinSR = skin.GetComponent<SpriteRenderer>();
        shirtSR = shirt.GetComponent<SpriteRenderer>();
        pantsSR = pants.GetComponent<SpriteRenderer>();

        /**/
        //  TODO: Debug stuff for when ParamourSelectAttributes not set yet
        ParamourSelectedAttributes.LoveSelectedHairColor = Color.blue;
        ParamourSelectedAttributes.LoveSelectedSkinColor = Color.white;
        ParamourSelectedAttributes.LoveSelectedShirtColor = Color.cyan;
        ParamourSelectedAttributes.LoveSelectedPantsColor = Color.black;
        /**/

        /* TODO: uncomment when done animating powers */
        // set hair color
        if (ParamourSelectedAttributes.LoveSelectedHairColor != null)
        { hairSR.color = ParamourSelectedAttributes.LoveSelectedHairColor; }
        // set skin color
        if (ParamourSelectedAttributes.LoveSelectedSkinColor != null)
        { skinSR.color = ParamourSelectedAttributes.LoveSelectedSkinColor; }
        // set shirt color
        if (ParamourSelectedAttributes.LoveSelectedShirtColor != null)
        { shirtSR.color = ParamourSelectedAttributes.LoveSelectedShirtColor; }
        // set pants color
        if (ParamourSelectedAttributes.LoveSelectedPantsColor != null)
        { pantsSR.color = ParamourSelectedAttributes.LoveSelectedPantsColor; }
    }

    void Update()
    {
        if (pa.isDamaged)
        {
            hairSR.color = Color.Lerp(ParamourSelectedAttributes.LoveSelectedHairColor, Color.red, Mathf.PingPong(Time.time, 0.75f));
            skinSR.color = Color.Lerp(ParamourSelectedAttributes.LoveSelectedSkinColor, Color.red, Mathf.PingPong(Time.time, 0.75f));
            shirtSR.color = Color.Lerp(ParamourSelectedAttributes.LoveSelectedShirtColor, Color.red, Mathf.PingPong(Time.time, 0.75f));
            pantsSR.color = Color.Lerp(ParamourSelectedAttributes.LoveSelectedPantsColor, Color.red, Mathf.PingPong(Time.time, 0.75f));
        }
        else if (!pa.isDamaged)
        {
            hairSR.color = Color.Lerp(hairSR.color, ParamourSelectedAttributes.LoveSelectedHairColor, Mathf.Lerp(0f, 1f, Time.deltaTime));
            skinSR.color = Color.Lerp(skinSR.color, ParamourSelectedAttributes.LoveSelectedSkinColor, Mathf.Lerp(0f, 1f, Time.deltaTime));
            shirtSR.color = Color.Lerp(shirtSR.color, ParamourSelectedAttributes.LoveSelectedShirtColor, Mathf.Lerp(0f, 1f, Time.deltaTime));
            pantsSR.color = Color.Lerp(pantsSR.color, ParamourSelectedAttributes.LoveSelectedPantsColor, Mathf.Lerp(0f, 1f, Time.deltaTime));
        }
    }
}
