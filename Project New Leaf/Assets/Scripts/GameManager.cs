using System.Collections;
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

    public static Sprite playerPortrait;
    public static Sprite paramourPortrait;

    //[SerializeField]
    //private Character playerCharacterScript;
    //[SerializeField]
    //private Character paramourCharacterScript;

    //[SerializeField]
    //private bool isPlayerActive;
    //[SerializeField]
    //private bool isParamourActive;
    //[SerializeField]
    //private bool startOfScene = false;
    //[SerializeField]
    //private bool isStoryBlock;

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
        
        //isStoryBlock = IsSceneAStoryBlock(SceneManager.GetActiveScene().name);

        //if (isStoryBlock)
        //{
        //    startOfScene = true;
        //}

        //isPlayerActive = GameObject.Find("SbPlayer").activeInHierarchy;
        //isParamourActive = GameObject.Find("Paramour").activeInHierarchy;

        //if (isPlayerActive)
        //{
        //    playerCharacterScript = GameObject.Find("PlayerNPC").GetComponent<Character>();
        //}
        //if (isParamourActive)
        //{
        //    paramourCharacterScript =GameObject.Find("ParamourNPC").GetComponent<Character>();
        //}

        PlayerScript = GameObject.FindObjectOfType<Player>();
        moveScript = FindObjectOfType<Player>().gameObject.GetComponent<Move>();
        
    }

    //private bool IsSceneAStoryBlock(string sceneName)
    //{
    //    bool storyBlock = false;

    //    switch (sceneName)
    //    {
    //        case "StoryBlock1":
    //            storyBlock = true;
    //            break;
    //        case "StoryBlock2":
    //            storyBlock = true;
    //            break;
    //        case "StoryBlock3":
    //            storyBlock = true;
    //            break;
    //        case "StoryBlock4":
    //            storyBlock = true;
    //            break;
    //    }

    //    return storyBlock;
    //}

    void Awake(){

        PlayerScript = GameObject.FindObjectOfType<Player>();
        moveScript = PlayerScript.gameObject.GetComponent<Move>();

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
        if (Input.GetButtonDown("Pause") && !pauseMenuCanvas.activeInHierarchy && !moveScript.GetIsPlayerInteracting() && moveScript.GetMovementState())
        {
            pauseMenuCanvas.SetActive(true);
            AudioManager.changeVolume = true;
            Time.timeScale = 0f;
            moveScript.ChangeMovementState();
        }
        //if (startOfScene && isStoryBlock && Input.GetButton("ButtonA"))
        //{
        //    Check();
        //    SetPortraitsIntoFlowcharts();
        //    startOfScene = false;
        //}
    }

    //public void Check()
    //{
    //    Debug.Log("Checking....");
    //    isPlayerActive = GameObject.Find("SbPlayer").activeInHierarchy;
    //    isParamourActive = GameObject.Find("Paramour").activeInHierarchy;

    //    if (isPlayerActive)
    //    {
    //        playerCharacterScript = GameObject.Find("PlayerNPC").GetComponent<Character>();
    //    }
    //    if (isParamourActive)
    //    {
    //        paramourCharacterScript = GameObject.Find("ParamourNPC").GetComponent<Character>();
    //    }
    //}

    //public void SetPortraitsIntoFlowcharts()
    //{
    //    if(isPlayerActive)
    //        this.playerCharacterScript.SetNameText(PlayerSelectedAttributes.PlaySelectedName);
    //    if(isParamourActive)
    //        this.paramourCharacterScript.SetNameText(ParamourSelectedAttributes.LoveSelectedName);

    //    Fungus.Flowchart[] flowcharts = FindObjectsOfType<Fungus.Flowchart>();
    //    for (int i = 0; i < flowcharts.Length; i++)
    //    {
    //        if (flowcharts[i] != null)
    //        {
    //            foreach (var sayCommand in flowcharts[i].GetComponentsInChildren<Fungus.Say>())
    //            {
    //                Debug.Log(flowcharts[i].name);
    //                if (isPlayerActive && sayCommand.character == this.playerCharacterScript)
    //                {
    //                    sayCommand.portrait = playerPortrait;
    //                }

    //                if (isParamourActive && sayCommand.character == this.paramourCharacterScript)
    //                {
    //                    sayCommand.portrait = paramourPortrait;
    //                }
                        
    //            }
    //        }
    //    }
    //}

    public static void SetPlayerPortrait(Sprite s)
    {
        playerPortrait = s;
    }

    public static void SetParamourPortrait(Sprite s)
    {
        paramourPortrait = s;
    }

    public static int PlayerCurrentHealth
    {get; set;}

    public static int PlayerCurrentMana
    {get; set;}

}
