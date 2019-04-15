using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to change Jump's pos because I'm tired of going in and changing them manually.
/// </summary>
public class Test_ChangePos : MonoBehaviour {
    public Animator anim;
    public SpriteRenderer theSprite;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        //anim.transform.position = new Vector2(-0.1f, 1.1f);
        //anim.rootPosition = new Vector3(-.1f, 1.1f, 0f);
        theSprite = GetComponent<SpriteRenderer>();
        theSprite.gameObject.transform.position = new Vector2(-0.1f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
