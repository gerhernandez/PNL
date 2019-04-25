using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColors : MonoBehaviour {
    // the animated Player
    public GameObject playerSprite;

    // the sprites attached to the Player
    public GameObject shirt;
    public GameObject pants;
    public GameObject skin;
    public GameObject hair;

    // Use this for initialization
    void Start () {
        // Find the name GameObject
        //playerSprite = GameObject.Find("Player(Clone)");
        playerSprite = GameObject.FindWithTag("Player");

        // Find the GameObjects under the Player
        // this method of finding GameObjects b/c GameObject.Find was returning Preview Scene objects
        hair = playerSprite.transform.Find("PlayerHair").gameObject;
        skin = playerSprite.transform.Find("PlayerSkin").gameObject;
        shirt = playerSprite.transform.Find("PlayerShirt").gameObject;
        pants = playerSprite.transform.Find("PlayerPants").gameObject;

        /*
        //  TODO: Debug stuff for when PlayerSelectAttributes not set yet
        PlayerSelectedAttributes.PlaySelectedHairColor = Color.black;
        PlayerSelectedAttributes.PlaySelectedSkinColor = Color.yellow;
        PlayerSelectedAttributes.PlaySelectedShirtColor = Color.green;
        PlayerSelectedAttributes.PlaySelectedPantsColor = Color.gray;
        */

        // set hair color
        if (PlayerSelectedAttributes.PlaySelectedHairColor != null)
        { hair.GetComponent<SpriteRenderer>().color = PlayerSelectedAttributes.PlaySelectedHairColor; }
        // set skin color
        if (PlayerSelectedAttributes.PlaySelectedSkinColor != null)
        { skin.GetComponent<SpriteRenderer>().color = PlayerSelectedAttributes.PlaySelectedSkinColor; }
        // set shirt color
        if (PlayerSelectedAttributes.PlaySelectedShirtColor != null)
        { shirt.GetComponent<SpriteRenderer>().color = PlayerSelectedAttributes.PlaySelectedShirtColor; }
        // set pants color
        if (PlayerSelectedAttributes.PlaySelectedPantsColor != null)
        { pants.GetComponent<SpriteRenderer>().color = PlayerSelectedAttributes.PlaySelectedPantsColor; }
    }
}
