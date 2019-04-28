using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColors : MonoBehaviour {
    // reference to the Player and the Player script
    public Player p;
    public GameObject playerSprite;
    
    // the GameObjects attached to the Player
    public GameObject hair;
    public GameObject skin;
    public GameObject shirt;
    public GameObject pants;

    // Powers reference and animations
    public Powers powerScript;
    public GameObject power;
    public SpriteRenderer powerSprite;

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
    void Start () {
        p = FindObjectOfType<Player>();
        
        // Find the name GameObject
        //playerSprite = GameObject.Find("Player(Clone)");
        playerSprite = GameObject.FindWithTag("Player");
        
        // Find the GameObjects and SpriteRenderers under the Player
        // using this method of finding GameObjects b/c GameObject.Find was returning Preview Scene objects (bug)
        hair = playerSprite.transform.Find("PlayerHair").gameObject;
        skin = playerSprite.transform.Find("PlayerSkin").gameObject;
        shirt = playerSprite.transform.Find("PlayerShirt").gameObject;
        pants = playerSprite.transform.Find("PlayerPants").gameObject;

        hairSR = hair.GetComponent<SpriteRenderer>();
        skinSR = skin.GetComponent<SpriteRenderer>();
        shirtSR = shirt.GetComponent<SpriteRenderer>();
        pantsSR = pants.GetComponent<SpriteRenderer>();

        // 3 things related to power
        power = p.transform.Find("Powers").gameObject;
        powerScript = p.GetComponent<Powers>();
        powerSprite = power.GetComponent<SpriteRenderer>();

        /*
        //  TODO: Debug stuff for when PlayerSelectAttributes not set yet
        PlayerSelectedAttributes.PlaySelectedHairColor = Color.black;
        PlayerSelectedAttributes.PlaySelectedSkinColor = Color.yellow;
        PlayerSelectedAttributes.PlaySelectedShirtColor = Color.green;
        PlayerSelectedAttributes.PlaySelectedPantsColor = Color.gray;
        */

        /* TODO: uncomment when done animating powers */
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
    }

    void Update()
    {
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

        // for Powers if damaged in a power state
        if (Powers.hasBoarPower && powerScript.IsCharging() && p.isDamaged)
        {
            StartDamageAnim();
        }
        else if (Powers.hasBoarPower && powerScript.IsCharging() && !p.isDamaged)
        {
            EndDamageAnim();
        }

        if (Powers.hasFlyingPower && powerScript.IsPlayerFlying() && p.isDamaged)
        {
            StartDamageAnim();
        }
        else if (Powers.hasFlyingPower && powerScript.IsPlayerFlying() && !p.isDamaged)
        {
            EndDamageAnim();
        }

        if (Powers.hasSnakePower && powerScript.IsViperCrawling() && p.isDamaged)
        {
            StartDamageAnim();
        }
        else if (Powers.hasSnakePower && powerScript.IsViperCrawling() && !p.isDamaged)
        {
            EndDamageAnim();
        }

        if (Powers.hasWolfPower && p.isDamaged)
        {
            StartDamageAnim();
        }
        else if (Powers.hasWolfPower && !p.isDamaged)
        {
            EndDamageAnim();
        }
    }

    // start and end damage animations
    void StartDamageAnim()
    {
        powerSprite.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.75f));
    }

    void EndDamageAnim()
    {
        powerSprite.color = Color.Lerp(powerSprite.color, Color.white, Mathf.Lerp(0f, 1f, Time.deltaTime));
    }
}
