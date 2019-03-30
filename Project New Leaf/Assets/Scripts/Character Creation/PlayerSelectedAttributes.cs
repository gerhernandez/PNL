using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectedAttributes : MonoBehaviour {
    // all things static
    // Sprites
    private static SpriteRenderer playSelectedHair;
    private static SpriteRenderer p1aySelectedSkin;
    private static SpriteRenderer p1aySelectedShirt;
    private static SpriteRenderer p1aySelectedPants;
    private static SpriteRenderer playSelectedLineart;
    private static SpriteRenderer playSelectedSkinShading;
    private static SpriteRenderer playSelectedClothShading;

    // colors of Sprites
    private static Color playSelectedSkinColor;
    private static Color playSelectedHairColor;
    private static Color playSelectedShirtColor;
    private static Color playSelectedPantsColor;

    // int
    private static int playSelectedSkinPos = 0;
    private static int playSelectedHairPos = 0;
    private static int playSelectedSkinColorPos = 0;
    private static int playSelectedHairColorPos = 0;
    private static int playSelectedShirtColorPos = 0;
    private static int playSelectedPantsColorPos = 0;
    private static int playSelectedCisOrTransInt = 0;
    private static int playSelectedPronounInt = 0;

    public SpriteRenderer PlaySelectedHair
    { get; set; }

    public SpriteRenderer PlaySelectedSkin
    { get; set; }

    public SpriteRenderer PlaySelectedShirt
    { get; set; }

    public SpriteRenderer PlaySelectedPants
    { get; set; }

    public SpriteRenderer PlaySelectedLineart
    { get; set; }

    public SpriteRenderer PlaySelectedSkinShading
    { get; set; }

    public SpriteRenderer PlaySelectedClothShading
    { get; set; }

    public Color PlaySelectedSkinColor
    { get; set; }

    public Color PlaySelectedHairColor
    { get; set; }

    public Color PlaySelectedShirtColor
    { get; set; }

    public Color PlaySelectedPantsColor
    { get; set; }

    public int PlaySelectedSkinPos
    { get; set; }

    public int PlaySelectedHairPos
    { get; set; }

    public int PlaySelectedSkinColorPos
    { get; set; }

    public int PlaySelectedHairColorPos
    { get; set; }

    public int PlaySelectedShirtColorPos
    { get; set; }

    public int PlaySelectedPantsColorPos
    { get; set; }

    public int PlaySelectedCisOrTransInt
    { get; set; }

    public int PlaySelectedPronounInt
    { get; set; }
}
