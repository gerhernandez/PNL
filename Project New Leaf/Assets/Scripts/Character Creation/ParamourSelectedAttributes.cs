using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamourSelectedAttributes : MonoBehaviour {
    // all things static
    // Sprites
    private static SpriteRenderer loveSelectedHair;
    private static SpriteRenderer loveSelectedSkin;
    private static SpriteRenderer loveSelectedShirt;
    private static SpriteRenderer loveSelectedPants;
    private static SpriteRenderer loveSelectedLineart;
    private static SpriteRenderer loveSelectedSkinShading;
    private static SpriteRenderer loveSelectedClothShading;

    // colors of Sprites
    private static Color loveSelectedSkinColor;
    private static Color loveSelectedHairColor;
    private static Color loveSelectedShirtColor;
    private static Color loveSelectedPantsColor;

    // int
    private static int loveSelectedSkinPos = 0;
    private static int loveSelectedHairPos = 0;
    private static int loveSelectedSkinColorPos = 0;
    private static int loveSelectedHairColorPos = 0;
    private static int loveSelectedShirtColorPos = 0;
    private static int loveSelectedPantsColorPos = 0;
    private static int loveSelectedCisOrTransInt = 0;
    private static int loveSelectedPronounInt = 0;

    public SpriteRenderer LoveSelectedHair
    { get; set; }

    public SpriteRenderer LoveSelectedSkin
    { get; set; }

    public SpriteRenderer LoveSelectedShirt
    { get; set; }

    public SpriteRenderer LoveSelectedPants
    { get; set; }

    public SpriteRenderer LoveSelectedLineart
    { get; set; }

    public SpriteRenderer LoveSelectedSkinShading
    { get; set; }

    public SpriteRenderer LoveSelectedClothShading
    { get; set; }

    public Color LoveSelectedSkinColor
    { get; set; }

    public Color LoveSelectedHairColor
    { get; set; }

    public Color LoveSelectedShirtColor
    { get; set; }

    public Color LoveSelectedPantsColor
    { get; set; }

    public int LoveSelectedSkinPos
    { get; set; }

    public int LoveSelectedHairPos
    { get; set; }

    public int LoveSelectedSkinColorPos
    { get; set; }

    public int LoveSelectedHairColorPos
    { get; set; }

    public int LoveSelectedShirtColorPos
    { get; set; }

    public int LoveSelectedPantsColorPos
    { get; set; }

    public int LoveSelectedCisOrTransInt
    { get; set; }

    public int LoveSelectedPronounInt
    { get; set; }
}
