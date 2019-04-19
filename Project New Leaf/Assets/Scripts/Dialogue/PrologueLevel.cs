using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PrologueLevel : MonoBehaviour {

    public List<GameObject> prologue;
    public int scene;

	// Use this for initialization
	void Start () {
        switch (scene)
        {
            case 1:
                foreach(GameObject fc in prologue)
                {
                    Instantiate(fc, fc.transform.position, Quaternion.identity);
                }
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
