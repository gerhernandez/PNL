﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public GameObject pauseMenuCanvas;

    public Player PlayerScript;

    private Move moveScript;

    private Sprite playerPortrait;
    private Sprite paramourPortrait;
    public Character playerCharacterScript;
    public Character paramourCharacterScript;
    private bool isParamourActive;
    private bool startOfScene = false;

    // story choice from player created
    private int storyChoice;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // delete any Managers in the scene
        DreamNightmareScript dreamNightmare = FindObjectOfType<DreamNightmareScript>();

        if (dreamNightmare != null)
        {
            DestroyObject(dreamNightmare.gameObject);
        }

        startOfScene = true;
        // ParamourCharacter is temporary --> Use actual name of paramour
        isParamourActive = GameObject.Find("ParamourCharacter").activeInHierarchy == true;
    }

    void Awake(){

        PlayerScript = GameObject.FindObjectOfType<Player>();
        moveScript = GameObject.Find("Player").GetComponent<Move>();

        storyChoice = PlayerSelectedAttributes.StoryChoice;
        switch(storyChoice){
            case 1:
                PlayerScript.Health = 5;
                PlayerScript.Mana = 6;
                for(int i = 0; i < 3; i++)
                {
                    PlayerScript.unlockRandomPower();
                }
                break;
            case 2:
                PlayerScript.Health = 5;
                PlayerScript.Mana = 4;
                for (int i = 0; i < 2; i++)
                {
                    PlayerScript.unlockRandomPower();
                }
                break;
            case 3:
                PlayerScript.Health = 5;
                PlayerScript.Mana = 4;
                for (int i = 0; i < 2; i++)
                {
                    PlayerScript.unlockRandomPower();
                }
                break;
            case 4:
                PlayerScript.Health = 4;
                PlayerScript.Mana = 3;
                for (int i = 0; i < 2; i++)
                {
                    PlayerScript.unlockRandomPower();
                }
                break;
            case 5:
                PlayerScript.Health = 4;
                PlayerScript.Mana = 2;
                PlayerScript.unlockRandomPower();
                break;
            case 6:
                PlayerScript.Health = 3;
                PlayerScript.Mana = 2;
                PlayerScript.unlockRandomPower();
                break;
            default:
                PlayerScript.Health = 1;
                PlayerScript.Mana = 1;
                break;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause") && !pauseMenuCanvas.activeInHierarchy)
        {
            pauseMenuCanvas.SetActive(true);
            AudioManager.changeVolume = true;
            Time.timeScale = 0f;
            moveScript.ChangeMovementState();
        }

        if (startOfScene)
        {
            startOfScene = false;
            SetPortraitsIntoFlowcharts();
            Flowchart.BroadcastFungusMessage("test");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetPortraitsIntoFlowcharts();
            Flowchart.BroadcastFungusMessage("test");
        }
    }

    public void SetPortraitsIntoFlowcharts()
    {
        Fungus.Flowchart[] flowcharts = FindObjectsOfType<Fungus.Flowchart>();
        for (int i = 0; i < flowcharts.Length; i++)
        {
            if (flowcharts[i] != null)
            {
                foreach (var sayCommand in flowcharts[i].GetComponentsInChildren<Fungus.Say>())
                {
                    if (sayCommand.character == this.playerCharacterScript)
                        sayCommand.portrait = playerPortrait;

                    if (isParamourActive && sayCommand.character == this.paramourCharacterScript)
                        sayCommand.portrait = paramourPortrait;
                }
            }
        }
    }

    public void SetPlayerPortrait(Sprite s)
    {
        playerPortrait = s;
    }

    public void SetParamourPortrait(Sprite s)
    {
        paramourPortrait = s;
    }

    public static int PlayerCurrentHealth
    {get; set;}

    public static int PlayerCurrentMana
    {get; set;}

}
