using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethorSwitch : MonoBehaviour {

    public bool mentorSwitchActivate;

	// Use this for initialization
	void Start () {
        mentorSwitchActivate = false;
	}

    void ActivateSwitch()
    {
        // activate the mentor's switch
        mentorSwitchActivate = true;
    }
}
