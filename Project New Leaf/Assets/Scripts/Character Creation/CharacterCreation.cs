using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : CharacterAttributes {
	//Texts
	public Text hairText;

    public Text hairColorText;
    public Text shirtColorText;
    public Text pantsColorText;

    /*
	public Text topsText;
	public Text headText;
	public Text bodyText;
	public Text bottomsText;
	public Text lowerText;
    */

    // Sprites
    public SpriteRenderer spriteHair;
    public SpriteRenderer spriteShirt;
    public SpriteRenderer spritePants;

    //Buttons
    public Button hairNxtBtn;
	public Button hairPrvBtn;

    public Button hairColorNxtBtn;
    public Button shirtColorNxtBtn;
    public Button pantsColorNxtBtn;

    /*
	public Button headNxtBtn;
	public Button headPrvBtn;
	public Button topsNxtBtn;
	public Button topsPrvBtn;
	public Button bodyNxtBtn;
	public Button bodyPrvBtn;
	public Button bottomsNxtBtn;
	public Button bottomsPrvBtn;
	public Button lowerNxtBtn;
	public Button lowerPrvBtn;
    */

    // index chosen
	int hairPos = 0;

    int hairColorPos = 0;
    int shirtColorPos = 0;
    int pantsColorPos = 0;

	int headPos = 0;
	int topsPos = 0;
	int bodyPos = 0;
	int bottomsPos = 0;
	int lowerPos = 0;

	// Use this for initialization
	void Start () {
        // add cosmetic values to CharacterAttributes Dictionaries
		CreateCosmetics();

        hairColors = new Color[10];

        // add colors for hair
        CreateHairColors();

        shirtColors = new Color[9];
        // add colors for shirts
        CreateShirtColors();

        // Load Hair sprites into respective Sprite arrays
        LoadHairSprites();
        spriteHair.sprite = NB_hair[hairPos];

        spriteHair.color = hairColors[hairColorPos];
        spriteShirt.color = shirtColors[shirtColorPos];
        //spritePants.color = pantsColors[pantsColorPos];

        // Text to show which value was chosen
		hairText.text = cosmetics["hair"].GetValue(0).ToString();
        /*
        headText.text = cosmetics["head"].GetValue(0).ToString();
		topsText.text = cosmetics["tops"].GetValue(0).ToString();
		bodyText.text = cosmetics["body"].GetValue(0).ToString();
		bottomsText.text = cosmetics["bottoms"].GetValue(0).ToString();
		lowerText.text = cosmetics["lower"].GetValue(0).ToString();
        */

        // Create and "delegate" buttons to go to next or previous index position.
        // Hair
		hairNxtBtn.onClick.AddListener(delegate{hairPos = nextClick(hairPos, "hair", hairText);});
		hairPrvBtn.onClick.AddListener(delegate{hairPos = prevClick(hairPos,"hair", hairText);});

        // Hair Color
        hairColorNxtBtn.onClick.AddListener(delegate{hairColorPos = nextClick(hairColorPos, "hairColor", hairColorText);});

        // Shirt Color
        shirtColorNxtBtn.onClick.AddListener(delegate {shirtColorPos = nextClick(shirtColorPos, "shirtColor", shirtColorText); });

        /*
        // Head
		headNxtBtn.onClick.AddListener(delegate{headPos = nextClick(headPos, "head", headText);});
		headPrvBtn.onClick.AddListener(delegate{headPos = prevClick(headPos,"head", headText);});
        */

        /*
        // Tops
		topsNxtBtn.onClick.AddListener(delegate{topsPos = nextClick(topsPos, "tops", topsText);});
		topsPrvBtn.onClick.AddListener(delegate{topsPos = prevClick(topsPos,"tops", topsText);});
        
        // Body
		bodyNxtBtn.onClick.AddListener(delegate{bodyPos = nextClick(bodyPos, "body", bodyText);});
		bodyPrvBtn.onClick.AddListener(delegate{bodyPos = prevClick(bodyPos,"body", bodyText);});

        // Legs
		bottomsNxtBtn.onClick.AddListener(delegate{bottomsPos = nextClick(bottomsPos, "bottoms", bottomsText);});
		bottomsPrvBtn.onClick.AddListener(delegate{bottomsPos = prevClick(bottomsPos,"bottoms", bottomsText);});

        // Lower
		lowerNxtBtn.onClick.AddListener(delegate{lowerPos = nextClick(lowerPos, "lower", lowerText);});
		lowerPrvBtn.onClick.AddListener(delegate{lowerPos = prevClick(lowerPos,"lower", lowerText);});
        */

        /*
        // TEST Add all the sprites to the CharacterAttributes Sprite[] arrrays
        // -----------------------------------------------------------------START
        charAttributes.TestAddSprites();

        helmet.sprite = charAttributes.helmets[0];
        chestplate.sprite = charAttributes.chestplates[0];
        glove.sprite = charAttributes.gloves[0];
        pairOfPants.sprite = charAttributes.pants[0];
        */

        // ----------------------------------------------------------------------END
    }
	
	// Update is called once per frame
	void Update ()
    {
        // **dirty flag method
        Debug.Log("hairPos: " + hairPos);
        Debug.Log("hairColorPos: " + hairColorPos);
        Debug.Log("shirtColorPos: " + shirtColorPos);

        spriteHair.sprite = NB_hair[hairPos];
        spriteHair.color = hairColors[hairColorPos];
        spriteShirt.color = shirtColors[shirtColorPos];
    }

	public int nextClick(int position, string key, Text displayText){
		position += 1;
		if(position >= cosmetics[key].Length){
			position = 0;
		}
		//displayText.text = cosmetics[key.ToString()].GetValue(position).ToString();
		return position;
	}

	public int prevClick(int position, string key, Text displayText){
		position -= 1;
		if(position < 0)
		{
			position = cosmetics[key].Length-1;
		}
		//displayText.text = cosmetics[key.ToString()].GetValue(position).ToString();
		return position;
	}
}
