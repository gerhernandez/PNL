using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour {
	//public int[] gender = {1,2,3,4};
	public int[] race = {1,2,3,4};
    public int[] cisOrTrans = {1,2};
    public int[] pronouns = {1,2,3};
	//public int[] skin = {1,2,3,4}; <-- race
	public int[] hair = {1,2,3,4};
	//public int[] eyes = {1,2,3,4};
    public int[] head = {1,2,3,4};
	public int[] tops = {1,2,3,4};
    public int[] body = {1,2,3,4};
	public int[] bottoms = {1,2,3,4};
    public int[] lower = {1,2,3,4};

	public int[] character;
	Dictionary<string, int[]> cosmetics = new Dictionary<string, int[]>();

	// Use this for initialization
	void Start () {
		//cosmetics.Add("gender", gender);
		cosmetics.Add("race", race);
        cosmetics.Add("cisOrTrans", cisOrTrans);
        cosmetics.Add("pronouns", pronouns);
		//cosmetics.Add("skin", skin);
		cosmetics.Add("hair", hair);
        //cosmetics.Add("eyes",eyes);
        cosmetics.Add("head", head);
		cosmetics.Add("tops", tops);
        cosmetics.Add("body", body);
		cosmetics.Add("bottoms", bottoms);
        cosmetics.Add("lower", lower);

		foreach(KeyValuePair<string, int[]> item in cosmetics)
		{
			Debug.Log(item.Key + " " + item.Value.GetValue(0));
		}
	}

}
