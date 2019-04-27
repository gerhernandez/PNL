using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColors : MonoBehaviour {
    // reference to the Player and the Player script
    //public Player p;
    /* TODO: used for testing animations of the powers */
    public Test_PowersActivated tp;
    
    public GameObject playerSprite;

    /* TODO: uncomment when done animating powers
    // the GameObjects attached to the Player
    public GameObject hair;
    public GameObject skin;
    public GameObject shirt;
    public GameObject pants;
    */

    // the power animations
    public GameObject boar;
    public GameObject hawk;
    public GameObject viper;
    public GameObject wolf;

    /* TODO: uncomment when done animating powers
    // sprite renderers of above GameObjects
    public SpriteRenderer hairSR;
    public SpriteRenderer skinSR;
    public SpriteRenderer shirtSR;
    public SpriteRenderer pantsSR;
    */

    public SpriteRenderer boarSR;
    public SpriteRenderer hawkSR;
    public SpriteRenderer viperSR;
    public SpriteRenderer wolfSR;

    /* TODO: can be used with Dialogue/Fungus for setting lighting color;on backburner for now
    public bool isTwilight;
    public bool isNight;
    public bool isDay;
    */

    // Use this for initialization
    void Start () {
        //p = FindObjectOfType<Player>();

        /* TODO: test "player" for playing animations*/
        tp = FindObjectOfType<Test_PowersActivated>();

        // Find the name GameObject
        //playerSprite = GameObject.Find("Player(Clone)");
        playerSprite = GameObject.FindWithTag("Player");

        /* TODO: commented out for now
        // Find the GameObjects and SpriteRenderers under the Player
        // this method of finding GameObjects b/c GameObject.Find was returning Preview Scene objects (bug)
        hair = playerSprite.transform.Find("PlayerHair").gameObject;
        skin = playerSprite.transform.Find("PlayerSkin").gameObject;
        shirt = playerSprite.transform.Find("PlayerShirt").gameObject;
        pants = playerSprite.transform.Find("PlayerPants").gameObject;

        hairSR = hair.GetComponent<SpriteRenderer>();
        skinSR = skin.GetComponent<SpriteRenderer>();
        shirtSR = shirt.GetComponent<SpriteRenderer>();
        pantsSR = pants.GetComponent<SpriteRenderer>();
        */

        boar = playerSprite.transform.Find("Boar").gameObject;
        hawk = playerSprite.transform.Find("Hawk").gameObject;
        viper = playerSprite.transform.Find("Viper").gameObject;
        wolf = playerSprite.transform.Find("Wolf").gameObject;

        boarSR = boar.GetComponent<SpriteRenderer>();
        hawkSR = hawk.GetComponent<SpriteRenderer>();
        viperSR = viper.GetComponent<SpriteRenderer>();
        wolfSR = wolf.GetComponent<SpriteRenderer>();

        /*
        //  TODO: Debug stuff for when PlayerSelectAttributes not set yet
        PlayerSelectedAttributes.PlaySelectedHairColor = Color.black;
        PlayerSelectedAttributes.PlaySelectedSkinColor = Color.yellow;
        PlayerSelectedAttributes.PlaySelectedShirtColor = Color.green;
        PlayerSelectedAttributes.PlaySelectedPantsColor = Color.gray;
        */

        /* TODO: uncomment when done animating powers
        // set hair color
        if (PlayerSelectedAttributes.PlaySelectedHairColor != null)
        { hairSR.color = PlayerSelectedAttributes.PlaySelectedHairColor; }
        // set skin color
        if (PlayerSelectedAttributes.PlaySelectedSkinColor != null)
        { skinSR.color = PlayerSelectedAttributes.PlaySelectedSkinColor; }
        // set shirt color
        if (PlayerSelectedAttributes.PlaySelectedShirtColor != null)
        { shirtSR.color = PlayerSelectedAttributes.PlaySelectedShirtColor; }
        // set pants color
        if (PlayerSelectedAttributes.PlaySelectedPantsColor != null)
        { pantsSR.color = PlayerSelectedAttributes.PlaySelectedPantsColor; }
        */
    }

    void Update()
    {
        /*
        Debug.Log("p.isDamaged: " + p.isDamaged);
        if (p.isDamaged)
        {
            hairSR.color = Color.Lerp(PlayerSelectedAttributes.PlaySelectedHairColor, Color.red, Mathf.PingPong(Time.time, 0.75f));
            skinSR.color = Color.Lerp(PlayerSelectedAttributes.PlaySelectedSkinColor, Color.red, Mathf.PingPong(Time.time, 0.75f));
            shirtSR.color = Color.Lerp(PlayerSelectedAttributes.PlaySelectedShirtColor, Color.red, Mathf.PingPong(Time.time, 0.75f));
            pantsSR.color = Color.Lerp(PlayerSelectedAttributes.PlaySelectedPantsColor, Color.red, Mathf.PingPong(Time.time, 0.75f));
        }
        else if (!p.isDamaged)
        {
            hairSR.color = Color.Lerp(hairSR.color, PlayerSelectedAttributes.PlaySelectedHairColor, Mathf.Lerp(0f, 1f, Time.deltaTime));
            skinSR.color = Color.Lerp(skinSR.color, PlayerSelectedAttributes.PlaySelectedSkinColor, Mathf.Lerp(0f, 1f, Time.deltaTime));
            shirtSR.color = Color.Lerp(shirtSR.color, PlayerSelectedAttributes.PlaySelectedShirtColor, Mathf.Lerp(0f, 1f, Time.deltaTime));
            pantsSR.color = Color.Lerp(pantsSR.color, PlayerSelectedAttributes.PlaySelectedPantsColor, Mathf.Lerp(0f, 1f, Time.deltaTime));
        }
        */

        // for boar damage
        if (tp.boarEnabled && tp.isDamaged)
        {
            boarSR.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.75f));
        }
        else if (tp.boarEnabled && !tp.isDamaged)
        {
            boarSR.color = Color.Lerp(boarSR.color, Color.white, Mathf.Lerp(0f, 1f, Time.deltaTime));
        }

        // for hawk damage
        if (tp.hawkEnabled && tp.isDamaged)
        {
            hawkSR.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.75f));
        }
        else if (tp.hawkEnabled && !tp.isDamaged)
        {
            hawkSR.color = Color.Lerp(hawkSR.color, Color.white, Mathf.Lerp(0f, 1f, Time.deltaTime));
        }

        // for viper damage
        if (tp.viperEnabled && tp.isDamaged)
        {
            viperSR.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.75f));
        }
        else if (tp.viperEnabled && !tp.isDamaged)
        {
            viperSR.color = Color.Lerp(viperSR.color, Color.white, Mathf.Lerp(0f, 1f, Time.deltaTime));
        }

        // for wolf damage
        if (tp.wolfEnabled && tp.isDamaged)
        {
            wolfSR.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.75f));
        }
        else if (tp.wolfEnabled && !tp.isDamaged)
        {
            wolfSR.color = Color.Lerp(wolfSR.color, Color.white, Mathf.Lerp(0f, 1f, Time.deltaTime));
        }
    }
}
