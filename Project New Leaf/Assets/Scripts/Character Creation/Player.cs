using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player inherits from BasicPlayer
public class Player : BasicPlayer
{
    private string name;

    // Health and Mana from BasicPlayer
    public Player()
    {
        Health = 100;
        Mana = 100;
    }

    // start
    void Start()
    {
        Debug.Log("Player Started\n");
    }
    
    // move Player
    public void Move()
    {

    }

    // getter-setter for Name
    public string Name
    { get; set; }
}
