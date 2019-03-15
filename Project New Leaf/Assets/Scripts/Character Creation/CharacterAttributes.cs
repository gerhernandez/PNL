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
    int[] legs = { 1, 2, 3 };

    // int arrays for colors
    int[] hairColorInts = new int[10];
    int[] shirtColorInts = new int[9];
    //int[] pantsColorInts = new int[5];

    public Dictionary<string, int[]> cosmetics = new Dictionary<string, int[]>();

    public void CreateCosmetics() {
        cosmetics.Add("race", race);
        cosmetics.Add("cisOrTrans", cisOrTrans);
        cosmetics.Add("pronouns", pronouns);
        cosmetics.Add("body", body);
        
        // ----- Hair int values ----
        for (int i = 0; i < 19; i++)
        { hair[i] = i; }
        cosmetics.Add("hair", hair);

        for (int i = 0; i < 10; i++)
        { hairColorInts[i] = i; }
        cosmetics.Add("hairColor", hairColorInts);
        // --------------------------

        // ---- Shirt int values -----
        cosmetics.Add("tops", tops);

        for (int i = 0; i < 9; i++)
        { shirtColorInts[i] = i; }
        cosmetics.Add("shirtColor", shirtColorInts);
        // --------------------------

        // ---- Pants int values ----
        cosmetics.Add("leg", legs);
        /*(
        for (int i = 0; i < 6; i++)
        { pantsColorInts[i] = i; }
        cosmetics.Add("pantsColor", pantsColorInts);*/
        // --------------------------

    }
    
    public void CreateHairColors()
    {
        Debug.Log("Length of hairColors: " + hairColors.Length);

        // Hair Color
        if (ColorUtility.TryParseHtmlString("#172d75", out hairColor0)) // darkBlue
        { hairColors[0] = hairColor0; }
        if (ColorUtility.TryParseHtmlString("#bc4b06", out hairColor1)) // darkOrange
        { hairColors[1] = hairColor1; }
        if (ColorUtility.TryParseHtmlString("#dbc250", out hairColor2)) // hayYellow
        { hairColors[2] = hairColor2; }
        if (ColorUtility.TryParseHtmlString("#151413", out hairColor3)) // black
        { hairColors[3] = hairColor3; }
        if (ColorUtility.TryParseHtmlString("#3d2e25", out hairColor4)) // darkBrown
        { hairColors[4] = hairColor4; }
        if (ColorUtility.TryParseHtmlString("#f69679", out hairColor5)) // peach
        { hairColors[5] = hairColor5; }
        if (ColorUtility.TryParseHtmlString("#f5989d", out hairColor6)) // pink
        { hairColors[6] = hairColor6; }
        if (ColorUtility.TryParseHtmlString("#9e0b0f", out hairColor7)) // darkRed
        { hairColors[7] = hairColor7; }
        if (ColorUtility.TryParseHtmlString("#36f1cd", out hairColor8)) // cyanBlue
        { hairColors[8] = hairColor8; }
        if (ColorUtility.TryParseHtmlString("#92278f", out hairColor9)) // purple
        { hairColors[9] = hairColor9; }
        Debug.Log("Length of hairColors: " + hairColors.Length);
    }

    public void CreateShirtColors()
    {
        // Shirt Colors
        if (ColorUtility.TryParseHtmlString("#e8e7dd", out shirtColor0)) // lightGrey
        { shirtColors[0] = shirtColor0; }
        if (ColorUtility.TryParseHtmlString("#e6cf23", out shirtColor1)) // yellow
        { shirtColors[1] = shirtColor1; }
        if (ColorUtility.TryParseHtmlString("#2a2629", out shirtColor2)) // darkGrey
        { shirtColors[2] = shirtColor2; }
        if (ColorUtility.TryParseHtmlString("#ffd3f4", out shirtColor3)) // lightMagenta
        { shirtColors[3] = shirtColor3; }
        if (ColorUtility.TryParseHtmlString("#412e5f", out shirtColor4)) // darkLilac
        { shirtColors[4] = shirtColor4; }
        if (ColorUtility.TryParseHtmlString("#a5243a", out shirtColor5)) // darkPink
        { shirtColors[5] = shirtColor5; }
        if (ColorUtility.TryParseHtmlString("#e87934", out shirtColor6)) // orange
        { shirtColors[6] = shirtColor6; }
        if (ColorUtility.TryParseHtmlString("#91b2ff", out shirtColor7)) // babyBlue
        { shirtColors[7] = shirtColor7; }
        if (ColorUtility.TryParseHtmlString("#a2c3a4", out shirtColor8)) // lightGreen
        { shirtColors[8] = shirtColor8; }
    }
    
    public void LoadHairSprites()
    {
        Male_hair = Resources.LoadAll<Sprite>("Sprites/Male/Hairstyles");
        Female_hair = Resources.LoadAll<Sprite>("Sprites/Male/Hairstyles");
        NB_hair = Resources.LoadAll<Sprite>("Sprites/NonBinary/Hairstyles");
    }
}
