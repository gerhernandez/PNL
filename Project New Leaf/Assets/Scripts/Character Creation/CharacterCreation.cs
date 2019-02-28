using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : CharacterAttributes {
	
	public Text hairText;
	public Text topsText;
	public Text headText;
	public Text bodyText;
	public Text bottomsText;
	public Text lowerText;

	CharacterAttributes charAttributes;

	GameObject characterAttributes;

	// Use this for initialization
	void Start () {

		hairText.text = cosmetics["hair"].GetValue(0).ToString();
		
		// foreach(KeyValuePair<string, int[]> item in cosmetics)
		// {
		// 	for(int i = 0; i < item.Value.Length; i++)
		// 	{
		// 		Debug.Log(item.Key + " " + item.Value.GetValue(i));
		// 	}
		// 	for(int i = 0; i < item.Value.Length; i++)
		// 	{
		// 		if(item.Key == "race")
		// 		{
		// 			Debug.Log(races[i]);
		// 		}
				
		// 	}
			
		// }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
