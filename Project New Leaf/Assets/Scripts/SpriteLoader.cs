using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader : MonoBehaviour {

    // player's selected attributes
    public SpriteRenderer playHair = null;
    public SpriteRenderer playLine;
    public SpriteRenderer playSkinShade;
    public SpriteRenderer playClothShade;
    public SpriteRenderer playSkin;
    public SpriteRenderer playShirt;
    public SpriteRenderer playPants;

    // paramour's selected attributes
    public SpriteRenderer loveHair;
    public SpriteRenderer loveLine;
    public SpriteRenderer loveSkinShade;
    public SpriteRenderer loveClothShade;
    public SpriteRenderer loveSkin;
    public SpriteRenderer loveShirt;
    public SpriteRenderer lovePants;

    private void Start()
    {
        LoadPlayer();
        LoadParamour();
    }

    public void LoadPlayer()
    {
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
