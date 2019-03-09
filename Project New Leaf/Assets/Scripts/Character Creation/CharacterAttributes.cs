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

    public Image shirtColor;

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

	public void CreateCosmetics(){
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

    /*
    // TEST Add sprites using path name into Sprite[] arrays
    // ------------------------------------------------START
    public void TestAddSprites()
    {
        helmets = Resources.LoadAll<Sprite>("Sprites/TestImages/ArmorIconPack_transparent/helmets");
        chestplates = Resources.LoadAll<Sprite>("Sprites/TestImages/ArmorIconPack_transparent/armor");
        gloves = Resources.LoadAll<Sprite>("Sprites/TestImages/ArmorIconPack_transparent/gloves");
        pants = Resources.LoadAll<Sprite>("Sprites/TestImages/ArmorIconPack_transparent/pants");
    }
    // ------------------------------------------------END
    */
    public void LoadHairSprites()
    {
        Male_hair = Resources.LoadAll<Sprite>("Sprites/Male/Hairstyles");
        Female_hair = Resources.LoadAll<Sprite>("Sprites/Male/Hairstyles");
        NB_hair = Resources.LoadAll<Sprite>("Sprites/NonBinary/Hairstyles");
    }
}
