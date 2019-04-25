using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour {

    /*TODO: make into single instance*/
    public GameObject player;

    public GameObject playerShirt;
    public GameObject playerHair;
    public GameObject playerSkin;
    public GameObject playerPants;

    void Awake()
    {
        // Instantiate here so Player is instiated before all other objects
        Instantiate(player);
        player.transform.position = transform.position;
    }
}
