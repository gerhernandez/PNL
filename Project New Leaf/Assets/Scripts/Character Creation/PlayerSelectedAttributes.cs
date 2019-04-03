using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSelectedAttributes{
    // all things static
    // Sprites
    private static Sprite playSelectedHair = null;
    private static Sprite p1aySelectedSkin = null;
    private static Sprite p1aySelectedShirt = null;
    private static Sprite p1aySelectedPants = null;
    private static Sprite playSelectedLineart = null;
    private static Sprite playSelectedSkinShading = null;
    private static Sprite playSelectedClothShading = null;

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

    public static Sprite PlaySelectedHair
    { get; set; }

    public static Sprite PlaySelectedSkin
    { get; set; }

    public static Sprite PlaySelectedShirt
    { get; set; }

    public static Sprite PlaySelectedPants
    { get; set; }

    public static Sprite PlaySelectedLineart
    { get; set; }

    public static Sprite PlaySelectedSkinShading
    { get; set; }

    public static Sprite PlaySelectedClothShading
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
