using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : CharacterCreation {

	public Canvas SelectingView; //Canvas of the Selection area
	public Text attributeTypeText; //The text being displayed to show what piece the attribute is selecting
	public Button nxtBtn; // This is a button to cycle through the images of specific attribute
	public GameObject PreviousBtn; 
	public GameObject NextAttributeBtn;
	public Text nxtBtnText; // text for the NextAttributeBtn
	Image displayAttribute;
	GameObject criteria;
	Text nameEntered;
	Button CIS;
	Button Trans;
	Button He;
	Button She;
	Button They;

	GameObject Prefab;
	
	int pos = 0;

	string[] AttributeText = {"Select your hair", "Select your eyes", "Select your top", "Select your bottoms", "Select your shoes", "Enter the following criteria"};
	void Start()
	{
		SelectingView = GameObject.Find("Selecting").GetComponent<Canvas>();
		attributeTypeText = GameObject.Find("AttributeTypeText").GetComponent<Text>();
		nxtBtn = GameObject.Find("NxtAttributeBtn").GetComponent<Button>();
		nxtBtnText = nxtBtn.GetComponentInChildren<Text>();
		PreviousBtn = GameObject.Find("PrevBtn");
		NextAttributeBtn = GameObject.Find("NxtBtn");
		displayAttribute = GameObject.Find("Image").GetComponent<Image>();
		criteria = GameObject.Find("Criteria");
		criteria.SetActive(false);
		displayAttribute.gameObject.SetActive(true);
		nxtBtn.onClick.AddListener(delegate{pos = nextClick(pos);});

	}
	public int nextClick(int position){
		position += 1;
		if(position == AttributeText.Length-1)
		{
			attributeTypeText.text = AttributeText[position];
			nxtBtnText.text = "Finish";
			nxtBtn.onClick.RemoveAllListeners();
			nxtBtn.onClick.AddListener(delegate{completeCharacter();});
			position = 0;
			PreviousBtn.gameObject.SetActive(false);
			NextAttributeBtn.gameObject.SetActive(false);
			displayAttribute.enabled = false;
			criteria.SetActive(true);
			
		}
		else
		{
			attributeTypeText.text = AttributeText[position];
		}
		return position;
	}

	public void completeCharacter(){
		Debug.Log("Character Created!");
	}
}
