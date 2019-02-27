using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : CharacterAttributes {
	
	CharacterAttributes charAttributes;

	GameObject characterAttributes;

	// Use this for initialization
	void Start () {
		
		foreach(KeyValuePair<string, int[]> item in cosmetics)
		{
			for(int i = 0; i < item.Value.Length; i++)
			{
				Debug.Log(item.Key + " " + item.Value.GetValue(i));
			}
			for(int i = 0; i < item.Value.Length; i++)
			{
				if(item.Key == "race")
				{
					Debug.Log(races[i]);
				}
				
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
