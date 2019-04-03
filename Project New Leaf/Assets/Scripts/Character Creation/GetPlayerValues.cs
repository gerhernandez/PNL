using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetPlayerValues : MonoBehaviour {
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

    public bool loadPlayer;
    public bool loadParamour;
    // Start
    void Start()
    {
        playerName.text = "Name: ";
        playPronoun.text = "Pronoun: ";
        playCisTran.text = "Cis/Trans: ";
    }

    public void Update()
    {
        if (PlayerSelectedAttributes.PlaySelectedHair != null)
        {
            Debug.Log("!!!!!!!!!!loading... ");
            LoadPlayer();
            
            Debug.Log("Confirmation Hair: " + PlayerSelectedAttributes.PlaySelectedHair.name);
        }

        if (ParamourSelectedAttributes.LoveSelectedHair != null)
            LoadParamour();
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
}
