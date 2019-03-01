using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CreatePlayer : MonoBehaviour {
    // basic player
    BasicPlayer player1;
    public int seconds;

    // Use this for initialization
    void Start()
    {
        // create a new player
        player1 = new Player();
        player1.RefreshCharge = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player1 health: " + player1.Health);

        player1.RefreshCharge += Time.deltaTime;
        player1.RefreshCharge = player1.RefreshCharge % 60;
        seconds = (int)(player1.RefreshCharge);

        Debug.Log("RefreshCharge (float):   " + player1.RefreshCharge);
        Debug.Log("RefreshCharge (seconds): " + seconds);
    }
}
