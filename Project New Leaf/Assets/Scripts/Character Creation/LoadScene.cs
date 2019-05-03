using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public bool loadScene;
    public string sceneName;

	// Use this for initialization
	void Start () {
     
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
            yield return null;
        }
    }

    public string SceneName
    {get; set;}
}
