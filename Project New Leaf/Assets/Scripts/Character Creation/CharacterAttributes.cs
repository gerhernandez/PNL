﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour {
	public int[] gender = {1,2,3,4};
	public int[] race = {1,2,3,4};
	public int[] skin = {1,2,3,4};
	public int[] hair = {1,2,3,4};
	public int[] eyes = {1,2,3,4};
	public int[] tops = {1,2,3,4};
	public int[] bottoms = {1,2,3,4};
	public int[] character;
	Dictionary<string, int[]> cosmetics = new Dictionary<string, int[]>();

	// Use this for initialization
	void Start () {
		cosmetics.Add("gender", gender);
		cosmetics.Add("race", race);
		cosmetics.Add("skin", skin);
		cosmetics.Add("hair", hair);
		cosmetics.Add("eyes",eyes);
		cosmetics.Add("tops", tops);
		cosmetics.Add("bottoms", bottoms);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
