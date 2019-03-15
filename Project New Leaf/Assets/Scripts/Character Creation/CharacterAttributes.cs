using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttributes : MonoBehaviour {
    // Skin and Cloth ------------------ Image and Sprites
    public Sprite Male_Skin;
    public Sprite Male_Shirt;
    public Sprite Male_Pants;
    public Sprite Male_Lineart;
    public Sprite Male_SkinShading;
    public Sprite Male_ClothShading;

    public Sprite Female_Skin;
    public Sprite Female_Shirt;
    public Sprite Female_Pants;
    public Sprite Female_Lineart;
    public Sprite Female_SkinShading;
    public Sprite Female_ClothShading;

    public Sprite NB_Skin;
    public Sprite NB_Shirt;
    public Sprite NB_Pants;
    public Sprite NB_Lineart;
    public Sprite NB_SkinShading;
    public Sprite NB_ClothShading;

    public Color raceColor0;    // Peach = #f3cda9
    public Color raceColor1;    // Tan = #cda681
    public Color raceColor2;    // Brown = #a57f5b
    public Color raceColor3;    // Darkest = #6a4c30

    // Hair ------------------ Image and Sprites
    public Sprite[] Male_hair;
    public Sprite[] Female_hair;
    public Sprite[] NB_hair;

    public Color[] hairColors;
    public Color hairColor0;    // darkBlue;    = 0x172d75
    public Color hairColor1;    // darkOrange;  = 0xbc4b06
    public Color hairColor2;    // hayYellow;   = 0xdbc250
    public Color hairColor3;    // black        = 0x151413
    public Color hairColor4;    // darkBrown    = 0x3d2e25
    public Color hairColor5;    // peach        = 0xf69679
    public Color hairColor6;    // pink         = 0xf5989d
    public Color hairColor7;    // darkRed      = 0x9e0b0f
    public Color hairColor8;    // cyanBlue     = 0x36f1cd
    public Color hairColor9;    // purple       = 0x92278f

    public Color[] shirtColors;
    public Color shirtColor0;   // lightGrey    = 0xe8e7dd
    public Color shirtColor1;   // yellow       =  0xe6cf23
    public Color shirtColor2;   // darkGrey     = 0x2a2629
    public Color shirtColor3;   // lightMagenta = 0xffd3f4
    public Color shirtColor4;   // darkLilac    = 0x412e5f
    public Color shirtColor5;   // darkPink     = 0xa5243a
    public Color shirtColor6;   // orange       = 0xe87934
    public Color shirtColor7;   // babyBlue     = 0x91b2ff
    public Color shirtColor8;   // lightGreen   = 0xa2c3a4

    public Color[] pantsColors;
    public Color pantsColor0;   // brown            = 0x7a4e24
    public Color pantsColor1;   // dark gray-blue   = 0x3d5356
    public Color pantsColor2;   // pastel blue      = 0xabcbcf
    public Color pantsColor3;   // black            = 0x2a2629
    public Color pantsColor4;   // medium gray-blue = 0x537479

    int[] race = { 1, 2, 3, 4 };
    int[] skinShading = { 1, 2, 3 };
    int[] clothShading = { 1, 2, 3 };
    int[] cisOrTrans = { 1, 2 };
    int[] pronouns = { 1, 2, 3 };
    int[] body = { 1, 2, 3 };
    int[] hair = new int[19];
    int[] tops = { 1, 2, 3 };
    int[] legs = { 1, 2, 3 };

    // int arrays for colors
    int[] hairColorInts = new int[10];
    int[] shirtColorInts = new int[9];
    int[] pantsColorInts = new int[5];

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
        
        for (int i = 0; i < 5; i++)
        { pantsColorInts[i] = i; }
        cosmetics.Add("pantsColor", pantsColorInts);
        // --------------------------

    }
    
    public void CreateHairColors()
    {
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
    
    public void CreatePantsColors()
    {
        if (ColorUtility.TryParseHtmlString("#7a4e24", out pantsColor0)) // brown
        { pantsColors[0] = pantsColor0; }
        if (ColorUtility.TryParseHtmlString("#3d5356", out pantsColor1)) // dark gray-blue
        { pantsColors[1] = pantsColor1; }
        if (ColorUtility.TryParseHtmlString("#abcbcf", out pantsColor2)) // pastel blue
        { pantsColors[2] = pantsColor2; }
        if (ColorUtility.TryParseHtmlString("#2a2629", out pantsColor3)) // black
        { pantsColors[3] = pantsColor3; }
        if (ColorUtility.TryParseHtmlString("#537479", out pantsColor4)) // medium gray-blue
        { pantsColors[4] = pantsColor4; }
    }

    public void LoadMaleSprites()
    {
        Male_Skin = Resources.Load<Sprite>("Sprites/Male/MaleSkinColor");
        Male_Shirt = Resources.Load<Sprite>("Sprites/Male/MaleShirtColor");
        Male_Pants = Resources.Load<Sprite>("Sprites/Male/MalePants");
        Male_Lineart = Resources.Load<Sprite>("Sprites/Male/MaleLineart");
        Male_SkinShading = Resources.Load<Sprite>("Sprites/Male/Shading/Male_Bodyshading");
        Male_ClothShading = Resources.Load<Sprite>("Sprites/Male/Shading/Male_Clothshading");
        Male_hair = Resources.LoadAll<Sprite>("Sprites/Male/Hairstyles");
    }

    public void LoadFemaleSprites()
    {
        Female_Skin = Resources.Load<Sprite>("Sprites/Female/FemaleSkincolor");
        Female_Shirt = Resources.Load<Sprite>("Sprites/Female/FemaleShirt");
        Female_Pants = Resources.Load<Sprite>("Sprites/Female/FemalePants");
        Female_Lineart = Resources.Load<Sprite>("Sprites/Female/FemaleLineArt");
        Female_SkinShading = Resources.Load<Sprite>("Sprites/Female/Shading/Female_Bodyshading");
        Female_ClothShading = Resources.Load<Sprite>("Sprites/Female/Shading/Female_Clothshading");
        Female_hair = Resources.LoadAll<Sprite>("Sprites/Female/Hairstyles");
    }

    public void LoadNonBinarySprites()
    {
        NB_Skin = Resources.Load<Sprite>("Sprites/NonBinary/NBSkinColor");
        NB_Shirt = Resources.Load<Sprite>("Sprites/NonBinary/NBShirt");
        NB_Pants = Resources.Load<Sprite>("Sprites/NonBinary/NBPants");
        NB_Lineart = Resources.Load<Sprite>("Sprites/NonBinary/NBLineart");
        NB_SkinShading = Resources.Load<Sprite>("Sprites/NonBinary/Shading/NonBinary_Bodyshading");
        NB_ClothShading = Resources.Load<Sprite>("Sprites/NonBinary/Shading/NonBinary_Clothshading");
        NB_hair = Resources.LoadAll<Sprite>("Sprites/NonBinary/Hairstyles");
    }
}
