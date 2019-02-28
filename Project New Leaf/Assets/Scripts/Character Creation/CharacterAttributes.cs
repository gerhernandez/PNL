﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour {
	int[] race = {1,2,3,4};
    int[] cisOrTrans = {1,2};
    int[] pronouns = {1,2,3};
	int[] hair = {1,2,3,4};
    int[] head = {1,2,3,4};
	int[] tops = {1,2,3,4};
    int[] body = {1,2,3,4};
	int[] bottoms = {1,2,3,4};
    int[] lower = {1,2,3,4};

	public Dictionary<string, int[]> cosmetics = new Dictionary<string, int[]>();


	void Awake(){
		CreateCosmetics();
	}
	

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
}
