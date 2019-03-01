using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttributes : MonoBehaviour {
	int[] race = {1,2,3,4};
    int[] cisOrTrans = {1,2};
    int[] pronouns = {1,2,3};
	int[] hair = {1,2,3,4};
    int[] head = {1,2,3,4};
	int[] tops = {1,2};
    int[] body = {1,2,3,4};
	int[] bottoms = {1,2,3,4};
    int[] lower = {1,2,3};

    // TEST sprite arrays
    // ------------------------------------------------START
	public Sprite[] helmets;
	public Sprite[] chestplates;
	public Sprite[] gloves;
	public Sprite[] pants;
    // ------------------------------------------------END

    public Dictionary<string, int[]> cosmetics = new Dictionary<string, int[]>();

	public void CreateCosmetics(){
		cosmetics.Add("race", race);
		cosmetics.Add("cisOrTrans", cisOrTrans);
		cosmetics.Add("pronouns", pronouns);
		cosmetics.Add("hair", hair);
		cosmetics.Add("head", head);
		cosmetics.Add("tops", tops);
		cosmetics.Add("body", body);
		cosmetics.Add("bottoms", bottoms);
		cosmetics.Add("lower", lower);
	}

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
}
