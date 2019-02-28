using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : CharacterAttributes {
	//Texts
	public Text hairText;
	public Text topsText;
	public Text headText;
	public Text bodyText;
	public Text bottomsText;
	public Text lowerText;

	//Buttons
	public Button hairNxtBtn;
	public Button hairPrvBtn;
	public Button headNxtBtn;
	public Button headPrvBtn;
	public Button topsNxtBtn;
	public Button topsPrvBtn;
	public Button bodyNxtBtn;
	public Button bodyPrvBtn;
	public Button bottomsNxtBtn;
	public Button bottomsPrvBtn;
	public Button lowerNxtBtn;
	public Button lowerPrvBtn;
	int pos = 0;

	CharacterAttributes charAttributes;

	GameObject characterAttributes;
	void Awake(){
		hairNxtBtn.onClick.AddListener(delegate{nextClick(pos, "hair", hairText, cosmetics);});
		hairPrvBtn.onClick.AddListener(delegate{prevClick(pos,"hair", hairText);});
	}

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

	public void nextClick(int position, string key, Text displayText, Dictionary <string, int[]> cosm){
		position += 1;
		// if(position > this.cosmetics[key].Length){
		// 	position = 0;
		// }
		//Debug.Log(cosm.Keys.Count.ToString());
		//Debug.Log(key);
		//displayText.text = cosmetics[key.ToString()].GetValue(position).ToString();
	}

	public void prevClick(int position, string key, Text displayText){
		position -= 1;
		if(position < 0)
		{
			//position = this.cosmetics[key].Length;
		}
		//displayText.text = cosmetics[key.ToString()].GetValue(position).ToString();
	}
}
