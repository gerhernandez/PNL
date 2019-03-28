using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : CharacterAttributes {
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

    public Button skinColorNxtBtn;
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
    public Canvas finishingTouchesCanvas;

    public GameObject fullBodySpriteCanvas;

    // name
    public string name;

    // index chosen
    int skinPos = 0;
	int hairPos = 0;
    int skinColorPos = 0;
    int hairColorPos = 0;
    int shirtColorPos = 0;
    int pantsColorPos = 0;

    // dirty flag ints
    int checkHairPos;
    int checkSkinColorPos;
    int checkHairColorPos;
    int checkShirtColorPos;
    int checkPantsColorPos;

	// Use this for initialization
	void Start () {
        fullBodyCanvas.enabled = false;
        selectingBodyTypeCanvas.enabled = true;
        finishingTouchesCanvas.enabled = false;
        fullBodySpriteCanvas.SetActive(false);
       
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
        
        // default Sprite
        spriteSkin.color = skinColors[skinPos];
        spriteHair.color = hairColors[hairColorPos];
        spriteShirt.color = shirtColors[shirtColorPos];
        spritePants.color = pantsColors[pantsColorPos];

        // Create and "delegate" buttons to go to next or previous index position.
        // Hair
		hairNxtBtn.onClick.AddListener(delegate{hairPos = nextClick(hairPos, "hair");});
		hairPrvBtn.onClick.AddListener(delegate{hairPos = prevClick(hairPos,"hair");});

        // Skin Color
        skinColorNxtBtn.onClick.AddListener(delegate{skinColorPos = nextClick(skinColorPos, "skin");});

        // Hair Color
        hairColorNxtBtn.onClick.AddListener(delegate{hairColorPos = nextClick(hairColorPos, "hairColor");});

        // Shirt Color
        shirtColorNxtBtn.onClick.AddListener(delegate{shirtColorPos = nextClick(shirtColorPos, "shirtColor");});

        // Pants Color
        pantsColorNxtBtn.onClick.AddListener(delegate{pantsColorPos = nextClick(pantsColorPos, "pantsColor");});

        name = "";

        checkHairPos = hairPos;
        checkSkinColorPos = skinColorPos;
        checkHairColorPos = hairColorPos;
        checkShirtColorPos = shirtColorPos;
        checkPantsColorPos = pantsColorPos;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("hairLength: " + Male_hair.Length);
        Debug.Log("pantsColors length: " + pantsColors.Length);
        Debug.Log("checkHairPos: " + checkHairPos);
        Debug.Log("hairPos: " + hairPos);
        if (checkHairPos != hairPos)
        {
            Debug.Log("+++Body Type: " + bodyType.ToString());
            Debug.Log("Hair changed");

            if (bodyType.name == ("Masculine"))
            {
                Debug.Log("+++Male hair changed");
                spriteHair.sprite = Male_hair[hairPos];
            }
            else if (bodyType.name == ("Feminine"))
            {
                Debug.Log("+++Female hair changed");
                spriteHair.sprite = Female_hair[hairPos];
            }
            else if (bodyType.name == "NonBinary")
            {
                Debug.Log("+++NonBinary hair changed");
                spriteHair.sprite = NB_hair[hairPos];
            }
            
            checkHairPos = hairPos;
        }

        if (checkSkinColorPos != skinColorPos)
        {
            Debug.Log("Skin color changed");

            spriteSkin.color = skinColors[skinColorPos];
            checkSkinColorPos = skinColorPos;
        }

        if (checkHairColorPos != hairColorPos)
        {
            Debug.Log("Hair color changed");

            spriteHair.color = hairColors[hairColorPos];
            checkHairPos = hairColorPos;
        }

        if (checkShirtColorPos != shirtColorPos)
        {
            Debug.Log("Shirt color changed");

            spriteShirt.color = shirtColors[shirtColorPos];
            checkShirtColorPos = shirtColorPos;
        }

        if (checkPantsColorPos != pantsColorPos)
        {
            Debug.Log("Pants color changed");

            spritePants.color = pantsColors[pantsColorPos];
            checkPantsColorPos = pantsColorPos;
        }

        
    }

	public int nextClick(int position, string key){
		position += 1;
		if(position >= cosmetics[key].Length){
			position = 0;
		}
		return position;
	}

	public int prevClick(int position, string key){
		position -= 1;
		if(position < 0)
		{
			position = cosmetics[key].Length-1;
		}
		return position;
	}
    
	public void setAsBodyType(Button bodySelected){
    	bodyType = bodySelected.GetComponentInChildren<Image>();
    }

    public void goToFullBodyCanvas(){
        goToNextCanvas = true;
        loadFullBodyCanvas();
    }

    public void goToFinishingTouchesCanvas()
    {
        goToNextCanvas = true;
        loadFinishingTouchesCanvas();
    }

    public void loadFullBodyCanvas(){
        fullBodyCanvas.enabled = true;
        selectingBodyTypeCanvas.enabled= false;
        fullBodySpriteCanvas.SetActive(true);
        if(bodyType.name == "Feminine") {
            Debug.Log("***Female body");
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
        }
        else if(bodyType.name == "NonBinary") {
            Debug.Log("***NonBinary body");
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
        }
        else if (bodyType.name == "Masculine") {
            Debug.Log("***Male body");
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
        }  
        goToNextCanvas = false;
    }

    public void loadFinishingTouchesCanvas()
    {
        finishingTouchesCanvas.enabled = true;
        fullBodyCanvas.enabled = false;
      
        goToNextCanvas = false;
    }
}
