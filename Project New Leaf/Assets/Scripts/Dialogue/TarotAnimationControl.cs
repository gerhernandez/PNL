using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotAnimationControl : MonoBehaviour {

    public Animator control;
    public SpriteRenderer drawn;

	// Use this for initialization
	void Start () {
        control = GetComponent<Animator>();
        drawn = GetComponent<SpriteRenderer>();
	}
	
    public void SetToIdle()
    {
        control.SetBool("Idle", true);
        control.SetBool("Walking", false);
    }

	// Update is called once per frame
	public void SetToWalkAnimation () {
        control.SetBool("Walking", true);
        control.SetBool("Idle", false);
	}
}
