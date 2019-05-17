using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBreak : MonoBehaviour {

    private Animator anim;
    //public Sprite brokenPieces;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
    public void StartAnimation()
    {
        anim.SetBool("breaking", true);
    }
}
