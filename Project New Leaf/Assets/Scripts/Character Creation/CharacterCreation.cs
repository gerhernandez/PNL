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
	int hairPos = 0;
	int headPos = 0;
	int topsPos = 0;
	int bodyPos = 0;
	int bottomsPos = 0;
	int lowerPos = 0;

	CharacterAttributes charAttributes;

	GameObject characterAttributes;

	// Use this for initialization
	void Start () {
		CreateCosmetics();
		hairText.text = cosmetics["hair"].GetValue(0).ToString();
		headText.text = cosmetics["head"].GetValue(0).ToString();
		topsText.text = cosmetics["tops"].GetValue(0).ToString();
		bodyText.text = cosmetics["body"].GetValue(0).ToString();
		bottomsText.text = cosmetics["bottoms"].GetValue(0).ToString();
		lowerText.text = cosmetics["lower"].GetValue(0).ToString();
		hairNxtBtn.onClick.AddListener(delegate{hairPos = nextClick(hairPos, "hair", hairText);});
		hairPrvBtn.onClick.AddListener(delegate{hairPos = prevClick(hairPos,"hair", hairText);});
		headNxtBtn.onClick.AddListener(delegate{headPos = nextClick(headPos, "head", headText);});
		headPrvBtn.onClick.AddListener(delegate{headPos = prevClick(headPos,"head", headText);});
		topsNxtBtn.onClick.AddListener(delegate{topsPos = nextClick(topsPos, "tops", topsText);});
		topsPrvBtn.onClick.AddListener(delegate{topsPos = prevClick(topsPos,"tops", topsText);});
		bodyNxtBtn.onClick.AddListener(delegate{bodyPos = nextClick(bodyPos, "body", bodyText);});
		bodyPrvBtn.onClick.AddListener(delegate{bodyPos = prevClick(bodyPos,"body", bodyText);});
		bottomsNxtBtn.onClick.AddListener(delegate{bottomsPos = nextClick(bottomsPos, "bottoms", bottomsText);});
		bottomsPrvBtn.onClick.AddListener(delegate{bottomsPos = prevClick(bottomsPos,"bottoms", bottomsText);});
		lowerNxtBtn.onClick.AddListener(delegate{lowerPos = nextClick(lowerPos, "lower", lowerText);});
		lowerPrvBtn.onClick.AddListener(delegate{lowerPos = prevClick(lowerPos,"lower", lowerText);});
		//Debug.Log(hair.GetValue(0));
		//Debug.Log(cosmetics["hair"].GetValue(0).ToString());
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
		// 			//Debug.Log(race[i]);
		// 		}
				
		// 	}
			
		// }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int nextClick(int position, string key, Text displayText){
		position += 1;
		if(position >= cosmetics[key].Length){
			position = 0;
		}
		displayText.text = cosmetics[key.ToString()].GetValue(position).ToString();
		return position;
	}

	public int prevClick(int position, string key, Text displayText){
		position -= 1;
		if(position < 0)
		{
			position = cosmetics[key].Length-1;
		}
		displayText.text = cosmetics[key.ToString()].GetValue(position).ToString();
		return position;
	}
}
