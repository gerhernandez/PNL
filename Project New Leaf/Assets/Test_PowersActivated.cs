using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PowersActivated : MonoBehaviour {
    public bool boarEnabled;
    public bool hawkEnabled;
    public bool viperEnabled;
    public bool wolfEnabled;

    public bool boarActivated;
    public bool hawkActivated;
    public bool viperActivated;
    public bool wolfActivated;

    public bool isDamaged;
    public bool isGrounded;

    void Start()
    {
        boarEnabled = true;
        hawkEnabled = true;
        viperEnabled = true;
        wolfEnabled = true;
    }
}
