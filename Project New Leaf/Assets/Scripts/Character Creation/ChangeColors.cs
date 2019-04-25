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
        playerSprite = GameObject.Find("Player");

        // Find the GameObjects under the Player
        hair = GameObject.Find("PlayerHair");
        skin = GameObject.Find("PlayerSkin");
        shirt = GameObject.Find("PlayerShirt");
        pants = GameObject.Find("PlayerPants");

        //  TODO: Debug stuff for when PlayerSelectAttributes not set yet
        PlayerSelectedAttributes.PlaySelectedHairColor = Color.black;
        PlayerSelectedAttributes.PlaySelectedSkinColor = Color.cyan;
        PlayerSelectedAttributes.PlaySelectedShirtColor = Color.green;
        PlayerSelectedAttributes.PlaySelectedPantsColor = Color.magenta;
        

        // set SpriteRenderers to PlayerSelectedAttributesColors
        if (PlayerSelectedAttributes.PlaySelectedHairColor != null)
        { hair.GetComponent<SpriteRenderer>().color = PlayerSelectedAttributes.PlaySelectedHairColor; }
        if (PlayerSelectedAttributes.PlaySelectedSkinColor != null)
        { skin.GetComponent<SpriteRenderer>().color = PlayerSelectedAttributes.PlaySelectedSkinColor; }
        if (PlayerSelectedAttributes.PlaySelectedShirtColor != null)
        { shirt.GetComponent<SpriteRenderer>().color = PlayerSelectedAttributes.PlaySelectedShirtColor; }
        if (PlayerSelectedAttributes.PlaySelectedPantsColor != null)
        { pants.GetComponent<SpriteRenderer>().color = PlayerSelectedAttributes.PlaySelectedPantsColor; }
    }
}
