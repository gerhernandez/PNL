using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : CharacterAttributes {
	//Scripts
    public selectButton chooseBodyTypeScript;
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
    public SpriteRenderer spriteSkin;
    public SpriteRenderer spriteShirt;
    public SpriteRenderer spritePants;
    public SpriteRenderer spriteLineart;
    public SpriteRenderer spriteSkinShading;
    public SpriteRenderer spriteClothShading;

    //Buttons
    public Button hairNxtBtn;
	public Button hairPrvBtn;

    public Button hairColorNxtBtn;
    public Button shirtColorNxtBtn;
    public Button pantsColorNxtBtn;

    public Button selectBodyStyle;

    public Button femButton;
    public Button nonButton;
    public Button masButton;
    
    // Booleans
    public bool goToNextCanvas = false;
    //Images
    static public Image bodyType;


    //Canvas'
    public Canvas fullBodyCanvas;

    public Canvas selectingBodyTypeCanvas;
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
    int skinPos = 0;
	int hairPos = 0;
    int hairColorPos = 0;
    int shirtColorPos = 0;
    int pantsColorPos = 0;

	int headPos = 0;
	int topsPos = 0;
	int bodyPos = 0;
	int bottomsPos = 0;
	int lowerPos = 0;

    // dirty flag ints
    int checkHairPos;

	// Use this for initialization
	void Start () {
        fullBodyCanvas.enabled = false;
        selectingBodyTypeCanvas.enabled = true;
        // chooseBodyTypeScript.GetImage();

        // Load all relevant sprites
        
        // add cosmetic values to CharacterAttributes Dictionaries
		CreateCosmeticsDictionary();
        
        // add colors for hair
        hairColors = new Color[10];
        CreateHairColors();

        // add colors for skin
        skinColors = new Color[4];
        CreateSkinColors();

        // add colors for shirts
        shirtColors = new Color[9];
        CreateShirtColors();

        // add colors for pants
        pantsColors = new Color[5];
        CreatePantsColors();

        Debug.Log("Uncommented Lines 114 - 118 for debugging purposes");
        // default Sprite
        spriteSkin.color = skinColors[skinPos];
        spriteHair.color = hairColors[hairColorPos];
        spriteShirt.color = shirtColors[shirtColorPos];
        spritePants.color = pantsColors[pantsColorPos];

        // // Text to show which value was chosen
		// hairText.text = cosmetics["hair"].GetValue(0).ToString();
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

        // Pants Color
        pantsColorNxtBtn.onClick.AddListener(delegate { pantsColorPos = nextClick(pantsColorPos, "pantsColor", pantsColorText); });

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
        // ----------------------------------------------------------------------END

        checkHairPos = hairPos;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("hairLength: " + Male_hair.Length);
        Debug.Log("pantsColors length: " + pantsColors.Length);

        // **dirty flag method recommended
        /*Debug.Log("hairPos: " + hairPos);
        Debug.Log("hairColorPos: " + hairColorPos);
        Debug.Log("shirtColorPos: " + shirtColorPos);
        */

        Debug.Log("checkHairPos: " + checkHairPos);
        Debug.Log("hairPos: " + hairPos);
        if (checkHairPos != hairPos)
        {
            Debug.Log("Hair changed");
            if (bodyType.ToString().Equals("Male"))
            {
                spriteHair.sprite = Male_hair[hairPos];
            }
            if (bodyType.ToString().Equals("Feminine"))
            {
                spriteHair.sprite = Female_hair[hairPos];
            }
            if (bodyType.ToString().Equals("NonBinary"))
            {
                spriteHair.sprite = NB_hair[hairPos];
            }
            
            checkHairPos = hairPos;
        }

        spriteHair.color = hairColors[hairColorPos];
        spriteShirt.color = shirtColors[shirtColorPos];
        spritePants.color = pantsColors[pantsColorPos];
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

    // public Image setAsBodyType(Button bodySelected){
    //     bodyType = bodySelected.GetComponentInChildren<Image>();
    //     return bodyType;
    // }

    
	public void setAsBodyType(Button bodySelected){
    	bodyType = bodySelected.GetComponentInChildren<Image>();
    }

    public void goToFullBodyCanvas(){
        goToNextCanvas = true;
        loadFullBodyCanvas();
    }

    public void loadFullBodyCanvas(){
        Debug.Log("***loadFullBodyCanvas() function entered");
        Debug.Log("***bodyType selected: " + bodyType.ToString());

        fullBodyCanvas.enabled = true;
        selectingBodyTypeCanvas.enabled = false;
        if(bodyType.ToString() == "Feminine"){
            Debug.Log("Female body");
            LoadFemaleSprites();
            spriteSkin.sprite = Female_Skin;
            spriteShirt.sprite = Female_Shirt;
            spritePants.sprite = Female_Pants;
            spriteLineart.sprite = Female_Lineart;
            spriteSkinShading.sprite = Female_SkinShading;
            spriteClothShading.sprite = Female_ClothShading;
            spriteHair.sprite = Female_hair[hairPos];
            spriteSkin.color = skinColors[skinPos];
            spriteHair.color = hairColors[hairColorPos];
            spriteShirt.color = shirtColors[shirtColorPos];
            spritePants.color = pantsColors[pantsColorPos];

            // Text to show which value was chosen
            hairText.text = cosmetics["hair"].GetValue(0).ToString();
        }
        else if(bodyType.ToString() == "NonBinary"){
            Debug.Log("NonBinary body");
            LoadNonBinarySprites();
            spriteSkin.sprite = NB_Skin;
            spriteShirt.sprite = NB_Shirt;
            spritePants.sprite = NB_Pants;
            spriteLineart.sprite = NB_Lineart;
            spriteSkinShading.sprite = NB_SkinShading;
            spriteClothShading.sprite = NB_ClothShading;
            spriteHair.sprite = NB_hair[hairPos];   
            spriteSkin.color = skinColors[skinPos];
            spriteHair.color = hairColors[hairColorPos];
            spriteShirt.color = shirtColors[shirtColorPos];
            spritePants.color = pantsColors[pantsColorPos];

            // Text to show which value was chosen
            hairText.text = cosmetics["hair"].GetValue(0).ToString();     
        }
        else{
            Debug.Log("Male body");
            LoadMaleSprites();
            spriteSkin.sprite = Male_Skin;
            spriteShirt.sprite = Male_Shirt;
            spritePants.sprite = Male_Pants;
            spriteLineart.sprite = Male_Lineart;
            spriteSkinShading.sprite = Male_SkinShading;
            spriteClothShading.sprite = Male_ClothShading;
            spriteHair.sprite = Male_hair[hairPos];
            spriteSkin.color = skinColors[skinPos];
            spriteHair.color = hairColors[hairColorPos];
            spriteShirt.color = shirtColors[shirtColorPos];
            spritePants.color = pantsColors[pantsColorPos];

            // Text to show which value was chosen
            hairText.text = cosmetics["hair"].GetValue(0).ToString();
        }
            
            
        goToNextCanvas = false;
    }
}
