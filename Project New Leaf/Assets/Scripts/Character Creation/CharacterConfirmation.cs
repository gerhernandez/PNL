using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterConfirmation : MonoBehaviour {

	public Canvas popUpCanvas;
	// Use this for initialization
	void Start () {
		popUpCanvas.enabled = false;
	}
	
	public void popUpConfirmation(){
		popUpCanvas.enabled = true;
	}

	public void Confirmation(Button btn){
		if(btn.name.Equals("YesBtn")){
			//create player
		}
		else{
			popUpCanvas.enabled = false;
		}
	}
}
