using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttributes : MonoBehaviour {
    // Hair ------------------ Image and Sprites

    // Male
    public Sprite[] Male_hair;

    // Female
    public Sprite[] Female_hair;

    // NonBinary
    public Sprite[] NB_hair;

    // Hair Color array
    public Color[] hairColors;

    // Hair Color
    public Color hairColor0;    // darkBlue;    = 0x17 2d 75
    public Color hairColor1;    // darkOrange;  = 0xbc4b06
    public Color hairColor2;    // hayYellow;   = 0xdbc250
    public Color hairColor3;    // black        = 0x151413
    public Color hairColor4;    // darkBrown    = 0x3d2e25
    public Color hairColor5;    // peach        = 0xf69679
    public Color hairColor6;    // pink         = 0xf5989d
    public Color hairColor7;    // darkRed      = 0x9e0b0f
    public Color hairColor8;    // cyanBlue     = 0x36f1cd
    public Color hairColor9;    // purple       = 0x92278f

    public SpriteRenderer shirt;

    public Color[] shirtColors;

    // Shirt Colors
    public Color shirtColor0;   // lightGrey    = 0xe8e7dd
    public Color shirtColor1;   // yellow       =  0xe6cf23
    public Color shirtColor2;   // darkGrey     = 0x2a2629
    public Color shirtColor3;   // lightMagenta = 0xffd3f4
    public Color shirtColor4;   // darkLilac    = 0x412e5f
    public Color shirtColor5;   // darkPink     = 0xa5243a
    public Color shirtColor6;   // orange       = 0xe87934
    public Color shirtColor7;   // babyBlue     = 0x91b2ff
    public Color shirtColor8;   // lightGreen   = 0xa2c3a4

    /*
    // original list
    int[] race = {1,2,3,4};
    int[] cisOrTrans = {1,2};
    int[] pronouns = {1,2,3};
	int[] hair = {1,2,3,4};
    int[] head = {1,2,3,4};
	int[] tops = {1,2};
    int[] body = {1,2,3,4};
	int[] bottoms = {1,2,3,4};
    int[] lower = {1,2,3};
    */

    int[] race = { 1, 2, 3, 4 };
    int[] cisOrTrans = { 1, 2 };
    int[] pronouns = { 1, 2, 3 };
    int[] body = { 1, 2, 3 };
    int[] hair = new int[19];
    int[] tops = { 1, 2, 3 };
    int[] legs = { 1, 2, 3, 4 };

    public Dictionary<string, int[]> cosmetics = new Dictionary<string, int[]>();

    public void CreateCosmetics() {
        cosmetics.Add("race", race);
        cosmetics.Add("cisOrTrans", cisOrTrans);
        cosmetics.Add("pronouns", pronouns);

        // ----- Hair int values ----
        for (int i = 0; i < 19; i++)
        { hair[i] = i; }
        cosmetics.Add("hair", hair);
        // --------------------------

        cosmetics.Add("tops", tops);
        cosmetics.Add("body", body);
        cosmetics.Add("leg", legs);
    }

    public void CreateHairColors()
    {
        // Hair Color
        ColorUtility.TryParseHtmlString("#172d75", out hairColor0);    // darkBlue
        ColorUtility.TryParseHtmlString("#bc4b06", out hairColor1);    // darkOrange
        ColorUtility.TryParseHtmlString("#dbc250", out hairColor2);    // hayYellow
        ColorUtility.TryParseHtmlString("#151413", out hairColor3);    // black
        ColorUtility.TryParseHtmlString("#3d2e25", out hairColor4);    // darkBrown
        ColorUtility.TryParseHtmlString("#f69679", out hairColor5);    // peach
        ColorUtility.TryParseHtmlString("#f5989d", out hairColor6);    // pink
        ColorUtility.TryParseHtmlString("#9e0b0f", out hairColor7);    // darkRed
        ColorUtility.TryParseHtmlString("#36f1cd", out hairColor8);    // cyanBlue
        ColorUtility.TryParseHtmlString("#92278f", out hairColor9);    // purple
    }

    public void CreateShirtColors()
    {
        // Shirt Colors
        ColorUtility.TryParseHtmlString("#e8e7dd", out shirtColor0);   // lightGrey
        ColorUtility.TryParseHtmlString("#e6cf23", out shirtColor1);   // yellow
        ColorUtility.TryParseHtmlString("#2a2629", out shirtColor2);   // darkGrey
        ColorUtility.TryParseHtmlString("#ffd3f4", out shirtColor3);   // lightMagenta
        ColorUtility.TryParseHtmlString("#412e5f", out shirtColor4);   // darkLilac
        ColorUtility.TryParseHtmlString("#a5243a", out shirtColor5);   // darkPink
        ColorUtility.TryParseHtmlString("#e87934", out shirtColor6);   // orange
        ColorUtility.TryParseHtmlString("#91b2ff", out shirtColor7);    // babyBlue
        ColorUtility.TryParseHtmlString("#a2c3a4", out shirtColor8);    // lightGreen
    }

    public void LoadHairSprites()
    {
        Male_hair = Resources.LoadAll<Sprite>("Sprites/Male/Hairstyles");
        Female_hair = Resources.LoadAll<Sprite>("Sprites/Male/Hairstyles");
        NB_hair = Resources.LoadAll<Sprite>("Sprites/NonBinary/Hairstyles");
    }
}
