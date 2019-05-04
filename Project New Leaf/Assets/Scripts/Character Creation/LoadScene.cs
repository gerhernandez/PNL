using System.Collections;
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
        loadingAnimation = GameObject.Find("LoadingCanvas").GetComponentInChildren<Animation>();
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
