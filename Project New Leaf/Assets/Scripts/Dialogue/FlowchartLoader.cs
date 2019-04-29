﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/// <summary>
/// This a level manager!!!
/// </summary>
public class FlowchartLoader : MonoBehaviour {
    public GetPlayerValues getVals;

    public GameObject cis_male;       // Story 1
    public GameObject cis_female;     // Story 2
    public GameObject trans_white;    // Story 3
    public GameObject color_male;     // Story 4
    public GameObject color_female;   // Story 5
    public GameObject color_trans;    // Story 6

    public int character_choice = 0;

    public string playerName;
    public string paramourName;
    public int playerPronoun;
    public int paramourPronoun;

    // Use this for initialization
    void Start () { 
        // get GetPlayerValues story choice from script; check if null first
        if (getVals != null)
        {
            character_choice = getVals.getStoryChoice();
            playerName = getVals.PlayerName;
            paramourName = getVals.ParamourName;
            playerPronoun = getVals.PlayerPronoun;
            paramourPronoun = getVals.ParamourPronoun;
        }
        
        Debug.Log("character_choice: " + character_choice);
        //Debug.Log("getStoryChoice(): " + getVals.getStoryChoice());

        // switch choice to choose which flowchart to use
        switch (character_choice)
        {
            case 1:
                cis_male.SetActive(true);
                StartCoroutine(SetFlowcharts(cis_male.GetComponentsInChildren<Flowchart>()));
                break;
            case 2:
                cis_female.SetActive(true);
                StartCoroutine(SetFlowcharts(cis_female.GetComponentsInChildren<Flowchart>()));
                break;
            case 3:
                trans_white.SetActive(true);
                StartCoroutine(SetFlowcharts(trans_white.GetComponentsInChildren<Flowchart>()));
                break;
            case 4:
                color_male.SetActive(true);
                StartCoroutine(SetFlowcharts(color_male.GetComponentsInChildren<Flowchart>()));
                break;
            case 5:
                color_female.SetActive(true);
                StartCoroutine(SetFlowcharts(color_female.GetComponentsInChildren<Flowchart>()));
                break;
            case 6:
                color_trans.SetActive(true);
                StartCoroutine(SetFlowcharts(color_trans.GetComponentsInChildren<Flowchart>()));
                break;
        }
	}
	
	//public void SetFlowcharts(List<GameObject> list)
    IEnumerator SetFlowcharts(Flowchart[] list)
    {
        // fc: flow chart in the list
        foreach (Flowchart fc in list)
        {
            // create "flowcharts" and assign in list
            fc.SetStringVariable("PlayerName", playerName);
            fc.SetStringVariable("ParamoreName", paramourName);
            fc.SetIntegerVariable("Pronoun", playerPronoun);
            fc.SetIntegerVariable("ParamorePronoun", paramourPronoun);
            yield return null;
        }
    }
}
