using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class PortraitLoader : MonoBehaviour {
    
    public Character playerCharacterScript;
    public Character paramourCharacterScript;

    [SerializeField]
    private bool isPlayerActive;
    [SerializeField]
    private bool isParamourActive;
    [SerializeField]
    private bool startOfScene = false;
    [SerializeField]
    private bool isStoryBlock;

    // Use this for initialization
    void Start () {
        isStoryBlock = IsSceneAStoryBlock(SceneManager.GetActiveScene().name);

        if (isStoryBlock)
        {
            startOfScene = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startOfScene && isStoryBlock && Input.GetButton("ButtonA"))
        {
            Check();
            SetPortraitsIntoFlowcharts();
            startOfScene = false;
        }
    }

    private bool IsSceneAStoryBlock(string sceneName)
    {
        bool storyBlock = false;

        switch (sceneName)
        {
            case "StoryBlock1":
                storyBlock = true;
                break;
            case "StoryBlock2":
                storyBlock = true;
                break;
            case "StoryBlock3":
                storyBlock = true;
                break;
            case "StoryBlock4":
                storyBlock = true;
                break;
        }

        return storyBlock;
    }

    public void Check()
    {
        Debug.Log("Checking....");
        isPlayerActive = GameObject.Find("SbPlayer").activeInHierarchy;
        isParamourActive = GameObject.Find("Paramour").activeInHierarchy;

        //if (isPlayerActive)
        //{
        //    playerCharacterScript = GameObject.Find("PlayerNPC").GetComponent<Character>();
        //}
        //if (isParamourActive)
        //{
        //    paramourCharacterScript = GameObject.Find("ParamourNPC").GetComponent<Character>();
        //}
    }

    public void SetPortraitsIntoFlowcharts()
    {
        if (isPlayerActive)
            this.playerCharacterScript.SetNameText(PlayerSelectedAttributes.PlaySelectedName);
        if (isParamourActive)
            this.paramourCharacterScript.SetNameText(ParamourSelectedAttributes.LoveSelectedName);

        Fungus.Flowchart[] flowcharts = FindObjectsOfType<Fungus.Flowchart>();
        for (int i = 0; i < flowcharts.Length; i++)
        {
            if (flowcharts[i] != null)
            {
                foreach (var sayCommand in flowcharts[i].GetComponentsInChildren<Fungus.Say>())
                {
                    //Debug.Log(flowcharts[i].name);
                    if (isPlayerActive && sayCommand.character == this.playerCharacterScript)
                    {
                        sayCommand.portrait = GameManager.playerPortrait;
                    }

                    if (isParamourActive && sayCommand.character == this.paramourCharacterScript)
                    {
                        sayCommand.portrait = GameManager.paramourPortrait;
                    }

                }
            }
        }
    }
}
