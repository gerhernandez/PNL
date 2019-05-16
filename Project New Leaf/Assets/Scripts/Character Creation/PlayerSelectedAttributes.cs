using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSelectedAttributes{
    // all things static
    // Sprites
    private static Sprite playSelectedHair = null; //1
    private static Sprite p1aySelectedSkin = null; //2
    private static Sprite p1aySelectedShirt = null; //3
    private static Sprite p1aySelectedPants = null; //4
    private static Sprite playSelectedLineart = null; //5
    private static Sprite playSelectedSkinShading = null; //6
    private static Sprite playSelectedClothShading = null; //7
    // make arrays of Sprites

    // colors of Sprites
    private static Color playSelectedSkinColor; // 1
    private static Color playSelectedHairColor; // 2
    private static Color playSelectedShirtColor; // 3
    private static Color playSelectedPantsColor; // 4
    // make arrays of Color

    // int
    private static int playSelectedSkinPos = 0; // 1
    private static int playSelectedHairPos = 0; // 2
    private static int playSelectedSkinColorPos = 0; // 3
    private static int playSelectedHairColorPos = 0; // 4
    private static int playSelectedShirtColorPos = 0; // 5
    private static int playSelectedPantsColorPos = 0; // 6
    private static int playSelectedCisOrTransInt = 0; // 7
    private static int playSelectedPronounInt = 0; // 8
    private static int playSelectedBodyType = 0;

    private static int storyChoice;

    private static string playSelectedName = "";
    
    public static int StoryChoice
    { get; set; }

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

    public static int PlaySelectedBodyType
    { get; set; }

    public static string PlaySelectedName
    { get; set; }
}
