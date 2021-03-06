﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public bool loadScene;
    public string sceneName;

    public Animation loadingAnimation;
    public Canvas loadingCanvas;

	// Use this for initialization
	void Start () {
        loadingAnimation = GameObject.Find("LeafSprite").GetComponentInChildren<Animation>();
        loadingCanvas = GameObject.Find("LoadingCanvas").GetComponent<Canvas>();
        loadingCanvas.enabled = false;
        loadingAnimation.Stop("Loading Leaf");
	}

    public void SetAndLoadScene(string s)
    {
        sceneName = s;
        StartCoroutine(LoadAsyncScene());
    }

    public IEnumerator LoadAsyncScene()
    {
        Move move = FindObjectOfType<Move>();
        Debug.Log(move == null);
        if (move != null)
        {
            move.ChangeMovementState();
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {    
            //Loading Canvas displayed
            loadingCanvas.enabled = true;
            loadingAnimation.Play("Loading Leaf");

            yield return null;
        }
        loadingCanvas.enabled = false;
        if(loadingCanvas.enabled == true && loadingAnimation.IsPlaying("Loading Leaf") ==  true){
            loadingCanvas.enabled = false;
            loadingAnimation.Stop("Loading Leaf");
        }
        
    }

    public string SceneName
    {get; set;}
}
