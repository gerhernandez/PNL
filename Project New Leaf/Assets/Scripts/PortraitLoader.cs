using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class PortraitLoader : MonoBehaviour {
    
    public Character characterScript;
    public bool isPlayerActive;
    public bool isParamourActive;

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

    public void SetPortraitsIntoFlowcharts()
    {
        if (isPlayerActive)
            this.characterScript.SetNameText(PlayerSelectedAttributes.PlaySelectedName);
        if (isParamourActive)
            this.characterScript.SetNameText(ParamourSelectedAttributes.LoveSelectedName);

        Fungus.Flowchart[] flowcharts = FindObjectsOfType<Fungus.Flowchart>();
        for (int i = 0; i < flowcharts.Length; i++)
        {
            if (flowcharts[i] != null)
            {
                foreach (var sayCommand in flowcharts[i].GetComponentsInChildren<Fungus.Say>())
                {
                    if (isPlayerActive && sayCommand.character == this.characterScript)
                    {
                        sayCommand.portrait = GameManager.playerPortrait;
                    }

                    if (isParamourActive && sayCommand.character == this.characterScript)
                    {
                        sayCommand.portrait = GameManager.paramourPortrait;
                    }

                }
            }
        }
    }
}
