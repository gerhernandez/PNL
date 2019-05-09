using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// enums w/ bit-mask won't be too costly
// state pattern for animations/grounded for jumping (no flags)

public class CharacterCreation : CharacterAttributes {
    // Event System
    public EventSystem eventSystem;

    // Text
    public Text selectingBodyTitle;
    public Text creatingCharTitle;
    public Text createButtonText;
    public Text createYourPlayerText;
    public Text playerNameFinishingTouchesText;

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

    // pronouns
    public Button ButtonSheHer;
    public Button ButtonTheyThem;
    public Button ButtonHeHim;

    // cis trans
    public Button ButtonCis;
    public Button ButtonTrans;

    public Button selectBodyStyle;

    //keyboard canvas
    public GameObject keyboardCanvas;

    // Keyboard Buttons
    public Button ButtonQ;
    public Button ButtonW;
    public Button ButtonE;
    public Button ButtonR;
    public Button ButtonT;
    public Button ButtonY;
    public Button ButtonU;
    public Button ButtonI;
    public Button ButtonO;
    public Button ButtonP;
    public Button ButtonA;
    public Button ButtonS;
    public Button ButtonD;
    public Button ButtonF;
    public Button ButtonG;
    public Button ButtonH;
    public Button ButtonJ;
    public Button ButtonK;
    public Button ButtonL;
    public Button ButtonZ;
    public Button ButtonX;
    public Button ButtonC;
    public Button ButtonV;
    public Button ButtonB;
    public Button ButtonN;
    public Button ButtonM;
    public Button ButtonEditName;
    public Button ButtonOk;
    public Button ButtonBackspace;

    public Text keyboardTextField;
    
    private string keyboardInput = "";

    // full body buttons
    public Button femButton;
    public Button nonButton;
    public Button masButton;
    
    //Images
    static public Image bodyType;
    
    //Canvases
    public GameObject fullBodyCanvas;
    public GameObject selectingBodyTypeCanvas;
    public GameObject finishingTouchesCanvas;
    public GameObject fullBodySpriteCanvas;
    public Text nameInput;

    // name
    public string playerName;
    public string paramourName;

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
    bool isPlayer;

