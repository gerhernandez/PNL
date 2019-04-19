using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColors : MonoBehaviour {
    public Color[] testColors;

    // the animated Player
    public GameObject playerSprite;
    
    // the GameObjects in the ChangeColorsCanvas
    public GameObject ChangeShirtColor;
    public GameObject ChangePantsColor;
    public GameObject ChangeHairColor;
    public GameObject ChangeSkinColor;

    // the sprites attached to the Player
    public SpriteRenderer[] playerSprites;
    public SpriteRenderer shirt;
    public SpriteRenderer pants;
    public SpriteRenderer skin;
    public SpriteRenderer hair;

    // the buttons in the ChangeColorCanvas
    public Button[] shirtColors;
    public Button[] pantsColors;
    public Button[] hairColors;
    public Button[] skinColors;

    public Color[] tempColors;
    
    // boolean to test if Player got damaged 
    public bool isDamaged;

    // for counting indexes
    private int i = 0;

    // Use this for initialization
    void Start () {
        // Find the name GameObject
        playerSprite = GameObject.Find("Player");
        // Find the sprites
        playerSprites = playerSprite.GetComponentsInChildren<SpriteRenderer>();

        /*
        foreach (SpriteRenderer s in playerSprites)
        {
            Debug.Log(s.name);
        }
        */

        // find the GameObjects 
        //ChangeColor = GameObject.Find("ChangeColorsCanvas");
        ChangeShirtColor = GameObject.Find("ShirtButtons");
        ChangePantsColor = GameObject.Find("PantsButtons");
        ChangeHairColor = GameObject.Find("HairButtons");
        ChangeSkinColor = GameObject.Find("SkinButtons");

        // Debugs
        /*
        if (ChangeShirtColor != null)
        {
            Debug.Log(ChangeShirtColor.name);
        }

        if (ChangePantsColor != null)
        {
            Debug.Log(ChangePantsColor.name);
        }

        if (ChangeHairColor != null)
        {
            Debug.Log(ChangeHairColor.name);
        }

        if (ChangeSkinColor != null)
        {
            Debug.Log(ChangeSkinColor.name);
        }
        */
        // get the buttons; if confusing, this DOESN'T get the colors, just the buttons
        shirtColors = ChangeShirtColor.GetComponentsInChildren<Button>();
        pantsColors = ChangePantsColor.GetComponentsInChildren<Button>();
        hairColors = ChangeHairColor.GetComponentsInChildren<Button>();
        skinColors = ChangeSkinColor.GetComponentsInChildren<Button>();
        
        // similar to delegate methods in CharacterCreation.cs, but in foreach loops
        // change the color of the selected sprite based on button's color
        foreach (Button b in shirtColors)
        {
            b.onClick.AddListener(delegate {
                Debug.Log("button clicked: " + b.name);
                playerSprites[3].color = b.image.color;
            });
        }

        foreach (Button b in pantsColors)
        {
            b.onClick.AddListener(delegate {
                Debug.Log("button clicked: " + b.name);
                playerSprites[4].color = b.image.color;
            });
        }

        foreach (Button b in hairColors)
        {
            b.onClick.AddListener(delegate {
                Debug.Log("button clicked: " + b.name);
                playerSprites[0].color = b.image.color;
            });
        }

        foreach (Button b in skinColors)
        {
            b.onClick.AddListener(delegate {
                Debug.Log("button clicked: " + b.name);
                playerSprites[2].color = b.image.color;
            });
        }

        testColors = new Color[5];
        for (int i = 0; i < 5; i++)
        {
            testColors[i] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }

        for (int i = 0; i < 5; i++)
        {
            playerSprites[i].color = testColors[i];
        }
    }

    void Update()
    {
        if (isDamaged)
        {
            tempColors = new Color[playerSprites.Length];

            i = 0;
            foreach (SpriteRenderer sprite in playerSprites)
            {
                Debug.Log("1stsprite.color: " + sprite.color);
                //tempColors[i] = sprite.color;
                Debug.Log("1sttempColor: " + tempColors[i].ToString() + "\n");

                sprite.color = Color.red;
                i++;
            }

            StartCoroutine("DamageDuration");
        }
    }

    IEnumerator DamageDuration()
    {
        yield return new WaitForSecondsRealtime(3f);

        i = 0;
        foreach (SpriteRenderer sprite in playerSprites)
        {
            Debug.Log("2ndtempColor: " + tempColors[i] + "\n");
            //sprite.color = tempColors[i];
            Debug.Log("2ndsprite.color: " + sprite.color);
            sprite.color = Color.Lerp(sprite.color, testColors[i], 2f);
            i++;
        }
        isDamaged = false;
    }
}
