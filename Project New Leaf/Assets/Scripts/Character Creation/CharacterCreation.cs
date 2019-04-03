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
    public Button skinColorPrvBtn;
    public Button hairColorNxtBtn;
    public Button hairColorPrvBtn;
    public Button shirtColorNxtBtn;
    public Button shirtColorPrvBtn;
    public Button pantsColorNxtBtn;
    public Button pantsColorPrvBtn;

    public Button selectBodyStyle;

    public Button femButton;
    public Button nonButton;
    public Button masButton;
    
    //Images
    static public Image bodyType;
    
    //Canvas'
    public Canvas fullBodyCanvas;
    public Canvas selectingBodyTypeCanvas;
    public Canvas finishingTouchesCanvas;
    public GameObject fullBodySpriteCanvas;
    public InputField nameInput;

    // name
    public string playerName;

    // index chosen
    int skinPos = 0;
	int hairPos = 0;
    int skinColorPos = 0;
    int hairColorPos = 0;
    int shirtColorPos = 0;
    int pantsColorPos = 0;
    int cisOrTransInt = 0;
    int pronounInt = 0;

    // Booleans
    public bool goToNextCanvas = false;
    bool change;
    
    //Scripts
    //PlayerSelectedAttributes PSA;

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
        skinColorPrvBtn.onClick.AddListener(delegate { skinColorPos = prevClick(skinColorPos, "skin");});

        // Hair Color
        hairColorNxtBtn.onClick.AddListener(delegate{hairColorPos = nextClick(hairColorPos, "hairColor");});
        hairColorPrvBtn.onClick.AddListener(delegate{hairColorPos = prevClick(hairColorPos, "hairColor");});

        // Shirt Color
        shirtColorNxtBtn.onClick.AddListener(delegate{shirtColorPos = nextClick(shirtColorPos, "shirtColor");});
        shirtColorPrvBtn.onClick.AddListener(delegate{shirtColorPos = prevClick(shirtColorPos, "shirtColor");});

        // Pants Color
        pantsColorNxtBtn.onClick.AddListener(delegate{pantsColorPos = nextClick(pantsColorPos, "pantsColor");});
        pantsColorPrvBtn.onClick.AddListener(delegate{pantsColorPos = prevClick(pantsColorPos, "pantsColor");});

        nameInput.onValueChanged.AddListener(delegate{  playerName = nameInput.text; });
        
        change = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (change)
        {
            if (bodyType.name == ("Masculine"))
            { spriteHair.sprite = Male_hair[hairPos]; }
            else if (bodyType.name == ("Feminine"))
            { spriteHair.sprite = Female_hair[hairPos]; }
            else if (bodyType.name == "NonBinary")
            { spriteHair.sprite = NB_hair[hairPos]; }

            spriteSkin.color = skinColors[skinColorPos];
            spriteHair.color = hairColors[hairColorPos];
            spriteShirt.color = shirtColors[shirtColorPos];
            spritePants.color = pantsColors[pantsColorPos];

            change = false;
        }
    }

	public int nextClick(int position, string key){
		position += 1;
		if (position >= cosmetics[key].Length){
			position = 0;
		}
        change = true;
		return position;
	}

	public int prevClick(int position, string key) {
		position -= 1;
		if (position < 0)
		{
			position = cosmetics[key].Length-1;
		}
        change = true;
		return position;
	}
    
	public void setAsBodyType(Button bodySelected) {
    	bodyType = bodySelected.GetComponentInChildren<Image>();
    }

    public void setAsPronoun(Button pr) {
        switch(pr.name)
        {
            case "He/Him":
                pronounInt =  cosmetics["pronouns"][0];
                break;
            case "She/Her":
                pronounInt = cosmetics["pronouns"][1];
                break;
            case "They/Them":
                pronounInt = cosmetics["pronouns"][2];
                break;
            default:
                pronounInt = 0;
                break;
        }
        Debug.Log("pronounInt: " + pronounInt);
    }

    public void setAsCisOrTrans(Button ct) {
        switch(ct.name)
        {
            case "Cis":
                cisOrTransInt = cosmetics["cisOrTrans"][0];
                break;
            case "Trans":
                cisOrTransInt = cosmetics["cisOrTrans"][1];
                break;
        }
        Debug.Log("cisOrTransInt: " + cisOrTransInt);
    }

    public void goToFullBodyCanvas() {
        goToNextCanvas = true;
        loadFullBodyCanvas();
    }

    public void goToFinishingTouchesCanvas() {
        goToNextCanvas = true;
        loadFinishingTouchesCanvas();
    }

    public void loadFullBodyCanvas() {
        fullBodyCanvas.enabled = true;
        selectingBodyTypeCanvas.enabled= false;
        fullBodySpriteCanvas.SetActive(true);

        if(bodyType.name == "Feminine") {
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

    public void goBack(Button btn){
        if(btn.name.Equals("BackToSelectingBody")){
            fullBodyCanvas.enabled = false;
            selectingBodyTypeCanvas.enabled = true;
            fullBodySpriteCanvas.SetActive(false);
        }
        else if(btn.name.Equals("BackToFullBody")){
            fullBodyCanvas.enabled = true;
            finishingTouchesCanvas.enabled = false;
        }
    }

    public void createPlayer()
    {
        // get all the assigned ints and sprites, then get their values to another scene
        PlayerSelectedAttributes.PlaySelectedHair = spriteHair.sprite;
        PlayerSelectedAttributes.PlaySelectedSkin = spriteSkin.sprite;
        PlayerSelectedAttributes.PlaySelectedShirt = spriteShirt.sprite;
        PlayerSelectedAttributes.PlaySelectedPants = spritePants.sprite;
        PlayerSelectedAttributes.PlaySelectedLineart = spriteLineart.sprite;
        PlayerSelectedAttributes.PlaySelectedSkinShading = spriteSkinShading.sprite;
        PlayerSelectedAttributes.PlaySelectedClothShading = spriteClothShading.sprite;
        
        PlayerSelectedAttributes.PlaySelectedSkinColor = spriteSkin.color;
        PlayerSelectedAttributes.PlaySelectedHairColor = spriteHair.color;
        PlayerSelectedAttributes.PlaySelectedShirtColor = spriteShirt.color;
        PlayerSelectedAttributes.PlaySelectedPantsColor = spritePants.color;

        PlayerSelectedAttributes.PlaySelectedName = playerName;
        PlayerSelectedAttributes.PlaySelectedCisOrTransInt = cisOrTransInt;
        PlayerSelectedAttributes.PlaySelectedPronounInt = pronounInt;
        Debug.Log("Player created");
    }

    public void createLover()
    {
        // get all the assigned ints and sprites, then get their values to another scene
        ParamourSelectedAttributes.LoveSelectedHair = spriteHair.sprite;
        ParamourSelectedAttributes.LoveSelectedSkin = spriteSkin.sprite;
        ParamourSelectedAttributes.LoveSelectedShirt = spriteShirt.sprite;
        ParamourSelectedAttributes.LoveSelectedPants = spritePants.sprite;
        ParamourSelectedAttributes.LoveSelectedLineart = spriteLineart.sprite;
        ParamourSelectedAttributes.LoveSelectedSkinShading = spriteSkinShading.sprite;
        ParamourSelectedAttributes.LoveSelectedClothShading = spriteClothShading.sprite;
        
        ParamourSelectedAttributes.LoveSelectedSkinColor = spriteSkin.color;
        ParamourSelectedAttributes.LoveSelectedHairColor = spriteHair.color;
        ParamourSelectedAttributes.LoveSelectedShirtColor = spriteShirt.color;
        ParamourSelectedAttributes.LoveSelectedPantsColor = spritePants.color;

        ParamourSelectedAttributes.LoveSelectedName = playerName;
        ParamourSelectedAttributes.LoveSelectedCisOrTransInt = cisOrTransInt;
        ParamourSelectedAttributes.LoveSelectedPronounInt = pronounInt;
        Debug.Log("Paramour created");
        Debug.Log("+++++++++++++++++++++");
        Debug.Log("Player Name : " + ParamourSelectedAttributes.LoveSelectedName);
        Debug.Log("Cis Or Trans : " + ParamourSelectedAttributes.LoveSelectedCisOrTransInt);
        Debug.Log("Pronoun : " + ParamourSelectedAttributes.LoveSelectedPronounInt);
        Debug.Log("+++++++++++++++++++++");
        Debug.Log("Player and Lover's values set! Passing values!");
    }

    public void resetForLover() {
        hairPos = 0;
        skinPos = 0;
        hairColorPos = 0;
        shirtColorPos = 0;
        pantsColorPos = 0;
        cisOrTransInt = 0;
        pronounInt = 0;
        selectingBodyTypeCanvas.enabled = true;
        fullBodyCanvas.enabled = false;
        fullBodySpriteCanvas.SetActive(false);
        finishingTouchesCanvas.enabled = false;
        Debug.Log("=====================");
        Debug.Log("Player Name : " + PlayerSelectedAttributes.PlaySelectedName);
        Debug.Log("Cis Or Trans : " + PlayerSelectedAttributes.PlaySelectedCisOrTransInt);
        Debug.Log("Pronoun : " + PlayerSelectedAttributes.PlaySelectedPronounInt);
        Debug.Log("=====================");
        Debug.Log("-------- Reset for lover --------");
    }

    // getters
    public int getCisTranInt()
    {
        return cisOrTransInt;
    }

    public int getPronounInt()
    {
        return pronounInt;
    }
}
