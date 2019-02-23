using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayer
{
    private int health;
    private int mana;
    private float refreshCharge;

    public int Health
    { get; set; }

    public int Mana
    { get; set; }

    // TEST: defined in Test_CreatePlayer.cs
    public float RefreshCharge
    { get; set; }
}