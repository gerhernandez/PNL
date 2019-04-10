using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public bool loadScene;
    public string sceneName;

	// Use this for initialization
	void Start () {
        loadScene = false;
        sceneName = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (loadScene)
        {
            StartCoroutine(LoadAsyncScene());
        }
	}

    public void SetAndLoadScene(string s)
    {
        sceneName = s;
        loadScene = true;
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
