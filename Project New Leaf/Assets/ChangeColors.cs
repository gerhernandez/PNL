using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColors : MonoBehaviour {
    public GameObject playerSprite;
    public GameObject ChangeColor;

    public SpriteRenderer[] playerSprites;
    public SpriteRenderer shirt;
    public SpriteRenderer pants;
    public SpriteRenderer skin;
    public SpriteRenderer hair;

    public Button[] shirtColors;

	// Use this for initialization
	void Start () {
        playerSprite = GameObject.Find("Player");
        playerSprites = playerSprite.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer s in playerSprites)
        {
            Debug.Log(s.name);
        }

        ChangeColor = GameObject.Find("ChangeColorsCanvas");
        if (ChangeColor != null)
        {
            Debug.Log(ChangeColor.name);
        }

        shirtColors = ChangeColor.GetComponentsInChildren<Button>();

        foreach (Button b in shirtColors)
        {
            Debug.Log(b.name);
            Debug.Log(b.image.color);
            b.onClick.AddListener(delegate { Debug.Log("button clicked: " + b.name); });
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
