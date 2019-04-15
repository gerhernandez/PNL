using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_AnimationColor : MonoBehaviour {
    public SpriteRenderer currSprite;
    public Color aColor;

	// Use this for initialization
	void Start () {
        currSprite = GetComponent<SpriteRenderer>();
        currSprite.color = new Color(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
    }
}
