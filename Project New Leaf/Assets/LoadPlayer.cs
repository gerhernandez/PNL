using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour {

    /*TODO: make into single instance*/
    public GameObject player;

    public SpriteRenderer playerShirt;
    public SpriteRenderer playerHair;
    public SpriteRenderer playerSkin;
    public SpriteRenderer playerPants;
	
    // Use this for initialization
	void Start () {
        GameObject.Instantiate(player);
        player.transform.position = transform.position;
        playerHair = GameObject.Find("PlayerHair").GetComponent<SpriteRenderer>();
        playerSkin = GameObject.Find("PlayerSkin").GetComponent<SpriteRenderer>();
        playerShirt = GameObject.Find("PlayerHair").GetComponent<SpriteRenderer>();
        playerPants = GameObject.Find("PlayerPants").GetComponent<SpriteRenderer>();

        playerHair.color  = PlayerSelectedAttributes.PlaySelectedHairColor;
        playerSkin.color  = PlayerSelectedAttributes.PlaySelectedSkinColor;
        playerShirt.color = PlayerSelectedAttributes.PlaySelectedShirtColor;
        playerPants.color = PlayerSelectedAttributes.PlaySelectedPantsColor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
