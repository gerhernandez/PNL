using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSelectedAttributes{
    // all things static
    // Sprites
    private static SpriteRenderer playSelectedHair = null;
    private static SpriteRenderer p1aySelectedSkin = null;
    private static SpriteRenderer p1aySelectedShirt = null;
    private static SpriteRenderer p1aySelectedPants = null;
    private static SpriteRenderer playSelectedLineart = null;
    private static SpriteRenderer playSelectedSkinShading = null;
    private static SpriteRenderer playSelectedClothShading = null;

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

    private static string playSelectedName = "";

    public static SpriteRenderer PlaySelectedHair
    { get; set; }

    public static SpriteRenderer PlaySelectedSkin
    { get; set; }

    public static SpriteRenderer PlaySelectedShirt
    { get; set; }

    public static SpriteRenderer PlaySelectedPants
    { get; set; }

    public static SpriteRenderer PlaySelectedLineart
    { get; set; }

    public static SpriteRenderer PlaySelectedSkinShading
    { get; set; }

    public static SpriteRenderer PlaySelectedClothShading
    { get; set; }

    public static Color PlaySelectedSkinColor
    { get; set; }

    public static Color PlaySelectedHairColor
    { get; set; }

    public static Color PlaySelectedShirtColor
    { get; set; }

    public static Color PlaySelectedPantsColor
    { get; set; }

    public static int PlaySelectedSkinPos
    { get; set; }

    public static int PlaySelectedHairPos
    { get; set; }

    public static int PlaySelectedSkinColorPos
    { get; set; }

    public static int PlaySelectedHairColorPos
    { get; set; }

    public static int PlaySelectedShirtColorPos
    { get; set; }

    public static int PlaySelectedPantsColorPos
    { get; set; }

    public static int PlaySelectedCisOrTransInt
    { get; set; }

    public static int PlaySelectedPronounInt
    { get; set; }

    public static string PlaySelectedName
    { get; set; }
}
