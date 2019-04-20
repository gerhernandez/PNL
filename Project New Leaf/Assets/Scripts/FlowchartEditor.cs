using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowchartEditor : MonoBehaviour {

    Flowchart fc;
    List<Block> blocks;
    Command currCommand;

    // Use this for initialization
    void Start () {
        
        
		
	}
	
	// Update is called once per frame
	void Update () {

        Command newCommand = null;

        if (fc == null)
        {
            fc = FindObjectOfType<Flowchart>();
            blocks = fc.GetExecutingBlocks();
        }

        if (blocks != null) {
            newCommand = blocks[0].ActiveCommand;
        }

        if (currCommand == null || currCommand == newCommand)
        {
            currCommand = newCommand;
            Debug.Log(currCommand.ToString());
        }
	}
}
