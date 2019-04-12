using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetPlayerValues : MonoBehaviour {
    public Text storyChoiceText;

    // player's selected attributes
    public Text playerName;
    public Text playPronoun;
    public Text playCisTran;
    public SpriteRenderer playHair;
    public SpriteRenderer playLine;
    public SpriteRenderer playSkinShade;
    public SpriteRenderer playClothShade;
    public SpriteRenderer playSkin;
    public SpriteRenderer playShirt;
    public SpriteRenderer playPants;

    // paramour's selected attributes
    public Text loveName;
    public Text lovePronoun;
    public Text loveCisTran;
    public SpriteRenderer loveHair;
    public SpriteRenderer loveLine;
    public SpriteRenderer loveSkinShade;
    public SpriteRenderer loveClothShade;
    public SpriteRenderer loveSkin;
    public SpriteRenderer loveShirt;
    public SpriteRenderer lovePants;

    private int storyChoice;

    public bool loadPlayer;
    public bool loadParamour;

    // Start
    void Start()
    {
        storyChoiceText.text = "Story Choice: ";
        storyChoice = 0;
        
        playerName.text = "Name: ";
        playPronoun.text = "Pronoun: ";
        playCisTran.text = "Cis/Trans: ";

        loveName.text = "Name: ";
        lovePronoun.text = "Pronoun: ";
        loveCisTran.text = "Cis/Trans: ";

        if (PlayerSelectedAttributes.PlaySelectedHair != null)
        {
            LoadPlayer();
            
            // select Player story
            selectPlayerStory();
        }

        if (ParamourSelectedAttributes.LoveSelectedHair != null)
        {
            LoadParamour();
        }

        
    }
    
    public void Update()
    {
        
    }
    
    public void LoadPlayer() {
        playerName.text = "Name: " + PlayerSelectedAttributes.PlaySelectedName;
        playPronoun.text = "Pronoun: " + PlayerSelectedAttributes.PlaySelectedPronounInt;
        playCisTran.text = "Cis/Trans: " + PlayerSelectedAttributes.PlaySelectedCisOrTransInt;

        playHair.sprite = PlayerSelectedAttributes.PlaySelectedHair;
        playLine.sprite = PlayerSelectedAttributes.PlaySelectedLineart;
        playSkinShade.sprite = PlayerSelectedAttributes.PlaySelectedSkinShading;
        playClothShade.sprite = PlayerSelectedAttributes.PlaySelectedClothShading;
        playSkin.sprite = PlayerSelectedAttributes.PlaySelectedSkin;
        playShirt.sprite = PlayerSelectedAttributes.PlaySelectedShirt;
        playPants.sprite = PlayerSelectedAttributes.PlaySelectedPants;

        playSkin.color = PlayerSelectedAttributes.PlaySelectedSkinColor;
        playHair.color = PlayerSelectedAttributes.PlaySelectedHairColor;
        playShirt.color = PlayerSelectedAttributes.PlaySelectedShirtColor;
        playPants.color = PlayerSelectedAttributes.PlaySelectedPantsColor;
    }

    public void LoadParamour()
    {
        loveName.text = "Name: " + ParamourSelectedAttributes.LoveSelectedName;
        lovePronoun.text = "Pronoun: " + ParamourSelectedAttributes.LoveSelectedPronounInt;
        loveCisTran.text = "Cis/Trans: " + ParamourSelectedAttributes.LoveSelectedCisOrTransInt;

        loveHair.sprite = ParamourSelectedAttributes.LoveSelectedHair;
        loveLine.sprite = ParamourSelectedAttributes.LoveSelectedLineart;
        loveSkinShade.sprite = ParamourSelectedAttributes.LoveSelectedSkinShading;
        loveClothShade.sprite = ParamourSelectedAttributes.LoveSelectedClothShading;
        loveSkin.sprite = ParamourSelectedAttributes.LoveSelectedSkin;
        loveShirt.sprite = ParamourSelectedAttributes.LoveSelectedShirt;
        lovePants.sprite = ParamourSelectedAttributes.LoveSelectedPants;

        loveSkin.color = ParamourSelectedAttributes.LoveSelectedSkinColor;
        loveHair.color = ParamourSelectedAttributes.LoveSelectedHairColor;
        loveShirt.color = ParamourSelectedAttributes.LoveSelectedShirtColor;
        lovePants.color = ParamourSelectedAttributes.LoveSelectedPantsColor;
    }

    // select the story based on number
    private void selectPlayerStory()
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
                                storyChoice = 1;
                                break;
                            case 2: // she
                                storyChoice = 2;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2: // trans
                        storyChoice = 3;
                        break;
                    default:
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
                                storyChoice = 4;
                                break;
                            case 2:
                                storyChoice = 5;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2: // trans
                        storyChoice = 6;
                        break;
                }
                break;
            default:
                break;
        }
        
        // display story text
        storyChoiceText.text = "Story Choice:  " + storyChoice;
    }

    public int getStoryChoice()
    {
        return storyChoice;
    }
}
