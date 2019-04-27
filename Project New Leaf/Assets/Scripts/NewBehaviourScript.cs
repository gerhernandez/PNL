using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
      
        float translation = Input.GetAxis("HorizontalX") * speed * Time.deltaTime;

        if(translation > 0.3f || translation < -0.3f)
        {
            translation *= Time.deltaTime;
            transform.Translate(translation, 0, 0);
        }
        
        Debug.Log("Current translation is: " + translation);


        //if (Input.GetAxis("HorizontalX") > 1)
        //{

        //}
    }
}
