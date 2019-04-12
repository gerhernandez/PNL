using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/// <summary>
/// This a level manager!!!
/// </summary>
public class FlowchartLoader : MonoBehaviour {
    public GetPlayerValues getVals;

    public List<GameObject> cis_male;       // Story 1
    public List<GameObject> cis_female;     // Story 2
    public List<GameObject> trans_white;    // Story 3
    public List<GameObject> color_male;     // Story 4
    public List<GameObject> color_female;   // Story 5
    public List<GameObject> color_trans;    // Story 6

    public static int character_choice = 0;

    // Use this for initialization
    void Start () {
        // get GetPlayerValues story choice from script; check if null first
        if (getVals != null)
        {
            character_choice = getVals.getStoryChoice();
        }
        
        Debug.Log("character_choice: " + character_choice);
        Debug.Log("getStoryChoice(): " + getVals.getStoryChoice());

        // switch choice to choose which flowchart to use
        switch (character_choice)
        {
            case 1:
                StartCoroutine(SetFlowcharts(cis_male));
                break;
            case 2:
                StartCoroutine(SetFlowcharts(cis_female));
                break;
            case 3:
                StartCoroutine(SetFlowcharts(trans_white));
                break;
            case 4:
                StartCoroutine(SetFlowcharts(color_male));
                break;
            case 5:
                StartCoroutine(SetFlowcharts(color_female));
                break;
            case 6:
                StartCoroutine(SetFlowcharts(color_trans));
                break;
        }
	}
	
	//public void SetFlowcharts(List<GameObject> list)
    IEnumerator SetFlowcharts(List<GameObject> list)
    {
        // fc: flow chart in the list
        foreach (GameObject fc in list)
        {
            // create "flowcharts" and assign in list
            Instantiate(fc, fc.transform.position, Quaternion.identity);
            yield return null;
        }
    }
}
