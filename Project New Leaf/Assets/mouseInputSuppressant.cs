using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mouseInputSuppressant : MonoBehaviour {

    private static mouseInputSuppressant instance = null;
    GameObject lastselect;

    // Use this for initialization
    void Start () {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        Cursor.visible = false;
        lastselect = new GameObject();
    }
	
	// Update is called once per frame
	void Update () { 
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }
    }
}
