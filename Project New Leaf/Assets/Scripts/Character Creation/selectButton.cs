using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectButton : MonoBehaviour {

	public Button feminineBtn;
	public Button nonbinaryBtn;
	public Button masculineBtn;

	static public Image bodyType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(bodyType);
	}

	public void setAsBodyType(Button bodySelected){
    	bodyType = bodySelected.GetComponentInChildren<Image>();
    }

	public Image GetImage(){
		return bodyType;
	}
}