    // Use this for initialization
    void Start () {
        fullBodyCanvas.SetActive(false);
        selectingBodyTypeCanvas.SetActive(true);
        finishingTouchesCanvas.SetActive(false);
        fullBodySpriteCanvas.SetActive(false);
        keyboardCanvas.SetActive(false);
        
        // Load all relevant sprites
        // add cosmetic values to CharacterAttributes Dictionaries
        CreateCosmeticsDictionary();
        
        // add colors for hair
        hairColors = new Color[10];
        CreateHairColors();
        // TODO: make dynamic!!
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

        // Player is created first, so this is true
        isPlayer = true;

        createButtonText.text = "Create Player";
        
        // change determines if the user had changed the value
        change = false;

        eventSystem.SetSelectedGameObject(femButton.gameObject);
        setAsBodyType(femButton); // ************************************************* TODO: temporary fix!!! //

        // Listeners: Keyboard keys
        ButtonQ.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonQ.GetComponentInChildren<Text>().text); });
        ButtonW.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonW.GetComponentInChildren<Text>().text); });
        ButtonE.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonE.GetComponentInChildren<Text>().text); });
        ButtonR.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonR.GetComponentInChildren<Text>().text); });
        ButtonT.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonT.GetComponentInChildren<Text>().text); });
        ButtonY.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonY.GetComponentInChildren<Text>().text); });
        ButtonU.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonU.GetComponentInChildren<Text>().text); });
        ButtonI.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonI.GetComponentInChildren<Text>().text); });
        ButtonO.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonO.GetComponentInChildren<Text>().text); });
        ButtonP.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonP.GetComponentInChildren<Text>().text); });
        ButtonA.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonA.GetComponentInChildren<Text>().text); });
        ButtonS.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonS.GetComponentInChildren<Text>().text); });
        ButtonD.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonD.GetComponentInChildren<Text>().text); });
        ButtonF.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonF.GetComponentInChildren<Text>().text); });
        ButtonG.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonG.GetComponentInChildren<Text>().text); });
        ButtonH.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonH.GetComponentInChildren<Text>().text); });
        ButtonJ.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonJ.GetComponentInChildren<Text>().text); });
        ButtonK.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonK.GetComponentInChildren<Text>().text); });
        ButtonL.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonL.GetComponentInChildren<Text>().text); });
        ButtonZ.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonZ.GetComponentInChildren<Text>().text); });
        ButtonX.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonX.GetComponentInChildren<Text>().text); });
        ButtonC.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonC.GetComponentInChildren<Text>().text); });
        ButtonV.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonV.GetComponentInChildren<Text>().text); });
        ButtonB.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonB.GetComponentInChildren<Text>().text); });
        ButtonN.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonN.GetComponentInChildren<Text>().text); });
        ButtonM.onClick.AddListener(delegate { AddToKeyboardInputField(ButtonM.GetComponentInChildren<Text>().text); });

        // Listeners: Keyborad functions
        ButtonEditName.onClick.AddListener(delegate { OpenKeyboardCanvas(); });
        ButtonOk.onClick.AddListener(delegate { NameConfirmed(); });
        ButtonBackspace.onClick.AddListener(delegate { Backspace(); });
        keyboardTextField.text = "";

        // Listeners: Pronoun
        ButtonSheHer.onClick.AddListener(delegate { setAsPronoun(ButtonSheHer); });
        ButtonTheyThem.onClick.AddListener(delegate { setAsPronoun(ButtonTheyThem); });
        ButtonHeHim.onClick.AddListener(delegate { setAsPronoun(ButtonHeHim); });

        // Listeners: CisTrans
        ButtonCis.onClick.AddListener(delegate { setAsCisOrTrans(ButtonCis); } );
        ButtonTrans.onClick.AddListener(delegate { setAsCisOrTrans(ButtonTrans); });
    }

    void OpenKeyboardCanvas()
    {
        finishingTouchesCanvas.SetActive(false);
        keyboardCanvas.SetActive(true);
        eventSystem.SetSelectedGameObject(ButtonQ.gameObject);
    }

    void AddToKeyboardInputField(string key)
    {
        if(keyboardTextField.text.Length > 0)
        {
            keyboardTextField.text += "" + key.ToLower();
        }
        else
        {
            keyboardTextField.text += "" + key;
        }
    }

    void NameConfirmed()
    {
        nameInput.text = keyboardTextField.text;
        keyboardCanvas.SetActive(false);
        finishingTouchesCanvas.SetActive(true);
        AssignNameToCharacter(nameInput.text);
        eventSystem.SetSelectedGameObject(ButtonEditName.gameObject);
    }

    void Backspace()
    {
        if(keyboardTextField.text.Length > 0)
        {
            keyboardTextField.text = keyboardTextField.text.Substring(0, keyboardTextField.text.Length - 1);
        }
    }

    void AssignNameToCharacter(string name)
    {
        if (isPlayer)
        {
            playerName = name;
        }
        else
        {
            paramourName = name;
        }
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

    void HighlightSelectedBody(Button bodySelected)
    {
        ColorBlock colorBlockFem = femButton.colors;
        ColorBlock colorBlockNon = nonButton.colors;
        ColorBlock colorBlockMas = masButton.colors;

        switch (bodySelected.name){
            case "FemButton":
                colorBlockFem.normalColor = Color.green;
                femButton.colors = colorBlockFem;

                colorBlockNon.normalColor = Color.white;
                nonButton.colors = colorBlockNon;

                colorBlockMas.normalColor = Color.white;
                masButton.colors = colorBlockMas;
                break;
            case "NonButton":
                colorBlockFem.normalColor = Color.white;
                femButton.colors = colorBlockFem;

                colorBlockNon.normalColor = Color.green;
                nonButton.colors = colorBlockNon;

                colorBlockMas.normalColor = Color.white;
                masButton.colors = colorBlockMas;
                break;
            case "MasButton":
                colorBlockFem.normalColor = Color.white;
                femButton.colors = colorBlockFem;

                colorBlockNon.normalColor = Color.white;
                nonButton.colors = colorBlockNon;

                colorBlockMas.normalColor = Color.green;
                masButton.colors = colorBlockMas;
                break;
        }
    }
    
    void HightlightPronoun(Button pronounSelected)
    {
        ColorBlock colorBlockSheHer = ButtonSheHer.colors;
        ColorBlock colorBlockTheyThem = ButtonTheyThem.colors;
        ColorBlock colorBlockHeHim = ButtonHeHim.colors;

        switch (pronounSelected.name)
        {
            case "She/Her":
                colorBlockSheHer.normalColor = Color.green;
                ButtonSheHer.colors = colorBlockSheHer;

                colorBlockTheyThem.normalColor = Color.white;
                ButtonTheyThem.colors = colorBlockTheyThem;

                colorBlockHeHim.normalColor = Color.white;
                ButtonHeHim.colors = colorBlockHeHim;
                break;
            case "They/Them":
                colorBlockSheHer.normalColor = Color.white;
                ButtonSheHer.colors = colorBlockSheHer;

                colorBlockTheyThem.normalColor = Color.green;
                ButtonTheyThem.colors = colorBlockTheyThem;

                colorBlockHeHim.normalColor = Color.white;
                ButtonHeHim.colors = colorBlockHeHim;
                break;
            case "He/Him":
                colorBlockSheHer.normalColor = Color.white;
                ButtonSheHer.colors = colorBlockSheHer;

                colorBlockTheyThem.normalColor = Color.white;
                ButtonTheyThem.colors = colorBlockTheyThem;

                colorBlockHeHim.normalColor = Color.green;
                ButtonHeHim.colors = colorBlockHeHim;
                break;
        }
    }

    void HighlightCisOrTrans(Button selected)
    {
        ColorBlock colorBlockCis = ButtonCis.colors;
        ColorBlock colorBlockTrans = ButtonTrans.colors;

        switch (selected.name)
        {
            case "Cis":
                colorBlockCis.normalColor = Color.green;
                ButtonCis.colors = colorBlockCis;

                colorBlockTrans.normalColor = Color.white;
                ButtonTrans.colors = colorBlockTrans;

                break;
            case "Trans":
                colorBlockCis.normalColor = Color.white;
                ButtonCis.colors = colorBlockCis;

                colorBlockTrans.normalColor = Color.green;
                ButtonTrans.colors = colorBlockTrans;

                break;
        }
    }

    void SetPronounHighlightToDefault()
    {
        ColorBlock colorBlockSheHer = ButtonSheHer.colors;
        ColorBlock colorBlockTheyThem = ButtonTheyThem.colors;
        ColorBlock colorBlockHeHim = ButtonHeHim.colors;

        colorBlockSheHer.normalColor = Color.white;
        ButtonSheHer.colors = colorBlockSheHer;

        colorBlockTheyThem.normalColor = Color.white;
        ButtonTheyThem.colors = colorBlockTheyThem;

        colorBlockHeHim.normalColor = Color.white;
        ButtonHeHim.colors = colorBlockHeHim;
                
    }

    void SetCisOrTransHighlightToDefault()
    {
        ColorBlock colorBlockCis = ButtonCis.colors;
        ColorBlock colorBlockTrans = ButtonTrans.colors;
        
        colorBlockCis.normalColor = Color.white;
        ButtonCis.colors = colorBlockCis;

        colorBlockTrans.normalColor = Color.white;
        ButtonTrans.colors = colorBlockTrans;
    }


    // Select Body Type for Main Character
    public void setAsBodyType(Button bodySelected) {
        // todo: keep image background color of choice selected
        bodyType = bodySelected.GetComponentInChildren<Image>();
        HighlightSelectedBody(bodySelected);
        eventSystem.SetSelectedGameObject(bodySelected.gameObject);
    }

    public void setAsPronoun(Button pr) {
        switch(pr.name)
        {
            case "He/Him":
                pronounInt =  cosmetics["pronouns"][0];
                HightlightPronoun(pr);
                break;
            case "She/Her":
                pronounInt = cosmetics["pronouns"][1];
                HightlightPronoun(pr);
                break;
            case "They/Them":
                pronounInt = cosmetics["pronouns"][2];
                HightlightPronoun(pr);
                break;
            default:
                pronounInt = 0;
                break;
        }
    }

    public void setAsCisOrTrans(Button ct) {
        switch(ct.name)
        {
            case "Cis":
                cisOrTransInt = cosmetics["cisOrTrans"][0];
                HighlightCisOrTrans(ct);
                break;
            case "Trans":
                cisOrTransInt = cosmetics["cisOrTrans"][1];
                HighlightCisOrTrans(ct);
                break;
        }
    }

    public void goToFullBodyCanvas() {
        goToNextCanvas = true;
        loadFullBodyCanvas();
    }

    public void goToFinishingTouchesCanvas() {
        goToNextCanvas = true;
        loadFinishingTouchesCanvas();
        eventSystem.SetSelectedGameObject(ButtonEditName.gameObject);
    }

    public void loadFullBodyCanvas() {
        fullBodyCanvas.SetActive(true);
        selectingBodyTypeCanvas.SetActive(false);
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
        eventSystem.SetSelectedGameObject(hairPrvBtn.gameObject);
    }

    // load Canvas where player puts in name and selects pronoun/cis-trans option
    public void loadFinishingTouchesCanvas()
    {
        finishingTouchesCanvas.SetActive(true);
        fullBodyCanvas.SetActive(false);

        goToNextCanvas = false;
    }

    public void goBack(Button btn){
        if(btn.name.Equals("BackToSelectingBody")){
            fullBodyCanvas.SetActive(false);
            selectingBodyTypeCanvas.SetActive(true);
            fullBodySpriteCanvas.SetActive(false);
            eventSystem.SetSelectedGameObject(femButton.gameObject);
        }
        else if(btn.name.Equals("BackToFullBody")){
            fullBodyCanvas.SetActive(true);
            finishingTouchesCanvas.SetActive(false);
            eventSystem.SetSelectedGameObject(hairPrvBtn.gameObject);
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

        PlayerSelectedAttributes.PlaySelectedSkinColorPos = skinColorPos;   // skin color pos selected
        PlayerSelectedAttributes.PlaySelectedHairPos = hairPos;             // hair pos selected

        PlayerSelectedAttributes.PlaySelectedName = playerName;
        PlayerSelectedAttributes.PlaySelectedCisOrTransInt = cisOrTransInt;
        PlayerSelectedAttributes.PlaySelectedPronounInt = pronounInt;

        CreateStoryInt();
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

        ParamourSelectedAttributes.LoveSelectedName = paramourName;
        ParamourSelectedAttributes.LoveSelectedCisOrTransInt = cisOrTransInt;
        ParamourSelectedAttributes.LoveSelectedPronounInt = pronounInt;
    }

    public void resetForLover() {
        hairPos = 0;
        skinPos = 0;
        hairColorPos = 0;
        shirtColorPos = 0;
        pantsColorPos = 0;
        cisOrTransInt = 0;
        pronounInt = 0;
        selectingBodyTypeCanvas.SetActive(true);
        eventSystem.SetSelectedGameObject(femButton.gameObject);
        SetPronounHighlightToDefault();
        SetCisOrTransHighlightToDefault();
        fullBodyCanvas.SetActive(false);
        fullBodySpriteCanvas.SetActive(false);
        finishingTouchesCanvas.SetActive(false);
        isPlayer = false;

        // set Text titles to Paramour
        selectingBodyTitle.text = "Select Paramour's Body Type";
        creatingCharTitle.text = "Create Your Paramour";
        createButtonText.text = "Create Paramour";
        createYourPlayerText.text = "Create Your Paramour";
        playerNameFinishingTouchesText.text = "Paramour's Name";
    }

    private void CreateStoryInt()
    {
        // start with skin choice
        switch (PlayerSelectedAttributes.PlaySelectedSkinColorPos)
        {
            case 0: // white
                switch (PlayerSelectedAttributes.PlaySelectedCisOrTransInt)
                {
                    case 1: // cis
                        switch (PlayerSelectedAttributes.PlaySelectedPronounInt)
                        {
                            case 1: // he
                                PlayerSelectedAttributes.StoryChoice = 1;
                                break;
                            case 2: // she
                                PlayerSelectedAttributes.StoryChoice = 2;
                                break;
                            default:
                                PlayerSelectedAttributes.StoryChoice = 6;
                                break;
                        }
                        break;
                    case 2: // trans
                        PlayerSelectedAttributes.StoryChoice = 3;
                        break;
                    default:
                        PlayerSelectedAttributes.StoryChoice = 6;
                        break;
                }
                break;
            case 1: // any other skin color
            case 2:
            case 3:
                switch (PlayerSelectedAttributes.PlaySelectedCisOrTransInt)
                {
                    case 1: // cis
                        switch (PlayerSelectedAttributes.PlaySelectedPronounInt)
                        {
                            case 1:
                                PlayerSelectedAttributes.StoryChoice = 4;
                                break;
                            case 2:
                                PlayerSelectedAttributes.StoryChoice = 5;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2: // trans
                        PlayerSelectedAttributes.StoryChoice = 6;
                        break;
                }
                break;
            default:
                PlayerSelectedAttributes.StoryChoice = 6;
                break;
        }
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
